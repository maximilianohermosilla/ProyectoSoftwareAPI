using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.DTO
{
    public class ComandaDTO
    {
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public string? FormaEntrega { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<MercaderiaDTO>? ComandaMercaderia { get; set; }

        public ComandaDTO(Comanda comanda)
        {
            this.ComandaId = comanda.ComandaId;
            this.FormaEntregaId = comanda.FormaEntregaId;
            this.PrecioTotal = comanda.PrecioTotal;
            this.Fecha = comanda.Fecha;
        }
    }
}
