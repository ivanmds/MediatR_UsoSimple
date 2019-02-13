﻿using System;
using System.Collections.Generic;

namespace PedidoCompra.AggregatesModel.PedidoAggregate
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public DateTime Criado { get; private set; }
        public string Descricao { get; private set; }
        public PedidoStatus Status { get; private set; }

        private List<PedidoItem> _itens;
        public IReadOnlyCollection<PedidoItem> Itens => _itens;

        public Pedido(Guid id, DateTime criado, string descricao, PedidoStatus status, List<PedidoItem> itens)
        {
            Id = id;
            Criado = criado;
            Descricao = descricao;
            Status = status;
            _itens = itens;
        }
        protected Pedido() { }

        public void AdicionarItem(PedidoItem item)
        {
            _itens.Add(item);
        }
    }
}
