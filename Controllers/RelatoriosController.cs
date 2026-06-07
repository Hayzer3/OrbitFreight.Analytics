using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Data;
using OrbiFreight.Analytics.DTOs;

namespace OrbiFreight.Analytics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ranking-rotas")]
        public async Task<IActionResult> GetRankingRotas()
        {
            var ranking = await _context.Alertas
                .Include(a => a.Carga)
                .Where(a => a.Carga != null) // Evita null reference
                .GroupBy(a => new { a.Carga.Origem, a.Carga.Destino })
                .Select(g => new
                {
                    Trajeto = g.Key.Origem + " -> " + g.Key.Destino,
                    TotalAlertas = g.Count(),
                    AlertasCriticos = g.Count(a => a.Nivel == "CRITICO" || a.Nivel == "ALTO")
                })
                .OrderByDescending(r => r.TotalAlertas)
                .ToListAsync();

            if (!ranking.Any())
                return NotFound("Não há dados suficientes para gerar o ranking.");

            return Ok(ranking);
        }


        [HttpGet("dashboard-resumo")]
        public async Task<ActionResult<DashboardResumoDto>> GetDashboardResumo()
        {
            var hoje = DateTime.Today;

            var cargasAtivas = await _context.Cargas.CountAsync(c => c.Status == "EM_TRANSITO" || c.Status == "Em Trânsito");

            var alertasHoje = await _context.Alertas
                .Where(a => (a.Nivel == "ALTO" || a.Nivel == "CRITICO") && a.DataCriacao >= hoje)
                .CountAsync();

            var perdas = await _context.Alertas
                .Include(a => a.Carga).ThenInclude(c => c.TipoCarga)
                .Where(a => a.Nivel == "ALTO" || a.Nivel == "CRITICO")
                .ToListAsync();

            var prejuizoTotal = perdas.Sum(a => a.Carga.TipoCarga.Nome.Contains("Vacina") ? 5000m : 1500m);

            var piorRota = await _context.Alertas
                .Include(a => a.Carga)
                .GroupBy(a => new { a.Carga.Origem, a.Carga.Destino })
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key.Origem} -> {g.Key.Destino}")
                .FirstOrDefaultAsync();

            var resumo = new DashboardResumoDto
            {
                TotalCargasEmTransito = cargasAtivas,
                TotalAlertasCriticosHoje = alertasHoje,
                PrejuizoEstimadoTotal = prejuizoTotal,
                PiorRotaAtual = piorRota ?? "Nenhuma rota com problemas"
            };

            return Ok(resumo);
        }

        [HttpGet("historico-alertas")]
        public async Task<IActionResult> GetHistoricoAlertas([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            if (pagina <= 0 || tamanho <= 0)
                return BadRequest("Página e tamanho devem ser maiores que zero.");

            var query = _context.Alertas
                .Include(a => a.Carga)
                .OrderByDescending(a => a.DataCriacao);

            var totalRegistros = await query.CountAsync();
            var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanho);

            var historico = await query
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .Select(a => new
                {
                    AlertaId = a.Id,
                    Risco = a.Nivel,
                    Mensagem = a.Descricao,
                    Data = a.DataCriacao,
                    StatusCarga = a.Carga.Status
                })
                .ToListAsync();

            var respostaPaginada = new
            {
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaginaAtual = pagina,
                Dados = historico
            };

            return Ok(respostaPaginada);
        }

        [HttpGet("perdas-estimadas")]
        public async Task<IActionResult> GetPerdasEstimadas()
        {
            var perdas = await _context.Alertas
                .Include(a => a.Carga)
                    .ThenInclude(c => c.TipoCarga)
                .Where(a => a.Nivel == "ALTO" || a.Nivel == "CRITICO")
                .GroupBy(a => new { a.Carga.TipoCarga.Id, a.Carga.TipoCarga.Nome })
                .Select(g => new
                {
                    TipoCargaId = g.Key.Id,
                    Produto = g.Key.Nome,
                    IncidentesCriticos = g.Count(),
                    PrejuizoFinanceiroEstimado = g.Key.Nome.Contains("Vacina")
                        ? g.Count() * 5000
                        : g.Count() * 1500
                })
                .OrderByDescending(p => p.PrejuizoFinanceiroEstimado)
                .ToListAsync();

            if (!perdas.Any())
                return Ok(new { Mensagem = "Nenhuma perda registrada. Operação 100% segura!" });

            return Ok(perdas);
        }
    }
}