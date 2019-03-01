using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoCompra.Domain.Pedidos;

namespace PedidoCompra.Contextos.Maps
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");
            builder.HasKey(p => p.Id);
        }
    }
}
