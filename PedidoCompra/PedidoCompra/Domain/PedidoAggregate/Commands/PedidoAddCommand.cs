using PedidoCompra.Domain.PedidoAggregate.Validations;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public class PedidoAddCommand : PedidoCommand
    {
        public PedidoAddCommand(DateTime criado, string descricao, PedidoStatus status)
        {
            Criado = criado;
            Id = Guid.NewGuid();
            Descricao = descricao;
            Status = status;
        }

        public override bool EhValido()
        {
            Validacao = new PedidoAddValidation().Validate(this);
            return Validacao.IsValid;
        }
    }
}
