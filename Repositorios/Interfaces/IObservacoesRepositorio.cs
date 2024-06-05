using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObservacoesRepositorio
    {
        Task<List<ObservacoesModel>> GetAll();

        Task<ObservacoesModel> GetById(int id);

        Task<ObservacoesModel> InsertObservacoes(ObservacoesModel obs);

        Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel obs, int id);

        Task<bool> DeleteObservacoes(int id);
    }
}
