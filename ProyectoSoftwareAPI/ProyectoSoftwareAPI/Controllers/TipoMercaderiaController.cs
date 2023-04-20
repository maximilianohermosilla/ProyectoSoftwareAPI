using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftwareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMercaderiaController : ControllerBase
    {
        private readonly ITipoMercaderiaService _tipoMercaderiaService;

        public TipoMercaderiaController(ITipoMercaderiaService tipoMercaderiaService)
        {
            _tipoMercaderiaService = tipoMercaderiaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoMercaderia>> GetAll() 
        {
            try
            {
                var response = _tipoMercaderiaService.GetAll();
                //var numero = int.Parse("2g");
                //return new JsonResult(response) { StatusCode = 200 };
                return Ok(response);
            }
            catch (Exception e)
            {
                return new JsonResult(new { Message = e.Message }) { StatusCode = 400 };
                //return BadRequest(e.Message);
            }
        }
    }
}
