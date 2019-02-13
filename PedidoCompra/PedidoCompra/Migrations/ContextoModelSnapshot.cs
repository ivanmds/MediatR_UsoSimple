﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidoCompra.Contextos;

namespace PedidoCompra.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PedidoCompra.AggregatesModel.PedidoAggregate.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Criado");

                    b.Property<string>("Descricao");

                    b.Property<byte>("Status");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PedidoCompra.AggregatesModel.PedidoAggregate.PedidoItem", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Descricao");

                    b.Property<float>("Quantidade");

                    b.Property<decimal>("ValorUnitario");

                    b.HasKey("Id");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("PedidoCompra.AggregatesModel.PedidoAggregate.PedidoItem", b =>
                {
                    b.HasOne("PedidoCompra.AggregatesModel.PedidoAggregate.Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
