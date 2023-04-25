using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsTechnologicalReserveAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			bool? isTechnologicalReserveAvailability = context.ModelState.CheckModelStateCheckBoxValue("IsTechnologicalReserveAvailability");
			if (isTechnologicalReserveAvailability is not null)
			{
				if (!isTechnologicalReserveAvailability.Value)
				{
					context.ModelState.SetModelValue("TechnologicalReserve", 1, default);
				}
			}
		}
	}
}
