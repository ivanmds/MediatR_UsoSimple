using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;

namespace PedidoCompra.Domain.PedidoAggregate.Handlers
{
    public class PedidoHandler : IRequestHandler<PedidoAddCommand, Resultado>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(IMediator mediator, IPedidoRepository pedidoRepository)
        {
            _mediator = mediator;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Resultado> Handle(PedidoAddCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = new Pedido(request.Id, request.Criado, request.Descricao, request.Status);
            await _pedidoRepository.AddAsync(pedido);

            return Resultado.Ok;
        }
    }
}
