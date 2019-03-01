using System;
using PedidoCompra.Domain.Pedidos.Validations.Pedido;
using System.Collections.Generic;

namespace PedidoCompra.Domain.Pedidos.Commands.Pedido.Add
{
    public class PedidoAddCommand : PedidoCommand
    {
        public PedidoAddCommand(DateTime criado, string descricao, PedidoStatus status, List<PedidoItemDto> itens, CartaoDto cartao)
        {
            Id = Guid.NewGuid();
            Criado = criado;
            Descricao = descricao;
            Status = status;
            Cartao = cartao ?? new CartaoDto();
            Itens = itens ?? new List<PedidoItemDto>();
        }

        public override bool EhValido()
        {
            Validacao = new PedidoAddValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
