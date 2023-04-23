using ProyectoSoftware.Application.DTO;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IComandaService
    {
        Task<ResponseModel> GetByDate(string fecha);
        Task<ResponseModel> GetById(Guid id);
        Task<ResponseModel> Insert(List<int> mercaderias, int formaEntrega);
    }
}
