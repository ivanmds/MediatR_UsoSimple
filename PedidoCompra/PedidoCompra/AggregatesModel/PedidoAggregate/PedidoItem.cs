using System;

namespace PedidoCompra.AggregatesModel.PedidoAggregate
{
    public class PedidoItem
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public float Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; } 

        public PedidoItem(Guid id, string descricao, float quantidade, decimal valorUnitario)
        {
            Id = id;
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        protected PedidoItem() { }
    }
}
