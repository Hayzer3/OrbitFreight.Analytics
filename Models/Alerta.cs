using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("ALERTA")]
    public class Alerta
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("carga_id")]
        public long CargaId { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("nivel")]
        public string Nivel { get; set; } = string.Empty;

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("CargaId")]
        public Carga? Carga { get; set; }
    }
}