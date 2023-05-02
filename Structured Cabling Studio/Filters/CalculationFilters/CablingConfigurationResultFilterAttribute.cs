using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Extensions.ISessionExtension;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class CablingConfigurationResultFilterAttribute : ActionFilterAttribute
	{
		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if(_ = context.HttpContext.Session.GetCablingConfiguration() != null)
			{
				context.HttpContext.Session.DeleteCablingConfiguration();
			}
			await next();
		}
	}
}