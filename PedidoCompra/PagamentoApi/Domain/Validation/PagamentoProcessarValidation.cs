using FluentValidation;
using PagamentoApi.Domain.Command;
using System;

namespace PagamentoApi.Domain.Validation
{
    public class PagamentoProcessarValidation: AbstractValidator<PagamentoProcessarCommand>
    {
        public PagamentoProcessarValidation()
        {
            Validar();
        }

        private void Validar()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pagamento inválido");

            RuleFor(p => p.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("PedidoId inválido");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email deve ser informado")
                .EmailAddress()
                .WithMessage("Email é inválido");

            RuleFor(p => p.Valor)
                .Must(v =>
                {
                    return v > 0;
                }).WithMessage("Pedido deve conter um valor");

            RuleFor(p => p.NomeNoCartao)
                .NotEmpty()
                .WithMessage("Nome deve ser informado");

            RuleFor(p => p.NumeroDoCartao)
                .NotEmpty()
                .WithMessage("Número do cartão deve ser informado")
                .Must(num =>
                {
                    return num.Length == 16;
                }).WithMessage("Número do cartão incompleto");

            RuleFor(p => p.VencimentoDoCartao)
                .NotEmpty()
                .WithMessage("Vencimento do cartão deve ser informado")
                .Must(num =>
                {
                    return num.Length == 7;
                }).WithMessage("Número do cartão incompleto");

            RuleFor(p => p.CodigoDoCartao)
                .Must(num => {
                    return num > 0 && num < 10000;
                })
                .WithMessage("Código do cartão inválido");
        }
    }
}
