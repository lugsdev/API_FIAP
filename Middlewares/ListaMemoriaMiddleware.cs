using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PrimeiraAPI.Models;
using System.Threading.Tasks;

namespace PrimeiraAPI.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ListaMemoriaMiddleware
	{
		private readonly RequestDelegate _next;

		public ListaMemoriaMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			ListaUsuario.Usuarios = [];
			ListaUsuario.Usuarios.Add(new Usuario{Id = 1, Username = "Admin", Password = "1234"});

			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ListaMemoriaMiddlewareExtensions
	{
		public static IApplicationBuilder UseListaMemoriaMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ListaMemoriaMiddleware>();
		}
	}
}
