using Application.Clients;
using Application.Coaches;
using Application.Exercises;
using Application.Routines;
using AutoMapper;
using Domain.Routines;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    public class RoutinesController : Controller
    {
        public readonly IValidator<CreateRoutine> _createValidator;
        public readonly IValidator<UpdateRoutine> _updateValidator;
        private readonly IRoutineClient _routine;
        private readonly ICoachClient _coach;
        private readonly IClientContract _client;
        private readonly IExerciseClient _exercise;
        private readonly IMapper _mapper;

        public RoutinesController(IValidator<CreateRoutine> createValidator, IValidator<UpdateRoutine> updateValidator, IRoutineClient routine, ICoachClient coach, IClientContract client, IExerciseClient exercise, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _routine = routine;
            _coach = coach;
            _client = client;
            _exercise = exercise;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var routines = await _routine.List();
            return View(routines);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateRoutine();

            model.Clients = await _client.List();
            model.Coachs = await _coach.List();
            model.Exercises = await _exercise.List();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoutine model)
        {
            var result = await _createValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _routine.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);

            }

            return View(model);
        }

        [HttpGet("routines/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Result<Routine> result = await _routine.Get(id);
            UpdateRoutine updateRoutine = _mapper.Map<UpdateRoutine>(result.Value);


            updateRoutine.Clients = await _client.List();
            updateRoutine.Coachs = await _coach.List();
            updateRoutine.Exercises = await _exercise.List();

            return View(updateRoutine);
        }

        [HttpPost("/routines/update/{id}")]
        public async Task<IActionResult> Update(UpdateRoutine model)
        {
            var result = await _updateValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _routine.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _routine.Delete(id);

            if(result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            if (result.Error == ExerciseErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
