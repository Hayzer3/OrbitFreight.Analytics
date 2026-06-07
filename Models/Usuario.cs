using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("cargo")]
        public string Cargo { get; set; } = string.Empty;
    }
}