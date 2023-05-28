using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Loggers;

namespace StructuredCablingStudio.Controllers
{
	public class Project : Controller
	{
		private readonly ICustomFileLogger _customLogger;

		public Project(ICustomFileLogger customLogger)
		{
			_customLogger = customLogger;
		}

		public IActionResult ProjectInformation()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the ProjectInformation page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}
	}
}
