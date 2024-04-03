using Application.Repositories;
using Domain.Exercises;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        IQueryable<Exercise> GetAllIncluding();
    }
}
