using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class StructuredCablingStudioParametersModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context?.Metadata?.ModelType == typeof(StructuredCablingStudioParameters))
			{
				return new BinderTypeModelBinder(typeof(StructuredCablingStudioParametersModelBinder));
			}
			return null;
		}
	}
}
