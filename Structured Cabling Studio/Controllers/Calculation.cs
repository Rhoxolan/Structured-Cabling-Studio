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
using static System.Convert;
using static System.DateTimeOffset;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.VisualBasic.FileIO;

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

		public Calculation(ILogger<Calculation> logger, ApplicationContext context, UserManager<User> userManager,
			SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_mapper = mapper;
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
			if(cablingConfiguration == null && id == null)
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


			var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World"));

			return File(stream, "text/plain", "test.txt");

			//return new FileStreamResult(stream, "text/plain")
			//{
			//	FileDownloadName = "test.txt"
			//};
		}

		public IActionResult Information()
		{
			return Content("Informatin Page");
		}
	}
}