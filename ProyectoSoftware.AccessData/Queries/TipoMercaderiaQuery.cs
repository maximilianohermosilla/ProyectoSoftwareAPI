using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class TipoMercaderiaQuery: ITipoMercaderiaQuery

    {
        private ProyectoSoftwareContext context;
        public TipoMercaderiaQuery(ProyectoSoftwareContext _context)
        {
            context = _context;
        }      

        public async Task<List<TipoMercaderia>> GetAll()
        {
            var lista = await context.TiposMercaderia.ToListAsync();

            return lista;
        }

        public async Task<TipoMercaderia> GetById(int id)
        {
            var tipo = await context.TiposMercaderia.Where(m => m.TipoMercaderiaId == id).FirstOrDefaultAsync();

            return tipo;
        }
    }
}
