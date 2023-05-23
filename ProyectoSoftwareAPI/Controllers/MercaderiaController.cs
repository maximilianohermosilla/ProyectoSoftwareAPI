using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.DTO;

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
        public async Task<IActionResult> GetByTypeNameOrder(int? tipo, string? nombre, string? orden = "ASC")
        {
            try
            {
                if (orden.ToUpper() == "DESC" || orden.ToUpper() == "ASC")
                {
                    var response = await _service.GetByTypeNameOrder(tipo, nombre, orden);


                    if (response.statusCode == 404)
                    {
                        return Ok(response.response);
                    }
                    if (response.statusCode == 400)
                    {
                        return BadRequest(new BadRequest { message = response.message });
                    }

                    return Ok(response.response);
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

                if (response.statusCode == 409)
                {
                    return Conflict(new BadRequest { message = response.message });
                }

                if (response.statusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return Created("", response.response);
            }
            catch (Exception ex)
            {    
                return BadRequest(new BadRequest{ message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _service.GetById(id);

                if (response.response == null)
                {
                    return NotFound(new BadRequest { message = string.Format(@"No se pudo encontrar la mercaderia con id: {0}", id) });
                }
                return Ok(response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(MercaderiaRequest request, int id)
        {
            try
            {
                var response = await _service.Update(request, id);

                if (response.statusCode == 409)
                {
                    return Conflict(new BadRequest { message = response.message });
                }

                if (response.statusCode == 404)
                {
                    return NotFound(new BadRequest { message = string.Format(@"No se pudo encontrar la mercaderia con id: {0}", id) });
                }

                if (response.statusCode == 400)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existeComanda = await _service.ExisteComandaMercaderia(id);

                if (existeComanda)
                {
                    return Conflict(new BadRequest { message = "No se puede eliminar la mercaderia porque existe en al menos una comanda" });
                }

                var response = await _service.Delete(id);

                if (response.statusCode == 409)
                {
                    return Conflict(new BadRequest { message = response.message });
                }

                if (response.statusCode == 404)
                {
                    return Conflict(new BadRequest { message = string.Format(@"No se pudo encontrar la mercaderia con id: {0}", id) });
                }

                if (response.statusCode == 400)
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
