/* using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Configuratons;

public class SuperMercadoConfiguration : IEntityTypeConfiguration<Supermercado>
{
    public void Configure(EntityTypeBuilder<Supermercado> builder)
    {
        builder.HasKey(x => x.IdSuperMercado);
        builder.Property(x => x.IdSuperMercado).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
        builder.Property(x => x.Direccion).HasColumnName("Direccion").IsRequired();

        builder.Ignore(x => x.ListaArticulo);
        builder.Ignore(x => x.ListaArticuloStock);
        builder.Ignore(x => x.VectorCaja);
    }
}
 */