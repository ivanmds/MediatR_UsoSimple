using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Threading.Tasks;
using System;
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
            return (await _contexto.AddAsync(pedido))?.Entity;
        }

        public async Task<PedidoItem> AdicionarItemAsync(PedidoItem pedidoItem)
        {
            return (await _contexto.AddAsync(pedidoItem))?.Entity;
        }

        public Pedido Atualizar(Pedido pedido)
        {
            _contexto.Pedidos.Attach(pedido).State = EntityState.Modified;
            return _contexto.Update(pedido).Entity;
        }

        public async Task<Pedido> RemoverAsync(Guid id)
        {
            Pedido pedido = await _contexto.FindAsync<Pedido>(id);
            if (pedido == null) return null;
            return _contexto.Remove(pedido)?.Entity;
        }
    }
}
