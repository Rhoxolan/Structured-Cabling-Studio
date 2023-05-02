using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudio.Extensions.ISessionExtension;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class CablingConfigurationModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext?.HttpContext?.Session != null)
			{
				bindingContext.Result = ModelBindingResult.Success(bindingContext.HttpContext.Session.GetCablingConfiguration());
			}
			return Task.CompletedTask;
		}
	}
}
