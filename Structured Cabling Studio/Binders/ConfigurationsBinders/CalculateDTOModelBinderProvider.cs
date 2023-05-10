using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StructuredCablingStudio.DTOs.ConfigurationsDTOs;

namespace StructuredCablingStudio.Binders.ConfigurationsBinders
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
