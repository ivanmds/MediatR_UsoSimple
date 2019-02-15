using System;
using System.Threading.Tasks;

namespace PedidoCompra.Contextos
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Contexto _contexto;
        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> SalvarAsync()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
