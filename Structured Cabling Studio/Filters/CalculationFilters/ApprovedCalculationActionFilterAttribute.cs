using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ApprovedCalculationActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			string? modelValue = context.ModelState.GetValueOrDefault("ApprovedCalculation")?.RawValue?.ToString();
			if (modelValue == "approved")
			{
				context.ModelState.SetModelValue("ApprovedCalculation", "", default);
			}
		}
	}
}
