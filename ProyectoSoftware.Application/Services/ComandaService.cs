using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Interfaces.ICommands;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Application.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class ComandaService: IComandaService
    {        
        private readonly IComandaQuery _comandaQuery;
        private readonly IComandaCommand _comandaCommand;
        private readonly IComandaMercaderiaCommand _comandaMercaderiaCommand;

        public ComandaService(IComandaQuery comandaQuery, IComandaCommand comandaCommand, IComandaMercaderiaCommand comandaMercaderiaCommand)
        {
            _comandaQuery = comandaQuery;
            _comandaCommand = comandaCommand;
            _comandaMercaderiaCommand = comandaMercaderiaCommand;
        }

        public async Task<List<ComandaResponse>> GetByDate(string fecha)
        {            
            List<ComandaResponse> listaDTO = new List<ComandaResponse>();
            try
            {
                DateTime date = Convert.ToDateTime(fecha);
                int total = 0;

                var lista = await _comandaQuery.GetByDate(date);

                foreach (var item in lista)
                {
                    ComandaResponse comandaResponse = new ComandaResponse();
                    comandaResponse.id = item.ComandaId;
                    comandaResponse.mercaderias = new List<MercaderiaComandaResponse>();
                    comandaResponse.formaEntrega = new Application.DTO.FormaEntrega();
                    comandaResponse.formaEntrega.id = item.FormaEntregaNavigation.FormaEntregaId;
                    comandaResponse.formaEntrega.descripcion = item.FormaEntregaNavigation.Descripcion;
                    comandaResponse.fecha = item.Fecha;

                    foreach (var mercaderia in item.ComandasMercaderia)
                    {
                        MercaderiaComandaResponse mercResponse = new MercaderiaComandaResponse();
                        mercResponse.id = mercaderia.MercaderiaNavigation.MercaderiaId;
                        mercResponse.nombre = mercaderia.MercaderiaNavigation.Nombre;
                        mercResponse.precio = mercaderia.MercaderiaNavigation.Precio;
                        total += mercaderia.MercaderiaNavigation.Precio;

                        comandaResponse.mercaderias?.Add(mercResponse);
                    }

                    comandaResponse.total = total;

                    listaDTO.Add(comandaResponse);
                }
                
                return listaDTO;

            }
            catch (FormatException e)
            {
                throw new Exception("Formato de fecha incorrecta. Ingrese una fecha válida con formato DD/MM/AAAA o AAAA/MM/DD");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ComandaResponse> Insert(List<int> mercaderias, int formaEntrega)
        {
            ComandaResponse comandaResponse = new ComandaResponse();
            try
            {
                Comanda comanda = new Comanda();
                comanda.FormaEntregaId = formaEntrega;
                comanda.Fecha = DateTime.Now;

                var response = await _comandaCommand.Insert(comanda);

                //Insertar ComandasMercaderias con el Guid de la nueva Comanda
                foreach (var item in mercaderias)
                {
                    ComandaMercaderia comandaMercaderia = new ComandaMercaderia();
                    comandaMercaderia.MercaderiaId = item;
                    comandaMercaderia.ComandaId = response.ComandaId;

                    await _comandaMercaderiaCommand.Insert(comandaMercaderia);
                }                
                
                if (response != null)
                {                    
                    var getComanda = await _comandaQuery.GetById(response.ComandaId);
                    List<MercaderiaComandaResponse> mercaderiasResponse = new List<MercaderiaComandaResponse>();
                    int total = 0;

                    //Armo lista de mercaderias para el response y sumo el precio total
                    foreach (var item in getComanda.ComandasMercaderia)
                    {
                        mercaderiasResponse.Add(new MercaderiaComandaResponse { id = item.MercaderiaNavigation.MercaderiaId, nombre = item.MercaderiaNavigation.Nombre, precio = item.MercaderiaNavigation.Precio } );
                        total += item.MercaderiaNavigation.Precio;
                    }

                    comandaResponse = new ComandaResponse()
                    {
                        id = getComanda.ComandaId,
                        mercaderias = mercaderiasResponse,
                        formaEntrega = new Application.DTO.FormaEntrega { id = getComanda.FormaEntregaNavigation.FormaEntregaId, descripcion = getComanda.FormaEntregaNavigation.Descripcion },
                        total = Convert.ToInt64(total),
                        fecha = getComanda.Fecha
                    };

                    //Actualizo la comanda con el precio total de todas las mercaderias
                    comanda.PrecioTotal = total;
                    await _comandaCommand.Update(comanda);
                }
            }
            catch (Exception ex)
            {
                return null;
            }            

            return comandaResponse;
        }

        public async Task<ComandaGetResponse> GetById(Guid id)
        {
            ComandaGetResponse comandaResponse = new ComandaGetResponse();
            int total = 0;

            var comanda = await _comandaQuery.GetById(id);

            if (comanda == null)
            {
                return null;
            }
            else
            {
                comandaResponse.id = comanda.ComandaId;
                comandaResponse.mercaderias = new List<MercaderiaGetResponse>();
                comandaResponse.formaEntrega = new Application.DTO.FormaEntrega();
                comandaResponse.formaEntrega.id = comanda.FormaEntregaNavigation.FormaEntregaId;
                comandaResponse.formaEntrega.descripcion = comanda.FormaEntregaNavigation.Descripcion;
                comandaResponse.fecha = comanda.Fecha;

                foreach (var mercaderia in comanda.ComandasMercaderia)
                {
                    MercaderiaGetResponse mercResponse = new MercaderiaGetResponse();
                    mercResponse.id = mercaderia.MercaderiaNavigation.MercaderiaId;
                    mercResponse.nombre = mercaderia.MercaderiaNavigation.Nombre;
                    mercResponse.precio = mercaderia.MercaderiaNavigation.Precio;
                    mercResponse.imagen = mercaderia.MercaderiaNavigation.Imagen;
                    mercResponse.tipo = new TipoMercaderiaResponse
                    {
                        id = mercaderia.MercaderiaNavigation.TipoMercaderiaNavigation.TipoMercaderiaId,
                        descripcion = mercaderia.MercaderiaNavigation.TipoMercaderiaNavigation.Descripcion
                    };

                    total += mercaderia.MercaderiaNavigation.Precio;

                    comandaResponse.mercaderias?.Add(mercResponse);
                }

                comandaResponse.total = total;
            }           

            return comandaResponse;
        }
    }
}
