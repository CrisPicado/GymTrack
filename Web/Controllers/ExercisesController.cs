using Application.Equipments;
using Application.Exercises;
using AutoMapper;
using Domain.Exercises;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IValidator<CreateExercise> _createValidator;
        private readonly IValidator<UpdateExercise> _updateValidator;
        private readonly IExerciseClient _exercises;
        private readonly IEquipmentsClient _equipment;
        private readonly IMapper _mapper;

        public ExercisesController(IValidator<CreateExercise> createValidator, IValidator<UpdateExercise> updateValidator, IExerciseClient exercises, IEquipmentsClient equipments, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _exercises = exercises;
            _equipment = equipments;
            _mapper = mapper;
        }

        [Authorize(Policy = "Exercises.Read")]
        public async Task<IActionResult> Index()
        {
            var exercises = await _exercises.List();
            return View(exercises);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateExercise();
            model.AvailableEquipments = await _equipment.List();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExercise model)
        {
            var result = await _createValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _exercises.Create(model);
                if(res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);
            }
            return View(model);
        }

        [HttpGet("/exercises/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Result<Exercise> result = await _exercises.Get(id);
            UpdateExercise updateExercise = _mapper.Map<UpdateExercise>(result.Value);
                
            updateExercise.AvailableEquipments = await _equipment.List();
            return View(updateExercise);
        }

        [HttpPost("/exercises/update/{id}")]
        public async Task<IActionResult> Update(UpdateExercise model)
        {
            var result = await _updateValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _exercises.Update(model);
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
            var result = await _exercises.Delete(id);

            if (result.IsSuccess)
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
