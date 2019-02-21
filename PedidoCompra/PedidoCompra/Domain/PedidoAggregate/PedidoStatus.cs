namespace PedidoCompra.Domain.PedidoAggregate
{
    public enum PedidoStatus: byte
    {
        Definir = 0,
        Analisando = 1,
        Reprovado = 2,
        Aprovado = 3,
    }
}
