using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface ITipoMercaderiaService
    {
        Task<List<TipoMercaderia>> GetAll();
    }
}
