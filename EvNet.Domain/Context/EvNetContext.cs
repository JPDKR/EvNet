using EvNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvNet.Domain.Context
{
    public partial class EvNetContext(DbContextOptions<EvNetContext> opciones) : DbContext(opciones)
    {
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
