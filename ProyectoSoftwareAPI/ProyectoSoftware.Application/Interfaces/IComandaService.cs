using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IComandaService
    {
        Task<List<Comanda>> GetAll();
        Task<Comanda> Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio);
    }
}
