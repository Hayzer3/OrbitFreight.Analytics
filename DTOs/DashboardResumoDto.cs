namespace OrbiFreight.Analytics.DTOs
{
    public class DashboardResumoDto
    {
        public int TotalCargasEmTransito { get; set; }
        public int TotalAlertasCriticosHoje { get; set; }
        public decimal PrejuizoEstimadoTotal { get; set; }
        public string PiorRotaAtual { get; set; } = string.Empty;
    }
}