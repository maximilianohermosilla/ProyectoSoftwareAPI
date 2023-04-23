using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class ComandaQuery: IComandaQuery
    {
        private ProyectoSoftwareContext _context;

        public ComandaQuery(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<Comanda> GetById(Guid id)
        {
            var response = await _context.Comandas.Include(f => f.FormaEntregaNavigation).Include(e => e.ComandasMercaderia)
                                                   .ThenInclude(cm => cm.MercaderiaNavigation).ThenInclude(tm => tm.TipoMercaderiaNavigation)
                                                   .Where(e => e.ComandaId == id).FirstOrDefaultAsync();

            return response;
        }

        public async Task<List<Comanda>> GetByDate(DateTime fecha)
        {
            var lista = await _context.Comandas.Include(f => f.FormaEntregaNavigation).Include(e => e.ComandasMercaderia)
                                               .ThenInclude(cm => cm.MercaderiaNavigation).Where(e => e.Fecha == fecha).ToListAsync();
                        
            return lista;
        }
    }
}
