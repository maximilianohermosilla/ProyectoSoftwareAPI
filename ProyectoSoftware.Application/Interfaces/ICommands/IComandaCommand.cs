using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces.ICommands
{
    public interface IComandaCommand
    {
        Task<Comanda> Insert(Comanda comanda);
        Task<Comanda> Update(Comanda comanda);
        Task Delete(Comanda comanda);
    }
}
