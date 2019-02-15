using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PedidoCompra.Repositorios
{
    public class PedidoCommandRepository : IPedidoCommandRepository
    {
        private readonly Contexto _contexto;
        public PedidoCommandRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Pedido> AdicionarAsync(Pedido pedido)
        {
            return (await _contexto.AddAsync(pedido)).Entity;
        }

        public async Task<IEnumerable<Pedido>> ListarAsync()
        {
            return await _contexto.Pedidos.ToArrayAsync();
        }
    }
}
