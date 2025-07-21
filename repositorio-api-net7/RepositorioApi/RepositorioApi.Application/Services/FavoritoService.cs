using RepositorioApi.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace RepositorioApi.Application.Services
{
    public class FavoritoService : IFavoritoService
    {
        // Chave utilizada para armazenar os IDs dos favoritos no cache
        private const string FAVORITOS_INDEX_KEY = "favoritos_index";
        private readonly IMemoryCache _cache;

        public FavoritoService(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Retorna a lista de IDs favoritos armazenada no cache.
        /// Se não houver nenhum item, retorna uma lista vazia.
        /// </summary>
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
            // Tenta recuperar a lista de favoritos existentes, ou cria uma nova se não existir
            if (!_cache.TryGetValue(FAVORITOS_INDEX_KEY, out List<int> index))
            {
                index = new List<int>();
            }

            // Adiciona o ID apenas se o mesmo ainda não se encontrar na lista
            if (!index.Contains(id))
            {
                index.Add(id);
                _cache.Set(FAVORITOS_INDEX_KEY, index);
            }
        }

        /// <summary>
        /// Remove um ID da lista de favoritos no cache.
        /// </summary>
        public void Remover(int id)
        {
            // Remove o item diretamente do cache (caso tenha sido armazenado individualmente)
            _cache.Remove(id);

            // Remove o ID da lista de favoritos (se existir) e atualiza o cache
            if (_cache.TryGetValue(FAVORITOS_INDEX_KEY, out List<int> index))
            {
                index.Remove(id);
                _cache.Set(FAVORITOS_INDEX_KEY, index);
            }
        }
    }
}
