using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;
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

        public Calculation(ILogger<Calculation> logger, ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Calculate()
		{
			//В привязчик
			{
				StructuredCablingStudioParameters parameters = new StructuredCablingStudioParameters
				{
					IsStrictСomplianceWithTheStandart = true,
					IsAnArbitraryNumberOfPorts = true,
					IsTechnologicalReserveAvailability = true,
					IsRecommendationsAvailability = false
				};
				ViewData["Diapasons"] = parameters.Diapasons;
			}

			return View(new CalculateViewModel { });
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Calculate(CalculateViewModel calculateVM)
		{
			if (!IsNullOrEmpty(calculateVM.ApprovedCalculation))
			{
				//Calculate
			}

			//В фильтр
			{
				if (!IsNullOrEmpty(calculateVM.ApprovedRestoreDefaults))
				{
					Console.WriteLine("ApprovedRestoreDefaults");
					ModelState.SetModelValue("ApprovedRestoreDefaults", "", default);
				}
				if (!IsNullOrEmpty(calculateVM.ApprovedCalculation))
				{
					Console.WriteLine("ApprovedCalculation");
					ModelState.SetModelValue("ApprovedCalculation", "", default);
				}
				if (!calculateVM.IsStrictComplianceWithTheStandart)
				{
					ModelState.SetModelValue("IsAnArbitraryNumberOfPorts", true, default);
				}
				if (!calculateVM.IsCableHankMeterageAvailability)
				{
					ModelState.SetModelValue("CableHankMeterage", "", default);
				}
				if (!calculateVM.IsTechnologicalReserveAvailability)
				{
					ModelState.SetModelValue("TechnologicalReserve", 1, default);
				}
				if (!calculateVM.IsRecommendationsAvailability)
				{
					ModelState.SetModelValue("IsCableRouteRunOutdoors", false, default);
					ModelState.SetModelValue("IsConsiderFireSafetyRequirements", false, default);
					ModelState.SetModelValue("IsCableShieldingNecessity", false, default);
					ModelState.SetModelValue("HasTenBase_T", false, default);
					ModelState.SetModelValue("HasFastEthernet", false, default);
					ModelState.SetModelValue("HasGigabitBASE_T", false, default);
					ModelState.SetModelValue("HasGigabitBASE_TX", false, default);
					ModelState.SetModelValue("HasTwoPointFiveGBASE_T", false, default);
					ModelState.SetModelValue("HasFiveGBASE_T", false, default);
					ModelState.SetModelValue("HasTenGE", false, default);
				}
			}

			//В привязчик
			{
				StructuredCablingStudioParameters parameters = new StructuredCablingStudioParameters
				{
					IsStrictСomplianceWithTheStandart = true,
					IsAnArbitraryNumberOfPorts = true,
					IsTechnologicalReserveAvailability = true,
					IsRecommendationsAvailability = false
				};
				ViewData["Diapasons"] = parameters.Diapasons;
			}

			Console.WriteLine(DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(calculateVM.RecordTime)).DateTime.ToLocalTime().ToString()); //Отладить
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