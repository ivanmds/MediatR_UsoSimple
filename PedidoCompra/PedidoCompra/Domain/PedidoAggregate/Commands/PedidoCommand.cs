using System;
using System.Collections.Generic;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; set; }
        public DateTime Criado { get; set; }
        public string Descricao { get; set; }
        public PedidoStatus Status { get; set; }

        public List<PedidoItemDto> Itens { get; set; }
    }

    public class PedidoItemDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public float Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public PedidoItemDto()
        {
            if (Id.Equals(Guid.Empty))
                Id = Guid.NewGuid();
        }
    }
}
