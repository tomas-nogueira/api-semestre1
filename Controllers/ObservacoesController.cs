using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ObservacoesController : ControllerBase
        {
            private readonly IObservacoesRepositorio _observacoesRepositorio;

            public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
            {
                _observacoesRepositorio = observacoesRepositorio;
            }

            [HttpGet("GetAllObservacoes")]
            public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
            {
                List<ObservacoesModel> obs = await _observacoesRepositorio.GetAll();
                return Ok(obs);
            }

            [HttpGet("GetObservacoesId/{id}")]
            public async Task<ActionResult<ObservacoesModel>> GetObservacoesId(int id)
            {
                ObservacoesModel obs = await _observacoesRepositorio.GetById(id);
                return Ok(obs);
            }

            [HttpPost("CreateObservacoes")]
            public async Task<ActionResult<ObservacoesModel>> InsertUser([FromBody] ObservacoesModel observacoesModel)
            {
                ObservacoesModel obs = await _observacoesRepositorio.InsertObservacoes(observacoesModel);
                return Ok(obs);
            }

        }
    }
