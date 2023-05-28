using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudioCore.Calculation;
using StructuredCablingStudioCore.Parameters;
using System.Security.Claims;
using StructuredCablingStudio.Data.Contexts;
using AutoMapper;
using static System.Convert;
using static System.DateTimeOffset;
using StructuredCablingStudio.DTOs.CalculationDTOs;
using StructuredCablingStudio.Filters.CalculationFilters;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudio.Loggers;

namespace StructuredCablingStudio.Controllers
{
    [Route("Calculation/{action}/{id?}")]
	public class CalculationCalculateController : Controller
	{
		private readonly ApplicationContext _context;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly ICustomFileLogger _customLogger;

		public CalculationCalculateController(UserManager<User> userManager, ApplicationContext context, IMapper mapper,
			ICustomFileLogger customLogger)
		{
			_userManager = userManager;
			_context = context;
			_mapper = mapper;
			_customLogger = customLogger;
		}


		/// <summary>
		/// Returns the partial view with the clean Calculate form
		/// </summary>
		[HttpGet]
		public IActionResult GetCalculateForm(StructuredCablingStudioParameters cablingParameters,
			ConfigurationCalculateParameters calculateParameters,
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

		/// <summary>
		/// Returns the partial view with the clean display of structured cabling configuration
		/// </summary>
		[HttpGet]
		public IActionResult GetConfigurationDisplayCalculate()
		{
			return PartialView("_ConfigurationDisplayCalculatePartial");
		}

		/// <summary>
		/// Edits the viewmodel data from the Calculate form after applying the "StrictComplianceWithTheStandart" setting
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
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

		/// <summary>
		/// Edits the viewmodel data from the Calculate form after applying the "RecommendationsAvailability" setting
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
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

		/// <summary>
		/// Edits the viewmodel data from the Сalculate form after applying the "CableHankMeterageAvailability" setting
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutCableHankMeterageAvailability(CalculateViewModel calculateVM)
		{
			var configurationCalculateParameters = _mapper.Map<ConfigurationCalculateParameters>(calculateVM);
			if (calculateVM.CableHankMeterage != configurationCalculateParameters.CableHankMeterage)
			{
				calculateVM.CableHankMeterage = configurationCalculateParameters.CableHankMeterage;
				ModelState.SetModelValue(nameof(calculateVM.CableHankMeterage), calculateVM.CableHankMeterage, default);
			}
			var ceiledAveragePermanentLink =
				(int)Math.Ceiling((calculateVM.MinPermanentLink + calculateVM.MaxPermanentLink) / 2 * calculateVM.TechnologicalReserve);
			if (calculateVM.CableHankMeterage < ceiledAveragePermanentLink)
			{
				calculateVM.CableHankMeterage = ceiledAveragePermanentLink;
				ModelState.SetModelValue(nameof(calculateVM.CableHankMeterage), calculateVM.CableHankMeterage, default);
			}
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		/// <summary>
		/// Edits the viewmodel data from the Сalculate form after applying the "AnArbitraryNumberOfPorts" setting
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public IActionResult PutAnArbitraryNumberOfPorts(CalculateViewModel calculateVM)
		{
			return PartialView("_CalculateFormPartial", calculateVM);
		}

		/// <summary>
		/// Edits the viewmodel data from the Сalculate form after applying the "TechnologicalReserveAvailability" setting
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
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

		/// <summary>
		/// Restore defaults settings on viewmodel data to the Сalculate form
		/// </summary>
		/// <returns>The partial view with the Calculate form</returns>
		[HttpPut]
		[ServiceFilter(typeof(DiapasonActionFilter))]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalculateParametersResultFilter))]
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

		/// <summary>
		/// Calculation of the structured cabling configuration
		/// </summary>
		/// <returns>The partial view with the display of the structured cabling configuration</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Calculate(CalculateViewModel calculateVM)
		{
			var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(calculateVM);
			var configurationCalculateParameters = _mapper.Map<ConfigurationCalculateParameters>(calculateVM);
			var recordTime = FromUnixTimeMilliseconds(ToInt64(calculateVM.RecordTime)).DateTime.ToLocalTime();
			var configuration = configurationCalculateParameters.Calculate(structuredCablingStudioParameters, recordTime,
				calculateVM.MinPermanentLink, calculateVM.MaxPermanentLink, calculateVM.NumberOfWorkplaces, calculateVM.NumberOfPorts);
			string logMessage = $"The cabling configuration was calculated; ip-address: {HttpContext.Connection.RemoteIpAddress?.ToString()}";
			if (User.Identity != null && User.Identity.IsAuthenticated)
			{
				var userId = User.FindFirst(ClaimTypes.NameIdentifier);
				if (userId != null)
				{
					var currentUser = await _userManager.FindByIdAsync(userId.Value);
					if (currentUser != null)
					{
						var configuratonEntity = _mapper.Map<CablingConfigurationEntity>(configuration);
						configuratonEntity.User = currentUser;
						await _context.CablingConfigurations.AddAsync(configuratonEntity);
						await _context.SaveChangesAsync();
						logMessage += $"; user: {currentUser.Email}";
					}
				}
			}
			_customLogger.Log("calculationlogs.log", logMessage);
			var structuredCablingParameters = _mapper.Map<StructuredCablingParameters>(structuredCablingStudioParameters);
			HttpContext.Session.SetStructuredCablingParameters(structuredCablingParameters);
			var calculateParameters = _mapper.Map<CalculateParameters>(configurationCalculateParameters);
			HttpContext.Session.SetCalculateParameters(calculateParameters);
			var calculateDTO = _mapper.Map<CalculateDTO>(calculateVM);
			HttpContext.Session.SetCalculateDTO(calculateDTO);
			return PartialView("_ConfigurationDisplayCalculatePartial", configuration);
		}
	}
}
