using Microsoft.AspNetCore.Mvc;

namespace StructuredCablingStudio.Controllers
{
	public class Project : Controller
	{
		public IActionResult ProjectInformation()
		{
			return View();
		}
	}
}
