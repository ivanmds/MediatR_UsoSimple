using MediatR;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public class PedidoAddCommand : IRequest<Resultado>
    {
        public Guid Id { get; set; }
        public DateTime Criado { get; set; }
        public string Descricao { get; set; }
        public PedidoStatus Status { get; set; }
    }
}
