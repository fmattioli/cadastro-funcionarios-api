using Gerenciamento.Funcionarios.CrossCutting.Model;
using Gerenciamento.Funcionarios.CrossCutting.Mongo;
using Gerenciamento.Funcionarios.CrossCutting.Repositorios;
using Gerenciamento.Funcionarios.CrossCutting.Services;
using Gerenciamento.Funcionarios.CrossCutting.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var applicationSettings = builder.Configuration.GetSection("Settings").Get<Settings>();

builder.Services.AddControllers();

builder.Services
    .AddRepositorios()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMongo(applicationSettings!.MongoSettings!)
    .AddValidators()
    .AddServicos()
    .AddControllers(options => options.Filters.Add(typeof(ActionValidationAttribute)))
    .AddNewtonsoftJson();

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
