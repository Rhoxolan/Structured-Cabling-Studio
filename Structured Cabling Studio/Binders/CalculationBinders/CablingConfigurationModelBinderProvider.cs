using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class CablingConfigurationModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context?.Metadata?.ModelType == typeof(CablingConfiguration))
			{
				return new BinderTypeModelBinder(typeof(CablingConfigurationModelBinder));
			}
			return null;
		}
	}
}
