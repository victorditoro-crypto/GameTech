using System.Text.Json;
using GameTech.Classes;

namespace GameTech.Services
{
    public class DadosService
    {
        public void SalvarClientes(List<Cliente> clientes)
        {
            string json = JsonSerializer.Serialize(clientes);

            File.WriteAllText("clientes.json", json);
        }

        public List<Cliente> CarregarClientes()
        {
            if (!File.Exists("clientes.json"))
            {
                return new List<Cliente>();
            }

            string json = File.ReadAllText("clientes.json");

            return JsonSerializer.Deserialize<List<Cliente>>(json);
        }

        public void SalvarProdutos(List<Produto> produtos)
        {
            string json = JsonSerializer.Serialize(produtos);

            File.WriteAllText("produtos.json", json);
        }

        public List<Produto> CarregarProdutos()
        {
            if (!File.Exists("produtos.json"))
            {
                return new List<Produto>();
            }

            string json = File.ReadAllText("produtos.json");

            return JsonSerializer.Deserialize<List<Produto>>(json);
        }

        public void SalvarVendas(List<Venda> vendas)
        {
            string json = JsonSerializer.Serialize(vendas);

            File.WriteAllText("vendas.json", json);
        }

        public List<Venda> CarregarVendas()
        {
            if (!File.Exists("vendas.json"))
            {
                return new List<Venda>();
            }

            string json = File.ReadAllText("vendas.json");

            return JsonSerializer.Deserialize<List<Venda>>(json);
        }
    }
}
