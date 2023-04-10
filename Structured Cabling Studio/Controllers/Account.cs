using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Entities;
using System.Security.Claims;

namespace StructuredCablingStudio.Controllers
{
	public class Account : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public Account(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignInWithGoogle()
		{
			string? redirectUrl = Url.Action(nameof(GoogleRedirect));
			var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
			return Challenge(properties, "Google");
		}

		public async Task<IActionResult> GoogleRedirect()
		{
			ExternalLoginInfo? loginInfo = await _signInManager.GetExternalLoginInfoAsync();
			if (loginInfo is not null)
			{
				var userEmail = loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value;
				User? user = await _userManager.FindByEmailAsync(userEmail!);
				if (user is null)
				{
					user = new User
					{
						Email = userEmail!,
						UserName = userEmail!
					};
					var createResult = await _userManager.CreateAsync(user);
					if (!createResult.Succeeded)
					{
						return View("AuthenticationFailed");
					}
					var addLoginResult = await _userManager.AddLoginAsync(user, loginInfo);
					if (!addLoginResult.Succeeded)
					{
						return View("AuthenticationFailed");
					}
				}
				var externalLoginSignInResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
				if (externalLoginSignInResult.Succeeded)
				{
					await _signInManager.SignInAsync(user, true);
					return RedirectToAction(nameof(Calculation.Calculate), nameof(Calculation));
				}
			}
			return View("AuthenticationFailed");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Calculation.Calculate), nameof(Calculation));
		}
	}
}
