using System.Threading.Tasks;

namespace PedidoCompra.Contextos
{
    public interface IUnitOfWork
    {
        Task<bool> SalvarAsync();
    }
}
