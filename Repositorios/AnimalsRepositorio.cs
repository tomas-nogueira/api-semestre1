using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AnimalsRepositorio : IAnimalsRepositorio
    {
        private readonly Contexto _dbContext;

        public AnimalsRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AnimalsModel>> GetAll()
        {
            return await _dbContext.Animals.ToListAsync();
        }
        public async Task<List<AnimalsModel>> GetAllStatus1()
        {
            return await _dbContext.Animals
            .Where(a => a.AnimalStatus == 1)
            .ToListAsync();
        }

        public async Task<AnimalsModel> GetById(int id)
        {
            return await _dbContext.Animals.FirstOrDefaultAsync(x => x.AnimalsId == id);
        }

        public async Task<AnimalsModel> InsertAnimal(AnimalsModel animal)
        {
            await _dbContext.Animals.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<AnimalsModel> UpdateAnimal(AnimalsModel animal, int id)
        {
            AnimalsModel animals = await GetById(id);
            if (animals == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                animals.AnimalNome = animal.AnimalNome;
                animals.AnimalRaca = animal.AnimalRaca;
                animals.AnimalCor = animal.AnimalCor;
                animals.AnimalSexo = animal.AnimalSexo;
                animals.AnimalTipo = animal.AnimalTipo;
                animals.AnimalObservacao = animal.AnimalObservacao;
                animals.AnimalFoto = animal.AnimalFoto;
                animals.AnimalDtDesaparecimento = animal.AnimalDtDesaparecimento;
                animals.AnimalDtEncontro = animal.AnimalDtEncontro;
                animals.AnimalStatus = animal.AnimalStatus;
                animals.UsuarioId = animal.UsuarioId;
                _dbContext.Animals.Update(animals);
                await _dbContext.SaveChangesAsync();
            }
            return animal;

        }

        public async Task<bool> DeleteAnimal(int id)
        {
            AnimalsModel animals = await GetById(id);
            if (animals == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Animals.Remove(animals);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
