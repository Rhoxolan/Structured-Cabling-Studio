using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;

namespace StructuredCablingStudio.Extensions.IServiceCollectionExtensions
{
    public static class AddDataInteractionBasisExtension
    {
        public static IServiceCollection AddDataInteractionBasis(this IServiceCollection services, WebApplicationBuilder builder)
            => services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CablingConfigurationsDB")));
    }
}
