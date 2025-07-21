using Microsoft.Extensions.Caching.Distributed;
using RepositorioApi.Application.Interfaces;
using RepositorioApi.Application.Services;
using RepositorioApi.Domain.Interfaces;
using RepositorioApi.Domain.Repositories;
using RepositorioApi.Infrastructure.ExternalServices;
using StackExchange.Redis;
using System.Text.Json;
using RepositorioApi.API.Configurations;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/repositoriosPorNome", async (string nome, IRepositorioService service) =>
{
    var result = await service.BuscarRepositoriosPorNome(nome);
    return Results.Ok(result);
});

app.MapGet("/favoritos", (IFavoritoService favoritoService) =>
{
    var ids = favoritoService.Listar();
    return Results.Ok(ids);
});

app.MapPost("/favoritos", (Favorito favorito, IFavoritoService favoritoService) =>
{
    favoritoService.Adicionar(favorito.Id);
    return Results.Ok();
});

app.MapDelete("/favoritos/{id:int}", (int id, IFavoritoService favoritoService) =>
{
    favoritoService.Remover(id);
    return Results.Ok();
});

app.Run();

record Favorito(int Id);