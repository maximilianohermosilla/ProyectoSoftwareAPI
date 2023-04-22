using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.ICommands
{
    public interface IMercaderiaCommand
    {
        Task<Mercaderia> Insert(Mercaderia mercaderia);
    }
}
