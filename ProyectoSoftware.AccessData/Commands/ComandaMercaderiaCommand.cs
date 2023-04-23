using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProyectoSoftware.AccessData.Commands
{
    public class ComandaMercaderiaCommand : IComandaMercaderiaCommand
    {
        private ProyectoSoftwareContext _context;

        public ComandaMercaderiaCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<ComandaMercaderia> Insert(ComandaMercaderia comandaMercaderia)
        {
            _context.Add(comandaMercaderia);
            await _context.SaveChangesAsync();

            return comandaMercaderia;
        }
    }
}
