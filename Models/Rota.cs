using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("ROTA")]
    public class Rota
    {
        [Key]
        [Column("ID_ROTA")]
        public int IdRota { get; set; }

        [Column("ORIGEM")]
        public string Origem { get; set; } = string.Empty;

        [Column("DESTINO")]
        public string Destino { get; set; } = string.Empty;
    }
}