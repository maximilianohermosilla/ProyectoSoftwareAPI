using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.IQueries;
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

        public async Task<Mercaderia> GetById(int? id)
        {
            var mercaderia = await _context.Mercaderias.Include(m => m.TipoMercaderiaNavigation).Where(m => m.MercaderiaId == id).FirstOrDefaultAsync();

            return mercaderia;
        }

        public async Task<Mercaderia> GetByName(string nombre)
        {
            try
            {
                var mercaderia = await _context.Mercaderias.Where(m => m.Nombre == nombre).FirstOrDefaultAsync();
                return mercaderia;

            }
            catch (Exception ex)
            {
                return null;
            }

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
