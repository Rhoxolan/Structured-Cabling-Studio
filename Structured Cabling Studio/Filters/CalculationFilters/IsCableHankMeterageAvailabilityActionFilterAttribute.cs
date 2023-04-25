using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsCableHankMeterageAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			bool? isCableHankMeterageAvailability = context.ModelState.CheckModelStateCheckBoxValue("IsCableHankMeterageAvailability");
			if (isCableHankMeterageAvailability is not null)
			{
				if (!isCableHankMeterageAvailability.Value)
				{
					context.ModelState.SetModelValue("CableHankMeterage", "", default);
				}
			}
		}
	}
}
