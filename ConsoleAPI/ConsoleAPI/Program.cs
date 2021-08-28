using System;
using System.Threading.Tasks;
using ConsoleAPI.Services;
using static System.Console;

namespace ConsoleAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Acessando a Web API. Aguarde...");

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

            ReadLine();
        }
    }
}
