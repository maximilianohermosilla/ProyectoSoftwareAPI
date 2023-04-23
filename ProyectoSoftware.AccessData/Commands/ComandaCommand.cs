using ProyectoSoftware.Application.Interfaces.ICommands;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class ComandaCommand : IComandaCommand
    {
        private ProyectoSoftwareContext _context;

        public ComandaCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }
        public async Task<Comanda> Insert(Comanda comanda)
        {
            _context.Add(comanda);
            await _context.SaveChangesAsync();

            return comanda;
        }

        public async Task<Comanda> Update(Comanda comanda)
        {
            _context.Update(comanda);
            await _context.SaveChangesAsync();

            return comanda;
        }
    }
}
