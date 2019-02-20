using System;
using System.Collections.Generic;

namespace PedidoCompra.Domain.PedidoAggregate.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime Criado { get; protected set; }
        public string Descricao { get; protected set; }
        public PedidoStatus Status { get; protected set; }
        public List<PedidoItemDto> Itens { get; protected set; }
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
