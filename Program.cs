using Microsoft.Data.SqlClient;
using PrimeiraAPI.Interfaces;
using PrimeiraAPI.Logging;
using PrimeiraAPI.Middlewares;
using PrimeiraAPI.Repository;
using PrimeiraAPI.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioCadastro, UsuarioRepository>();

var stringConexao = configuration.GetValue<string>("ConnectionStringSQL");
builder.Services.AddScoped<IDbConnection>((conexao) => new SqlConnection(stringConexao));


builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
	LogLevel = LogLevel.Information
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
//middleware com usuário para test
app.UseListaMemoriaMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
