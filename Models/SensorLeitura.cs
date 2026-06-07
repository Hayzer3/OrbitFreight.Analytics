using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("SENSOR_LEITURA")]
    public class SensorLeitura
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("carga_id")]
        public long CargaId { get; set; }

        [Column("temperatura")]
        public double Temperatura { get; set; }

        [Column("umidade")]
        public double Umidade { get; set; }

        [Column("data_hora_leitura")]
        public DateTime DataHoraLeitura { get; set; }

        // Aqui você faz a ligação com a classe que criamos acima
        public CoordenadaGPS Coordenadas { get; set; } = new CoordenadaGPS();

        [ForeignKey("CargaId")]
        public Carga? Carga { get; set; }
    }
}