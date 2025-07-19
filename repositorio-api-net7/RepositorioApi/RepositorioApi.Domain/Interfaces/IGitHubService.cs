using RepositorioApi.Domain.Entities;

namespace RepositorioApi.Domain.Interfaces
{
    public interface IGitHubService
    {
        Task<List<Repositorio>> BuscarRepositoriosPorNome(string nome);
    }
}
