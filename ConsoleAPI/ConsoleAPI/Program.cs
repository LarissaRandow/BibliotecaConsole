using System;
using System.Threading.Tasks;
using ConsoleAPI.Services;
using static System.Console;

namespace ConsoleAPI
{
    class Program
    {
        private static bool bibliotecario = false;
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        private static bool MainMenu()
        {
            //Console.Clear();
            string resultado;
            if (!bibliotecario)
            {
                Console.WriteLine("\r\nChoose an option:");
                Console.WriteLine("1) Exibir Todos Os Livros");
                Console.WriteLine("2) Pesquisar Por Gênero");
                Console.WriteLine("3) Pesquisar Por Nome");
                Console.WriteLine("4) Reservar Um Livro");
                Console.WriteLine("5) Calcular Multa");
                Console.WriteLine("6) Realizar Login");


                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        resultado = TodosLivros();
                        Console.WriteLine("\r\n " +  resultado);
                        return true;
                    case "2":
                        return true;
                    case "3":
                        return true;
                    case "4":
                        return true;
                    case "5":
                        return true;
                    case "6":
                        bibliotecario = true;
                        return true;
                    default:
                        return true;
                }
            }
            else
            {
                Console.WriteLine("1) Cadastrar Gênero");
                Console.WriteLine("2) Pesquisar Gênero");
                Console.WriteLine("3) Atualizar Gênero");
                Console.WriteLine("4) Deletar Gênero");

                Console.WriteLine("5) Cadastrar Livros");
                Console.WriteLine("6) Pesquisar Livros");
                Console.WriteLine("7) Atualizar Livro");
                Console.WriteLine("8) Deletar Deletar");

                
                Console.WriteLine("9) Exibir Todos Os Livros");
                Console.WriteLine("10) Pesquisar Por Gênero");
                Console.WriteLine("11) Pesquisar Por Nome");

                Console.WriteLine("12) Pesquisar Reserva");
                Console.WriteLine("13) Atualizar Reserva");
                Console.WriteLine("14) Deletar Gênero");

                Console.WriteLine("15) Calcular Multa");

                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        return true;
                    case "2":
                        return true;
                    case "3":
                        return true;
                    case "4":
                        return true;
                    case "5":
                        return true;
                    default:
                        return true;
                }
            }
        }

        private static string TodosLivros()
        {
            var repositorio = new ProdutoService();
            var produtoTask = repositorio.GetProdutosAsync();

            produtoTask.ContinueWith(task =>
            {
                var produtos = task.Result;
                foreach (var p in produtos)
                    WriteLine(p.ToString());
                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            return "livros";
        }
    }
}
