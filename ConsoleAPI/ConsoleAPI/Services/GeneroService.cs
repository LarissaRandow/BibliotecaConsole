using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsoleAPI.Models;
using Newtonsoft.Json;

namespace ConsoleAPI.Services
{
    public class GeneroService
    {
        HttpClient cliente = new HttpClient();

        public GeneroService()
        {
            cliente.BaseAddress = new Uri("https://localhost:44390/");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Genero>> GetGenerosAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Generos");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Genero>>(dados);
            }

            return new List<Genero>();
        }

        public async Task<List<Genero>> PostGenerosAsync(string nome)
        {
            Genero genero = new Genero
            {
                Id = 0,
                Nome = nome
            };
            JsonContent content = JsonContent.Create(genero);
            HttpResponseMessage response = await cliente.PostAsync("api/Generos", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao criar gênero : " + response.StatusCode);
            }

            return new List<Genero>();
        }

    }
}
