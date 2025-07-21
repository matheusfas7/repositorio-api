using RepositorioApi.Domain.Entities;
using RepositorioApi.Domain.Interfaces;
using System.Text.Json;

namespace RepositorioApi.Infrastructure.ExternalServices
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("request");
        }

        public async Task<List<Repositorio>> BuscarRepositoriosPorNome(string nome)
        {
            var url = $"https://api.github.com/search/repositories?q={nome}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var document = JsonDocument.Parse(json);
            var items = document.RootElement.GetProperty("items");

            var repositorios = new List<Repositorio>();

            foreach (var item in items.EnumerateArray())
            {
                repositorios.Add(new Repositorio
                {
                    Id = item.GetProperty("id").GetInt32(),
                    Nome = item.GetProperty("name").GetString(),
                    Descricao = item.GetProperty("description").GetString(),
                    Url = item.GetProperty("html_url").GetString(),
                    Stars = item.GetProperty("stargazers_count").GetInt32(),
                    Forks = item.GetProperty("forks_count").GetInt32(),
                    Watchers = item.GetProperty("watchers_count").GetInt32()
                });
            }

            return repositorios;
        }
    }
}
