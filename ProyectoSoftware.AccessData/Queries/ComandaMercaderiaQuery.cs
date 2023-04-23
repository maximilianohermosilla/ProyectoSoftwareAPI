using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private ProyectoSoftwareContext _context;
        public ComandaMercaderiaQuery(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComandaMercaderia>> GetByMercaderiaId(int mercaderiaId)
        {
            var lista = await _context.ComandasMercaderia.Where(m => m.MercaderiaId == mercaderiaId).ToListAsync();

            return lista;
        }
    }
}
