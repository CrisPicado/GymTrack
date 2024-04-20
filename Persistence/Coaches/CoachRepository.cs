using Application.Coaches;
using Domain.Coaches;
using Persistence.Contexts;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Coaches
{
    public class CoachRepository : RepositoryBase<Coach>, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
