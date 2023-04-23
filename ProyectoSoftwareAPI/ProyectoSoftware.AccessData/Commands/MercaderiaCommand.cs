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


        public async Task Delete(Mercaderia mercaderia)
        {
            try
            {
                _context.Mercaderias.Remove(mercaderia);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }
        public async Task<Mercaderia> Update(Mercaderia mercaderia)
        {
            try
            {
                _context.Mercaderias.Update(mercaderia);
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
