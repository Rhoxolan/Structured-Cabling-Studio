using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsRecommendationsAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsRecommendationsAvailability")?.RawValue;
			if (rawValue is not null)
			{
				var valuesChanger = () =>
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
				};
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						valuesChanger();
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						valuesChanger();
					}
				}
			}
		}
	}
}
