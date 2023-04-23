using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface IFormaEntregaQuery
    {
        Task<List<FormaEntrega>> GetAll();
    }
}

