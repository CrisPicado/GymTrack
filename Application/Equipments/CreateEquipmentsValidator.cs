using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Equipments;
using FluentValidation;

namespace Application.Equipments
{
    public class CreateEquipmentsValidator : AbstractValidator<CreateEquipments>
    {
        public CreateEquipmentsValidator()
        {
            RuleFor(e => e.Name).Length(2, 40);
            RuleFor(e => e.Description).Length(2, 100);

        }
    }
}
