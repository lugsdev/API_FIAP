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
            return usuario;
        }

        public IList<Usuario> ListarUsuario()
        {
            var comandoSql = @"SELECT * FROM USUARIO";
            return _dbConnection.Query<Usuario>(comandoSql).ToList();
        }

    }
}
