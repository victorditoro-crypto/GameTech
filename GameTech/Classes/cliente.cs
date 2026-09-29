namespace GameTech.Classes
{
    public class Cliente : Pessoa
    {
        public string Email { get; set; }

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string telefone, string email)
            : base(id, nome, telefone)
        {
            this.Email = email;
        }

        public override string ExibirInformacoes()
        {
            return $"Cliente - ID: {Id} | Nome: {Nome} | Telefone: {Telefone} | E-mail: {Email}";
        }
    }
}
