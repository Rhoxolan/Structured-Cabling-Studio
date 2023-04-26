using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsStrictComplianceWithTheStandartActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if (!model.IsStrictComplianceWithTheStandart)
				{
					model.IsAnArbitraryNumberOfPorts = true;
					context.ModelState.SetModelValue(nameof(model.IsAnArbitraryNumberOfPorts), model.IsAnArbitraryNumberOfPorts, default);
				}
			}
		}
	}
}
