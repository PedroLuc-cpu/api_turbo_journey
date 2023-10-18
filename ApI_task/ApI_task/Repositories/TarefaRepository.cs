using ApI_task.Data;
using ApI_task.Models;
using ApI_task.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApI_task.Repositories
{
    public class TarefaRepository : ITarefaRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepository(SistemaTarefasDBContext sistemaTarefasDBContext) { _dbContext = sistemaTarefasDBContext; }

        public async Task<TarefaModels> Adicionar(TarefaModels tarefa)
        {
            await _dbContext.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<List<TarefaModels>> BucarTodos()
        {
            return await _dbContext.Tarefa.ToListAsync();  
        }

        public async Task<TarefaModels> BurcarPorId(int id)
        {
            return await _dbContext.Tarefa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModels> Atualizar(TarefaModels tarefa, int id)
        {
            TarefaModels tarefaPorId = await BurcarPorId(id);

            if(tarefaPorId == null)
            {
              throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Description = tarefa.Description;
            tarefaPorId.Status = tarefa.Status;

            _dbContext.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Deleta(int id)
        {
            TarefaModels tarefaPorId = await BurcarPorId(id);

            if(tarefaPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
