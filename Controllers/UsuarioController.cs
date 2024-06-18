using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("GetAllUsuario")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUsuario")]
        public async Task<ActionResult<UsuarioModel>> InsertUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.InsertUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUsuario(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuarioModel obs = await _usuarioRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(obs);
        }

        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuarioRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }

        [HttpPost("LoginUsuario/")]
        public async Task<ActionResult<UsuarioModel>> LoginUsuario([FromBody] LoginModel usuario) // esse usuario é que o usuario digitou
        {
            UsuarioModel usuariomail = await _usuarioRepositorio.GetByEmail(usuario.UsuarioEmail); // esse usuário é o do banco

            if (usuariomail == null) // Verifica se o usuário foi encontrado no banco
            {
                return BadRequest(false);
            }

            if (usuario.UsuarioEmail == usuariomail.UsuarioEmail && usuario.UsuarioSenha == usuariomail.UsuarioSenha) // comparacao
            {
                return Ok(usuariomail);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
