using ApI_task.Models;

namespace ApI_task.Repositories.Interface
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModels>> BucarTodos();

        Task<TarefaModels> BurcarPorId(int id);

        Task<TarefaModels> Adicionar(TarefaModels tarefa);

        Task<TarefaModels> Atualizar(TarefaModels tarefa, int id);

        Task<bool> Deleta(int  id);
    }
}
