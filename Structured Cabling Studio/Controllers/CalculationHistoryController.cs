using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using System.Security.Claims;

namespace StructuredCablingStudio.Controllers
{
	[Route("Calculation/{action}/{id?}")]
	public class CalculationHistoryController : Controller
	{
		private readonly ApplicationContext _context;

		public CalculationHistoryController(ApplicationContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Returns the partial view with the list of structured cabling configurations
		/// </summary>
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetConfigurationsListBox()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userId != null)
			{
				var configurations = await _context.CablingConfigurations.Where(c => c.User.Id == userId.Value).ToListAsync();
				return PartialView("_ConfigurationsListPartial", configurations);
			}
			return Unauthorized();
		}

		/// <summary>
		/// Returns the partial view with the clean display of structured cabling configuration
		/// </summary>
		[HttpGet]
		[Authorize]
		public IActionResult GetConfigurationDisplayHistory()
		{
			return PartialView("_ConfigurationDisplayHistoryPartial");
		}

		/// <summary>
		/// Returns the partial view with the display of structured cabling configuration
		/// </summary>
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetConfigurationDisplayHistoryById(uint id)
		{
			var cablingConfiguration = await _context.CablingConfigurations.FindAsync(id);
			return PartialView("_ConfigurationDisplayHistoryPartial", cablingConfiguration);
		}

		/// <summary>
		/// Returns the partial view with the delete confirm
		/// </summary>
		[HttpGet]
		[Authorize]
		public IActionResult GetDeleteConfigurationConfirm()
		{
			return PartialView("_DeleteConfigurationPartial");
		}

		/// <summary>
		/// Removes the cabling configuration
		/// </summary>
		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeleteConfiguration(uint id)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return Unauthorized();
			}
			var cablingConfiguration = await _context.CablingConfigurations
				.Where(c => c.User.Id == userId.Value)
				.FirstOrDefaultAsync(c => c.Id == id);
			if (cablingConfiguration == null)
			{
				return NotFound();
			}
			_context.CablingConfigurations.Remove(cablingConfiguration);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Returns the partial view with the delete confirm
		/// </summary>
		[HttpGet]
		[Authorize]
		public IActionResult GetDeleteAllConfigurationsConfirm()
		{
			return PartialView("_DeleteAllConfigurationsPartial");
		}

		/// <summary>
		/// Removes all the cabling configurations
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> DeleteAllConfigurations()
		{
			if (User.Identity == null || !User.Identity.IsAuthenticated)
			{
				return Unauthorized();
			}
			var userId = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return Unauthorized();
			}
			var configurationsToRemove = await _context.CablingConfigurations
				.Where(c => c.User.Id == userId.Value)
				.ToListAsync();
			_context.CablingConfigurations.RemoveRange(configurationsToRemove);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
