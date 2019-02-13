using Microsoft.EntityFrameworkCore;
using PedidoCompra.Domain.PedidoAggregate;
using PedidoCompra.Contextos.Maps;

namespace PedidoCompra.Contextos
{
    public class Contexto : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Teste;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
