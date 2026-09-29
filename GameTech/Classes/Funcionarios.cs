namespace GameTech.Classes
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, string telefone, string cargo)
            : base(id, nome, telefone)
        {
            this.Cargo = cargo;
        }

        public override string ExibirInformacoes()
        {
            return $"Funcionário - ID: {Id} | Nome: {Nome} | Cargo: {Cargo}";
        }
    }
}
