using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Services.FileLoggerService;

namespace StructuredCablingStudio.Controllers
{
    public class Project : Controller
	{
		private readonly IFileLoggerService _fileLoggerService;

		public Project(IFileLoggerService fileLoggerService)
		{
			_fileLoggerService = fileLoggerService;
		}

		public IActionResult ProjectInformation()
		{
			_fileLoggerService.Log("pagesloading.log",
				$"The loading of the ProjectInformation page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}
	}
}
