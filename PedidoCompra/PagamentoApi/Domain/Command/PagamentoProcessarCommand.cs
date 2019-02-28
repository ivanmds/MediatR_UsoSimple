using PagamentoApi.Domain.Validation;
using System;

namespace PagamentoApi.Domain.Command
{
    public class PagamentoProcessarCommand : Command
    {
        public PagamentoProcessarCommand(Guid pedidoId, string email, string nomeNoCartao, string numeroDoCartao, string vencimentoDoCartao, int codigoDoCartao)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            Email = email;
            NomeNoCartao = nomeNoCartao;
            NumeroDoCartao = numeroDoCartao;
            VencimentoDoCartao = vencimentoDoCartao;
            CodigoDoCartao = codigoDoCartao;
            Status = PagamentoStatus.Aprocessar;
        }

        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public string Email { get; private set; }
        public string NomeNoCartao { get; private set; }
        public PagamentoStatus Status { get; private set; }
        private string _numeroDoCartao;
        public string NumeroDoCartao
        {
            get { return _numeroDoCartao; }
            private set
            {
                _numeroDoCartao = value.Replace(" ", "");
            }
        }

        public string VencimentoDoCartao { get; private set; }
        public int CodigoDoCartao { get; private set; }

        public override bool EhValido()
        {
            Validacao = new PagamentoProcessarValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
