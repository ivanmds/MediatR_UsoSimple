using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios
{
    public interface IPedidoQueryRepository
    {
        Task<IEnumerable<Pedido>> ListarAsync();
    }
}
