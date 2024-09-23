using PrimeiraAPI.Models;

namespace PrimeiraAPI.Interfaces
{
	public interface IAlunoCadastro
	{
		//IList<Aluno> listaAluno { get; set; }

		public IList<Aluno> ListarAlunos();
		public Aluno CriarAluno(Aluno dadosAluno);
		public void AtualizeAluno(Aluno dadosAluno);
		public void DeleteAluno(int Id);


	}
}
