﻿using System.Threading.Tasks;

namespace PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios
{
    public interface IPedidoCommandRepository
    {
        Task<Pedido> AdicionarAsync(Pedido pedido);
    }
}