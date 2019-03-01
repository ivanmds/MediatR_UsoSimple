using FluentValidation;
using PedidoCompra.Domain.Pedidos.Commands.PedidoItem;
using System;

namespace PedidoCompra.Domain.Pedidos.Validations.PedidoItem
{
    public class PedidoItemValidation<T> : AbstractValidator<T> where T : PedidoItemCommand
    {
        protected void ValidarId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do item inválido.");
        }

        protected void ValidarDescricao()
        {
            RuleFor(p => p.Descricao)
                .MinimumLength(5)
                .MaximumLength(1000)
                .WithMessage("Descrição do item deve conter de 5 a 1000 caracteres.");
        }

        protected void ValidarValorUnitario()
        {
            RuleFor(p => p.ValorUnitario)
                .Must((valor) =>
                {
                    return valor > 0;
                }).WithMessage("Valor unitário do item deve ser maior que 0.");
        }

        protected void ValidarQuantidade()
        {
            RuleFor(p => p.Quantidade)
                .Must((quantidade) =>
                {
                    return quantidade > 0;
                }).WithMessage("Quantidade do item deve ser maior que 0.");
        }

        protected void ValidarPedidoId()
        {
            RuleFor(p => p.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do item inválido.");
        }
    }
}
