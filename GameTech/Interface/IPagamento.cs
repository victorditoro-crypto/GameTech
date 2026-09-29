namespace GameTech.Interfaces
{
    public interface IPagamento
    {
        void RealizarPagamento(decimal valor);

        string TipoPagamento();
    }
}
