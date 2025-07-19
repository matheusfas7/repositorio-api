using RepositorioApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioApi.Domain.Interfaces
{
    public interface IFavoritoService
    {
        Task AdicionarFavoritoAsync(Favorito favorito);
        Task<List<Favorito>> ListarFavoritosAsync();
    }
}
