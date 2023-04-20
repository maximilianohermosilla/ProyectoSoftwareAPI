﻿using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.DTO
{
    public class ComandaGetResponse
    {
        public Guid id { get; set; }
        public List<MercaderiaResponse>? mercaderias { get; set; }
        public FormaEntrega formaEntrega { get; set; }
        public double total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
