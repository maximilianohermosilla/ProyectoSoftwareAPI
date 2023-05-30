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
        private readonly IMercaderiaQuery _mercaderiaQuery;
        private readonly IComandaCommand _comandaCommand;
        private readonly IComandaMercaderiaCommand _comandaMercaderiaCommand;

        public ComandaService(IComandaQuery comandaQuery, IComandaCommand comandaCommand, IComandaMercaderiaCommand comandaMercaderiaCommand, IMercaderiaQuery mercaderiaQuery)
        {
            _comandaQuery = comandaQuery;
            _mercaderiaQuery = mercaderiaQuery;
            _comandaCommand = comandaCommand;
            _comandaMercaderiaCommand = comandaMercaderiaCommand;
        }

        public async Task<ResponseModel> GetByDate(string fecha)
        {            
            ResponseModel response = new ResponseModel();
            List<ComandaResponse> listaDTO = new List<ComandaResponse>();
            try
            {
                DateTime date = Convert.ToDateTime(fecha);

                DateTime hoy = DateTime.Now;

                if (date > hoy)
                {
                    response.statusCode = 400;
                    response.message = "La fecha ingresada debe ser inferior a la fecha actual";
                    response.response = null;
                    return response;
                }

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

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
                return response;

            }
            catch (FormatException ex)
            {
                throw new Exception("Formato de fecha incorrecta. Ingrese una fecha válida con formato DD/MM/AAAA o AAAA/MM/DD");
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;

                return response;
            }
        }

        public async Task<ResponseModel> Insert(List<int> mercaderias, int formaEntrega)
        {
            ResponseModel response = new ResponseModel();
            ComandaResponse comandaResponse = new ComandaResponse();
            Comanda comanda = new Comanda();
            try
            {
                comanda.FormaEntregaId = formaEntrega;
                comanda.Fecha = DateTime.Now;

                var responseInsert = await _comandaCommand.Insert(comanda);            
                
                if (responseInsert != null)
                {
                    //Insertar ComandasMercaderias con el Guid de la nueva Comanda
                    try
                    {
                        foreach (var item in mercaderias)
                        {
                            ComandaMercaderia comandaMercaderia = new ComandaMercaderia();
                            comandaMercaderia.MercaderiaId = item;
                            comandaMercaderia.ComandaId = responseInsert.ComandaId;

                            await _comandaMercaderiaCommand.Insert(comandaMercaderia);
                        }
                    }
                    catch (Exception e)
                    {
                        //await _comandaMercaderiaCommand.DeleteByComandaId(comanda.ComandaId);
                        await _comandaCommand.Delete(comanda);
                        response.statusCode = 400;
                        response.message = "Ocurrió un error con una de las mercaderias seleccionadas";
                        response.response = null;
                        return response;
                    }                    

                    var getComanda = await _comandaQuery.GetById(responseInsert.ComandaId);
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
                await _comandaCommand.Delete(comanda);
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Comanda insertada exitosamente";
            response.response = comandaResponse;
            return response;
        }

        public async Task<ResponseModel> GetById(Guid? id)
        {
            ResponseModel response = new ResponseModel();
            ComandaGetResponse comandaResponse = new ComandaGetResponse();
            int total = 0;

            try
            {
                var comanda = await _comandaQuery.GetById(id);

                if (comanda == null)
                {
                    response.statusCode = 404;
                    response.message = "No se encontró la comanda con id: " + id.ToString();
                    response.response = null;
                    return response;
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

                response.statusCode = 200;
                response.message = "Se encontró la comanda";
                response.response = comandaResponse;
                return response;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }
        }

        public async Task<bool> ValidateListMercaderias(List<int> mercaderias)
        {
            foreach (int id in mercaderias)
            {
                var response = await _mercaderiaQuery.GetById(id);
                if (response == null) 
                    return false;
            }

            return true;
        }
    }
}
