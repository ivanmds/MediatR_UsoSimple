using System;
using PedidoCompra.Domain.PedidoAggregate.Validations;
using PedidoCompra.Domain.PedidoAggregate.Validations.Pedido;

namespace PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Atualizar
{
    public class PedidoAtualizarCommand : PedidoCommand
    {
        public PedidoAtualizarCommand(DateTime criado, string descricao, PedidoStatus status)
        {
            Criado = criado;
            Descricao = descricao;
            Status = status;
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoAtualizarValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
