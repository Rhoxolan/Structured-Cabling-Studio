using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StructuredCablingStudio.DTOs.CalculateDTOs;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class CalculateDTOModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context?.Metadata?.ModelType == typeof(CalculateDTO))
			{
				return new BinderTypeModelBinder(typeof(CalculateDTOModelBinder));
			}
			return null;
		}
	}
}
