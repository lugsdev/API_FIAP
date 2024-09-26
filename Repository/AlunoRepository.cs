using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;
using System.Data;
using Dapper;

namespace PrimeiraAPI.Repository
{
	public class AlunoRepository : IAlunoCadastro
	{
		private readonly IDbConnection _dbConnection;

        public AlunoRepository(IDbConnection dbConnection)
        {
			_dbConnection = dbConnection;
		}

        public Aluno AtualizeAluno(Aluno dadosAluno)
		{
			var comandoSql = $@"UPDATE ALUNO SET NOME = @NOME, IDADE = @IDADE, ENDERECO = @ENDERECO 
																WHERE CODIGO = {dadosAluno.Codigo}";
			var novoAluno = _dbConnection.Query(comandoSql, dadosAluno);

			return dadosAluno;
		}

		public Aluno CriarAluno(Aluno dadosAluno)
		{
			dadosAluno.Id = Guid.NewGuid();

			var ultimoCodigo = @"SELECT TOP (1) CODIGO FROM ALUNO ORDER BY CODIGO DESC";
			var retornaUltimoCodigo = _dbConnection.Query<int>(ultimoCodigo).FirstOrDefault();

			dadosAluno.Codigo = retornaUltimoCodigo + 1;

			var comandoSql = $@"INSERT INTO ALUNO (ID, CODIGO, NOME, IDADE, ENDERECO) 
                                      VALUES (@ID, @CODIGO, @NOME, @IDADE, @ENDERECO)";
			var novoAluno = _dbConnection.Query(comandoSql, dadosAluno);

			return dadosAluno;
		}

		public void DeleteAluno(int codigo)
		{
			var comandoSql = $@"DELETE FROM ALUNO WHERE CODIGO = {codigo}";
			var removeAluno = _dbConnection.Query(comandoSql);

		}

		public IList<Aluno> ListarAlunos()
		{
			var comandoSql = @"SELECT * FROM ALUNO";
			return _dbConnection.Query<Aluno>(comandoSql).ToList();
		}
	}
}
