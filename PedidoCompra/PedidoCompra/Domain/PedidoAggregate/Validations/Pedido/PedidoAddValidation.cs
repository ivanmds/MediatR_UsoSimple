using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Add;

namespace PedidoCompra.Domain.PedidoAggregate.Validations.Pedido
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
