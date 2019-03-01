using System;

namespace PagamentoApi.Domain
{
    public class Pagamento
    {
        public Pagamento(Guid id, Guid pedidoId, string email, PagamentoStatus status, decimal valor, Cartao cartao)
        {
            Id = id;
            PedidoId = pedidoId;
            Email = email;
            Status = status;
            Valor = valor;
            Cartao = cartao;
        }

        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public string Email { get; private set; }
        public PagamentoStatus Status { get; private set; }
        public decimal Valor { get; private set; }

        public Cartao Cartao { get; private set; }
    }
}