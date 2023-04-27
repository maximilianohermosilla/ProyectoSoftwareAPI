using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface ITipoMercaderiaQuery
    {
        Task<List<TipoMercaderia>> GetAll();
        Task<TipoMercaderia> GetById(int id);
    }
}
