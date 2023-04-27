using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.ICommands
{
    public interface ITipoMercaderiaCommand
    {
        Task<List<TipoMercaderia>> GetAll();
    }
}
