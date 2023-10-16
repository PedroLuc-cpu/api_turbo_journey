using ApI_task.Data;
using ApI_task.Models;
using ApI_task.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApI_task.Repositories
{
    public class UsuarioRepository : IUsuarioRepositorio
    {

        private readonly SistemaTarefasDBContext _dbcontext;
        public UsuarioRepository(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbcontext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModels> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModels>> BuscarTodosUsuario()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModels> Adicionar(UsuarioModels usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModels> Atualizar(UsuarioModels usuario, int id)
        {
            UsuarioModels usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();

            return usuarioPorId;
    
        }

        public async Task<bool> Deletar(int id)
        {
            UsuarioModels usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            _dbcontext.Usuarios.Remove(usuarioPorId);
            await _dbcontext.SaveChangesAsync();

            return true;

        }
    }
}
