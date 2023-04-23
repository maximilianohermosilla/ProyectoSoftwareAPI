﻿using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IMercaderiaService
    {
        Task<List<Mercaderia>> GetAll();
        Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId);
        Task<MercaderiaGetResponse> GetByName(string name);
        Task<MercaderiaResponse> GetById(int name);
        Task<MercaderiaResponse> Insert(MercaderiaRequest mercaderia);
        Task<IEnumerable<MercaderiaGetResponse>> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
    }
}
