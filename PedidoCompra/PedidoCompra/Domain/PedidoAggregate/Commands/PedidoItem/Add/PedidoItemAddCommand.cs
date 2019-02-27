using PedidoCompra.Domain.PedidoAggregate.Validations.PedidoItem;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Add
{
    public class PedidoItemAddCommand : PedidoItemCommand
    {
        public PedidoItemAddCommand(string descricao, float quantidade, decimal valorUnitario)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public void SetPedidoId(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoItemAddValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
