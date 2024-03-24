using Domain.Routines;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routines
{
    public class UpdateRoutineValidator : AbstractValidator<UpdateRoutine>
    {
        public UpdateRoutineValidator() 
        {
            RuleFor(r => r.Name).Length(3, 100);
            RuleFor(r => r.Description).Length(10, 255);
            RuleFor(r => r.SequenceNumber).GreaterThan(0);
            RuleFor(r => r.CoachId).GreaterThan(0);
            RuleFor(r => r.ClientId).GreaterThan(0);
            RuleFor(r => r.ExerciseIds).NotEmpty();
        }
    }
}
