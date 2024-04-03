using Application.Clients;
using Application.Coaches;
using Domain.Clients;
using Domain.Coaches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private ICoachService _service;
        public CoachesController(ICoachService service)
        {
            _service = service;
        }
        [HttpGet]
        public IList<Coach> List() 
        {
            var result = _service.List();
            if (result.IsSuccess) 
            {
                return result.Value;
            }
            return (IList<Coach>)StatusCode(StatusCodes.Status500InternalServerError, null);
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
        public IActionResult Create([FromBody] CreateCoach coach)
        {
            var result = _service.Create(coach);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCoach coach)
        {
            var result = _service.Update(coach);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status202Accepted);
            }

            if (result.Error == CoachErrors.NotFound())
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

            if (result.Error == CoachErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
