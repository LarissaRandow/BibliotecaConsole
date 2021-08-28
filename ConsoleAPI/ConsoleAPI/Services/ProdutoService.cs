using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsoleAPI.Models;
using Newtonsoft.Json;

namespace ConsoleAPI.Services
{
    public class ProdutoService
    {
        HttpClient cliente = new HttpClient();

        public ProdutoService()
        {
            cliente.BaseAddress = new Uri("https://localhost:44390/");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Produtos");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Produto>>(dados);
            }

            return new List<Produto>();

        }
    }
}
