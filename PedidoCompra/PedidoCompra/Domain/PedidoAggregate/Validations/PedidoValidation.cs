using FluentValidation;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Validations
{
    public abstract class PedidoValidation<T> : AbstractValidator<T> where T : PedidoCommand
    {
        protected void ValidarId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id informado é inválido.");
        }

        protected void ValidarStatus()
        {
            RuleFor(p => p.Status)
                .NotEqual(PedidoStatus.Definir)
                .WithMessage("Status deve ser definido");
        }

        protected void ValidarDescricao()
        {
            RuleFor(p => p.Descricao)
                    .MinimumLength(5)
                    .MaximumLength(200)
                    .WithMessage("Descricao inválido. Descrição deve conter de 5 a 200 caracteres.");

        }

        protected void ValidarCriado()
        {
            RuleFor(p => p.Criado)
                .NotEqual(DateTime.MinValue)
                .WithMessage("Informe um data válida.");
        }
    }
}
