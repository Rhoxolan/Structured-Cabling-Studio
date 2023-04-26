using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsCableHankMeterageAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if (!model.IsCableHankMeterageAvailability)
				{
					model.CableHankMeterage = null;
					context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
				}
			}
		}
	}
}
