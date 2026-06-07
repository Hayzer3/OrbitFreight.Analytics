using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrbiFreight.Analytics.Models
{
    // O [Owned] avisa ao EF Core que essas colunas pertencem à tabela de quem as chamar
    [Owned]
    public class CoordenadaGPS
    {
        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }
    }
}