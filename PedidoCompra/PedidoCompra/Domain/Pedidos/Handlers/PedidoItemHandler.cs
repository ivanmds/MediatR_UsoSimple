﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.Pedidos.Commands.PedidoItem.Add;
using PedidoCompra.Domain.Pedidos.Commands.PedidoItem.Deletar;
using PedidoCompra.Domain.Pedidos.Interfaces.Repositorios;

namespace PedidoCompra.Domain.Pedidos.Handlers
{
    public class PedidoItemHandler : IRequestHandler<PedidoItemAddCommand, ValidationResult>,
                                     IRequestHandler<PedidoItemDeletarCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoCommandRepository _pedidoRepository;

        public PedidoItemHandler(IMediator mediator, IUnitOfWork unitOfWork, IPedidoCommandRepository pedidoRepository)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(PedidoItemAddCommand comando, CancellationToken cancelar)
        {
            if(comando.EhValido())
            {
                PedidoItem item = new PedidoItem(comando.Id, comando.Descricao, comando.Quantidade, comando.ValorUnitario, comando.PedidoId);

                await _pedidoRepository.AdicionarItemAsync(item);

                if(!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }

        public async Task<ValidationResult> Handle(PedidoItemDeletarCommand comando, CancellationToken cancelar)
        {
            if(comando.EhValido())
            {
                await _pedidoRepository.RemoverItemAsync(comando.Id);

                if (!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }
    }
}
