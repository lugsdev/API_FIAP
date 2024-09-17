using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeiraAPI.Services
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetToken(Usuario usuario)
		{
			var usuarioExiste = ListaUsuario.Usuarios.Any(x => x.Username.Equals(usuario.Username) && x.Password.Equals(usuario.Password));

			if (!usuarioExiste)
				return string.Empty;

			var tokenHandler = new JwtSecurityTokenHandler();

			var chaveCriptografada = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT")!);

			var tokenPropriedades = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, usuario.Username),
					new Claim(ClaimTypes.Role, (usuario.PermissaoSistema -1).ToString())
				}),

				Expires = DateTime.UtcNow.AddHours(2),

				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografada), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenPropriedades);
			return tokenHandler.WriteToken(token);
		}
	}
}
