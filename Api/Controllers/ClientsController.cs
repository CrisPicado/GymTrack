using Application.Clients;
using Domain.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Client> List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return result.Value;
            }

            return (IList<Client>)StatusCode(StatusCodes.Status500InternalServerError, null);
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
        public IActionResult Create([FromBody] CreateClient client)
        {
            var result = _service.Create(client);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateClient client)
        {
            var result = _service.Update(client);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status202Accepted);
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

            if (result.Error == ClientErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
