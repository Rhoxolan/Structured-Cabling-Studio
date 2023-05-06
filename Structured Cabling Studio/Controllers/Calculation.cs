using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore;
using StructuredCablingStudioCore.Calculation;
using StructuredCablingStudioCore.Parameters;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Localization;
using static System.Convert;
using static System.DateTimeOffset;
using static System.Text.Encoding;
using static System.String;

namespace StructuredCablingStudio.Controllers
{
	public class Calculation : Controller
	{
		private readonly ILogger<Calculation> _logger;
		private readonly ApplicationContext _context;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<Calculation> _localizer;

		public Calculation(ILogger<Calculation> logger, ApplicationContext context, UserManager<User> userManager,
			SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IStringLocalizer<Calculation> localizer)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_mapper = mapper;
			_localizer = localizer;
		}

		[Authorize]
		public IActionResult History()
		{
			return View();
		}

		public IActionResult Information()
		{
			return Content("Informatin Page");
		}
	}
}