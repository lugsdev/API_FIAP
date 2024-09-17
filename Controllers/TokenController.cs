using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		private readonly ILogger<TokenController> _logger;

		private readonly ITokenService _tokenService;

		public TokenController(ITokenService tokenService, ILogger<TokenController> logger)
		{
			_tokenService = tokenService;
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Post([FromBody] Usuario usuario)
		{
			var token = _tokenService.GetToken(usuario);

			if (!string.IsNullOrWhiteSpace(token))
			{
				_logger.LogInformation($"Usuário Autenticado: {usuario.Username} - Permissão: {usuario.PermissaoSistema}");
				return Ok(token);
				
			}
			return Unauthorized();
		}
	}
}
