using System;
using System.Threading.Tasks;

namespace PedidoCompra.Domain.Pedidos.Interfaces.Repositorios
{
    public interface IPedidoCommandRepository
    {
        Task<Pedido> AdicionarAsync(Pedido pedido);
        Task<Pedido> RemoverAsync(Guid id);
        Pedido Atualizar(Pedido pedido);
        Task<PedidoItem> AdicionarItemAsync(PedidoItem pedidoItem);
        Task<PedidoItem> RemoverItemAsync(Guid pedidoItemId);
    }
}
