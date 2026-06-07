using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrbiFreight.Analytics.Models
{
    [Table("TIPO_CARGA")]
    public class TipoCarga
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("temp_min")]
        public double TempMin { get; set; }

        [Column("temp_max")]
        public double TempMax { get; set; }

        [Column("umidade_max")]
        public double UmidadeMax { get; set; }

        [Column("prazo_max_horas")]
        public int PrazoMaxHoras { get; set; }
    }
}