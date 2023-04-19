using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Domain.DTO
{
    public class MercaderiaDTO
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public string? TipoMercaderia { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }

        public MercaderiaDTO(Mercaderia mercaderia)
        {
            this.MercaderiaId = mercaderia.MercaderiaId;
            this.Nombre = mercaderia.Nombre;
            this.TipoMercaderiaId = mercaderia.TipoMercaderiaId;
            this.Precio = mercaderia.Precio;
            this.Ingredientes = mercaderia.Ingredientes;
            this.Preparacion = mercaderia.Preparacion;
            this.Imagen = mercaderia.Imagen;
        }

        public MercaderiaDTO(Mercaderia mercaderia, string tipoMercaderia)
        {
            this.MercaderiaId = mercaderia.MercaderiaId;
            this.Nombre = mercaderia.Nombre;
            this.TipoMercaderiaId = mercaderia.TipoMercaderiaId;
            this.Precio = mercaderia.Precio;
            this.Ingredientes = mercaderia.Ingredientes;
            this.Preparacion = mercaderia.Preparacion;
            this.Imagen = mercaderia.Imagen;
            this.TipoMercaderia = tipoMercaderia;
        }

    }
}
