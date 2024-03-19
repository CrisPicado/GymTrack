using Application.Repositories;
using Domain.Coaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public interface ICoachRepository : IRepositoryBase<Coach>
    {
    }
}
