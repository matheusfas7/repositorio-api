using RepositorioApi.Application.DTOs;
using RepositorioApi.Domain.Entities;
using RepositorioApi.Application.Interfaces;
using RepositorioApi.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace RepositorioApi.Application.Services
{
    public class FavoritoService : IFavoritoService
    {
        private const string FAVORITOS_INDEX_KEY = "favoritos_index";
        private readonly IMemoryCache _cache;

        public FavoritoService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<int> Listar()
        {
            if (!_cache.TryGetValue(FAVORITOS_INDEX_KEY, out List<int> index))
            {
                return new List<int>();
            }

            return index;
        }

        public void Adicionar(int id)
        {
            // Recupera a lista de IDs favoritos, ou inicializa vazia
            if (!_cache.TryGetValue(FAVORITOS_INDEX_KEY, out List<int> index))
            {
                index = new List<int>();
            }

            // Adiciona ao índice, se ainda não estiver presente
            if (!index.Contains(id))
            {
                index.Add(id);
                _cache.Set(FAVORITOS_INDEX_KEY, index);
            }
        }

        public void Remover(int id)
        {
            _cache.Remove(id);

            if (_cache.TryGetValue(FAVORITOS_INDEX_KEY, out List<int> index))
            {
                index.Remove(id);
                _cache.Set(FAVORITOS_INDEX_KEY, index);
            }
        }
    }
}
