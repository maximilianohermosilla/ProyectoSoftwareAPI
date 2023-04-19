using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IMercaderiaService
    {
        Task<List<Mercaderia>> GetAll();
        Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId);
    }
}
