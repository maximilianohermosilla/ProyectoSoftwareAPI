using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface IComandaQuery
    {
        Task<Comanda> GetById(Guid id);
        Task<List<Comanda>> GetByDate(DateTime fecha);
    }
}
