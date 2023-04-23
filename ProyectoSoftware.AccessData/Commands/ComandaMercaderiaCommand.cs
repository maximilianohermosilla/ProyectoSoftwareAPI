using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.ICommands;
using ProyectoSoftware.Domain.Models;

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

        public async Task DeleteByComandaId(Guid comandaId)
        {
            try
            {
                var lista = await _context.ComandasMercaderia.Where(cm => cm.ComandaId == comandaId).ToListAsync();
                _context.ComandasMercaderia.RemoveRange(lista);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

    }
}
