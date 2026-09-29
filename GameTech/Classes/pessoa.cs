namespace GameTech.Classes
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        protected Pessoa()
        {
        }

        protected Pessoa(int id, string nome, string telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
        }

        public virtual string ExibirInformacoes()
        {
            return $"ID: {Id} | Nome: {Nome} | Telefone: {Telefone}";
        }
    }
}
