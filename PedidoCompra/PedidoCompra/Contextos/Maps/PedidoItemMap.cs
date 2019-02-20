using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoCompra.Domain.PedidoAggregate;

namespace PedidoCompra.Contextos.Maps
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Pedido);
        }
    }
}
