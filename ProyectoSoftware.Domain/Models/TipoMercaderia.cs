namespace ProyectoSoftware.Domain.Models
{
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }
        public string Descripcion { get; set; }

        public IList<Mercaderia>? Mercaderias { get; set; }
    }
}
