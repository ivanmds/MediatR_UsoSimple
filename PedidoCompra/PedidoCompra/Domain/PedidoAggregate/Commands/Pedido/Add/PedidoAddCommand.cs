using System;
using PedidoCompra.Domain.PedidoAggregate.Validations.Pedido;
using System.Collections.Generic;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Add
{
    public class PedidoAddCommand : PedidoCommand
    {
        public PedidoAddCommand(DateTime criado, string descricao, PedidoStatus status, List<PedidoItemDto> itens)
        {
            Id = Guid.NewGuid();
            Criado = criado;
            Descricao = descricao;
            Status = status;
            Itens = itens;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoAddValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
