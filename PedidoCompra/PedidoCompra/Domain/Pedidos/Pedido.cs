using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidoCompra.Domain.Pedidos
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public DateTime Criado { get; private set; }
        public string Descricao { get; private set; }
        public PedidoStatus Status { get; private set; }
        public decimal Valor { get; private set; }

        public Guid CartaoId { get; private set; }
        public virtual Cartao Cartao { get; private set; }

        private List<PedidoItem> _itens;
        public IReadOnlyCollection<PedidoItem> Itens => _itens;


        public Pedido(Guid id, DateTime criado, string descricao, PedidoStatus status, Cartao cartao = null, List<PedidoItem> itens = null)
        {
            Id = id;
            Criado = criado;
            Descricao = descricao;
            Status = status;
            Cartao = cartao;
            _itens = itens ?? new List<PedidoItem>();
        }

        protected Pedido()
        {
            _itens = new List<PedidoItem>();
        }

        public void AdicionarItem(PedidoItem item)
        {
            Valor += item.ValorTotal();
            _itens.Add(item);
        }

        public void AdicionarItem(IEnumerable<PedidoItem> itens)
        {
            if (itens?.Count() > 0)
                foreach (PedidoItem item in itens)
                    AdicionarItem(item);
        }

        public void AdicionarCartao(Cartao cartao)
        {
            Cartao = cartao;
        }
    }
}
