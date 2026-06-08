using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Models;

namespace OrbiFreight.Analytics.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carga> Cargas { get; set; }
        public DbSet<TipoCarga> TiposCarga { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<SensorLeitura> SensoresLeitura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.ToUpper());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToUpper());
                }
            }
        }
    }
}