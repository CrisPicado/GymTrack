using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Shared;

namespace Infrastructure.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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


    }
}
