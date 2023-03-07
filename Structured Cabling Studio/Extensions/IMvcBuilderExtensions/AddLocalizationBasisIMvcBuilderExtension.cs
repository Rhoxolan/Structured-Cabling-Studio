using Microsoft.AspNetCore.Mvc.Razor;

namespace StructuredCablingStudio.Extensions.IMvcBuilderExtensions
{
    public static class AddLocalizationBasisIMvcBuilderExtension
    {
        public static IMvcBuilder AddLocalizationBasis(this IMvcBuilder mvcBuilder)
            => mvcBuilder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
    }
}
