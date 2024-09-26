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

        public Aluno AtualizeAluno(Aluno dadosAluno)
		{
			//var _atualizeAluno = listaAluno.SingleOrDefault(x => x.Id == dadosAluno.Id);

			//_atualizeAluno!.Nome = dadosAluno.Nome;
			//_atualizeAluno.Idade = dadosAluno.Idade;
			//_atualizeAluno.Endereco = dadosAluno.Endereco;

			//if(dadosAluno.Id is null)

			var comandoSql = $@"UPDATE ALUNO SET NOME = {dadosAluno.Nome}, 
												 CODIGO = {dadosAluno.Codigo},
												 IDADE = {dadosAluno.Idade}, 
												 ENDERECO = {dadosAluno.Endereco}
									       WHERE ID = {dadosAluno.Id}";

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
