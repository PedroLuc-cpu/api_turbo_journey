using ApI_task.Data.Map;
using ApI_task.Models;
using Microsoft.EntityFrameworkCore;

namespace ApI_task.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options) 
        {
            
        }

        public DbSet<UsuarioModels> Usuarios { get; set; }

        public DbSet<TarefaModels> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
