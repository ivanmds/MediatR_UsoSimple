using PedidoCompra.Domain.Pedidos.Validations.PedidoItem;
using System;

namespace PedidoCompra.Domain.Pedidos.Commands.PedidoItem.Deletar
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
