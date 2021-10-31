using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ConsoleAPI.Models;
using Newtonsoft.Json;

namespace ConsoleAPI.Services
{
    public class LivroService
    {
        HttpClient cliente = new HttpClient();

        public LivroService()
        {
            cliente.BaseAddress = new Uri("https://localhost:44390/");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task PostLivroAsync(string nome, int generoId)
        {
            Livro livro = new Livro
            {
                Id = 0,
                Nome = nome,
                Reservado = false,
                Genero = generoId
            };
            JsonContent content = JsonContent.Create(livro);
            HttpResponseMessage response = await cliente.PostAsync("api/Livros", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao criar livro : " + response.StatusCode);
            }

        }

        public async Task<List<Livro>> GetLivrosAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Livros");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Livro>>(dados);
            }

            return new List<Livro>();

        }

        public async Task<List<Livro>> GetLivroGenerosAsync(string generoId)
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Livros/Genero?id=" + generoId);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Livro>>(dados);
            }

            return new List<Livro>();
        }

        public async Task<List<Livro>> GetLivroNomeAsync(string nome)
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Livros/Nome?nome=" + nome);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Livro>>(dados);
            }

            return new List<Livro>();
        }

        public async Task DeleteLivroAsync(string idLivro)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("api/Livros/" + idLivro);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao excluir o livro : " + response.StatusCode);
            }
        }

        public async Task PutLivroAsync(string id, string nome, bool reservado, int generoId)
        {
            Livro livro = new Livro
            {
                Id = int.Parse(id),
                Nome = nome,
                Reservado = reservado,
                Genero = generoId
            };
            JsonContent content = JsonContent.Create(livro);
            HttpResponseMessage response = await cliente.PutAsync("api/Livros/" + id, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao criar livro : " + response.StatusCode);
            }

        }
    }
}
