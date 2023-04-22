using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class MercaderiaQuery: IMercaderiaQuery
    {
        private ProyectoSoftwareContext _context;
        public MercaderiaQuery(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<List<Mercaderia>> GetAll()
        {
            var lista = await _context.Mercaderias.ToListAsync();

            return lista;
        }

        public async Task<List<Mercaderia>> GetAllByType(int tipoMercaderia)
        {
            var lista = await _context.Mercaderias.Where(m => m.TipoMercaderiaId == tipoMercaderia).ToListAsync();

            return lista;
        }

        public async Task<List<Mercaderia>> GetByTypeNameOrder(int? tipo, string? nombre, string orden)
        {
            var lista = new List<Mercaderia>();

            if (orden == "DESC")
            {
                lista = await _context.Mercaderias.Include(m => m.TipoMercaderiaNavigation)
                                                    .Where(m => (tipo == null || m.TipoMercaderiaId == tipo)
                                                          && (nombre == null || m.Nombre.Contains(nombre)))
                                                    .OrderByDescending(m => m.Precio).ToListAsync();
            }
            else
            {
                lista = await _context.Mercaderias.Include(m => m.TipoMercaderiaNavigation)
                                                    .Where(m => (tipo == null || m.TipoMercaderiaId == tipo)
                                                          && (nombre == null || m.Nombre.Contains(nombre)))
                                                    .OrderBy(m => m.Precio).ToListAsync();
            }            

            return lista;
        }
    }
}
