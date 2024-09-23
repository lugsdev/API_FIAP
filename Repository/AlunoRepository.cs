using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;
using System.Data;
using Dapper;

namespace PrimeiraAPI.Repository
{
	public class AlunoRepository : IAlunoCadastro
	{
		//public IList<Aluno> listaAluno { get; set; }

		private readonly IDbConnection _dbConnection;

        public AlunoRepository(IDbConnection dbConnection)
        {
            //listaAluno = new List<Aluno>();
			_dbConnection = dbConnection;
		}

        public void AtualizeAluno(Aluno dadosAluno)
		{
			//var _atualizeAluno = listaAluno.SingleOrDefault(x => x.Id == dadosAluno.Id);

			//_atualizeAluno!.Nome = dadosAluno.Nome;
			//_atualizeAluno.Idade = dadosAluno.Idade;
			//_atualizeAluno.Endereco = dadosAluno.Endereco;

			var comandoSql = $@"UPDATE ALUNO SET @NOME = {dadosAluno.Nome}, 
												 @IDADE = {dadosAluno.Idade}, 
												 @ENDERECO = {dadosAluno.Endereco}
											 WHERE @ID = {dadosAluno.Id}";
		}

		public Aluno CriarAluno(Aluno dadosAluno)
		{
			//dadosAluno.Id = listaAluno.Select(x => x.Id).Any() ? listaAluno.Select(x => x.Id).Max() + 1 : 1;
			//listaAluno.Add(dadosAluno);

			var comandoSql = @"INSERT INTO ALUNO (ID, NOME, IDADE, ENDERECO) 
                                             VALUES (@ID, @NOME, @IDADE, @ENDERECO)";
			var novoAluno = _dbConnection.Query(comandoSql, dadosAluno);
			dadosAluno.Id = new Guid();

			return dadosAluno;
		}

		public void DeleteAluno(int Id)
		{
			//var _deleteAluno = listaAluno.SingleOrDefault(x => x.Id == Id);

			//if (_deleteAluno != null)

			//listaAluno.Remove(_deleteAluno);

		}

		public IList<Aluno> ListarAlunos()
		{
			var comandoSql = @"SELECT * FROM ALUNO";
			return _dbConnection.Query<Aluno>(comandoSql).ToList();
		}
	}
}
