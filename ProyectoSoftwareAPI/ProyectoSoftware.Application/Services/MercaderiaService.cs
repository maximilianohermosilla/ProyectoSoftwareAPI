﻿using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.IQueries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class MercaderiaService: IMercaderiaService
    {        
        private readonly IMercaderiaQuery _query;
        private readonly IMercaderiaCommand _command;

        public MercaderiaService(IMercaderiaQuery query, IMercaderiaCommand command)
        {
            _query = query;
            _command = command;
        }

        public async Task<List<Mercaderia>> GetAll()
        {
            var mercaderias = await _query.GetAll();

            return mercaderias;
        }

        public async Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId)
        {
            var mercaderias = await _query.GetAllByType(tipoMercaderiaId);

            return mercaderias;
        }

        public async Task<MercaderiaResponse> GetById(int id)
        {
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
            }
            return mercaderiaResponse;
        }

        public async Task<MercaderiaGetResponse> GetByName(string name)
        {
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
            }
                return mercaderiaResponse;
        }

        public async Task<IEnumerable<MercaderiaGetResponse>> GetByTypeNameOrder(int? tipo, string? nombre, string orden)
        {
            List<MercaderiaGetResponse> listaDTO = new List<MercaderiaGetResponse>();

            try
            { 
                orden = orden.ToUpper() == "DESC" ? "DESC" : "ASC";
                var lista = await _query.GetByTypeNameOrder(tipo, nombre, orden);

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
                
                return listaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MercaderiaResponse> Insert(MercaderiaRequest mercaderiaRequest)
        {
            MercaderiaResponse mercaderiaResponse = new MercaderiaResponse();

            try
            {
                var mercaderiaName = await _query.GetByName(mercaderiaRequest.nombre);

                if (mercaderiaName == null)
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

                    var response = await _command.Insert(mercaderia);

                    if (response != null)
                    {
                        mercaderiaResponse = new MercaderiaResponse
                        {
                            id = response.MercaderiaId,
                            nombre = response.Nombre,
                            tipo = new TipoMercaderiaResponse { id = response.TipoMercaderiaId, descripcion = "" },
                            precio = response.Precio,
                            ingredientes = response.Ingredientes,
                            imagen = response.Imagen,
                            preparacion = response.Preparacion
                        };
                    }
                    else
                    {
                        mercaderiaResponse = null;
                    }

                    return mercaderiaResponse;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
