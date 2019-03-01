using PedidoCompra.Domain.Pedidos.Commands.PedidoItem;

namespace PedidoCompra.Domain.Pedidos.Validations.PedidoItem
{
    public class PedidoItemAddValidation : PedidoItemValidation<PedidoItemCommand>
    {
        public PedidoItemAddValidation()
        {
            ValidarId();
            ValidarDescricao();
            ValidarQuantidade();
            ValidarValorUnitario();
            ValidarPedidoId();
        }
    }
}
