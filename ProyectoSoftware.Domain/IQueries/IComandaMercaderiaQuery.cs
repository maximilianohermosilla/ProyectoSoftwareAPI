using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.IQueries
{
    public interface IComandaMercaderiaQuery
    {
        Task<IEnumerable<ComandaMercaderia>> GetByMercaderiaId(int mercaderiaId);
    }
}
