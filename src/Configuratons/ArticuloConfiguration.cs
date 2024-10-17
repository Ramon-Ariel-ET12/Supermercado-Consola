using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Configuratons;

public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
{
    public void Configure(EntityTypeBuilder<Articulo> builder)
    {
        builder.HasKey(x => x.Codigo);
        builder.Property(x => x.Codigo).HasColumnName("Codigo").IsRequired();
        builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
        builder.Property(x => x.Descripcion).HasColumnName("Descripcion").IsRequired();
        builder.Property(x => x.Precio).HasColumnName("Precio").IsRequired();


    }
}
