﻿using Microsoft.AspNetCore.Http;
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

		private readonly IUsuarioCadastro _usuarioCadastro;


		public TokenController(ITokenService tokenService, IUsuarioCadastro usuarioCadastro, ILogger<TokenController> logger)
		{
			_tokenService = tokenService;
			_usuarioCadastro = usuarioCadastro;
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

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_usuarioCadastro.ListarUsuario());
		}

		[HttpGet("GetById/{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_usuarioCadastro.ListarUsuarioPorId(id));
		}

		[HttpPut]
		public IActionResult Put(Usuario usuario)
		{
			return Ok(_usuarioCadastro.CriarUsuario(usuario));
		}
	}
}
