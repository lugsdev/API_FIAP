using PrimeiraAPI.Models;

namespace PrimeiraAPI.Interfaces
{
	public interface IUsuarioCadastro
	{
		public IList<Usuario> ListarUsuario();
		public Usuario CriarUsuario(Usuario dadosAluno);
		//public void AtualizeAluno(Usuario dadosAluno);
		//public void DeleteAluno(int Id);
	}
}
