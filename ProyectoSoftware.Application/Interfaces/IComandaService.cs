using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IComandaService
    {
        Task<List<Comanda>> GetAll();
        Task<List<ComandaResponse>> GetByDate(string fecha);
        Task<ComandaGetResponse> GetById(Guid id);
        Task<ComandaResponse> Insert(List<int> mercaderias, int formaEntrega);
    }
}
