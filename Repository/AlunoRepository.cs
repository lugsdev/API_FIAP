using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;
using System.Data;
using Dapper;

namespace PrimeiraAPI.Repository
{
	public class AlunoRepository : IAlunoCadastro
	{
		public IList<Aluno> listaAluno { get; set; }

		private readonly IDbConnection _connection;

        public AlunoRepository(IDbConnection dbConnection)
        {
            listaAluno = new List<Aluno>();
			_connection = dbConnection;

		}

        public void AtualizeAluno(Aluno dadosAluno)
		{
			var _atualizeAluno = listaAluno.SingleOrDefault(x => x.Id == dadosAluno.Id);

			_atualizeAluno!.Nome = dadosAluno.Nome;
			_atualizeAluno.Idade = dadosAluno.Idade;
			_atualizeAluno.Endereco = dadosAluno.Endereco;
		}

		public Aluno CriarAluno(Aluno dadosAluno)
		{
			dadosAluno.Id = listaAluno.Select(x => x.Id).Any() ? listaAluno.Select(x => x.Id).Max() + 1 : 1;
			listaAluno.Add(dadosAluno);

			return dadosAluno;
		}

		public void DeleteAluno(int Id)
		{
			var _deleteAluno = listaAluno.SingleOrDefault(x => x.Id == Id);

			if (_deleteAluno != null)
			listaAluno.Remove(_deleteAluno);

		}

		public IEnumerable<Aluno> ListarAlunos()
		{
			return listaAluno;
		}
	}
}
