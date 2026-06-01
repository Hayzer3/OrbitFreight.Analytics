namespace OrbiFreight.Analytics.Models
{
    public class HistoricoAlerta
    {
        public int Id { get; set; }
        public int CargaId { get; set; }
        public double TemperaturaRegistrada { get; set; }
        public string MensagemGemini { get; set; } = string.Empty;
        public DateTime DataOcorrencia { get; set; }
    }
}