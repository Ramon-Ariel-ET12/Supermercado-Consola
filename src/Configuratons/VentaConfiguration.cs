using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Configuratons;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.HasKey(x => x.IdVenta);
        builder.Property(x => x.IdVenta).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.NroTicket).HasColumnName("NroTicket").IsRequired();
        builder.Property(x => x.Fecha).HasColumnName("Fecha").IsRequired();

    }
}
