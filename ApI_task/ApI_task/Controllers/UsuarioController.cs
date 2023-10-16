using ApI_task.Models;
using ApI_task.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApI_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;


        // injeção de dependencia...
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModels>>> BuscarTodosUsuario()
        {
            List<UsuarioModels> usuarios = await _usuarioRepositorio.BuscarTodosUsuario();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModels>> BuscarPorId(int id)
        {
           UsuarioModels usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<ActionResult<UsuarioModels>> Cadastrar([FromBody] UsuarioModels usuarioModel)
        {
           UsuarioModels usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<UsuarioModels>> Atualizar([FromBody] UsuarioModels usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModels usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }



        [HttpDelete]

        public async Task<ActionResult<UsuarioModels>> Deletar(int id)
        {
            bool deletado = await _usuarioRepositorio.Deletar(id);
            return Ok(deletado);
        }



    }
}
