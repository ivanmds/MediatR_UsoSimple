using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Deletar;

namespace PedidoCompra.Domain.PedidoAggregate.Validations.Pedido
{
    public class PedidoDeletarValidation : PedidoValidation<PedidoDeletarCommand>
    {
        public PedidoDeletarValidation()
        {
            ValidarId();            
        }
    }
}
