using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        public Task<List<TipoMercaderia>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
