using Microsoft.EntityFrameworkCore;
using PedidoCompra.Domain.Pedidos;
using PedidoCompra.Contextos.Maps;

namespace PedidoCompra.Contextos
{
    public class Contexto : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLServer;Initial Catalog=PedidoCompra;Persist Security Info=True;User ID=sa;Password=123456");
        }
    }
}
