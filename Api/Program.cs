using Carter;
using Microsoft.EntityFrameworkCore;
using Application.Infrastructure;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Connection string de la base de datos
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Application).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddCarter();


builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Carter para Minimal APIs
app.MapCarter();

app.Run();

