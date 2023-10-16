using ApI_task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApI_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TarefaModels>> BuscarTodasTarefas() 
        {
            return Ok();
        }
    }
}
