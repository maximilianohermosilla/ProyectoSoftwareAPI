using Azure.Core;
using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class MercaderiaCommand : IMercaderiaCommand
    {
        private ProyectoSoftwareContext _context;

        public MercaderiaCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<Mercaderia> Insert(Mercaderia mercaderia)
        {
            try
            {
                _context.Add(mercaderia);
                await _context.SaveChangesAsync();                
                return mercaderia;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                return null;
            }
        }
    }
}
