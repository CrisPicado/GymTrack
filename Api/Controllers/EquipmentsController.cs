using Application.Clients;
using Application.Equipments;
using Domain.Clients;
using Domain.Equipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private IEquipmentsService _service;

        public EquipmentsController(IEquipmentsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Equipment> List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return result.Value;
            }

            return (IList<Equipment>)StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var result = _service.Get(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEquiments equiments)
        {
            var result = _service.Create(equiments);

            if (result.IsSuccess)
            {
                return Created();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateEquipments equiments)
        {
            var result = _service.Update(equiments);

            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == ClientErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == EquipmentsErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
