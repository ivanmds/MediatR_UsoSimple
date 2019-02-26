using PedidoCompra.Domain.PedidoAggregate.Validations.Pedido;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Deletar
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
