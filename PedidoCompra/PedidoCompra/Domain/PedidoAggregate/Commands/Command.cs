using FluentValidation.Results;
using MediatR;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult Validacao { get; protected set; } = new ValidationResult();
        public abstract bool EhValido();
    }
}
