namespace ProyectoSoftware.Domain.Models
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; }
        public int MercaderiaId { get; set; }
        public Guid ComandaId { get; set; }

        public virtual Mercaderia MercaderiaNavigation { get; set; }
        public virtual Comanda ComandaNavigation { get; set; }
    }
}
