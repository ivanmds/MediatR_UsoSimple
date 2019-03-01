using PedidoCompra.Domain.Pedidos.Validations.Pedido;
using System;

namespace PedidoCompra.Domain.Pedidos.Commands.Pedido.Deletar
{
    public class PedidoDeletarCommand : PedidoCommand
    {
        public PedidoDeletarCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoDeletarValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
