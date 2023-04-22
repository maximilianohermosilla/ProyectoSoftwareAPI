using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.IQueries
{
    public interface IComandaQuery
    {
        Task<List<Comanda>> GetAll();
        Task<Comanda> GetById(Guid id);
        Task<List<Comanda>> GetByDate(DateTime fecha);
    }
}
