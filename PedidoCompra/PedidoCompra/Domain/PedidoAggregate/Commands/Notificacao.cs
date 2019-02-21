using MediatR;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public class Notificacao : INotification
    {
        public Guid Id { get; set; }
        public DateTime Criado { get; set; }
        public string Descricao { get; set; }
    }
}
