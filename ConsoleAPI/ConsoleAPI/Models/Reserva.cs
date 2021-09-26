using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPI.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime Data { get; set; }
        public int Livro { get; set; }

        public override string ToString()
        {
            return string.Format($"{Cpf} - {Livro}");
        }
    }
}
