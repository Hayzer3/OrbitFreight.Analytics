using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("ALERTA")]
    public class Alerta
    {
        [Key]
        [Column("ID_ALERTA")]
        public int IdAlerta { get; set; }

        [Column("ID_CARGA")]
        public int IdCarga { get; set; }

        [Column("MENSAGEM")]
        public string Mensagem { get; set; } = string.Empty;

        [Column("NIVEL_RISCO")]
        public string NivelRisco { get; set; } = string.Empty;

        [Column("DATA_ALERTA")]
        public DateTime DataAlerta { get; set; }

        [ForeignKey("IdCarga")]
        public Carga? Carga { get; set; }
    }
}