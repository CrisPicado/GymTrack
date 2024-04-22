using Application.Coaches;
using AutoMapper;
using Domain.Coaches;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    public class CoachesController : Controller
    {
        private readonly IValidator<CreateCoach> _createValidator;
        private readonly IValidator<UpdateCoach> _updateValidator;
        private readonly ICoachClient _client;
        private readonly IMapper _mapper;

        public CoachesController(IValidator<CreateCoach> createValidator, IValidator<UpdateCoach> updateValidator, ICoachClient client, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _client = client;
            _mapper = mapper;
        }
        [Authorize(Policy = "Coaches.Read")]
        public async Task<IActionResult> Index()
        {
            var coaches = await _client.List();
            return View(coaches);
        }

        [Authorize(Policy = "Coaches.Read")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCoach());
        }

        [Authorize(Policy = "Coaches.Read")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCoach model)
        {
            var result = await _createValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);
            }
            return View(model);
        }

        [Authorize(Policy = "Coaches.Read")]
        [HttpGet("/coaches/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Result<Coach> result = await _client.Get(id);
            UpdateCoach updateCoach = _mapper.Map<UpdateCoach>(result.Value);
            return View(updateCoach);
        }

        [Authorize(Policy = "Coaches.Read")]
        [HttpPost("/coaches/update/{id}")]
        public async Task<IActionResult> Update(UpdateCoach model)
        {
            var result = await _updateValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }

        [Authorize(Policy = "Coaches.Read")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _client.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            if (result.Error == CoachErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
