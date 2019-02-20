using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Threading.Tasks;
using System;

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
            return (await _contexto.AddAsync(pedido))?.Entity;
        }

        public async Task<Pedido> RemoverAsync(Guid id)
        {
            Pedido pedido = await _contexto.FindAsync<Pedido>(id);
            if (pedido == null) return null;
            return _contexto.Remove(pedido)?.Entity;
        }
    }
}
