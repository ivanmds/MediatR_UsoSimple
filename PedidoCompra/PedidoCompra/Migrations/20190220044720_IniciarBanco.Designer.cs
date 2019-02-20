﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidoCompra.Contextos;

namespace PedidoCompra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20190220044720_IniciarBanco")]
    partial class IniciarBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PedidoCompra.Domain.PedidoAggregate.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Criado");

                    b.Property<string>("Descricao");

                    b.Property<byte>("Status");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PedidoCompra.Domain.PedidoAggregate.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<Guid>("PedidoId");

                    b.Property<float>("Quantidade");

                    b.Property<decimal>("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("PedidoCompra.Domain.PedidoAggregate.PedidoItem", b =>
                {
                    b.HasOne("PedidoCompra.Domain.PedidoAggregate.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}