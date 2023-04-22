﻿using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.IQueries
{
    public interface IMercaderiaQuery
    {
        Task<List<Mercaderia>> GetAll();
        Task<List<Mercaderia>> GetAllByType(int tipoMercaderiaId);
        Task<List<Mercaderia>> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
    }
}
