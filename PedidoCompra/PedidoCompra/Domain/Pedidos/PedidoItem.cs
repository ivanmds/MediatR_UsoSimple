﻿using System;

namespace PedidoCompra.Domain.Pedidos
{
    public class PedidoItem
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Guid PedidoId { get; private set; }
        public virtual Pedido Pedido { get; private set; }

        public PedidoItem(Guid id, string descricao, decimal quantidade, decimal valorUnitario, Guid pedidoId)
        {
            Id = id;
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PedidoId = pedidoId;
        }

        protected PedidoItem() { }

        public decimal ValorTotal()
        {
            return Quantidade * ValorUnitario;
        }
    }
}
