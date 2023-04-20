using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftware.Domain.ICommands
{
    public interface IComandaCommand
    {
        Task<Comanda> Insert(List<Mercaderia> listaProductos, int formaEntrega);
    }
}
