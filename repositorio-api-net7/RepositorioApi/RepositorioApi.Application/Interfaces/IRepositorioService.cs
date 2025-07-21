using RepositorioApi.Application.DTOs;

namespace RepositorioApi.Application.Interfaces
{
    public interface IRepositorioService
    {
        Task<List<RepositorioDTO>> BuscarRepositoriosPorNome(string nome);
        Task<List<RepositorioDTO>> BuscarRepositoriosPorRelevancia(string nome);
    }
}
