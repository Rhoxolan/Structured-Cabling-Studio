using Microsoft.AspNetCore.Mvc.Razor;

namespace StructuredCablingStudio.Extensions.IMvcBuilderExtensions
{
    public static class AddLocalizationBasisExtension
    {
        public static IMvcBuilder AddLocalizationBasis(this IMvcBuilder mvcBuilder)
            => mvcBuilder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
    }
}
