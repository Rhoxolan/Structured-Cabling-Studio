using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.DTOs.CalculateDTOs;
using StructuredCablingStudio.Filters.CalculationFilters;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;
using StructuredCablingStudioCore.Parameters;
using System.Security.Claims;
using static System.Convert;
using static System.DateTimeOffset;

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

		public async Task<IActionResult> Calculate(StructuredCablingStudioParameters cablingParameters, ConfigurationCalculateParameters calculateParameters,
			CalculateDTO calculateDTO, uint? id)
		{
			CalculateViewModel viewModel = _mapper.Map<CalculateViewModel>(cablingParameters);
			viewModel.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.GetValueOrDefault();
			viewModel.CableHankMeterage = calculateParameters.CableHankMeterage;
			viewModel.MinPermanentLink = calculateDTO.MinPermanentLink;
			viewModel.MaxPermanentLink = calculateDTO.MaxPermanentLink;
			viewModel.NumberOfPorts = calculateDTO.NumberOfPorts;
			viewModel.NumberOfWorkplaces = calculateDTO.NumberOfWorkplaces;

			if(id != null)
			{
				var configuration = await _context.CablingConfigurations.FindAsync(id);
				if(configuration != null && configuration.User != null)
				{
					if (!User.Identity!.IsAuthenticated)
					{
						return Unauthorized();
					}
					var userId = User.FindFirst(ClaimTypes.NameIdentifier);
					var currentUser = await _userManager.FindByIdAsync(userId.Value);
					if(configuration.User.Id != currentUser.Id)
					{
						return Unauthorized();
					}
				}

				ViewData["CablingConfiguration"] = configuration;
			}

			ViewData["Diapasons"] = cablingParameters.Diapasons;
			return View(viewModel);
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
						}
					}
				}
				
			}
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