using ProyectoSoftware.Application.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface IMercaderiaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetAllByType(int tipoMercaderiaId);
        Task<ResponseModel> GetByName(string name);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(MercaderiaRequest mercaderia);
        Task<ResponseModel> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
        Task<ResponseModel> Update(MercaderiaRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
        Task<bool> ExisteComandaMercaderia(int id);
    }
}
