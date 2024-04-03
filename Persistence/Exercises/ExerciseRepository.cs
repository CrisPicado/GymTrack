using Application.Clients;
using Application.Exercises;
using Domain.Clients;
using Domain.Exercises;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Exercises
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {

        public ExerciseRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<Exercise> GetAllIncluding()
        {
            return _context.Exercises
                .Include(e=>e.Equipment)
                .Include(r=>r.Routines);
        }
    }
}
