using System;
using PedidoCompra.Domain.Pedidos.Validations.Pedido;

namespace PedidoCompra.Domain.Pedidos.Commands.Pedido.Atualizar
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
