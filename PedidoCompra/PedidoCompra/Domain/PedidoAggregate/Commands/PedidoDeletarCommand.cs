using PedidoCompra.Domain.PedidoAggregate.Validations;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public class PedidoDeletarCommand : PedidoCommand
    {
        public PedidoDeletarCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            return new PedidoDeletarValidation().Validate(this).IsValid;
        }
    }
}
