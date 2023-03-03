using Microsoft.AspNetCore.Mvc;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Models;
using StructuredCablingStudio.Repositories;
using System.Diagnostics;

namespace StructuredCablingStudio.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;
		private readonly IApplicationRepository<CablingConfigurationEntity> _repository;

		public HomeController(/*ILogger<HomeController> logger*/ IApplicationRepository<CablingConfigurationEntity> repository)
		{
			//_logger = logger;
			_repository = repository;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}