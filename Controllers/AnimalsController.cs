using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepositorio _animalsRepositorio;

        public AnimalsController(IAnimalsRepositorio animalsRepositorio)
        {
            _animalsRepositorio = animalsRepositorio;
        }

        [HttpGet("GetAllAnimals")]
        public async Task<ActionResult<List<AnimalsModel>>> GetAllAnimals()
        {
            List<AnimalsModel> animals = await _animalsRepositorio.GetAll();
            return Ok(animals);
        }

        [HttpGet("GetAnimalId/{id}")]
        public async Task<ActionResult<AnimalsModel>> GetAnimalId(int id)
        {
            AnimalsModel animal = await _animalsRepositorio.GetById(id);
            return Ok(animal);
        }

        [HttpPost("CreateAnimal")]
        public async Task<ActionResult<AnimalsModel>> InsertAnimal([FromBody] AnimalsModel animalsModel)
        {
            AnimalsModel animal = await _animalsRepositorio.InsertAnimal(animalsModel);
            return Ok(animal);
        }

        [HttpPut("UpdateAnimal/{id:int}")]

        public async Task<ActionResult<AnimalsModel>> UpdateAnimal(int id, [FromBody] AnimalsModel animalsModel)
        {
            animalsModel.AnimalsId = id;
            AnimalsModel animal = await _animalsRepositorio.UpdateAnimal(animalsModel, id);
            return Ok(animal);
        }

        [HttpDelete("DeleteAnimal/{id:int}")]
        public async Task<ActionResult<AnimalsModel>> DeleteAnimal(int id)
        {
            bool deleted = await _animalsRepositorio.DeleteAnimal(id);
            return Ok(deleted);
        }

    }
}
