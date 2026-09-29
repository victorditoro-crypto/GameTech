using GameTech.Interfaces;

namespace GameTech.Classes
{
    public class Venda : IPagamento
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public string FormaPagamento { get; set; }

        public Venda()
        {
            Itens = new List<ItemVenda>();
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (ItemVenda item in Itens)
            {
                total += item.CalcularSubtotal();
            }

            return total;
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (quantidade > produto.Estoque)
            {
                throw new Exception("Não tem estoque suficiente.");
            }

            produto.RemoverEstoque(quantidade);

            ItemVenda item = new ItemVenda(produto, quantidade);

            Itens.Add(item);
        }

        public void RealizarPagamento(decimal valor)
        {
            Console.WriteLine("Pagamento realizado: " + valor.ToString("C"));
        }

        public string TipoPagamento()
        {
            return FormaPagamento;
        }

        public override string ToString()
        {
            return "Venda: " + Id +
                   " | Cliente: " + Cliente.Nome +
                   " | Total: " + CalcularTotal().ToString("C");
        }
    }
}
