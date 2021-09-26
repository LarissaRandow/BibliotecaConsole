namespace ConsoleAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Reservado { get; set; }
        public int Genero { get; set; }

        public override string ToString()
        {
            return string.Format($"{Nome}");
        }
    }
}
