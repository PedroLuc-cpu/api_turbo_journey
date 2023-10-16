using ApI_task.Models;

namespace ApI_task.Repositories.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModels>> BuscarTodosUsuario();

        Task<UsuarioModels> BuscarPorId(int id);

        Task<UsuarioModels> Adicionar(UsuarioModels usuario);

        Task<UsuarioModels> Atualizar(UsuarioModels usuario, int id);

        Task<bool> Deletar (int id);
    }
}
