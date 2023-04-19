using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class MercaderiaService: IMercaderiaService
    {        
        private readonly IMercaderiaQuery _mercaderiaQuery;

        public MercaderiaService(IMercaderiaQuery mercaderiaQuery)
        {
            _mercaderiaQuery = mercaderiaQuery;
        }

        public async Task<List<Mercaderia>> GetAll()
        {
            var mercaderias = await _mercaderiaQuery.GetAll();

            return mercaderias;
        }

        public async Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId)
        {
            var mercaderias = await _mercaderiaQuery.GetAllByType(tipoMercaderiaId);

            return mercaderias;
        }
    }
}
