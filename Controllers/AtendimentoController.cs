using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AtendimentoController : ControllerBase
	{
		private readonly ILogger<AtendimentoController> _logger;

		private readonly IAlunoCadastro _alunoCadastro;

        public AtendimentoController(IAlunoCadastro alunoCadastro, ILogger<AtendimentoController> logger)
        {
            _alunoCadastro = alunoCadastro;
			_logger = logger;
        }

        [HttpGet("aluno")]
		public IActionResult GetAlunos()
		{
			_logger.LogInformation("Utilizou método de obter lista de alunos");
			return Ok(_alunoCadastro.ListarAlunos());
		}

		[HttpPost("insereAluno")]
		public IActionResult CriarAlunos(Aluno dadosAluno)
		{
			_alunoCadastro.CriarAluno(dadosAluno);
			_logger.LogInformation($"Cadastrou aluno. Código: {dadosAluno.Id}");
			return Ok(dadosAluno);
		}

		[HttpPut("atualizeAluno")]
		public IActionResult PutAtualizeAlunos(Aluno dadosAluno)
		{
			_alunoCadastro.AtualizeAluno(dadosAluno);
			_logger.LogInformation($"Atualizou aluno. Código: {dadosAluno.Id}");
			return Ok();
		}

		[HttpDelete("DeleteAluno")]
		public IActionResult DeleteAlunos(int Id)
		{
			_alunoCadastro.DeleteAluno(Id);
			_logger.LogInformation($"Excluiu aluno.");
			return Ok();
		}

	}
}
