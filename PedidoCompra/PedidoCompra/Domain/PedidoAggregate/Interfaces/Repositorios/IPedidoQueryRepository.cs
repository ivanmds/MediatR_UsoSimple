using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios
{
    public interface IPedidoQueryRepository
    {
        Task<Pedido> ObterAsync(Guid id);
        Task<IEnumerable<Pedido>> ListarAsync();
    }
}
