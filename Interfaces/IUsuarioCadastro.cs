using PrimeiraAPI.Models;

namespace PrimeiraAPI.Interfaces
{
	public interface IUsuarioCadastro
	{
		public Usuario CriarUsuario(Usuario usuario);
		public IList<Usuario> ListarUsuario();
		public Usuario? ListarUsuarioPorId(int id);
		//public void AtualizeUsuario(Usuario dadosUsuario);
		//public void DeleteUsuarioo(int Id);
	}
}
