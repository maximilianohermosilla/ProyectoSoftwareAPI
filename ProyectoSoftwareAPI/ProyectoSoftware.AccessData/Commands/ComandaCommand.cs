using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class ComandaCommand: IComandaCommand
    {
        private ProyectoSoftwareContext _context;

        public ComandaCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }
        public async Task<Comanda> Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            Comanda comanda = new Comanda();
            comanda.FormaEntregaId = formaEntrega.FormaEntregaId;
            comanda.PrecioTotal = precio;
            comanda.Fecha = DateTime.Now;

            _context.Add(comanda);
            await _context.SaveChangesAsync();

            foreach (var item in listaProductos)
            {
                ComandaMercaderia comandaMercaderia = new ComandaMercaderia();
                comandaMercaderia.MercaderiaId = item.MercaderiaId;
                comandaMercaderia.ComandaId = comanda.ComandaId;
                _context.Add(comandaMercaderia);
                _context.SaveChanges();
            }

            return comanda;
           
        }
    }
}
