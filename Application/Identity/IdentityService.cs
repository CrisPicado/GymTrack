using Shared;

namespace Application.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IAccountService _accountService;
        public IdentityService(IAccountService accountService) 
        {
			_accountService = accountService;   
        }

        public async Task<Result> SignIn(string email, string password)
        {
            // TODO: email and password validation => InputCredentials
            return await _accountService.SignIn(email, password); 
        }

        public async Task<Result> SignUp(string email, string password)
        {
            // TODO: email and password validation => InputCredentials
            return await _accountService.SignUp(email, password);  
        }
        public async Task SignOut()
        {
            await _accountService.SignOut(); 
        }

        public Result HasAccess(string email, string controller, string action)
        {
            return _accountService.HasAccess(email, controller, action);
        }


    }
}
