using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.ICommands
{
    public interface IMercaderiaCommand
    {
        Task<Mercaderia> Insert(Mercaderia mercaderia);
        Task<Mercaderia> Update(Mercaderia mercaderia);
        Task Delete(Mercaderia mercaderia);
    }
}
