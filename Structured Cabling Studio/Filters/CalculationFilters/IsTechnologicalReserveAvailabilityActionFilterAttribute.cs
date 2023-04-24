using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsTechnologicalReserveAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsTechnologicalReserveAvailability")?.RawValue;
			if (rawValue is not null)
			{
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						context.ModelState.SetModelValue("TechnologicalReserve", 1, default);
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						context.ModelState.SetModelValue("TechnologicalReserve", 1, default);
					}
				}
			}
		}
	}
}
