using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface IMercaderiaQuery
    {
        Task<List<Mercaderia>> GetAll();
        Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId);
        Task<Mercaderia> GetByName(string nombre);
        Task<Mercaderia> GetById(int id);
        Task<List<Mercaderia>> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
    }
}
