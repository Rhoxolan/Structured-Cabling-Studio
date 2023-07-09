using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudioCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudio.Loggers;
using StructuredCablingStudio.Services.SaveToTXTService;

namespace StructuredCablingStudio.Controllers
{
	public class Calculation : Controller
	{
		private readonly ICustomFileLogger _customLogger;
		private readonly ISaveToTXTService _saveToTXTService;

		public Calculation(ICustomFileLogger customLogger, ISaveToTXTService saveToTXTService)
		{
			_customLogger = customLogger;
			_saveToTXTService = saveToTXTService;
		}

		public IActionResult Calculate()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the Calculate page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[Authorize]
		public IActionResult History()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the History page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		public IActionResult Information()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the Information page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[HttpPost]
		public IActionResult SaveToTXT(string serializedCablingConfiguration)
		{
			_customLogger.Log("cablingconfigurationstxtsaving.log",
				$"The saving to txt of the cabling configuration was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			var cablingConfiguration = JsonSerializer.Deserialize<CablingConfiguration>(serializedCablingConfiguration, options);
			if (cablingConfiguration != null)
			{
				var fileName = _saveToTXTService.GetFileName(cablingConfiguration);
				var textBytes = _saveToTXTService.SaveToTXT(cablingConfiguration);
				return File(textBytes, "text/plain", fileName);
			}
			return NoContent();
		}
	}
}