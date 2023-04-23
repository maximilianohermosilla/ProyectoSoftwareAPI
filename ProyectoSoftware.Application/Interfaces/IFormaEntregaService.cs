
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IFormaEntregaService
    {
        Task<List<FormaEntrega>> GetAll();
    }
}
