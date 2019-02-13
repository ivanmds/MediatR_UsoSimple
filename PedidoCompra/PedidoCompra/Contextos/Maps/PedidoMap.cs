﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoCompra.AggregatesModel.PedidoAggregate;

namespace PedidoCompra.Contextos.Maps
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Itens)
                .WithOne()
                .HasForeignKey(p => p.Id);
        }
    }
}
