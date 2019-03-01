using PedidoCompra.Domain.Pedidos.Commands.Pedido.Add;

namespace PedidoCompra.Domain.Pedidos.Validations.Pedido
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
