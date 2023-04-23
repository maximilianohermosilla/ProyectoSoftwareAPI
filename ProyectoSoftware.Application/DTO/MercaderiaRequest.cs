﻿namespace ProyectoSoftware.Application.DTO
{
    public class MercaderiaRequest
    {
        public string? nombre { get; set; }
        public int tipo { get; set; }
        public double precio { get; set; }
        public string? ingredientes { get; set; }
        public string? imagen { get; set; }
        public string? preparacion { get; set; }
    }
}
