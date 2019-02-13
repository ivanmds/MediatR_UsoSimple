using System.Threading.Tasks;

namespace PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios
{
    public interface IPedidoRepository
    {
        Task<Pedido> AddAsync(Pedido pedido);
    }
}
