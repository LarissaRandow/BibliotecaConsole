using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
    }
}
