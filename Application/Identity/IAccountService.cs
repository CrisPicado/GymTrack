using Shared;

namespace Application.Identity
{
    public interface IAccountService
    {
        Task<Result> SignUp(string email, string password);

        Task<Result> SignIn(string email, string password);

        Task SignOut();

        Result HasAccess(string email, string controller, string action);
    }
}
