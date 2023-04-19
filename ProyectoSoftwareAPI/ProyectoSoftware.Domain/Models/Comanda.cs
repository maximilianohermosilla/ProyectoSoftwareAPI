namespace ProyectoSoftware.Domain.Models
{
    public class Comanda
    {
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public virtual FormaEntrega FormaEntregaNavigation { get; set; }
        public IList<ComandaMercaderia> ComandasMercaderia { get; set; }
    }
}
