using FluentValidation.Results;
using MediatR;
using System;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public DateTime Data { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public TipoMensagem Tipo { get; protected set; }
        public ValidationResult Validacao { get; protected set; } = new ValidationResult();
        public abstract bool EhValido();
    }
}
