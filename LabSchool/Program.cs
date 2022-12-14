global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using LabSchool.Models;
global using LabSchool.Services.AlunoService;
global using LabSchool.Services.PedagogoService;
global using LabSchool.Services.ProfessorService;
global using LabSchool.Services.AtendimentoService;
using LabSchool.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAlunoService, AlunoService >();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IPedagogoService, PedagogoService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddDbContext<DataContext>();

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
