using Domain.Clients;
using Domain.Coaches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public class UpdateCoachValidator : AbstractValidator<UpdateCoach>
    {

        public UpdateCoachValidator()
        {
            RuleFor(o => o.FirstName).Length(2, 40);
            RuleFor(o => o.LastName).Length(2, 40);
            RuleFor(o => o.Email).Length(5, 150).EmailAddress();
            RuleFor(o => o.PhoneNumber).Length(8, 15);
        }
    }
}
