namespace PedidoCompra.Domain.PedidoAggregate
{
    public enum PedidoStatus: byte
    {
        Definir = 0,
        Aprovado = 1,
        Analisando = 2,
        Reprovado = 3
    }
}
