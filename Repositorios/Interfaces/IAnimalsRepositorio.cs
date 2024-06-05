using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAnimalsRepositorio
    {
        Task<List<AnimalsModel>> GetAll();

        Task<AnimalsModel> GetById(int id);

        Task<AnimalsModel> InsertAnimal(AnimalsModel animal);

        Task<AnimalsModel> UpdateAnimal(AnimalsModel animal, int id);

        Task<bool> DeleteAnimal(int id);
    }
}
