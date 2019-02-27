using MediatR;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Add;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Atualizar;
using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Deletar;
using PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Add;
using PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Deletar;

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
        public async Task<IEnumerable<Pedido>> Obter()
        {
            return await _pedidoRepository.ListarAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<Pedido> ObterPorId(Guid id)
        {
            return await _pedidoRepository.ObterAsync(id);
        }

        [HttpPost("")]
        public async Task<ValidationResult> Novo([FromBody]PedidoAddCommand pedidoAddCommand)
        {
            return await _mediator.Send(pedidoAddCommand);
        }

        [HttpPut("{id:guid}")]
        public async Task<ValidationResult> Atualizar(Guid id, [FromBody] PedidoAtualizarCommand pedidoAtualizarCommand)
        {
            pedidoAtualizarCommand.SetId(id);
            return await _mediator.Send(pedidoAtualizarCommand);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ValidationResult> Deletar(Guid id)
        {
            PedidoDeletarCommand pedidoDeletarCommand = new PedidoDeletarCommand(id);
            return await _mediator.Send(pedidoDeletarCommand);
        }

        [HttpPost("{id:guid}/itens")]
        public async Task<ValidationResult> AtualizarItem(Guid id, [FromBody] PedidoItemAddCommand pedidoItemAddCommand)
        {
            pedidoItemAddCommand.SetPedidoId(id);
            return await _mediator.Send(pedidoItemAddCommand);
        }

        [HttpDelete("{id:guid}/itens/{pedidoItemId:guid}")]
        public async Task<ValidationResult> DeletarItem(Guid id, Guid pedidoItemId)
        {
            PedidoItemDeletarCommand pedidoItemDeletarCommand = new PedidoItemDeletarCommand(pedidoItemId, id);
            return await _mediator.Send(pedidoItemDeletarCommand);
        }
    }
}
