namespace OrbiFreight.Analytics.DTOs
{
    public class LeituraIoTRequestDto
    {
        public long Carga_id { get; set; }
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public string Risco { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}