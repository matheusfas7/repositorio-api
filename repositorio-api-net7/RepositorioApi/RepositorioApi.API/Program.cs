using RepositorioApi.Application.Interfaces;
using RepositorioApi.API.Configurations;
using RepositorioApi.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.MapGet("/repositorios", async (string nome, IRepositorioService service) =>
{
    if (string.IsNullOrWhiteSpace(nome))
        return Results.BadRequest("O nome do repositório deve ser informado.");

    var result = await service.BuscarRepositoriosPorNome(nome);
    return Results.Ok(result);
});

app.MapGet("/repositoriosPorRelevancia", async (string nome, IRepositorioService service) =>
{
    if (string.IsNullOrWhiteSpace(nome))
        return Results.BadRequest("O nome do repositório deve ser informado.");

    var result = await service.BuscarRepositoriosPorRelevancia(nome);
    return Results.Ok(result);
});

app.MapGet("/favoritos", (IFavoritoService favoritoService) =>
{
    var ids = favoritoService.Listar();

    if (ids == null || !ids.Any())
        return Results.NoContent();

    return Results.Ok(ids);
});

app.MapPost("/favoritos", (FavoritoDTO favorito, IFavoritoService favoritoService) =>
{
    if (favorito == null || favorito.Id <= 0)
        return Results.BadRequest("ID do repositório inválido.");

    favoritoService.Adicionar(favorito.Id);
    return Results.Ok();
});

app.MapDelete("/favoritos/{id:int}", (int id, IFavoritoService favoritoService) =>
{
    if (id <= 0)
        return Results.BadRequest("ID do repositório inválido.");

    favoritoService.Remover(id);
    return Results.Ok();
});

app.Run();