using PedidoCompra.Domain.PedidoAggregate.Commands;

namespace PedidoCompra.Domain.PedidoAggregate.Validations
{
    public class PedidoDeletarValidation : PedidoValidation<PedidoDeletarCommand>
    {
        public PedidoDeletarValidation()
        {
            ValidarId();            
        }
    }
}
