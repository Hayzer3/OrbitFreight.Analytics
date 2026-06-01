using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("TIPO_CARGA")]
    public class TipoCarga
    {
        [Key]
        [Column("ID_TIPO")]
        public int IdTipo { get; set; }

        [Column("NOME")]
        public string Nome { get; set; } = string.Empty;
    }
}