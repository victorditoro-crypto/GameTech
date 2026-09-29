using GameTech.Classes;
using GameTech.Services;

namespace GameTech
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Produto> produtos = new List<Produto>();
        static List<Venda> vendas = new List<Venda>();

        static DadosService dados = new DadosService();

        static int idCliente = 1;
        static int idProduto = 1;
        static int idVenda = 1;

        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("==============================");
                Console.WriteLine("       GAMETECH");
                Console.WriteLine("==============================");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar produto");
                Console.WriteLine("3 - Listar clientes");
                Console.WriteLine("4 - Listar produtos");
                Console.WriteLine("5 - Fazer venda");
                Console.WriteLine("6 - Listar vendas");
                Console.WriteLine("7 - Ver estoque baixo");
                Console.WriteLine("8 - Salvar dados");
                Console.WriteLine("9 - Carregar dados");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("==============================");

                Console.Write("Escolha: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();

                    if (opcao == 1)
                    {
                        CadastrarCliente();
                    }
                    else if (opcao == 2)
                    {
                        CadastrarProduto();
                    }
                    else if (opcao == 3)
                    {
                        ListarClientes();
                    }
                    else if (opcao == 4)
                    {
                        ListarProdutos();
                    }
                    else if (opcao == 5)
                    {
                        FazerVenda();
                    }
                    else if (opcao == 6)
                    {
                        ListarVendas();
                    }
                    else if (opcao == 7)
                    {
                        EstoqueBaixo();
                    }
                    else if (opcao == 8)
                    {
                        Salvar();
                    }
                    else if (opcao == 9)
                    {
                        Carregar();
                    }
                    else if (opcao == 0)
                    {
                        Console.WriteLine("Programa encerrado.");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                    }
                }
                catch
                {
                    Console.WriteLine("Digite uma opção válida.");
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aperte ENTER para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (opcao != 0);
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("=== CADASTRAR CLIENTE ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(
                idCliente,
                nome,
                telefone,
                email
            );

            clientes.Add(cliente);

            idCliente++;

            Console.WriteLine("Cliente cadastrado!");
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("=== CADASTRAR PRODUTO ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Estoque: ");
            int estoque = int.Parse(Console.ReadLine());

            Console.Write("Plataforma: ");
            string plataforma = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoriaNome = Console.ReadLine();

            Categoria categoria = new Categoria(
                1,
                categoriaNome
            );

            Produto produto = new Produto(
                idProduto,
                nome,
                preco,
                estoque,
                plataforma,
                categoria
            );

            produtos.Add(produto);

            idProduto++;

            Console.WriteLine("Produto cadastrado!");
        }

        static void ListarClientes()
        {
            Console.WriteLine("=== CLIENTES ===");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.ExibirInformacoes());
            }
        }

        static void ListarProdutos()
        {
            Console.WriteLine("=== PRODUTOS ===");

            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }

            foreach (Produto produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        static void FazerVenda()
        {
            Console.WriteLine("=== FAZER VENDA ===");

            if (clientes.Count == 0 || produtos.Count == 0)
            {
                Console.WriteLine(
                    "Cadastre cliente e produto primeiro."
                );

                return;
            }

            ListarClientes();

            Console.Write("ID do cliente: ");
            int id = int.Parse(Console.ReadLine());

            Cliente clienteEscolhido = null;

            foreach (Cliente cliente in clientes)
            {
                if (cliente.Id == id)
                {
                    clienteEscolhido = cliente;
                }
            }

            if (clienteEscolhido == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Venda venda = new Venda();

            venda.Id = idVenda;
            venda.Cliente = clienteEscolhido;

            idVenda++;

            while (true)
            {
                Console.WriteLine();
                ListarProdutos();

                Console.WriteLine();
                Console.WriteLine("Digite 0 para terminar.");

                Console.Write("ID do produto: ");
                int idProdutoEscolhido =
                    int.Parse(Console.ReadLine());

                if (idProdutoEscolhido == 0)
                {
                    break;
                }

                Produto produtoEscolhido = null;

                foreach (Produto produto in produtos)
                {
                    if (produto.Id == idProdutoEscolhido)
                    {
                        produtoEscolhido = produto;
                    }
                }

                if (produtoEscolhido == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    continue;
                }

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                try
                {
                    venda.AdicionarItem(
                        produtoEscolhido,
                        quantidade
                    );

                    Console.WriteLine("Produto adicionado!");
                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            }

            if (venda.Itens.Count == 0)
            {
                Console.WriteLine("Nenhum produto foi vendido.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=== PAGAMENTO ===");
            Console.WriteLine("1 - Pix");
            Console.WriteLine("2 - Dinheiro");
            Console.WriteLine("3 - Cartão");

            Console.Write("Escolha: ");
            int pagamento = int.Parse(Console.ReadLine());

            if (pagamento == 1)
            {
                venda.FormaPagamento = "Pix";
            }
            else if (pagamento == 2)
            {
                venda.FormaPagamento = "Dinheiro";
            }
            else
            {
                venda.FormaPagamento = "Cartão";
            }

            decimal total = venda.CalcularTotal();

            Console.WriteLine();
            Console.WriteLine("Total: " + total.ToString("C"));

            venda.RealizarPagamento(total);

            vendas.Add(venda);

            Console.WriteLine("Venda realizada!");
        }

        static void ListarVendas()
        {
            Console.WriteLine("=== VENDAS ===");

            if (vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda realizada.");
            }

            foreach (Venda venda in vendas)
            {
                Console.WriteLine(venda);
            }
        }

        static void EstoqueBaixo()
        {
            Console.WriteLine("=== ESTOQUE BAIXO ===");

            foreach (Produto produto in produtos)
            {
                if (produto.Estoque <= 5)
                {
                    Console.WriteLine(
                        produto.Nome +
                        " - Estoque: " +
                        produto.Estoque
                    );
                }
            }
        }

        static void Salvar()
        {
            dados.SalvarClientes(clientes);
            dados.SalvarProdutos(produtos);
            dados.SalvarVendas(vendas);

            Console.WriteLine("Dados salvos!");
        }

        static void Carregar()
        {
            clientes = dados.CarregarClientes();
            produtos = dados.CarregarProdutos();
            vendas = dados.CarregarVendas();

            Console.WriteLine("Dados carregados!");
        }
    }
}
