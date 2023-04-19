namespace ProyectoSoftware.Domain.Models
{
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }

        public virtual TipoMercaderia TipoMercaderiaNavigation { get; set; }
        public IList<ComandaMercaderia> ComandasMercaderia { get; set; }
    }
}
