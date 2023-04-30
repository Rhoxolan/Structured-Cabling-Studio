using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ApprovedCalculationActionFilterAttribute : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await next();
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if (model.ApprovedCalculation == "approved")
				{
					model.ApprovedCalculation = "";
					context.ModelState.SetModelValue(nameof(model.ApprovedCalculation), model.ApprovedCalculation, default);
				}
			}
		}
	}
}
