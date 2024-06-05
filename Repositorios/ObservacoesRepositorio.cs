using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<ObservacoesModel> InsertObservacoes(ObservacoesModel obs)
        {
            await _dbContext.Observacoes.AddAsync(obs);
            await _dbContext.SaveChangesAsync();
            return obs;
        }

        public async Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel obs, int id)
        {
            ObservacoesModel obsU = await GetById(id);
            if (obsU == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                obsU.ObservacoesDescricao = obs.ObservacoesDescricao;
                obsU.ObservacoesLocal = obs.ObservacoesLocal;
                obsU.ObservacoesData = obs.ObservacoesData;
                obsU.AnimalsId = obs.AnimalsId;
                obsU.UsuarioId = obs.UsuarioId;
                _dbContext.Observacoes.Update(obsU);
                await _dbContext.SaveChangesAsync();
            }
            return obs;

        }

        public async Task<bool> DeleteObservacoes(int id)
        {
            ObservacoesModel obsU = await GetById(id);
            if (obsU == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(obsU);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
