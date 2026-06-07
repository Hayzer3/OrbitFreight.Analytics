using Microsoft.AspNetCore.Mvc;
using OrbiFreight.Analytics.DTOs;
using System;

namespace OrbiFreight.Analytics.Controllers
{
    [ApiController]
    [Route("api/iot")] 
    public class IoTController : ControllerBase
    {
        [HttpPost("leituras")] 
        public IActionResult ReceberLeitura([FromBody] LeituraIoTRequestDto payload)
        {
            Console.WriteLine("ALERTA IOT RECEBIDO!");
            Console.WriteLine($"Carga: {payload.Carga_id}");
            Console.WriteLine($"Temperatura: {payload.Temperatura}°C");
            Console.WriteLine($"Umidade: {payload.Umidade}%");
            Console.WriteLine($"Risco: {payload.Risco}");
            Console.WriteLine("------------------------------");

            return Ok("Dados recebidos com sucesso pelo C#!");
        }
    }
}