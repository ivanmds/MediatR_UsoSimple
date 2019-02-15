using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using System.Data.SqlClient;
using Dapper;

namespace PedidoCompra.Repositorios
{
    public class PedidoQueryRepository : IPedidoQueryRepository, IDisposable
    {
        private readonly SqlConnection _db;
        public PedidoQueryRepository()
        {
            _db = new SqlConnection(@"Data Source=localhost\SQLServer;Initial Catalog=PedidoCompra;Persist Security Info=True;User ID=sa;Password=123456");
        }

        public async Task<IEnumerable<Pedido>> ListarAsync()
        {
            return await _db.QueryAsync<Pedido>("SELECT Id, Criado, Descricao, Status FROM Pedido");
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
