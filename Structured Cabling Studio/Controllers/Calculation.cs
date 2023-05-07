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
using StructuredCablingStudio.DTOs.CalculateDTOs;
using StructuredCablingStudio.Filters.CalculationFilters;

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

		public IActionResult Calculate()
		{
			return View();
		}

		[HttpPut]
		public IActionResult LoadCalculateForm(StructuredCablingStudioParameters cablingParameters, ConfigurationCalculateParameters calculateParameters,
			CalculateDTO calculateDTO)
		{
			CalculateViewModel viewModel = _mapper.Map<CalculateViewModel>(cablingParameters);
			viewModel.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.GetValueOrDefault();
			viewModel.CableHankMeterage = calculateParameters.CableHankMeterage;
			viewModel.MinPermanentLink = calculateDTO.MinPermanentLink;
			viewModel.MaxPermanentLink = calculateDTO.MaxPermanentLink;
			viewModel.NumberOfPorts = calculateDTO.NumberOfPorts;
			viewModel.NumberOfWorkplaces = calculateDTO.NumberOfWorkplaces;
			ViewData["Diapasons"] = cablingParameters.Diapasons;
			return PartialView("_CalculateFormPartial", viewModel);
		}

		[HttpPut]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutStrictComplianceWithTheStandart(CalculateViewModel calculateVM)
		{
			if (!calculateVM.IsStrictComplianceWithTheStandart)
			{
				calculateVM.IsAnArbitraryNumberOfPorts = true;
				ModelState.SetModelValue(nameof(calculateVM.IsAnArbitraryNumberOfPorts), calculateVM.IsAnArbitraryNumberOfPorts, default);
			}
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		[HttpPut]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutRecommendationsAvailability(CalculateViewModel calculateVM)
		{
			if (!calculateVM.IsRecommendationsAvailability)
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
				ModelState.SetModelValue(nameof(calculateVM.IsCableRouteRunOutdoors), calculateVM.IsCableRouteRunOutdoors, default);
				ModelState.SetModelValue(nameof(calculateVM.IsConsiderFireSafetyRequirements), calculateVM.IsConsiderFireSafetyRequirements, default);
				ModelState.SetModelValue(nameof(calculateVM.IsCableShieldingNecessity), calculateVM.IsCableShieldingNecessity, default);
				ModelState.SetModelValue(nameof(calculateVM.HasTenBase_T), calculateVM.HasTenBase_T, default);
				ModelState.SetModelValue(nameof(calculateVM.HasFastEthernet), calculateVM.HasFastEthernet, default);
				ModelState.SetModelValue(nameof(calculateVM.HasGigabitBASE_T), calculateVM.HasGigabitBASE_T, default);
				ModelState.SetModelValue(nameof(calculateVM.HasGigabitBASE_TX), calculateVM.HasGigabitBASE_TX, default);
				ModelState.SetModelValue(nameof(calculateVM.HasTwoPointFiveGBASE_T), calculateVM.HasTwoPointFiveGBASE_T, default);
				ModelState.SetModelValue(nameof(calculateVM.HasFiveGBASE_T), calculateVM.HasFiveGBASE_T, default);
				ModelState.SetModelValue(nameof(calculateVM.HasTenGE), calculateVM.HasTenGE, default);
			}
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		[HttpPut]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutCableHankMeterageAvailability(CalculateViewModel calculateVM)
		{
			var configurationCalculateParameters = _mapper.Map<ConfigurationCalculateParameters>(calculateVM);
			if (calculateVM.CableHankMeterage != configurationCalculateParameters.CableHankMeterage)
			{
				calculateVM.CableHankMeterage = configurationCalculateParameters.CableHankMeterage;
				ModelState.SetModelValue(nameof(calculateVM.CableHankMeterage), calculateVM.CableHankMeterage, default);
			}
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		[HttpPut]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutAnArbitraryNumberOfPorts(CalculateViewModel calculateVM)
		{
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		[HttpPut]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutTechnologicalReserveAvailability(CalculateViewModel calculateVM)
		{
			var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(calculateVM);
			if (calculateVM.TechnologicalReserve != structuredCablingStudioParameters.TechnologicalReserve)
			{
				calculateVM.TechnologicalReserve = structuredCablingStudioParameters.TechnologicalReserve;
				ModelState.SetModelValue(nameof(calculateVM.TechnologicalReserve), calculateVM.TechnologicalReserve, default);
			}
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		[HttpPut]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult RestoreDefaultsCalculateForm(CalculateViewModel calculateVM)
		{
			var cablingParameters = new StructuredCablingStudioParameters
			{
				IsStrictComplianceWithTheStandart = true,
				IsAnArbitraryNumberOfPorts = true,
				IsTechnologicalReserveAvailability = true,
				IsRecommendationsAvailability = true
			};
			cablingParameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
			cablingParameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
			cablingParameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
			cablingParameters.RecommendationsArguments.ConnectionInterfaces = new List<ConnectionInterfaceStandard>
			{
				ConnectionInterfaceStandard.FastEthernet,
				ConnectionInterfaceStandard.GigabitBASE_T
			};
			var calculateParameters = new ConfigurationCalculateParameters
			{
				IsCableHankMeterageAvailability = true
			};
			calculateVM.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.Value;
			calculateVM.CableHankMeterage = calculateParameters.CableHankMeterage;
			calculateVM.TechnologicalReserve = cablingParameters.TechnologicalReserve;
			calculateVM.IsStrictComplianceWithTheStandart = cablingParameters.IsStrictComplianceWithTheStandart.Value;
			calculateVM.IsAnArbitraryNumberOfPorts = cablingParameters.IsAnArbitraryNumberOfPorts.Value;
			calculateVM.IsTechnologicalReserveAvailability = cablingParameters.IsTechnologicalReserveAvailability.Value;
			calculateVM.IsRecommendationsAvailability = cablingParameters.IsRecommendationsAvailability.Value;
			calculateVM.IsCableRouteRunOutdoors = cablingParameters.RecommendationsArguments.IsolationType == IsolationType.Outdoor;
			calculateVM.IsConsiderFireSafetyRequirements = cablingParameters.RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH;
			calculateVM.IsCableShieldingNecessity = cablingParameters.RecommendationsArguments.ShieldedType == ShieldedType.FTP;
			calculateVM.HasTenBase_T
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T);
			calculateVM.HasFastEthernet
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet);
			calculateVM.HasGigabitBASE_T
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_T);
			calculateVM.HasGigabitBASE_TX
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_TX);
			calculateVM.HasTwoPointFiveGBASE_T
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
			calculateVM.HasFiveGBASE_T
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FiveGBASE_T);
			calculateVM.HasTenGE
				= cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenGE);
			ModelState.SetModelValue(nameof(calculateVM.IsCableHankMeterageAvailability), calculateVM.IsCableHankMeterageAvailability, default);
			ModelState.SetModelValue(nameof(calculateVM.CableHankMeterage), calculateVM.CableHankMeterage, default);
			ModelState.SetModelValue(nameof(calculateVM.TechnologicalReserve), calculateVM.TechnologicalReserve, default);
			ModelState.SetModelValue(nameof(calculateVM.IsStrictComplianceWithTheStandart), calculateVM.IsStrictComplianceWithTheStandart, default);
			ModelState.SetModelValue(nameof(calculateVM.IsAnArbitraryNumberOfPorts), calculateVM.IsAnArbitraryNumberOfPorts, default);
			ModelState.SetModelValue(nameof(calculateVM.IsTechnologicalReserveAvailability), calculateVM.IsTechnologicalReserveAvailability, default);
			ModelState.SetModelValue(nameof(calculateVM.IsRecommendationsAvailability), calculateVM.IsRecommendationsAvailability, default);
			ModelState.SetModelValue(nameof(calculateVM.IsCableRouteRunOutdoors), calculateVM.IsCableRouteRunOutdoors, default);
			ModelState.SetModelValue(nameof(calculateVM.IsConsiderFireSafetyRequirements), calculateVM.IsConsiderFireSafetyRequirements, default);
			ModelState.SetModelValue(nameof(calculateVM.IsCableShieldingNecessity), calculateVM.IsCableShieldingNecessity, default);
			ModelState.SetModelValue(nameof(calculateVM.HasTenBase_T), calculateVM.HasTenBase_T, default);
			ModelState.SetModelValue(nameof(calculateVM.HasFastEthernet), calculateVM.HasFastEthernet, default);
			ModelState.SetModelValue(nameof(calculateVM.HasGigabitBASE_T), calculateVM.HasGigabitBASE_T, default);
			ModelState.SetModelValue(nameof(calculateVM.HasGigabitBASE_TX), calculateVM.HasGigabitBASE_TX, default);
			ModelState.SetModelValue(nameof(calculateVM.HasTwoPointFiveGBASE_T), calculateVM.HasTwoPointFiveGBASE_T, default);
			ModelState.SetModelValue(nameof(calculateVM.HasFiveGBASE_T), calculateVM.HasFiveGBASE_T, default);
			ModelState.SetModelValue(nameof(calculateVM.HasTenGE), calculateVM.HasTenGE, default);
			return PartialView("_CalculateFormPartial", calculateVM);
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

		[HttpPost]
		public IActionResult SaveToTXT(string serializedCablingConfiguration)
		{
			throw new NotImplementedException();
		}
	}
}