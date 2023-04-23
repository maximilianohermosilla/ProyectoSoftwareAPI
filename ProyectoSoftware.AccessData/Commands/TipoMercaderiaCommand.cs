using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        private ProyectoSoftwareContext _context;

        public TipoMercaderiaCommand(ProyectoSoftwareContext context)
        {
            _context = context;
        }

        public Task<List<TipoMercaderia>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
