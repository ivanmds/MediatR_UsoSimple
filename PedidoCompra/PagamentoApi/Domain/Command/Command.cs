using MediatR;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace PagamentoApi.Domain.Command
{
    public abstract class Command : IRequest<ValidationResult>
    {
        [JsonIgnore]
        public ValidationResult Validacao { get; protected set; } = new ValidationResult();
        public abstract bool EhValido();
    }
}
