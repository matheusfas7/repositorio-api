using RepositorioApi.Application.DTOs;
using RepositorioApi.Domain.Entities;
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

        public async Task<List<RepositorioDTO>> BuscarRepositoriosComRelevancia(string termo)
        {
            var repositorios = await _gitHubService.BuscarRepositoriosComRelevancia(termo);

            var resultado = repositorios.Select(r => new RepositorioDTO
            {
                Nome = r.Nome,
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
