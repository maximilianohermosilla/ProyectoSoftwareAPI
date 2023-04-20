namespace ProyectoSoftware.Domain.DTO
{
    public class ComandaRequest
    {
        public List<MercaderiaResponse>? mercaderias { get; set; }
        public int formaEntrega { get; set; }
    }
}
