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
            Task<bool> task;
            while (showMenu)
            {
                task = MainMenuAsync();
                task.Wait();
                showMenu = task.Result;
            }

        }

        private static async Task<bool> MainMenuAsync()
        {
            //Console.Clear();
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
                        await TodosLivrosAsync();
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
                Console.WriteLine("\r\nChoose an option:");
                Console.WriteLine("1) Cadastrar Gênero");
                Console.WriteLine("2) Pesquisar Gênero");
                Console.WriteLine("3) Atualizar Gênero");
                Console.WriteLine("4) Deletar Gênero");
                WriteLine("\r");
                Console.WriteLine("5) Cadastrar Livros");
                Console.WriteLine("6) Atualizar Livro");
                Console.WriteLine("7) Deletar Deletar");
                WriteLine("\r");
                Console.WriteLine("8) Exibir Todos Os Livros");
                Console.WriteLine("9) Pesquisar Por Gênero");
                Console.WriteLine("10) Pesquisar Por Nome");
                WriteLine("\r");
                Console.WriteLine("11) Pesquisar Reserva");
                Console.WriteLine("12) Atualizar Reserva");
                Console.WriteLine("13) Deletar Gênero");
                WriteLine("\r");
                Console.WriteLine("14) Calcular Multa");

                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        return true;
                    case "2":
                        await TodosGenerosAsync();
                        return true;
                    case "3":
                        return true;
                    case "4":
                        return true;
                    case "5":
                        return true;
                    case "6":
                        return true;
                    case "7":
                        return true;
                    case "8":
                        await TodosLivrosAsync();
                        return true;
                    case "9":
                        return true;
                    case "10":
                        return true;
                    case "11":
                        await TodosReservasAsync();
                        return true;
                    case "12":
                        return true;
                    case "13":
                        return true;
                    case "14":
                        return true;
                    default:
                        return true;
                }
            }
        }

        private static async Task TodosLivrosAsync()
        {
            var repositorio = new LivroService();
            var livroTask = repositorio.GetLivrosAsync();
            WriteLine("\r");
            WriteLine("--------Lista----------");
            await livroTask.ContinueWith(task =>
            {
                var livros = task.Result;
                foreach (var p in livros)
                    WriteLine(p.ToString());
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            WriteLine("-----------------------");
        }

        private static async Task TodosGenerosAsync()
        {
            var repositorio = new GeneroService();
            var generoTask = repositorio.GetGenerosAsync();
            WriteLine("\r");
            WriteLine("--------Lista----------");
            await generoTask.ContinueWith(task =>
            {
                var generos = task.Result;
                foreach (var p in generos)
                    WriteLine(p.ToString());
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            WriteLine("-----------------------");
        }

        private static async Task TodosReservasAsync()
        {
            var repositorio = new ReservaService();
            var reservaTask = repositorio.GetReservasAsync();
            WriteLine("\r");
            WriteLine("--------Lista----------");
            await reservaTask.ContinueWith(task =>
            {
                var reservas = task.Result;
                foreach (var p in reservas)
                    WriteLine(p.ToString());
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            WriteLine("-----------------------");
        }
    }
}


//var repositorio = new ProdutoService();
//var produtoTask = repositorio.GetProdutosAsync();

//produtoTask.ContinueWith(task =>
//{
//    var produtos = task.Result;
//    foreach (var p in produtos)
//        WriteLine(p.ToString());
//    Environment.Exit(0);
//},
//TaskContinuationOptions.OnlyOnRanToCompletion
//);