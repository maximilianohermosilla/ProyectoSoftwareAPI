using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class FormaEntregaQuery: IFormaEntregaQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public FormaEntregaQuery(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<List<FormaEntrega>> GetAll()
        {           
            var lista = await _context.FormasEntrega.ToListAsync();

            return lista;        
        }
    }
}
