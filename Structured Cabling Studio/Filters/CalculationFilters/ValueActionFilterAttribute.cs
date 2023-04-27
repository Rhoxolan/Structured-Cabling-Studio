using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ValueActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if(model.CableHankMeterage != null && model.CableHankMeterage.Value != 0)
				{
					var ceiledAveragePermanentLink = (int)Math.Ceiling((model.MinPermanentLink + model.MaxPermanentLink) / 2 * model.TechnologicalReserve);
					if (model.CableHankMeterage < ceiledAveragePermanentLink)
					{
						model.CableHankMeterage = ceiledAveragePermanentLink;
						context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
					}
				}
			}
		}
	}
}
