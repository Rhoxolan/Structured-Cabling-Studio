using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Repositories;

namespace StructuredCablingStudio.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddCablingConfigurationsInteractionBasis(this IServiceCollection services, WebApplicationBuilder builder)
			=> services.AddScoped<IApplicationRepository<CablingConfigurationEntity>, DbApplicationRepository>()
			.AddDbContext<ApplicationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("CablingConfigurationsDB")));
	}
}
