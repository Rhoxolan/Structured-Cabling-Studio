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

        public IActionResult Calculate(CalculateViewModel calculateVM)
		{
			StructuredCablingStudioParameters parameters = new StructuredCablingStudioParameters
            {
                IsStrictСomplianceWithTheStandart = true,
                IsAnArbitraryNumberOfPorts = true,
                IsTechnologicalReserveAvailability = true,
                IsRecommendationsAvailability = false
            };
            ViewData["Diapasons"] = parameters.Diapasons;
			return View(calculateVM);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult CalculateConfirmed(CalculateViewModel calculateVM)
		{
            if (!IsNullOrEmpty(calculateVM.ApprovedRestoreDefaults))
            {
                Console.WriteLine("ApprovedRestoreDefaults");
				//logic
				calculateVM.ApprovedRestoreDefaults = null;
			}
            if (!IsNullOrEmpty(calculateVM.ApprovedCalculation))
            {
				Console.WriteLine("ApprovedCalculation");
                //logic
                calculateVM.ApprovedCalculation = null;
			}
            if (!calculateVM.IsStrictComplianceWithTheStandart)
            {
				calculateVM.IsAnArbitraryNumberOfPorts = true;
			}
            if (!calculateVM.IsCableHankMeterageAvailability)
            {
                calculateVM.CableHankMeterage = null;
            }
			if (!calculateVM.IsTechnologicalReserveAvailability)
			{
				calculateVM.TechnologicalReserve = 1;
			}
			if (!calculateVM.IsRecommendationsAvailability) //Подумать за фильтры или какой-то аналог, куда можно это вынести
            {
                calculateVM.IsCableRouteRunOutdoors = false;
                calculateVM.IsConsiderFireSafetyRequirements = false;
                calculateVM.IsCableShieldingNecessity = false;
                calculateVM.HasTenBase_T = false;
                calculateVM.HasFastEthernet = false;
                calculateVM.HasGigabitBASE_T = false;
                calculateVM.HasGigabitBASE_TX = false;
                calculateVM.HasTwoPointFiveGBASE_T = false;
                calculateVM.HasFiveGBASE_T = false;
                calculateVM.HasTenGE = false;
			}
            Console.WriteLine(DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(calculateVM.RecordTime)).DateTime.ToLocalTime().ToString()); //Отладить
            return RedirectToAction(nameof(Calculate), calculateVM);
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