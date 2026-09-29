namespace GameTech.Classes
{
    public class Produto
    {
        private decimal preco;
        private int estoque;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public Categoria Categoria { get; set; }

        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("O preço não pode ser negativo.");

                preco = value;
            }
        }

        public int Estoque
        {
            get { return estoque; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("O estoque não pode ser negativo.");

                estoque = value;
            }
        }

        public Produto()
        {
        }

        public Produto(
            int id,
            string nome,
            decimal preco,
            int estoque,
            string plataforma,
            Categoria categoria)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.Estoque = estoque;
            this.Plataforma = plataforma;
            this.Categoria = categoria;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            Estoque += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (quantidade > Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;
        }

        public bool EstoqueBaixo()
        {
            return Estoque <= 5;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Nome} | Plataforma: {Plataforma} | " +
                   $"Preço: {Preco:C} | Estoque: {Estoque} | " +
                   $"Categoria: {Categoria?.Nome}";
        }
    }
}
