using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.ICommands
{
    public interface IComandaMercaderiaCommand
    {
        Task<ComandaMercaderia> Insert(ComandaMercaderia comandaMercaderia);
        Task DeleteByComandaId(Guid comandaId);
    }
}
