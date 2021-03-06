﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PedidoCompra.Domain.Pedidos;
using PedidoCompra.Domain.Pedidos.Interfaces.Repositorios;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using System.Linq;

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

        public async Task<Pedido> ObterAsync(Guid id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT p.Id, p.Criado, p.Descricao, p.Status, c.Id, c.Nome, c.Numero, c.Vencimento, c.Codigo FROM Pedido p INNER JOIN Cartao c ON p.CartaoId = c.Id WHERE p.Id = @PedidoId ");
            query.Append("SELECT i.Id, i.Descricao, i.Quantidade, i.ValorUnitario, i.PedidoId FROM PedidoItem i  WHERE i.PedidoId = @PedidoId ");

            using (var multi = await _db.QueryMultipleAsync(query.ToString(), new { PedidoId = id }))
            {
                Pedido pedido = (multi.Read<Pedido, Cartao, Pedido>((p, c) =>
                {
                    p.AdicionarCartao(c);

                    return p;

                })).FirstOrDefault();

                IEnumerable<PedidoItem> itens = await multi.ReadAsync<PedidoItem>();

                if (pedido == null) return null;

                pedido.AdicionarItem(itens);

                return pedido;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
