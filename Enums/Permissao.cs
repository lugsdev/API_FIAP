namespace PrimeiraAPI.Enums
{
    [Flags]
	public enum Permissao
	{
	    Nenhuma = 0,        // Nenhuma permissão
        Ler = 1 << 0,       // Permissão para ler
        Escrever = 1 << 1,  // Permissão para escrever
        Executar = 1 << 2,  // Permissão para executar
        Apagar = 1 << 3,    // Permissão para apagar
        Administrar = Ler | Escrever | Executar | Apagar // Permissão total
	}
}
