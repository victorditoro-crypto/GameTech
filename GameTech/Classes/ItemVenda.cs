namespace GameTech.Classes
{
    public class ItemVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemVenda()
        {
        }

        public ItemVenda(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public decimal CalcularSubtotal()
        {
            return Produto.Preco * Quantidade;
        }
    }
}
