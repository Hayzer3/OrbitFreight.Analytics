using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Models;

namespace OrbiFreight.Analytics.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<TipoCarga> TiposCarga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.HasDefaultSchema("RM566503");


            modelBuilder.Entity<Alerta>().ToTable("ALERTA");
            modelBuilder.Entity<Carga>().ToTable("CARGA");
            modelBuilder.Entity<Rota>().ToTable("ROTA");
            modelBuilder.Entity<TipoCarga>().ToTable("TIPO_CARGA");

            modelBuilder.Entity<Rota>().Property(r => r.IdRota).HasColumnName("ID_ROTA");
            modelBuilder.Entity<Rota>().Property(r => r.Origem).HasColumnName("ORIGEM");
            modelBuilder.Entity<Rota>().Property(r => r.Destino).HasColumnName("DESTINO");

  
            modelBuilder.Entity<TipoCarga>().Property(t => t.IdTipo).HasColumnName("ID_TIPO");
            modelBuilder.Entity<TipoCarga>().Property(t => t.Nome).HasColumnName("NOME");

            // Colunas de Carga
            modelBuilder.Entity<Carga>().Property(c => c.IdCarga).HasColumnName("ID_CARGA");
            modelBuilder.Entity<Carga>().Property(c => c.Status).HasColumnName("STATUS");
            modelBuilder.Entity<Carga>().Property(c => c.IdRota).HasColumnName("ID_ROTA"); 
            // Colunas de Alerta
            modelBuilder.Entity<Alerta>().Property(a => a.IdAlerta).HasColumnName("ID_ALERTA");
            modelBuilder.Entity<Alerta>().Property(a => a.NivelRisco).HasColumnName("NIVEL_RISCO");
            modelBuilder.Entity<Alerta>().Property(a => a.Mensagem).HasColumnName("MENSAGEM");
            modelBuilder.Entity<Alerta>().Property(a => a.DataAlerta).HasColumnName("DATA_ALERTA");
        }
    }
}