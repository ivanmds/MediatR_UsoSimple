using System;
using System.Collections.Generic;

namespace PedidoCompra.Domain.Pedidos.Commands.Pedido
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime Criado { get; protected set; }
        public string Descricao { get; protected set; }
        public PedidoStatus Status { get; protected set; }
        public CartaoDto Cartao { get; protected set; }
        public List<PedidoItemDto> Itens { get; protected set; }
    }

    public class PedidoItemDto
    {
        public PedidoItemDto()
        {
            if (Id.Equals(Guid.Empty))
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }

    public class CartaoDto
    {
        public CartaoDto()
        {
            if (Id.Equals(Guid.Empty))
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Vencimento { get; set; }
        public int Codigo { get; set; }
    }
}
