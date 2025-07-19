using RepositorioApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioApi.Application.Interfaces
{
    public interface IRepositorioService
    {
        Task<List<RepositorioDTO>> BuscarRepositoriosPorNome(string nome);
    }
}
