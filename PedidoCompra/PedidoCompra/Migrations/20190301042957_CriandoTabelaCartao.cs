using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidoCompra.Migrations
{
    public partial class CriandoTabelaCartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "PedidoItem",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<Guid>(
                name: "CartaoId",
                table: "Pedido",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Vencimento = table.Column<string>(nullable: true),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CartaoId",
                table: "Pedido",
                column: "CartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cartao_CartaoId",
                table: "Pedido",
                column: "CartaoId",
                principalTable: "Cartao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cartao_CartaoId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_CartaoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "PedidoItem",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
