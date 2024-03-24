using Application.Routines;
using Domain.Routines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private IRoutineService _service;

        public RoutinesController(IRoutineService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Routine> List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return result.Value;
            }

            return (IList<Routine>)StatusCode(StatusCodes.Status500InternalServerError, null);
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
        public IActionResult Create([FromBody] CreateRoutine routine)
        {
            var result = _service.Create(routine);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateRoutine routine)
        {
            var result = _service.Update(routine);

            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == RoutineErrors.NotFound())
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

            if (result.Error == RoutineErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
