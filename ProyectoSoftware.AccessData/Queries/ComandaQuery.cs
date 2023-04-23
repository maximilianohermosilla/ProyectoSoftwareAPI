using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoSoftware.AccessData.Queries
{
    public class ComandaQuery: IComandaQuery
    {
        private ProyectoSoftwareContext _context;

        public ComandaQuery(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public async Task<List<Comanda>> GetAll()
        {
            
            var lista = await _context.Comandas.ToListAsync();
            List<ComandaDTO> listaDTO = new List<ComandaDTO>();

            foreach (var item in lista)
            {
                ComandaDTO comandaDTO = new ComandaDTO(item);
                comandaDTO.FormaEntrega = await _context.FormasEntrega.Where(f => f.FormaEntregaId == item.FormaEntregaId).Select(f => f.Descripcion).FirstOrDefaultAsync();

                comandaDTO.ComandaMercaderia = (from m in _context.Mercaderias
                                                join cm in _context.ComandasMercaderia
                                                on m.MercaderiaId equals cm.MercaderiaId
                                                join tm in _context.TiposMercaderia
                                                on m.TipoMercaderiaId equals tm.TipoMercaderiaId
                                                where cm.ComandaId == item.ComandaId
                                                select new MercaderiaDTO(m, tm.Descripcion)).ToList();

                listaDTO.Add(comandaDTO);
            }

            return lista;
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
