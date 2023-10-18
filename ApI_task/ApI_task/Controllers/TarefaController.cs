using ApI_task.Models;
using ApI_task.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApI_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public ActionResult<List<TarefaModels>> BuscarTodasTarefas() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModels>> BuscarPorId(int id) {

            TarefaModels tarefa = await _tarefaRepositorio.BurcarPorId(id);
            return Ok(tarefa);

        }
    }
}
