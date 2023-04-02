using Microsoft.AspNetCore.Identity;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;

namespace StructuredCablingStudio.Extensions.IServiceCollectionExtensions
{
    public static class AddIdentityInteractionBasisExtension
    {
        public static IdentityBuilder AddIdentityInteractionBasis(this IServiceCollection services)
            => services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>();
    }
}
