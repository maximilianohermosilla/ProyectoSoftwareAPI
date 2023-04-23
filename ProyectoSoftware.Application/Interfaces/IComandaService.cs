using ProyectoSoftware.Application.DTO;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IComandaService
    {
        Task<List<ComandaResponse>> GetByDate(string fecha);
        Task<ComandaGetResponse> GetById(Guid id);
        Task<ComandaResponse> Insert(List<int> mercaderias, int formaEntrega);
    }
}
