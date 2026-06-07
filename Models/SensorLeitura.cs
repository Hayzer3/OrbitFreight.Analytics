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

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }
    }
}