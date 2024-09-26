namespace PrimeiraAPI.Models
{
	public class Aluno
	{
        public Guid Id { get; set; }
        public int Codigo { get; set; }
		public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereco { get; set; }
    }
}
