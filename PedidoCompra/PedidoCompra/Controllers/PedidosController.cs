using MediatR;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PedidoCompra.Controllers
{
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IPedidoQueryRepository _pedidoRepository;

        public PedidosController(IMediator mediator, IPedidoQueryRepository pedidoRepository)
        {
            _mediator = mediator;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Pedido>> Get()
        {
            return await _pedidoRepository.ListarAsync();
        }

        [HttpPost("")]
        public async Task<ValidationResult> Post([FromBody]PedidoAddCommand pedidoAddCommand)
        {
            return await _mediator.Send(pedidoAddCommand);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ValidationResult> Deletar(Guid id)
        {
            PedidoDeletarCommand pedidoDeletarCommand = new PedidoDeletarCommand(id);
            return await _mediator.Send(pedidoDeletarCommand);
        }
    }
}
