using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class FormaEntregaService: IFormaEntregaService
    {
        private readonly IFormaEntregaQuery _formaEntregaQuery;

        public FormaEntregaService(IFormaEntregaQuery formaEntregaQuery)
        {
            _formaEntregaQuery = formaEntregaQuery;
        }

        public async Task<List<FormaEntrega>> GetAll()
        {
            var formasEntrega = await _formaEntregaQuery.GetAll();

            return formasEntrega;
        }
    }
}
