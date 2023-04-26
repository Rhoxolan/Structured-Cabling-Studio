using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsTechnologicalReserveAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if (!model.IsTechnologicalReserveAvailability)
				{
					model.TechnologicalReserve = 1;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
				}
			}
		}
	}
}
