using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.Binders.ConfigurationsBinders
{
    public class ConfigurationCalculateParametersModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context?.Metadata?.ModelType == typeof(ConfigurationCalculateParameters))
            {
                return new BinderTypeModelBinder(typeof(ConfigurationCalculateParametersModelBinder));
            }
            return null;
        }
    }
}
