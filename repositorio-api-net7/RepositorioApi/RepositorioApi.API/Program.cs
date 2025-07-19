using Microsoft.Extensions.Caching.Distributed;
using RepositorioApi.Application.Interfaces;
using RepositorioApi.Application.Services;
using RepositorioApi.Domain.Interfaces;
using RepositorioApi.Domain.Repositories;
using RepositorioApi.Infrastructure.ExternalServices;
using StackExchange.Redis;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositorioService, RepositorioService>();
builder.Services.AddHttpClient<IGitHubService, GitHubService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/repositorios", async (string nome, IRepositorioService service) =>
{
    var result = await service.BuscarRepositoriosComRelevancia(nome);
    return Results.Ok(result);
});

# region [program cs]
//app.MapGet("/repos/me", async (IRepositorioService service) =>
//{
//    var result = await service.ListarRepositoriosDoUsuario("octocat");
//    return Results.Ok(result);
//});

//app.MapPost("/favoritos", async (Favorito favorito, IRepositorioService service) =>
//{
//    await service.AdicionarFavorito(favorito);
//    return Results.Ok();
//});

//app.MapGet("/favoritos", async (IRepositorioService service) =>
//{
//    var result = await service.ListarFavoritos();
//    return Results.Ok(result);
//});

#endregion

# region [teste]
app.MapPost("/favoritos", async (Favorito favorito, IDistributedCache redis) =>
{
    await redis.SetStringAsync(favorito.Url, JsonSerializer.Serialize(favorito));
    return Results.Ok();
});

app.MapGet("/favoritos/{url}", async (string url, IDistributedCache redis) =>
{
    var data = await redis.GetStringAsync(url);

    if (string.IsNullOrEmpty(data)) return null;

    var favorito = JsonSerializer.Deserialize<Favorito>(data, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = false
    });

    return favorito;
});

# endregion 

app.Run();

record Favorito(string Nome, string Url);

//interface IRepositorioService
//{
//    Task<List<object>> ListarRepositoriosDoUsuario(string usuario);
//    Task AdicionarFavorito(Favorito favorito);
//    Task<List<Favorito>> ListarFavoritos();
//}

//class RepositorioService : IRepositorioService
//{
//    private readonly HttpClient _http;

//    public RepositorioService()
//    {
//        _http = new HttpClient();
//        _http.DefaultRequestHeaders.UserAgent.ParseAdd("request");
//    }

//    public async Task<List<object>> ListarRepositoriosDoUsuario(string usuario)
//    {
//        // TODO
//        // Seu código aqui
//        throw new NotImplementedException("Implementar lógica para listar repositórios.");
//    }

//    public async Task AdicionarFavorito(Favorito favorito)
//    {
//        // TODO
//        // Seu código aqui
//    }

//    public async Task<List<Favorito>> ListarFavoritos()
//    {
//        // TODO
//        // Seu código aqui
//        throw new NotImplementedException("Implementar lógica para listar favoritos.");
//    }
//}