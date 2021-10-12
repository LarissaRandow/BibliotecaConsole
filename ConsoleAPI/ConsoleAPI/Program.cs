using System;
using System.Threading.Tasks;
using ConsoleAPI.Services;
using static System.Console;

namespace ConsoleAPI
{
    class Program
    {
        private static bool bibliotecario = false;
        private static LivroService repositorioLivro = new LivroService();
        private static GeneroService repositorioGenero = new GeneroService();
        private static ReservaService repositorioReserva = new ReservaService();
        private static LoginService repositorioLogin = new LoginService();

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
                        await PesquisarLivroGenero();
                        return true;
                    case "3":
                        await PesquisarLivroNome();
                        return true;
                    case "4":
                        await CadastraReservaAsync();
                        return true;
                    case "5":
                        await CalcularMulta();
                        return true;
                    case "6":
                        await Login();
                        return true;
                    default:
                        return true;
                }
            }
            else
            {
                Console.WriteLine("\r\nChoose an option:");
                Console.WriteLine("1) Cadastrar Gênero");
                Console.WriteLine("2) Pesquisar Gêneros");
                Console.WriteLine("3) Atualizar Gênero");
                WriteLine("\r");
                Console.WriteLine("4) Cadastrar Livros"); 
                Console.WriteLine("5) Atualizar Livro");
                Console.WriteLine("6) Deletar Livro");
                WriteLine("\r");
                Console.WriteLine("7) Exibir Todos Os Livros");
                Console.WriteLine("8) Pesquisar Por Gênero");
                Console.WriteLine("9) Pesquisar Por Nome"); 
                WriteLine("\r");
                Console.WriteLine("10) Pesquisar Reservas");
                Console.WriteLine("11) Atualizar Reserva");
                Console.WriteLine("12) Deletar Reserva");
                WriteLine("\r");
                Console.WriteLine("13) Calcular Multa"); 

                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await CadastraGeneroAsync();
                        return true;
                    case "2":
                        await TodosGenerosAsync();
                        return true;
                    case "3":
                        await AtualizarGeneroAsync();
                        return true;
                    case "4":
                        await CadastraLivroAsync();
                        return true;
                    case "5":
                        await AtualizarLivroAsync();
                        return true;
                    case "6":
                        await DeletarLivroAsync();
                        return true;
                    case "7":
                        await TodosLivrosAsync();
                        return true;
                    case "8":
                        await PesquisarLivroGenero();
                        return true;
                    case "9":
                        await PesquisarLivroNome();
                        return true;
                    case "10":
                        await TodosReservasAsync();
                        return true;
                    case "11":
                        await AtualizarReservaAsync();
                        return true;
                    case "12":
                        await DeletarReservaAsync();
                        return true;
                    case "13":
                        await CalcularMulta();
                        return true;
                    default:
                        return true;
                }
            }
        }

        private static async Task Login()
        {
            Write("\r\nEmail: ");
            string email = ReadLine();
            Write("\r\nSenha: ");
            string senha = ReadLine();

            var teste = await repositorioLogin.GetLoginAsync(email, senha);
            bibliotecario = bool.Parse(teste);
        }
        private static async Task TodosLivrosAsync()
        {
            
            var livroTask = repositorioLivro.GetLivrosAsync();
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

        private static async Task PesquisarLivroGenero()
        {
            Write("\r\nGenero Id: ");
            string generoId = ReadLine();

            var livroTask = repositorioLivro.GetLivroGenerosAsync(generoId);

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

        private static async Task PesquisarLivroNome()
        {
            Write("\r\nNome: ");
            string nome = ReadLine();

            var livroTask = repositorioLivro.GetLivroNomeAsync(nome);

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

        private static async Task CadastraGeneroAsync()
        {
            Write("\r\nNome: ");
            string nome = ReadLine();

            await repositorioGenero.PostGenerosAsync(nome);
        }

        private static async Task CadastraLivroAsync()
        {
            Write("\r\nNome: ");
            string nome = ReadLine();

            Write("\r\nGenero Id: ");
            int generoId = Convert.ToInt32(ReadLine());

            await repositorioLivro.PostLivroAsync(nome, generoId);
        }

        private static async Task CadastraReservaAsync()
        {
            Write("\r\nCPF: ");
            string nome = ReadLine();

            Write("\r\nLivro Id: ");
            int livroId = Convert.ToInt32(ReadLine());

            await repositorioReserva.PostReservaAsync(nome, livroId);
        }

        private static async Task TodosGenerosAsync()
        {
            var generoTask = repositorioGenero.GetGenerosAsync();
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
            var reservaTask = repositorioReserva.GetReservasAsync();
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

        private static async Task DeletarLivroAsync()
        {
            Write("\r\nLivro ID: ");
            string id = ReadLine();

            await repositorioLivro.DeleteLivroAsync(id);
        }

        private static async Task DeletarReservaAsync()
        {
            Write("\r\nReserva ID: ");
            string id = ReadLine();

            await repositorioReserva.DeletarReservaAsync(id);
        }

        private static async Task CalcularMulta()
        {
            Write("\r\nReserva ID: ");
            string id = ReadLine();

            await repositorioReserva.CalcularMulta(id);
        }

        private static async Task AtualizarGeneroAsync()
        {
            Write("\r\nId: ");
            string id = ReadLine();
            Write("\r\nNome: ");
            string nome = ReadLine();

            await repositorioGenero.PutGenerosAsync(id, nome);
        }

        private static async Task AtualizarReservaAsync()
        {
            Write("\r\nId: ");
            string id = ReadLine();
            Write("\r\nCpf: ");
            string cpf = ReadLine();
            Write("\r\nLivro: ");
            string livro = ReadLine();

            await repositorioReserva.PutReservaAsync(id, cpf, livro);
        }

        private static async Task AtualizarLivroAsync()
        {
            Write("\r\nId: ");
            string id = ReadLine();

            Write("\r\nNome: ");
            string nome = ReadLine();

            Write("\r\nReservado: ");
            bool reservado = Convert.ToBoolean(ReadLine());

            Write("\r\nGenero Id: ");
            int generoId = Convert.ToInt32(ReadLine());

            await repositorioLivro.PutLivroAsync(id, nome, reservado, generoId);
        }
    }
}