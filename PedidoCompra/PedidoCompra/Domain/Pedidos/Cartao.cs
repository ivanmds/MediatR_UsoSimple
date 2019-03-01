using System;

namespace PedidoCompra.Domain.Pedidos
{
    public class Cartao
    {
        public Cartao(Guid id, string nome, string numero, string vencimento, int codigo)
        {
            Id = id;
            Nome = nome;
            Numero = numero;
            Vencimento = vencimento;
            Codigo = codigo;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        
        private string _numero;
        public string Numero
        {
            get { return _numero; }
            private set
            {
                _numero = value.Replace(" ", "");
            }
        }
        public string Vencimento { get; private set; }
        public int Codigo { get; private set; }
    }
}
