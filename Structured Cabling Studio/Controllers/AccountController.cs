using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Entities;

namespace StructuredCablingStudio.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult SignInWithGoogle()
		{
			string? redirectUrl = Url.Action(nameof(GoogleRedirect));
			var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
			return Challenge(properties, "Google");
		}

		public async Task<IActionResult> GoogleRedirect()
		{
			ExternalLoginInfo? loginInfo = await _signInManager.GetExternalLoginInfoAsync();
			if (loginInfo is null)
			{

			}
			throw new NotImplementedException();
		}

		public IActionResult AuthenticationFailed()
		{
			return View();
		}
	}
}
