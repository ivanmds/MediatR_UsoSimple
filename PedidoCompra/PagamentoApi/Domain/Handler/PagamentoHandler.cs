using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PagamentoApi.Domain.Command;

namespace PagamentoApi.Domain.Handler
{
    public class PagamentoHandler : IRequestHandler<PagamentoProcessarCommand, ValidationResult>
    {
        private readonly IMediator _mediator;

        public PagamentoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> Handle(PagamentoProcessarCommand comando, CancellationToken cancelar)
        {
            if(comando.EhValido())
            {

            }

            return comando.Validacao;
        }
    }
}
