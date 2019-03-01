using System;

namespace PedidoCompra.Domain.Pedidos.Commands.Pedido.Add
{
    public class PedidoAddNotification : Notificacao
    {
        public Guid Id { get; set; }
        public DateTime Criado { get; set; }
        public string Descricao { get; set; }

        public Cartao Cartao { get; set; }
    }
}
