using PedidoCompra.Domain.Pedidos.Commands.PedidoItem.Deletar;

namespace PedidoCompra.Domain.Pedidos.Validations.PedidoItem
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
