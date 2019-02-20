using FluentValidation;
using PedidoCompra.Domain.PedidoAggregate.Commands;

namespace PedidoCompra.Domain.PedidoAggregate.Validations
{
    public class PedidoAddValidation : PedidoValidation<PedidoAddCommand>
    {
        public PedidoAddValidation()
        {
            ValidarId();
            ValidarCriado();
            ValidarStatus();
            ValidarDescricao();
            ValidarItens();
        }
    }
}
