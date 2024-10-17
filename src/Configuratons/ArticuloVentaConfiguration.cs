using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Configuratons;

public class ArticuloVentaConfiguration : IEntityTypeConfiguration<ArticuloVenta>
{
    public void Configure(EntityTypeBuilder<ArticuloVenta> builder)
    {
        builder.HasKey(x => x.IdArticuloVenta);
        builder.Property(x => x.IdArticuloVenta).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Cantidad).HasColumnName("Cantidad").IsRequired();
    }
}
