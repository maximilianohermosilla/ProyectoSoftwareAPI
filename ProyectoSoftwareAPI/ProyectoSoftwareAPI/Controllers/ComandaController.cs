using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Domain.DTO;
using System.ComponentModel.DataAnnotations;

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
        [ProducesResponseType(typeof(List<ComandaGetResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDate(string fecha)
        {
            try
            {
                var response = await _service.GetByDate(fecha);
                return Ok(response);
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
                if (response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la comanda. Revise las mercaderias y forma de entrega ingresadas" });
                }
                return Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var response = await _service.GetAll();
        //        //var numero = int.Parse("2g");
        //        //return new JsonResult(response) { StatusCode = 200 };
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        return new JsonResult(new { Message = e.Message }) { StatusCode = 400 };
        //        //return BadRequest(e.Message);
        //    }
        //}
    }
}
