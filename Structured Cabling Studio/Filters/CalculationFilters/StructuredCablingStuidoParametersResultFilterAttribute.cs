using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class StructuredCablingStuidoParametersResultFilterAttribute : Attribute, IResultFilter
	{
		public void OnResultExecuting(ResultExecutingContext context)
		{

		}

		public void OnResultExecuted(ResultExecutedContext context)
		{
		}
	}
}
