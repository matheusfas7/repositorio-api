using RepositorioApi.Application.DTOs;
using RepositorioApi.Application.Interfaces;
using RepositorioApi.Domain.Interfaces;

namespace RepositorioApi.Application.Services
{
    public class RepositorioService : IRepositorioService
    {
        private readonly IGitHubService _gitHubService;

        public RepositorioService(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<List<RepositorioDTO>> BuscarRepositoriosPorNome(string nome)
        {
            var repositorios = await _gitHubService.BuscarRepositoriosPorNome(nome);

            var resultado = repositorios.Select(r => new RepositorioDTO
            {
                Id = r.Id,
                Nome = r.Nome,
                Descricao = r.Descricao,
                Url = r.Url,
                Stars = r.Stars,
                Forks = r.Forks,
                Watchers = r.Watchers
            })
            .ToList();

            return resultado;
        }

        public async Task<List<RepositorioDTO>> BuscarRepositoriosPorRelevancia(string nome)
        {
            var repositorios = await _gitHubService.BuscarRepositoriosPorNome(nome);

            var resultado = repositorios.Select(r => new RepositorioDTO
            {
                Id = r.Id,
                Nome = r.Nome,
                Descricao = r.Descricao,
                Url = r.Url,
                Stars = r.Stars,
                Forks = r.Forks,
                Watchers = r.Watchers,
                Relevancia = r.CalcularRelevancia()
            })
            .OrderByDescending(r => r.Relevancia)
            .ToList();

            return resultado;
        }
    }
}
