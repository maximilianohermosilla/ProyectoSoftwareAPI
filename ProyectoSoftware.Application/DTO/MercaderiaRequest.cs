using System.ComponentModel.DataAnnotations;

namespace ProyectoSoftware.Application.DTO
{
    public class MercaderiaRequest
    {
        [MaxLength(50)]
        public string? nombre { get; set; }
        public int tipo { get; set; }
        public double precio { get; set; }
        [MaxLength(255)]
        public string? ingredientes { get; set; }
        [MaxLength(255)]
        public string? imagen { get; set; }
        [MaxLength(255)]
        public string? preparacion { get; set; }
    }
}
