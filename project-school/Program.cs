using Domain.Interface;
using Domain.Services;
using Entities.Entities;
using Infra.Repository;
using System.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));
builder.Services.AddScoped<IGeneric<TableAluno>, AlunoRepository>();
builder.Services.AddScoped<IGeneric<TableTurma>, TurmaRepository>();
builder.Services.AddScoped<IGeneric<TableAluno_Turma>, Aluno_TurmaRepository>();
builder.Services.AddScoped<IRole<TableTurma>, TurmaRepository>();
builder.Services.AddScoped<IRole<TableAluno_Turma>, Aluno_TurmaRepository>();
builder.Services.AddScoped<Service>();


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
