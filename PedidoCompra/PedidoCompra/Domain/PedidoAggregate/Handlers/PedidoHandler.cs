using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using FluentValidation.Results;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Add;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Deletar;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Atualizar;

namespace PedidoCompra.Domain.PedidoAggregate.Handlers
{
    public class PedidoHandler : IRequestHandler<PedidoAddCommand, ValidationResult>,
                                 IRequestHandler<PedidoDeletarCommand, ValidationResult>,
                                 IRequestHandler<PedidoAtualizarCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoCommandRepository _pedidoRepository;

        public PedidoHandler(IMediator mediator, IUnitOfWork unitOfWork, IPedidoCommandRepository pedidoRepository)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(PedidoAddCommand comando, CancellationToken cancelar)
        {
            if (comando.EhValido())
            {
                Pedido pedido = new Pedido(comando.Id, comando.Criado, comando.Descricao, comando.Status);

                if (comando.Itens?.Count > 0)
                    foreach (PedidoItemDto item in comando.Itens)
                        pedido.AdicionarItem(new PedidoItem(item.Id, item.Descricao, item.Quantidade, item.ValorUnitario, pedido.Id));


                await _pedidoRepository.AdicionarAsync(pedido);

                if (!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));

                await _mediator.Publish(new PedidoAddNotification() { Id = pedido.Id, Criado = pedido.Criado, Descricao = pedido.Descricao });
            }

            return comando.Validacao;
        }

        public async Task<ValidationResult> Handle(PedidoDeletarCommand comando, CancellationToken cancelar)
        {
            if (comando.EhValido())
            {
                Pedido pedido = await _pedidoRepository.RemoverAsync(comando.Id);

                if (pedido == null)
                {
                    comando.Validacao.Errors.Add(new ValidationFailure("Deletar", "Não foi encontrado pedido para ser deletado"));
                    return comando.Validacao;
                }
                else
                {
                    if (pedido.Status == PedidoStatus.Aprovado)
                    {
                        comando.Validacao.Errors.Add(new ValidationFailure("Status", "Pedido já está aprovado."));
                        return comando.Validacao;
                    }
                }

                if (!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }

        public async Task<ValidationResult> Handle(PedidoAtualizarCommand comando, CancellationToken cancelar)
        {
            if(comando.EhValido())
            {
                Pedido pedido = new Pedido(comando.Id, comando.Criado, comando.Descricao, comando.Status);

                if (comando.Itens?.Count > 0)
                    foreach (PedidoItemDto item in comando.Itens)
                        pedido.AdicionarItem(new PedidoItem(item.Id, item.Descricao, item.Quantidade, item.ValorUnitario, pedido.Id));

                _pedidoRepository.Atualizar(pedido);

                if (!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }
    }
}
