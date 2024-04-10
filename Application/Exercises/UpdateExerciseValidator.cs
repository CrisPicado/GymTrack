using Domain.Equipments;
using Domain.Exercises;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public class UpdateExerciseValidator : AbstractValidator<UpdateExercise>
    {
        public UpdateExerciseValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("El nombre es requerido.")
                                 .Length(2, 40).WithMessage("El nombre debe tener entre 2 y 40 caracteres.");

            RuleFor(e => e.TargetZone).NotEmpty().WithMessage("La zona objetivo es requerida.")
                                      .Length(2, 50).WithMessage("La zona objetivo debe tener entre 2 y 50 caracteres.");

            RuleFor(e => e.Sets).GreaterThanOrEqualTo(1).WithMessage("Debe haber al menos 1 serie.");

            RuleFor(e => e.Repeats).GreaterThanOrEqualTo(1).WithMessage("Debe haber al menos 1 repetición.");

            RuleFor(e => e.Weight).GreaterThanOrEqualTo(0).WithMessage("El peso debe ser mayor o igual a 0.");

            RuleFor(e => e.EquipmentId).NotEmpty().WithMessage("El ID del equipo es requerido.");
        }
    }
}
