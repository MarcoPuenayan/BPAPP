using Microsoft.EntityFrameworkCore;

namespace BPAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.IdCliente).IsUnique();
            });
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        //public DbSet<Personas> Personas { get; set; }
    }
}