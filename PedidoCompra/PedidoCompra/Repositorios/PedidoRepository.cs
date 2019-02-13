using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Threading.Tasks;

namespace PedidoCompra.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly Contexto _contexto;
        public PedidoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Pedido> AddAsync(Pedido pedido)
        {
            pedido = (await _contexto.AddAsync(pedido)).Entity;
            await _contexto.SaveChangesAsync();
            return pedido;
        }
    }
}
