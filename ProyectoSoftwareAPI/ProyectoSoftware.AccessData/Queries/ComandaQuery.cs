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

        public async Task<List<ComandaResponse>> GetByDate(DateTime fecha)
        {
            var lista = await _context.Comandas.Include(f => f.FormaEntregaNavigation).Include(e => e.ComandasMercaderia).ThenInclude(cm => cm.MercaderiaNavigation).Where(e => e.Fecha == fecha).ToListAsync();
            List<ComandaResponse> listaDTO = new List<ComandaResponse>();
            foreach (var item in lista)
            {
                ComandaResponse comandaResponse = new ComandaResponse();
                comandaResponse.id = item.ComandaId;
                comandaResponse.mercaderias = new List<MercaderiaComandaResponse>();
                comandaResponse.formaEntrega = new Domain.DTO.FormaEntrega();
                comandaResponse.formaEntrega.id = item.FormaEntregaNavigation.FormaEntregaId;
                comandaResponse.formaEntrega.descripcion = item.FormaEntregaNavigation.Descripcion;
                comandaResponse.total = item.PrecioTotal;
                comandaResponse.fecha = item.Fecha;

                foreach (var mercaderia in item.ComandasMercaderia)
                {
                    MercaderiaComandaResponse mercResponse = new MercaderiaComandaResponse();
                    mercResponse.id = mercaderia.MercaderiaNavigation.MercaderiaId;
                    mercResponse.nombre = mercaderia.MercaderiaNavigation.Nombre;
                    mercResponse.precio = mercaderia.MercaderiaNavigation.Precio;

                    comandaResponse.mercaderias?.Add(mercResponse);
                }

                listaDTO.Add(comandaResponse);
            }
            
            return listaDTO;
        }
    }
}
