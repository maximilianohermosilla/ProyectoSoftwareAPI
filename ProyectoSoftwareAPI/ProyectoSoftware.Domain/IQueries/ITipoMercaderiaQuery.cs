using ProyectoSoftware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftware.Domain.IQueries
{
    public interface ITipoMercaderiaQuery
    {
        Task<List<TipoMercaderia>> GetAll();
    }
}
