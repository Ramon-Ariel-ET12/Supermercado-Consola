using Microsoft.EntityFrameworkCore;
using src.Configuratons;
using src.Models;

namespace src.Persistence;

public class SuperMercadoDbContext : DbContext
{
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<ArticuloStock> ArticuloStocks { get; set; }
    public DbSet<ArticuloVenta> ArticuloVentas { get; set; }
    public DbSet<Caja> Cajas { get; set; }
    // public DbSet<Supermercado> Supermercados { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ArticuloConfiguration());
        builder.ApplyConfiguration(new ArticuloStockConfiguration());
        builder.ApplyConfiguration(new ArticuloVentaConfiguration());
        builder.ApplyConfiguration(new CajaConfiguration());
        // builder.ApplyConfiguration(new SuperMercadoConfiguration());
        builder.ApplyConfiguration(new VentaConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Host=localhost;Database=5to_SuperMercado;Username=5to_agbd;Password=Trigg3rs!;", new MySqlServerVersion(new Version(8, 0, 39)));
    }
}
