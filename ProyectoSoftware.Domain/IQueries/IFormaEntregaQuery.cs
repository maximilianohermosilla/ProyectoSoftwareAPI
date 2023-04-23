using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.IQueries
{
    public interface IFormaEntregaQuery
    {
        Task<List<FormaEntrega>> GetAll();
    }
}

