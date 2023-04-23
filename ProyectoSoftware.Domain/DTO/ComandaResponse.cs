namespace ProyectoSoftware.Domain.DTO
{
    public class ComandaResponse
    {
        public Guid id { get; set; }
        public List<MercaderiaComandaResponse>? mercaderias { get; set; }
        public FormaEntrega formaEntrega { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
    }
}
