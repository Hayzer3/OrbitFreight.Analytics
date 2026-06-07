using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("CARGA")]
    public class Carga
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("tipo_id")]
        public long TipoId { get; set; }

        [Column("veiculo_id")]
        public long VeiculoId { get; set; }

        [Column("motorista_id")]
        public long MotoristaId { get; set; }

        [Column("placa_veiculo")]
        public string PlacaVeiculo { get; set; } = string.Empty;

        [Column("origem")]
        public string Origem { get; set; } = string.Empty;

        [Column("destino")]
        public string Destino { get; set; } = string.Empty;

        [Column("temp_min")]
        public double TempMin { get; set; }

        [Column("temp_max")]
        public double TempMax { get; set; }

        [Column("umidade_max")]
        public double UmidadeMax { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [ForeignKey("TipoId")]
        public TipoCarga? TipoCarga { get; set; }

        public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
    }
}