using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem
{
    public abstract class PedidoItemCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public float Quantidade { get; protected set; }
        public decimal ValorUnitario { get; protected set; }
        public Guid PedidoId { get; protected set; }
    }
}
