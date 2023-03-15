using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YenorApi.Contextos;
using YenorApi.Repositorios.UsuarioRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AddJsonOptions esta op��o evita redund�ncia cliclca
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configura��es de conex�o com banco de dados
builder.Services.AddDbContext<YenorApiDataBaseContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("YenorApi"))
);

//adicionar os reposit�rios para que sejam chamados
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
