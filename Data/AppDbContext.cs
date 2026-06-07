using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Models;

namespace OrbiFreight.Analytics.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carga> Cargas { get; set; }
        public DbSet<TipoCarga> TiposCarga { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<SensorLeitura> SensoresLeitura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento automático para forçar MAIÚSCULAS em tudo
            // Isso resolve o ORA-00904 sem precisar mapear coluna por coluna
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Nome da tabela em maiúsculo
                entity.SetTableName(entity.GetTableName()?.ToUpper());

                foreach (var property in entity.GetProperties())
                {
                    // Nome da coluna em maiúsculo
                    property.SetColumnName(property.GetColumnName().ToUpper());
                }
            }
        }
    }
}