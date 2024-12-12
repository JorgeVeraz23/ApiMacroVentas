using MacroVentasEnterprise.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MacroVentasEnterprise
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Usuario> User { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ventas>()
                .HasMany(v => v.VentaDetalles)
                .WithOne(d => d.Ventas)
                .HasForeignKey(g => g.IdVentas)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
