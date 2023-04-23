using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.DTO;

namespace ProyectoSoftwareAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _service;

        public ComandaController(IComandaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ComandaResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDate(string fecha)
        {
            try
            {
                var response = await _service.GetByDate(fecha);

                if (response.StatusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return Ok(response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ComandaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert(ComandaRequest request)
        {
            try
            {
                var response = await _service.Insert(request.mercaderias, request.formaEntrega);
                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la comanda. Revise las mercaderias y forma de entrega ingresadas. " });
                }
                return Created("", response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ComandaGetResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _service.GetById(id);

                if (response.StatusCode == 404)
                {
                    return NotFound(new BadRequest { message = string.Format(@"No se pudo encontrar la comanda {0}", id) });
                }

                if (response.StatusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return Ok(response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }
    }
}
