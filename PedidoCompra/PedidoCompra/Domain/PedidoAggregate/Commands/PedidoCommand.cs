using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime Criado { get; protected set; }
        public string Descricao { get; protected set; }
        public PedidoStatus Status { get; protected set; }
    }
}
