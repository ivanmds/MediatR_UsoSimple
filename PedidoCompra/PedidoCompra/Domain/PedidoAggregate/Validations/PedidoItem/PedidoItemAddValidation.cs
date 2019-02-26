using PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem;

namespace PedidoCompra.Domain.PedidoAggregate.Validations.PedidoItem
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
