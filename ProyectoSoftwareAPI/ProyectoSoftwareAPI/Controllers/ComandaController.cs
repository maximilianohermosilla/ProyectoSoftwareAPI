using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSoftware.Application.Interfaces;
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

        [HttpGet]
        public async Task<IActionResult> GetByDate(string fecha)
        {
            try
            {
                var response = await _service.GetByDate(fecha);
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
