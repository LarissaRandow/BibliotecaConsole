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
    public class ReservaService
    {
        HttpClient cliente = new HttpClient();

        public ReservaService()
        {
            cliente.BaseAddress = new Uri("https://localhost:44390/");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Reserva>> GetReservasAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Reservas");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Reserva>>(dados);
            }

            return new List<Reserva>();

        }

        public async Task PostReservaAsync(string cpf, int livroId)
        {
            Reserva reserva = new Reserva
            {
                Id = 0,
                Cpf = cpf,
                Data = DateTime.Now,
                Livro = livroId
            };
            JsonContent content = JsonContent.Create(reserva);
            HttpResponseMessage response = await cliente.PostAsync("api/Reservas", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao criar reserva : " + response.StatusCode);
            }

        }

        public async Task DeletarReservaAsync(string idReserva)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("api/Reservas/" + idReserva);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao excluir a reserva : " + response.StatusCode);
            }
            else
            {
                Console.Write("Reservar Deleta com sucesso");
            }
        }
    }
}
