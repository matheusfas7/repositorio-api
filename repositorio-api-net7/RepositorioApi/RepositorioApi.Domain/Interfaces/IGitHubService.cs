using RepositorioApi.Domain.Entities;

namespace RepositorioApi.Domain.Interfaces
{
    public interface IGitHubService
    {
        Task<List<Repositorio>> BuscarRepositoriosComRelevancia(string termo);
    }
}
