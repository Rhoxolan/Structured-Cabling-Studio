using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Filters.CalculationFilters;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

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

		public Calculation(ILogger<Calculation> logger, ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_mapper = mapper;
		}

		public IActionResult Calculate(StructuredCablingStudioParameters parameters)
		{
			CalculateViewModel viewModel = _mapper.Map<CalculateViewModel>(parameters);
			ViewData["Diapasons"] = parameters.Diapasons;
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[ApprovedRestoreDefaultsActionFilter]
		[ApprovedCalculationActionFilter]
		[IsStrictComplianceWithTheStandartActionFilter]
		[IsCableHankMeterageAvailabilityActionFilter]
		[IsTechnologicalReserveAvailabilityActionFilter]
		[IsRecommendationsAvailabilityActionFilter]
		public IActionResult Calculate(CalculateViewModel calculateVM, StructuredCablingStudioParameters parameters)
		{
			if (calculateVM.ApprovedCalculation == "approved")
			{
				//Calculate
				Console.WriteLine(DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(calculateVM.RecordTime)).DateTime.ToLocalTime().ToString()); //Отладить
			}
			ViewData["Diapasons"] = parameters.Diapasons;
			return View(calculateVM);
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