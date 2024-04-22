using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Shared;

namespace Infrastructure.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPermissionRepository _permissionsRepository;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPermissionRepository permissionsRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _permissionsRepository = permissionsRepository;
        }

        public async Task<Result> SignIn(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Result.Success();
            }
            return Result.Failure(IdentityErrors.InvalidUserOrPassword());
        }

        public async Task<Result> SignUp(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return Result.Success();
            }

            return Result.Failure(IdentityErrors.NotCreated());
        }
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public Result HasAccess(string email, string controller, string action)
        {
            bool hasAccess = _permissionsRepository.HasAccess(email, controller, action);
            if (hasAccess)
            {
                return Result.Success();
            }
            return Result.Failure(IdentityErrors.AccessDenied());
        }
    }
}
