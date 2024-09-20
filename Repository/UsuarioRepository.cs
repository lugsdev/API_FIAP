using Dapper;
using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;
using System.Data;

namespace PrimeiraAPI.Repository
{
    public class UsuarioRepository : IUsuarioCadastro
    {
		private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection connection)
        {
			_dbConnection = connection;
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            var comandoSql = @"INSERT INTO USUARIO (ID, USERNAME, PASSWORD, PERMISSAOSISTEMA) 
                                             VALUES (@ID, @USERNAME, @PASSWORD, @PERMISSAOSISTEMA)";
            var novoUsuario = _dbConnection.Execute(comandoSql, usuario);
            usuario.Id = novoUsuario;

            //no caso abaixo a classe deve ser do tipo IEnumerable<Usuario>
			//return _dbConnection.Query<Usuario>(comandoSql, usuario);

			return usuario;
        }

        public IList<Usuario> ListarUsuario()
        {
            var comandoSql = @"SELECT * FROM USUARIO";
            return _dbConnection.Query<Usuario>(comandoSql).ToList();
        }

		public Usuario? ListarUsuarioPorId(int id)
		{
			var comandoSql = @"SELECT * FROM USUARIO WHERE ID = @ID";
			return _dbConnection.Query<Usuario>(comandoSql, new {ID = id}).SingleOrDefault();
		}

	}
}
