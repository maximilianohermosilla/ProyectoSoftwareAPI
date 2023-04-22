using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.ICommands
{
    public interface IComandaMercaderiaCommand
    {
        Task<ComandaMercaderia> Insert(ComandaMercaderia comandaMercaderia);
    }
}
