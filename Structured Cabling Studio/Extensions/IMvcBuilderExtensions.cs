using Microsoft.AspNetCore.Mvc.Razor;

namespace StructuredCablingStudio.Extensions
{
	public static class IMvcBuilderExtensions
	{
		public static IMvcBuilder AddLocalizationBasis(this IMvcBuilder mvcBuilder)
			=> mvcBuilder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
			.AddDataAnnotationsLocalization();
	}
}
