using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IComandaService
    {
        Task<List<Comanda>> GetAll();
        Task<List<ComandaResponse>> GetByDate(string fecha);
        Task<Comanda> Insert(List<Mercaderia> listaProductos, int formaEntrega);
    }
}
