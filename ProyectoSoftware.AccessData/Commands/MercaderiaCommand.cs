using ProyectoSoftware.Application.Interfaces.ICommands;
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
            _context.Add(mercaderia);
            await _context.SaveChangesAsync();    
            
            return mercaderia;            
        }


        public async Task Delete(Mercaderia mercaderia)
        {
            _context.Mercaderias.Remove(mercaderia);
            await _context.SaveChangesAsync();            
        }

        public async Task<Mercaderia> Update(Mercaderia mercaderia)
        {
            _context.Mercaderias.Update(mercaderia);
            await _context.SaveChangesAsync();

            return mercaderia;            
        }
    }
}
