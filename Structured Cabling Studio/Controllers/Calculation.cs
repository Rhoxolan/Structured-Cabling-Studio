using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.DTOs.CalculateDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Filters.CalculationFilters;
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

		public IActionResult Calculate(StructuredCablingStudioParameters cablingParameters, ConfigurationCalculateParameters calculateParameters,
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
			return View(viewModel);
		}

		//[CablingConfigurationResultFilter]
		//public async Task<IActionResult> Calculate(StructuredCablingStudioParameters cablingParameters, ConfigurationCalculateParameters calculateParameters,
		//    CalculateDTO calculateDTO, CablingConfiguration? cablingConfiguration, uint? id)
		//{
		//    CalculateViewModel viewModel = _mapper.Map<CalculateViewModel>(cablingParameters);
		//    viewModel.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.GetValueOrDefault();
		//    viewModel.CableHankMeterage = calculateParameters.CableHankMeterage;
		//    viewModel.MinPermanentLink = calculateDTO.MinPermanentLink;
		//    viewModel.MaxPermanentLink = calculateDTO.MaxPermanentLink;
		//    viewModel.NumberOfPorts = calculateDTO.NumberOfPorts;
		//    viewModel.NumberOfWorkplaces = calculateDTO.NumberOfWorkplaces;
		//    if (id != null)
		//    {
		//        if (User.Identity == null || !User.Identity.IsAuthenticated)
		//        {
		//            return LocalRedirect("/");
		//        }
		//        var userId = User.FindFirst(ClaimTypes.NameIdentifier);
		//        if (userId == null)
		//        {
		//            return LocalRedirect("/");
		//        }
		//        var configurations = await _context.CablingConfigurations.Where(c => c.User.Id == userId.Value).ToListAsync();
		//        var configuration = configurations?.FirstOrDefault(c => c.Id == id);
		//        if (configuration == null)
		//        {
		//            return LocalRedirect("/");
		//        }
		//        ViewData["CablingConfiguration"] = _mapper.Map<CablingConfiguration>(configuration);
		//    }
		//    else if (cablingConfiguration != null)
		//    {
		//        ViewData["CablingConfiguration"] = cablingConfiguration;
		//    }
		//    ViewData["Diapasons"] = cablingParameters.Diapasons;
		//    return View(viewModel);
		//}

		[CablingConfigurationResultFilter]
		public async Task<IActionResult> Calculated(StructuredCablingStudioParameters cablingParameters, ConfigurationCalculateParameters calculateParameters,
			CalculateDTO calculateDTO, CablingConfiguration? cablingConfiguration, uint? id)
		{
			if (cablingConfiguration == null && id == null)
			{
				return LocalRedirect("/");
			}
			if (id != null)
			{
				if (User.Identity == null || !User.Identity.IsAuthenticated)
				{
					return LocalRedirect("/");
				}
				var userId = User.FindFirst(ClaimTypes.NameIdentifier);
				if (userId == null)
				{
					return LocalRedirect("/");
				}
				var configurations = await _context.CablingConfigurations.Where(c => c.User.Id == userId.Value).ToListAsync();
				var configuration = configurations?.FirstOrDefault(c => c.Id == id);
				if (configuration == null)
				{
					return LocalRedirect("/");
				}
				ViewData["CablingConfiguration"] = _mapper.Map<CablingConfiguration>(configuration);
			}
			else if (cablingConfiguration != null)
			{
				ViewData["CablingConfiguration"] = cablingConfiguration;
			}
			CalculateViewModel viewModel = _mapper.Map<CalculateViewModel>(cablingParameters);
			viewModel.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.GetValueOrDefault();
			viewModel.CableHankMeterage = calculateParameters.CableHankMeterage;
			viewModel.MinPermanentLink = calculateDTO.MinPermanentLink;
			viewModel.MaxPermanentLink = calculateDTO.MaxPermanentLink;
			viewModel.NumberOfPorts = calculateDTO.NumberOfPorts;
			viewModel.NumberOfWorkplaces = calculateDTO.NumberOfWorkplaces;
			ViewData["Diapasons"] = cablingParameters.Diapasons;
			return View("Calculate", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[RestoreDefaultsActionFilter]
		[IsStrictComplianceWithTheStandartActionFilter]
		[IsRecommendationsAvailabilityActionFilter]
		[ServiceFilter(typeof(ValueActionFilter), Order = int.MinValue + 1)]
		[ServiceFilter(typeof(DiapasonActionFilter), Order = int.MinValue)]
		[ServiceFilter(typeof(StructuredCablingStudioParametersResultFilter))]
		[ServiceFilter(typeof(ConfigurationCalulateParametersResultFilter))]
		[ServiceFilter(typeof(CalculateDTOResultFilter))]
		public async Task<IActionResult> Calculate(CalculateViewModel calculateVM)
		{
			if (calculateVM.ApprovedCalculation == "approved")
			{
				var cablingParameters = _mapper.Map<StructuredCablingStudioParameters>(calculateVM);
				var calculateParameters = _mapper.Map<ConfigurationCalculateParameters>(calculateVM);
				var recordTime = FromUnixTimeMilliseconds(ToInt64(calculateVM.RecordTime)).DateTime.ToLocalTime();
				var configuration = calculateParameters.Calculate(cablingParameters, recordTime, calculateVM.MinPermanentLink, calculateVM.MaxPermanentLink,
					calculateVM.NumberOfWorkplaces, calculateVM.NumberOfPorts);
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
							return RedirectToAction(nameof(Calculated), new { id = configuratonEntity.Id });
						}
					}
				}
				HttpContext.Session.SetCablingConfiguration(configuration);
				return RedirectToAction(nameof(Calculated));
			}
			return View(calculateVM);
		}

		[Authorize]
		public IActionResult History()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SaveToTXT(string serializedCablingConfiguration)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			var cablingConfiguration = JsonSerializer.Deserialize<CablingConfiguration>(serializedCablingConfiguration, options);
			if (cablingConfiguration != null)
			{
				var fileName = $"{_localizer["StructuredCablingConfiguration"]} " +
					$"{cablingConfiguration.RecordTime.Day:00}." +
					$"{cablingConfiguration.RecordTime.Month:00}." +
					$"{cablingConfiguration.RecordTime.Year} " +
					$"{cablingConfiguration.RecordTime.Hour:00}." +
					$"{cablingConfiguration.RecordTime.Minute:00}." +
					$"{cablingConfiguration.RecordTime.Second:00}.txt";
				StringBuilder cablingConfigurationSB = new();
				cablingConfigurationSB.AppendLine(_localizer["CreatedIn"]);
				cablingConfigurationSB.AppendLine();
				cablingConfigurationSB.AppendLine();
				cablingConfigurationSB.AppendLine($"{_localizer["RecordTime"]} {cablingConfiguration.RecordTime.ToShortDateString()} " +
					$"{cablingConfiguration.RecordTime.ToLongTimeString()}");
				cablingConfigurationSB.AppendLine($"{_localizer["MinPermanentLink"]} {cablingConfiguration.MinPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["MaxPermanentLink"]} {cablingConfiguration.MaxPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["AveragePermanentLink"]} {cablingConfiguration.MaxPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["NumberOfWorkplaces"]} {cablingConfiguration.NumberOfWorkplaces}");
				cablingConfigurationSB.AppendLine($"{_localizer["NumberOfPorts"]} {cablingConfiguration.NumberOfPorts}");
				if (cablingConfiguration.CableHankMeterage != null)
				{
					cablingConfigurationSB.AppendLine($"{_localizer["CableQuantity"]} {cablingConfiguration.CableQuantity:F2} " +
						$"{_localizer["m"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["CableHankMeterage"]} {cablingConfiguration.CableHankMeterage:F2} " +
						$"{_localizer["m"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["HankQuantity"]} {cablingConfiguration.HankQuantity}");
				}
				cablingConfigurationSB.AppendLine($"{_localizer["TotalCableQuantity"]} {cablingConfiguration.TotalCableQuantity} " +
					$"{_localizer["m"]}");
				if (!IsNullOrEmpty(cablingConfiguration.Recommendations["Insulation Type"]) &&
					!IsNullOrEmpty(cablingConfiguration.Recommendations["Insulation Material"]) &&
					!IsNullOrEmpty(cablingConfiguration.Recommendations["Shielding"]))
				{
					cablingConfigurationSB.AppendLine();
					cablingConfigurationSB.AppendLine(_localizer["CableSelectionRecommendations"]);
					cablingConfigurationSB.AppendLine($"{_localizer["Insulation Type"]} {cablingConfiguration.Recommendations["Insulation Type"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["Insulation Material"]} {cablingConfiguration.Recommendations["Insulation Material"]}");
					if (!IsNullOrEmpty(cablingConfiguration.Recommendations["Standart"]))
					{
						cablingConfigurationSB.AppendLine($"{_localizer["Standart"]} {cablingConfiguration.Recommendations["Standart"]}");
					}
					cablingConfigurationSB.AppendLine($"{_localizer["Shielding"]} {cablingConfiguration.Recommendations["Shielding"]}");
				}
				var stream = new MemoryStream(UTF8.GetBytes(cablingConfigurationSB.ToString()));
				return File(stream, "text/plain", fileName);
			}
			return LocalRedirect("/");
		}

		public IActionResult Information()
		{
			return Content("Informatin Page");
		}
	}
}