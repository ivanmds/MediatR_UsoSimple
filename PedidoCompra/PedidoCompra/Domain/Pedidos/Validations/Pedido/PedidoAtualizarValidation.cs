using PedidoCompra.Domain.Pedidos.Commands.Pedido.Atualizar;

namespace PedidoCompra.Domain.Pedidos.Validations.Pedido
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
