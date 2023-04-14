﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Models.ViewModels.AccountViewModels;
using System.Security.Claims;

namespace StructuredCablingStudio.Controllers
{
	[Authorize]
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
		public IActionResult SignIn(string returnUrl)
		{
			return View("SignIn", new SignInViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public IActionResult SignInWithGoogle(string returnUrl)
		{
			string? redirectUrl = Url.Action(nameof(GoogleLoginCallback), nameof(Account), new { returnUrl });
			string provider = "Google";
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return Challenge(properties, provider);
		}

		[AllowAnonymous]
		public async Task<IActionResult> GoogleLoginCallback(string returnUrl)
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
						return View("AuthenticationFailed", new AuthenticationFailedViewModel { ReturnUrl = returnUrl });
					}
					var addLoginResult = await _userManager.AddLoginAsync(user, loginInfo);
					if (!addLoginResult.Succeeded)
					{
						return View("AuthenticationFailed", new AuthenticationFailedViewModel { ReturnUrl = returnUrl });
					}
				}
				var externalLoginSignInResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
				if (externalLoginSignInResult.Succeeded)
				{
					await _signInManager.SignInAsync(user, true);
					return LocalRedirect(returnUrl);
				}
			}
			return View("AuthenticationFailed", new AuthenticationFailedViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout(string returnUrl)
		{
			await _signInManager.SignOutAsync();
			return LocalRedirect(returnUrl);
		}
	}
}
