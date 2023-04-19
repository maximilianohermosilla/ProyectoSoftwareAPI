using ProyectoSoftware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftware.Application.Interfaces
{
    public interface ITipoMercaderiaService
    {
        Task<List<TipoMercaderia>> GetAll();
    }
}
