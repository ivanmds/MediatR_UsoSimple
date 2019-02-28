using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagamentoApi.Domain.Command;
using System.Linq;
using System.Threading.Tasks;

namespace PagamentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult> Processar(PagamentoProcessarCommand pagamentoProcessarCommand)
        {
            ValidationResult resultado = await _mediator.Send(pagamentoProcessarCommand);

            if (!resultado.IsValid) return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));

            string uri = $"{Request.Host.Value}/{Request.Path.Value}/status/{pagamentoProcessarCommand.Id}";
            return Created(uri, pagamentoProcessarCommand);
        }

    }
}