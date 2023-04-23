using ProyectoSoftware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftware.Application.Interfaces.IQueries
{
    public interface ITipoMercaderiaQuery
    {
        Task<List<TipoMercaderia>> GetAll();
        Task<TipoMercaderia> GetById(int id);
    }
}
