using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("CARGA")]
    public class Carga
    {
        [Key]
        [Column("ID_CARGA")]
        public int IdCarga { get; set; }

        [Column("ID_TIPO")]
        public int IdTipo { get; set; }

        [Column("ID_ROTA")]
        public int IdRota { get; set; }

        [Column("STATUS")]
        public string Status { get; set; } = string.Empty;

        [ForeignKey("IdRota")]
        public Rota? Rota { get; set; }

        [ForeignKey("IdTipo")]
        public TipoCarga? TipoCarga { get; set; }

        public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
    }
}