using Application.Exercises;
using Domain.Exercises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private IExerciseService _service;

        public ExercisesController(IExerciseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Exercise> List()
        {

            var result = _service.List();

            if (result.IsSuccess)
            {
                return result.Value;
            }

            return (IList<Exercise>)StatusCode(StatusCodes.Status500InternalServerError, null);
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
        public IActionResult Create([FromBody] CreateExercise exercise)
        {
            var result = _service.Create(exercise);

            if (result.IsSuccess)
            {
                return Created();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateExercise exercise)
        {
            var result = _service.Update(exercise);

            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == ExerciseErrors.NotFound())
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

            if (result.Error == ExerciseErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
