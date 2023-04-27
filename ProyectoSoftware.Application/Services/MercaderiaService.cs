using ProyectoSoftware.Application.DTO;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Interfaces.ICommands;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class MercaderiaService : IMercaderiaService
    {
        private readonly IMercaderiaQuery _query;
        private readonly ITipoMercaderiaQuery _tipoMercaderiaQuery;
        private readonly IMercaderiaCommand _command;
        private readonly IComandaMercaderiaQuery _comandaMercaderiaQuery;

        public MercaderiaService(IMercaderiaQuery query, IMercaderiaCommand command, IComandaMercaderiaQuery comandaMercaderiaQuery, ITipoMercaderiaQuery tipoMercaderiaQuery)
        {
            _query = query;
            _command = command;
            _comandaMercaderiaQuery = comandaMercaderiaQuery;
            _tipoMercaderiaQuery = tipoMercaderiaQuery;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();
            var mercaderias = await _query.GetAll();

            response.message = "Consulta realizada correctamente";
            response.statusCode = 200;
            response.response = mercaderias;

            return response;
        }

        public async Task<ResponseModel> GetAllByType(int tipoMercaderiaId)
        {
            ResponseModel response = new ResponseModel();
            var mercaderias = await _query.GetAllByType(tipoMercaderiaId);

            response.message = "Consulta realizada correctamente";
            response.statusCode = 200;
            response.response = mercaderias;

            return response;
        }

        public async Task<ResponseModel> GetById(int id)
        {
            ResponseModel response = new ResponseModel();
            MercaderiaResponse mercaderiaResponse = new MercaderiaResponse();

            var mercaderia = await _query.GetById(id);

            if (mercaderia != null)
            {
                mercaderiaResponse = new MercaderiaResponse
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    precio = mercaderia.Precio,
                    tipo = new TipoMercaderiaResponse { id = mercaderia.TipoMercaderiaNavigation.TipoMercaderiaId, descripcion = mercaderia.TipoMercaderiaNavigation.Descripcion },
                    imagen = mercaderia.Imagen,
                    preparacion = mercaderia.Preparacion,
                    ingredientes = mercaderia.Ingredientes
                };

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = mercaderiaResponse;

                return response;
            }

            response.message = "No se encontró la mercadería seleccionada";
            response.statusCode = 404;
            response.response = null;

            return response;
        }

        public async Task<ResponseModel> GetByName(string name)
        {
            ResponseModel response = new ResponseModel();
            MercaderiaGetResponse mercaderiaResponse = new MercaderiaGetResponse();

            var mercaderia = await _query.GetByName(name);
            if (mercaderia != null)
            {
                mercaderiaResponse = new MercaderiaGetResponse
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    precio = mercaderia.Precio,
                    tipo = new TipoMercaderiaResponse { id = mercaderia.TipoMercaderiaNavigation.TipoMercaderiaId, descripcion = mercaderia.TipoMercaderiaNavigation.Descripcion },
                    imagen = mercaderia.Imagen
                };

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = mercaderiaResponse;
            }

            response.message = "No se encontró la mercadería seleccionada";
            response.statusCode = 404;
            response.response = null;

            return response;
        }

        public async Task<ResponseModel> GetByTypeNameOrder(int? tipo, string? nombre, string orden)
        {
            ResponseModel response = new ResponseModel();
            List<MercaderiaGetResponse> listaDTO = new List<MercaderiaGetResponse>();

            try
            {
                orden = orden.ToUpper() == "DESC" ? "DESC" : "ASC";
                var lista = await _query.GetByTypeNameOrder(tipo, nombre, orden);

                if (!lista.Any())
                {
                    response.message = "No se encontró ninguna mercadería con los parámetros ingresados";
                    response.statusCode = 404;
                    response.response = lista;

                    return response;
                }

                foreach (var mercaderia in lista)
                {
                    if (mercaderia != null)
                    {
                        MercaderiaGetResponse mercaderiaResponse = new MercaderiaGetResponse
                        {
                            id = mercaderia.MercaderiaId,
                            nombre = mercaderia.Nombre,
                            precio = mercaderia.Precio,
                            tipo = new TipoMercaderiaResponse { id = mercaderia.TipoMercaderiaNavigation.TipoMercaderiaId, descripcion = mercaderia.TipoMercaderiaNavigation.Descripcion },
                            imagen = mercaderia.Imagen
                        };

                        listaDTO.Add(mercaderiaResponse);
                    }
                }

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.statusCode = 400;
                response.response = null;

                return response;
            }
        }

        public async Task<ResponseModel> Insert(MercaderiaRequest mercaderiaRequest)
        {
            ResponseModel response = new ResponseModel();
            MercaderiaResponse mercaderiaResponse = new MercaderiaResponse();

            try
            {
                if (mercaderiaRequest.precio <= 0)
                {
                    response.message = "El precio debe ser mayor a 0";
                    response.statusCode = 400;
                    response.response = null;

                    return response;
                }

                if (mercaderiaRequest.nombre == "")
                {
                    response.message = "Debe ingresar un nombre para la mercadería";
                    response.statusCode = 400;
                    response.response = null;

                    return response;
                }

                var tipoMercaderia = await _tipoMercaderiaQuery.GetById(mercaderiaRequest.tipo);

                if (tipoMercaderia == null)
                {
                    response.message = "No existe el tipo de mercaderia seleccionado";
                    response.statusCode = 409;
                    response.response = null;

                    return response;
                }

                var mercaderiaName = await _query.GetByName(mercaderiaRequest.nombre);

                if (mercaderiaName != null)
                {
                    response.message = "Ya existe una mercaderia con el nombre ingresado";
                    response.statusCode = 409;
                    response.response = null;

                    return response;
                }
                else
                {
                    Mercaderia mercaderia = new Mercaderia
                    {
                        Nombre = mercaderiaRequest.nombre,
                        TipoMercaderiaId = mercaderiaRequest.tipo,
                        Precio = Convert.ToInt32(mercaderiaRequest.precio),
                        Ingredientes = mercaderiaRequest.ingredientes,
                        Preparacion = mercaderiaRequest.preparacion,
                        Imagen = mercaderiaRequest.imagen
                    };

                    var responseCommand = await _command.Insert(mercaderia);

                    if (responseCommand == null)
                    {
                        response.message = "Ocurrió un error al insertar la comanda. Revise los parámetros";
                        response.statusCode = 409;
                        response.response = null;
                    }
                    else
                    {
                        mercaderiaResponse = new MercaderiaResponse
                        {
                            id = responseCommand.MercaderiaId,
                            nombre = responseCommand.Nombre,
                            tipo = new TipoMercaderiaResponse { id = responseCommand.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion },
                            precio = responseCommand.Precio,
                            ingredientes = responseCommand.Ingredientes,
                            imagen = responseCommand.Imagen,
                            preparacion = responseCommand.Preparacion
                        };
                    }

                    response.message = "Mercaderia ingresada correctamente";
                    response.statusCode = 200;
                    response.response = mercaderiaResponse;

                    return response;
                }

            }
            catch (Exception ex)
            {
                response.message = "Ocurrió un error al insertar la mercadería" ;
                response.statusCode = 400;
                response.response = null;

                return response;
            }
        }

        public async Task<ResponseModel> Update(MercaderiaRequest mercaderiaRequest, int id)
        {
            ResponseModel response = new ResponseModel();
            MercaderiaResponse mercaderiaResponse = new MercaderiaResponse();

            try
            {
                if (mercaderiaRequest.precio <= 0)
                {
                    response.message = "El precio debe ser mayor a 0";
                    response.statusCode = 400;
                    response.response = null;

                    return response;
                }

                var tipoMercaderia = await _tipoMercaderiaQuery.GetById(mercaderiaRequest.tipo);

                if (tipoMercaderia == null)
                {
                    response.message = "No existe el tipo de mercaderia seleccionado";
                    response.statusCode = 409;
                    response.response = null;

                    return response;
                }

                var mercaderiaUpdate = await _query.GetById(id); 

                if (mercaderiaUpdate != null)
                {   
                    //Si el nombre ingresado es distinto al nombre que tenía la mercaderia, valido que no se repita
                    if (mercaderiaRequest.nombre != mercaderiaUpdate.Nombre)
                    {
                        var mercaderiaName = await _query.GetByName(mercaderiaRequest.nombre);
                        if (mercaderiaName != null)
                        {
                            response.message = "Ya existe otra mercaderia con el nombre ingresado";
                            response.statusCode = 409;
                            response.response = null;

                            return response;
                        }
                    }

                    mercaderiaUpdate.Nombre = mercaderiaRequest.nombre;
                    mercaderiaUpdate.TipoMercaderiaId = mercaderiaRequest.tipo;
                    mercaderiaUpdate.Precio = Convert.ToInt32(mercaderiaRequest.precio);
                    mercaderiaUpdate.Ingredientes = mercaderiaRequest.ingredientes;
                    mercaderiaUpdate.Preparacion = mercaderiaRequest.preparacion;
                    mercaderiaUpdate.Imagen = mercaderiaRequest.imagen;

                    var responseUpdate = await _command.Update(mercaderiaUpdate);

                    if (responseUpdate != null)
                    {
                        mercaderiaResponse = new MercaderiaResponse
                        {
                            id = responseUpdate.MercaderiaId,
                            nombre = responseUpdate.Nombre,
                            tipo = new TipoMercaderiaResponse { id = tipoMercaderia.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion },
                            precio = responseUpdate.Precio,
                            ingredientes = responseUpdate.Ingredientes,
                            imagen = responseUpdate.Imagen,
                            preparacion = responseUpdate.Preparacion
                        };
                    }
                    else
                    {
                        response.message = "Ocurrió un error al actualizar la mercadería";
                        response.statusCode = 400;
                        response.response = null;

                        return response;
                    }

                    response.message = "Mercaderia actualizada correctamente";
                    response.statusCode = 200;
                    response.response = mercaderiaResponse;

                    return response;
                }
                else
                {
                    response.message = "No se ha encontrado la mercaderia seleccionada";
                    response.statusCode = 404;
                    response.response = null;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.statusCode = 400;
                response.response = null;

                return response;
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            MercaderiaResponse mercaderiaResponse = new MercaderiaResponse();

            try
            {
                var mercaderia = await _query.GetById(id);

                if (mercaderia == null)
                {
                    response.message = "No se ha encontrado la mercaderia seleccionada";
                    response.statusCode = 404;
                    response.response = null;

                    return response;
                }
                else
                {
                    bool existenComandas = await ExisteComandaMercaderia(id);

                    if (existenComandas)
                    {
                        response.message = "No se puede eliminar la mercadería porque existe en al menos una comanda";
                        response.statusCode = 409;
                        response.response = null;

                        return response;
                    }

                    mercaderiaResponse = new MercaderiaResponse
                    {
                        id = mercaderia.MercaderiaId,
                        nombre = mercaderia.Nombre,
                        precio = mercaderia.Precio,
                        tipo = new TipoMercaderiaResponse { id = mercaderia.TipoMercaderiaNavigation.TipoMercaderiaId, descripcion = mercaderia.TipoMercaderiaNavigation.Descripcion },
                        imagen = mercaderia.Imagen,
                        preparacion = mercaderia.Preparacion,
                        ingredientes = mercaderia.Ingredientes
                    };

                    await _command.Delete(mercaderia);

                    response.message = "Mercaderia eliminada correctamente";
                    response.statusCode = 200;
                    response.response = mercaderiaResponse;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.statusCode = 400;
                response.response = null;

                return response;
            }
        }

        public async Task<bool> ExisteComandaMercaderia(int id)
        {
            var comandasMercaderia = await _comandaMercaderiaQuery.GetByMercaderiaId(id);

            return comandasMercaderia.Any();
        }

    }
}
