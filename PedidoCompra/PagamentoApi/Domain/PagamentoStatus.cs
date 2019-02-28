namespace PagamentoApi.Domain
{
    public enum PagamentoStatus: byte
    {
        Erro = 0,
        Aprocessar = 10,
        Processando = 20,
        Aprovado = 30,
        Recusado = 40
    }
}
