
namespace ConsoleAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public override string ToString()
        {
            return string.Format($"{Nome} - R${Preco} - {Estoque} unidades");
        }
    }
}
