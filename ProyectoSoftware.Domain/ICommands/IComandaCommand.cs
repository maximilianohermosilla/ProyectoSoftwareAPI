using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.ICommands
{
    public interface IComandaCommand
    {
        Task<Comanda> Insert(Comanda comanda);
        Task<Comanda> Update(Comanda comanda);
    }
}
