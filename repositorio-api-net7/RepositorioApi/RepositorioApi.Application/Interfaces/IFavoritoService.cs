namespace RepositorioApi.Application.Interfaces
{
    public interface IFavoritoService
    {
        List<int> Listar();
        void Adicionar(int id);
        void Remover(int id);
    }
}
