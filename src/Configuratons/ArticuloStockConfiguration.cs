using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Configuratons;

public class ArticuloStockConfiguration : IEntityTypeConfiguration<ArticuloStock>
{
    public void Configure(EntityTypeBuilder<ArticuloStock> builder)
    {
        builder.HasKey(x => x.IdArticuloStock);
        builder.Property(x => x.IdArticuloStock).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Cantidad).HasColumnName("Cantidad").IsRequired();
    }
}
