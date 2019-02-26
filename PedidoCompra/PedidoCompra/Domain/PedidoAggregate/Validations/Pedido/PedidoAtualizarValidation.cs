using PedidoCompra.Domain.PedidoAggregate.Commands.Pedido.Atualizar;

namespace PedidoCompra.Domain.PedidoAggregate.Validations.Pedido
{
    public class PedidoAtualizarValidation : PedidoValidation<PedidoAtualizarCommand>
    {
        public PedidoAtualizarValidation()
        {
            ValidarId();
            ValidarCriado();
            ValidarStatus();
            ValidarDescricao();
        }
    }
}
