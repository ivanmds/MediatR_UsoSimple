using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Add;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;

namespace PedidoCompra.Domain.PedidoAggregate.Handlers
{
    public class PedidoItemHandler : IRequestHandler<PedidoItemAddCommand, ValidationResult>
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

                if(await _unitOfWork.SalvarAsync())
                    comando.Validacao.Errors.Add(new ValidationFailure("Salvar", "Erro ao tentar salvar operação"));
            }

            return comando.Validacao;
        }
    }
}
