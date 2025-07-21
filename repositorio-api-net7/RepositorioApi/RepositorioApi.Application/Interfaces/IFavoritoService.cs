using RepositorioApi.Application.DTOs;
using RepositorioApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioApi.Application.Interfaces
{
    public interface IFavoritoService
    {
        List<int> Listar();
        void Adicionar(int id);
        void Remover(int id);
    }
}
