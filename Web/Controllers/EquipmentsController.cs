using Application.Clients;
using Application.Equipments;
using AutoMapper;
using Domain.Equipments;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Web.Extensions;

namespace Web.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IValidator<CreateEquipments> _createValidator;
        private readonly IValidator<UpdateEquipments> _updateValidator;
        private readonly IEquipmentsClient _equipment;
        private readonly IMapper _mapper;

        public EquipmentsController(IValidator<CreateEquipments> createValidator, IValidator<UpdateEquipments> updateValidator, IEquipmentsClient equipment, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _equipment = equipment;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var equipments = await _equipment.List();
            return View(equipments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateEquipments());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipments model)
        {
            var result = await _createValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _equipment.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, res.Error.description);
            }
            return View(model);
        }

        [HttpGet("/equipments/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Result<Equipment> result = await _equipment.Get(id);
            UpdateEquipments updateEquipments = _mapper.Map<UpdateEquipments>(result.Value);
            return View(updateEquipments);
        }

        [HttpPost("/equipments/update/{id}")]
        public async Task<IActionResult> Update(UpdateEquipments model)
        {
            var result = await _updateValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _equipment.Update(model);
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
            var result = await _equipment.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            if (result.Error == EquipmentsErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}