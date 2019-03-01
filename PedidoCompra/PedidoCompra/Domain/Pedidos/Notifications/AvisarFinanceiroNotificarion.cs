using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PedidoCompra.Domain.Pedidos.Commands.Pedido.Add;

namespace PedidoCompra.Domain.Pedidos.Notifications
{
    public class AvisarFinanceiroNotificarion : INotificationHandler<PedidoAddNotification>
    {
        public async Task Handle(PedidoAddNotification notification, CancellationToken cancellationToken)
        {
            //notificar departamento de analise financeira
        }
    }
}
