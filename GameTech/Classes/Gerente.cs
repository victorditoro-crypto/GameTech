namespace GameTech.Classes
{
    public class Gerente : Funcionario
    {
        public double Bonus { get; set; }

        public Gerente()
        {
        }

        public Gerente(
            int id,
            string nome,
            string telefone,
            string cargo,
            double bonus)
            : base(id, nome, telefone, cargo)
        {
            this.Bonus = bonus;
        }

        public override string ExibirInformacoes()
        {
            return $"Gerente - ID: {Id} | Nome: {Nome} | Cargo: {Cargo} | Bônus: {Bonus:C}";
        }
    }
}
