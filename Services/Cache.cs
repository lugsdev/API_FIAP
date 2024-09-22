﻿using Microsoft.Extensions.Caching.Memory;

namespace PrimeiraAPI.Services;

public class Cache
{
	private readonly IServiceProvider _serviceProvider;
	private const string VALOR_INSERIR_CACHE = "Variável com valor padrão";

	public Cache(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public string RetonarValorCache()
	{
		var retorno = string.Empty;

		var cache = _serviceProvider.GetRequiredService<IMemoryCache>();

		MemoryCacheEntryOptions options = new()
		{
			AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
		};

		cache.TryGetValue("ValorCache", out object? valor);

		if (valor == null)
		{
			cache.Set("ValorCache", $"Retornado do Cache {VALOR_INSERIR_CACHE}");
			return VALOR_INSERIR_CACHE;
		}

		return (string)valor;
	}
}
