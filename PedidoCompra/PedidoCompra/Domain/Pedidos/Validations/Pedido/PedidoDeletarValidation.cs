using PedidoCompra.Domain.Pedidos.Commands.Pedido.Deletar;

namespace PedidoCompra.Domain.Pedidos.Validations.Pedido
{
    public class PedidoDeletarValidation : PedidoValidation<PedidoDeletarCommand>
    {
        public PedidoDeletarValidation()
        {
            ValidarId();            
        }
    }
}
