using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPI.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return string.Format($"{Nome}");
        }
    }
}
