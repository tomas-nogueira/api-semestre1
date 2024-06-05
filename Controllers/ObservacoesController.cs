using Api.Models;
using Api.Repositorios;
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
            public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoesModel)
            {
                ObservacoesModel obs = await _observacoesRepositorio.InsertObservacoes(observacoesModel);
                return Ok(obs);
            }

            [HttpPut("UpdateObservacoes/{id:int}")]

            public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacoesModel)
            {
                observacoesModel.ObservacoesId = id;
                ObservacoesModel obs = await _observacoesRepositorio.UpdateObservacoes(observacoesModel, id);
                return Ok(obs);
            }

            [HttpDelete("DeleteObservacoes/{id:int}")]
            public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
            {
                bool deleted = await _observacoesRepositorio.DeleteObservacoes(id);
                return Ok(deleted);
            }

    }

}
