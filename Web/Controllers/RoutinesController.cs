using Application.Clients;
using Application.Coaches;
using Application.Exercises;
using Application.Routines;
using AutoMapper;
using Domain.Routines;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers
{
    public class RoutinesController : Controller
    {
        public readonly IValidator<CreateRoutine> _createValidator;
        public readonly IValidator<UpdateRoutine> _updateValidator;
        private readonly IRoutineClient _client;
        private readonly ICoachService _coachService;
        private readonly IClientService _clientService;
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public RoutinesController(IValidator<CreateRoutine> createValidator, IValidator<UpdateRoutine> updateValidator, IRoutineClient client, ICoachService coachService, IClientService clientService, IExerciseService exerciseService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _client = client;
            _coachService = coachService;
            _clientService = clientService;
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var routines = await _client.List();
            return View(routines);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateRoutine());
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
                var res = await _client.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);

            }

            return View(model);
        } 

    }
}
