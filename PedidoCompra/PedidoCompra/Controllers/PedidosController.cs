using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedidoCompra.Domain;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using System.Threading.Tasks;

namespace PedidoCompra.Controllers
{
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IMediator _mediator;

        public PedidosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }

        [HttpPost("")]
        public async Task Post([FromBody]PedidoAddCommand pedidoAddCommand)
        {
            Resultado resultado = await _mediator.Send<Resultado>(pedidoAddCommand);
        }
    }
}
