using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Application.Identity
{
    public interface IAccountService
    {
        Task<Result> SignUp(string email, string password);

        Task<Result> SignIn(string email, string password);

        Task SignOut();
    }
}
