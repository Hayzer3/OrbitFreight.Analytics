using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Models;

namespace OrbiFreight.Analytics.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<TipoCarga> TiposCarga { get; set; }
        public DbSet<SensorLeitura> SensoresLeituras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Substitua RM566503 pelo RM do líder do grupo, se necessário
            modelBuilder.HasDefaultSchema("RM566503");

            base.OnModelCreating(modelBuilder);
        }
    }
}