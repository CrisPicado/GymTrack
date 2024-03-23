using Domain.Clients;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class UpdateClientValidator : AbstractValidator<UpdateClient>
    {
        public UpdateClientValidator() 
        {
            RuleFor(o => o.FirstName).Length(2, 40);
            RuleFor(o => o.LastName).Length(2, 40);
            RuleFor(o => o.BirthDate).InclusiveBetween
                (new DateTime(1900, 01, 01), new DateTime(2024, 01, 01));
            RuleFor(o => o.Email).Length(5, 150).EmailAddress();
            RuleFor(o => o.PhoneNumber).Length(8, 15);
            RuleFor(o => o.Height)
                .NotNull().WithMessage("La altura es requerida.")
                .GreaterThan(0).WithMessage("La altura debe ser mayor que cero.");
            RuleFor(o => o.Weight)
                .NotNull().WithMessage("El peso es requerido.")
                .GreaterThan(0).WithMessage("El peso debe ser mayor que cero.");

        }
    }
}
