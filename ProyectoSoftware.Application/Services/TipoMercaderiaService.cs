using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class TipoMercaderiaService: ITipoMercaderiaService
    {
        private readonly ITipoMercaderiaQuery _tipoMercaderiaQuery;

        public TipoMercaderiaService(ITipoMercaderiaQuery tipoMercaderiaQuery)
        {
            _tipoMercaderiaQuery = tipoMercaderiaQuery;
        }

        public async Task<List<TipoMercaderia>> GetAll()
        {
            var tiposMercaderia = await _tipoMercaderiaQuery.GetAll();

            return tiposMercaderia;
        }
    }
}
