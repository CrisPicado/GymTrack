using Application.Identity;
using Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	public class AccountController : Controller
	{
		public IAccountService _accountService;
        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAccountService accountService, IAuthorizationService authorizationService)
		{
			_accountService = accountService;
            _authorizationService = authorizationService;
        }

		[HttpGet]
		public async Task<IActionResult> SignIn()
		{
			return View(new AccountViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(AccountViewModel model, [FromQuery] string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.SignIn(model.Email, model.Password);
				if (result.IsSuccess)
				{
					if (!string.IsNullOrEmpty(returnUrl))
					{
						return LocalRedirect(returnUrl);
					}

					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, result.Error.description);
			}

			return View(model);
		}


		[HttpGet]
		public  async Task<IActionResult> SignUp()
		{
			return View(new AccountViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(AccountViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.SignUp(model.Email, model.Password);
				if (result.IsSuccess)
				{
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError(string.Empty, result.Error.description);
			}

			return View(model);
		}

		[HttpGet]
		[HttpPost]
		public async Task<IActionResult> SignOut()
		{
			await _accountService.SignOut();
			return RedirectToAction("Index", "Home");
		}

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

