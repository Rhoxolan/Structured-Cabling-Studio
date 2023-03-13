using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;

namespace StructuredCablingStudio.Extensions.IServiceCollectionExtensions
{
    public static class AddCablingConfigurationsInteractionBasisExtension
    {
        public static IServiceCollection AddCablingConfigurationsInteractionBasis(this IServiceCollection services, WebApplicationBuilder builder)
            => services.AddDbContext<ApplicationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("CablingConfigurationsDB")));
    }
}
