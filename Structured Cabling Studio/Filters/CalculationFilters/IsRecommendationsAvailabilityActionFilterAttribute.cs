using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsRecommendationsAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			bool? isRecommendationsAvailability = context.ModelState.CheckModelStateCheckBoxValue("IsRecommendationsAvailability");
			if (isRecommendationsAvailability is not null)
			{
				if (!isRecommendationsAvailability.Value)
				{
					context.ModelState.SetModelValue("IsCableRouteRunOutdoors", false, default);
					context.ModelState.SetModelValue("IsConsiderFireSafetyRequirements", false, default);
					context.ModelState.SetModelValue("IsCableShieldingNecessity", false, default);
					context.ModelState.SetModelValue("HasTenBase_T", false, default);
					context.ModelState.SetModelValue("HasFastEthernet", false, default);
					context.ModelState.SetModelValue("HasGigabitBASE_T", false, default);
					context.ModelState.SetModelValue("HasGigabitBASE_TX", false, default);
					context.ModelState.SetModelValue("HasTwoPointFiveGBASE_T", false, default);
					context.ModelState.SetModelValue("HasFiveGBASE_T", false, default);
					context.ModelState.SetModelValue("HasTenGE", false, default);
				}
			}
		}
	}
}
