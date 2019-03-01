using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PedidoCompra.Domain.Pedidos.Commands.Pedido.Add;

namespace PedidoCompra.Domain.Pedidos.Notifications
{
    public class ProcessarPagamentoCartaoNotification : INotificationHandler<PedidoAddNotification>
    {
        public async Task Handle(PedidoAddNotification notificacao, CancellationToken cancelar)
        {
            throw new System.NotImplementedException();
        }
    }
}
