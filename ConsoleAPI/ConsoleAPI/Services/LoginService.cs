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
    public class LoginService
    {
        HttpClient cliente = new HttpClient();

        public LoginService()
        {
            cliente.BaseAddress = new Uri("https://localhost:44390/");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetLoginAsync(string email, string senha)
        {
            HttpResponseMessage response = await cliente.GetAsync("/api/Bibliotecarios/Login?email=" + email + "&senha=" + senha);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Não foi possível realizar o login";
        }
    }
}
