using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ApprovedRestoreDefaultsActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			string? modelValue = context.ModelState.GetValueOrDefault("ApprovedRestoreDefaults")?.RawValue?.ToString();
			if (modelValue == "approved")
			{
				context.ModelState.SetModelValue("ApprovedRestoreDefaults", "", default);
			}
		}
	}
}
