namespace PrimeiraAPI.Interfaces
{
	public interface IBancoDados
	{
		int inserir<T>();
		object Retornar(int id);
	}
}
