using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudioCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudio.Services.SaveToTXTService;
using StructuredCablingStudio.Services.FileLoggerService;

namespace StructuredCablingStudio.Controllers
{
    public class Calculation : Controller
	{
		private readonly IFileLoggerService _fileLoggerService;
		private readonly ISaveToTXTService _saveToTXTService;

		public Calculation(IFileLoggerService fileLoggerService, ISaveToTXTService saveToTXTService)
		{
			_fileLoggerService = fileLoggerService;
			_saveToTXTService = saveToTXTService;
		}

		public IActionResult Calculate()
		{
			_fileLoggerService.Log("pagesloading.log",
				$"The loading of the Calculate page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[Authorize]
		public IActionResult History()
		{
			_fileLoggerService.Log("pagesloading.log",
				$"The loading of the History page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		public IActionResult Information()
		{
			_fileLoggerService.Log("pagesloading.log",
				$"The loading of the Information page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[HttpPost]
		public IActionResult SaveToTXT(string serializedCablingConfiguration)
		{
			_fileLoggerService.Log("cablingconfigurationstxtsaving.log",
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