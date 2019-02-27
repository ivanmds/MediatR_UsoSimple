using PedidoCompra.Domain.PedidoAggregate.Validations.PedidoItem;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Deletar
{
    public class PedidoItemDeletarCommand : PedidoItemCommand
    {
        public PedidoItemDeletarCommand(Guid id, Guid pedidoId)
        {
            Id = id;
            PedidoId = pedidoId;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoItemDeletarValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
