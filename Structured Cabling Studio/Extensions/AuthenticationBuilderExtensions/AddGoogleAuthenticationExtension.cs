using Microsoft.AspNetCore.Authentication;

namespace StructuredCablingStudio.Extensions.AuthenticationBuilderExtensions
{
    public static class AddGoogleAuthenticationExtension
    {
        public static AuthenticationBuilder AddGoogleAuthentication(this AuthenticationBuilder authenticationBuilder, WebApplicationBuilder applicationBuilder)
            => authenticationBuilder.AddGoogle(opt =>
            {
                var googleSection = applicationBuilder.Configuration.GetSection("Authentication:Google");
                opt.ClientId = googleSection["ClientId"]!;
                opt.ClientSecret = googleSection["ClientSecret"]!;
            });
    }
}