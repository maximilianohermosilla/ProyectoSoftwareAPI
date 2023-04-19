using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;

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
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var response = await _tipoMercaderiaService.GetAll();
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
