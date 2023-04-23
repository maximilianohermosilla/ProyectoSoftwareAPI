using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface IComandaMercaderiaQuery
    {
        Task<IEnumerable<ComandaMercaderia>> GetByMercaderiaId(int mercaderiaId);
    }
}
