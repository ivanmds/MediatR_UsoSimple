using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using FluentValidation.Results;
using PedidoCompra.Contextos;

namespace PedidoCompra.Domain.PedidoAggregate.Handlers
{
    public class PedidoHandler : IRequestHandler<PedidoAddCommand, ValidationResult>
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
                        pedido.AdicionarItem(new PedidoItem(item.Id, item.Descricao, item.Quantidade, item.ValorUnitario));


                await _pedidoRepository.AdicionarAsync(pedido);

                if (!await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }
    }
}
