using PedidoCompra.Domain.PedidoAggregate.Commands.PedidoItem.Deletar;

namespace PedidoCompra.Domain.PedidoAggregate.Validations.PedidoItem
{
    public class PedidoItemDeletarValidation : PedidoItemValidation<PedidoItemDeletarCommand>
    {
        public PedidoItemDeletarValidation()
        {
            ValidarId();
            ValidarPedidoId();
        }
    }
}
