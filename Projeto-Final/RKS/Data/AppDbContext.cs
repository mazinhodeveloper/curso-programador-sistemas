using Microsoft.EntityFrameworkCore;
using API.Data.Models;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ACL> ACLs { get; set; } = null!;
        public DbSet<PERFIL> PERFILs { get; set; } = null!;
        public DbSet<STATUS> STATUSs { get; set; } = null!;
        public DbSet<USUARIO> USUARIOs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<USUARIO>(entity =>
            {
                entity.ToTable("USUARIO");                    // Nome da tabela no banco
                entity.HasKey(e => e.idUsuario);              // Primary Key
                entity.Property(e => e.idUsuario)
                      .ValueGeneratedOnAdd();                 // IDENTITY(1,1)
            });
        }
    }
}