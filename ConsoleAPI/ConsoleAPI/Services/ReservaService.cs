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

        public async Task<string> CalcularMulta(string id)
        {
            HttpResponseMessage response = await cliente.GetAsync("api/Reservas/" + id);

            var mensagem = "Reserva dentro do prazo";
            if (response.IsSuccessStatusCode)
            {
                
                var dados = await response.Content.ReadAsStringAsync();
                var reserva = JsonConvert.DeserializeObject<Reserva>(dados);

                var diferença = DateTime.Today.Subtract(reserva.Data).TotalDays;
                if (diferença > 0)
                {
                    mensagem = "Multa: R$" + Math.Floor(diferença);
                }
                    
            }
            Console.WriteLine(mensagem);
            return mensagem;

        }

        public async Task PostReservaAsync(string cpf, int livroId)
        {
            Reserva reserva = new Reserva
            {
                Id = 0,
                Cpf = cpf,
                Data = DateTime.Now.AddDays(14),
                Livro = livroId
            };
            JsonContent content = JsonContent.Create(reserva);
            HttpResponseMessage response = await cliente.PostAsync("api/Reservas", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Falha ao criar reserva : " + response.StatusCode);
            }

        }

        public async Task DeletarReservaAsync(string idReserva)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("api/Reservas/" + idReserva);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Falha ao excluir a reserva : " + response.StatusCode);
            }
            else
            {
                Console.Write("Reservar Deleta com sucesso");
            }
        }

        public async Task PutReservaAsync(string idReserva, string cpf, string idLivro)
        {
            Reserva reserva = new Reserva
            {
                Id = int.Parse(idReserva),
                Cpf = cpf,
                Data = DateTime.Now,
                Livro = int.Parse(idLivro)
            };
            JsonContent content = JsonContent.Create(reserva);
            HttpResponseMessage response = await cliente.PutAsync("api/Reservas/" + idReserva, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao atualizar reserva : " + response.StatusCode);
            }

        }
    }
}
