namespace ProyectoSoftware.Application.DTO
{
    public class ComandaGetResponse
    {
        public Guid id { get; set; }
        public List<MercaderiaGetResponse>? mercaderias { get; set; }
        public FormaEntrega formaEntrega { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
    }
}
