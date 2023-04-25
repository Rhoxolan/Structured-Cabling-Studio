using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class IsStrictComplianceWithTheStandartActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			bool? isStrictComplianceWithTheStandart = context.ModelState.CheckModelStateCheckBoxValue("IsStrictComplianceWithTheStandart");
			if(isStrictComplianceWithTheStandart is not null)
			{
				if (!isStrictComplianceWithTheStandart.Value)
				{
					context.ModelState.SetModelValue("IsAnArbitraryNumberOfPorts", true, default);
				}
			}
		}
	}
}
