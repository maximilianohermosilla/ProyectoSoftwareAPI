using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.DTO;

namespace ProyectoSoftwareAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _service;

        public MercaderiaController(IMercaderiaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MercaderiaGetResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByTypeNameOrder(int? tipo, string? nombre, string orden = "ASC")
        {
            try
            {
                if (orden.ToUpper() == "DESC" || orden.ToUpper() == "ASC")
                {
                    var response = await _service.GetByTypeNameOrder(tipo, nombre, orden);
                    if (response == null)
                    {
                        return BadRequest(new BadRequest { message = "No se ha encontrado una mercadería con los parámetros de búsqueda" });
                    }
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new BadRequest { message = "El campo orden debe ser ASC o DESC" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MercaderiaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Insert(MercaderiaRequest request)
        {
            try
            {
                var response = await _service.Insert(request);
                if (response == null)
                {
                    //return new JsonResult(new { message = "Se ha generado un conflicto. Verifique los datos ingresados" }) { StatusCode = 409 };
                    return Conflict(new { message = "Se ha generado un conflicto. El nombre ya existe o se ha ingresado un parámetro inválido" });
                }
                return Created("", response);
            }
            catch (Exception ex)
            {    
                return BadRequest(new BadRequest{ message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<MercaderiaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _service.GetById(id);

                if (response == null)
                {
                    return NotFound(new BadRequest { message = string.Format(@"No se pudo encontrar la mercaderia con id: {0}", id) });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

    }
}
