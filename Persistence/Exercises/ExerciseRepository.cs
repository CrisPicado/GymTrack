using Application.Exercises;
using Domain.Exercises;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Shared.Repositories;

namespace Persistence.Exercises
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {

        public ExerciseRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<Exercise> GetAllIncluding()
        {
            return _context.Set<Exercise>()
                .Include(e => e.Equipment)
                .Include(r => r.Routines);
        }

    }
}
