using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class ComandaService: IComandaService
    {        
        private readonly IComandaQuery _comandaQuery;
        private readonly IComandaCommand _comandaCommand;

        public ComandaService(IComandaQuery comandaQuery, IComandaCommand comandaCommand)
        {
            _comandaQuery = comandaQuery;
            _comandaCommand = comandaCommand;
        }

        public async Task<List<Comanda>> GetAll()
        {
            var comandas = await _comandaQuery.GetAll();

            return comandas;
        }

        public async Task<Comanda> Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            var response = await _comandaCommand.Insert(listaProductos, formaEntrega, precio);
            return response;
        }
    }
}
