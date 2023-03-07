using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Repositories;
using System.Globalization;

namespace StructuredCablingStudio.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddCablingConfigurationsInteractionBasis(this IServiceCollection services, WebApplicationBuilder builder)
			=> services.AddScoped<IApplicationRepository<CablingConfigurationEntity>, DbApplicationRepository>()
			.AddDbContext<ApplicationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("CablingConfigurationsDB")));

		public static IServiceCollection AddLocalizationBasis(this IServiceCollection services)
			=> services.AddLocalization(options => options.ResourcesPath = "Resources").Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo("ru"),
					new CultureInfo("en"),
					new CultureInfo("ua")
				};
				options.DefaultRequestCulture = new RequestCulture("ru");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});
	}
}
