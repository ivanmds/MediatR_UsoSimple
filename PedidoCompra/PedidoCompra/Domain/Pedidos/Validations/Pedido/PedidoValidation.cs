﻿using FluentValidation;
using PedidoCompra.Domain.Pedidos.Commands.Pedido;
using System;
using System.Linq;

namespace PedidoCompra.Domain.Pedidos.Validations.Pedido
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
                .Must(p => p >= PedidoStatus.Analisando && p <= PedidoStatus.Aprovado)
                .WithMessage("Defina um status válido.");
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

        protected void ValidarItens()
        {
            RuleFor(p => p.Itens)
                .NotNull()
                .Must(itens => itens?.Count() > 0)
                .WithMessage("O pedido deve conter mais de 1 item.");

            ValidarIdDosItens();
            ValidarDescricaoDosItens();
            ValidarValorUnitarioDosItens();
            ValidarQuantidadeDosItens();
        }

        protected void ValidarCartao()
        {
            RuleFor(p => p.Cartao)
                .NotNull()
                .WithMessage("Informe um cartão");

            ValidarIdCartao();
            ValidarNumeroCartao();
            ValidarCodigoCartao();
            ValidarVencimentoCartao();
        }

        private void ValidarIdDosItens()
        {
            RuleForEach(p => p.Itens)
                 .Custom((item, contexto) =>
                 {
                     if (item.Id == Guid.Empty)
                     {
                         contexto.AddFailure("Id do item inválido.");
                     }
                 });
        }

        private void ValidarDescricaoDosItens()
        {
            RuleForEach(p => p.Itens)
                .Custom((item, contexto) =>
                {
                    if (item.Descricao?.Count() < 5 || item.Descricao?.Count() > 1000)
                    {
                        contexto.AddFailure("Descrição do item deve conter de 5 a 1000 caracteres.");
                    }
                });
        }

        private void ValidarValorUnitarioDosItens()
        {
            RuleForEach(p => p.Itens)
                .Custom((item, contexto) =>
                {
                    if (item.ValorUnitario <= 0)
                    {
                        contexto.AddFailure("Valor unitário do item deve ser maior que 0.");
                    }
                });
        }

        private void ValidarQuantidadeDosItens()
        {
            RuleForEach(p => p.Itens)
                .Custom((item, contexto) =>
                {
                    if (item.Quantidade <= 0)
                    {
                        contexto.AddFailure("Quantidade do item deve ser maior que 0.");
                    }
                });
        }

        private void ValidarIdCartao()
        {
            RuleFor(p => p.Cartao.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cartão é inválido");
        }

        private void ValidarNumeroCartao()
        {
            RuleFor(p => p.Cartao.Numero)
                .NotNull()
                .WithMessage("Informe o número do cartão")
                .Length(16)
                .WithMessage("Informe um número válido de cartão");

        }

        private void ValidarCodigoCartao()
        {
            RuleFor(p => p.Cartao.Codigo)
               .Must(c => {
                   return c >= 1 && c < 10000;
               }).WithMessage("Informe um código válido de cartão");
        }

        private void ValidarVencimentoCartao()
        {
            RuleFor(p => p.Cartao.Vencimento)
             .NotNull()
             .WithMessage("Informe o vencimento do cartão")
             .Length(7)
             .WithMessage("Informe um vencimento válido de cartão");
        }
    }
}
