﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Add;

namespace PedidoCompra.Domain.PedidoAggregate.Notifications
{
    public class EnviarEmailNotificarion : INotificationHandler<PedidoAddNotification>
    {
        public async Task Handle(PedidoAddNotification notification, CancellationToken cancellationToken)
        {
            //Enviar email que pedido está sendo analisado.
        }
    }
}
