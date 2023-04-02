using Microsoft.AspNetCore.Identity;

namespace StructuredCablingStudio.Data.Entities
{
    public class User : IdentityUser
    {
        public List<CablingConfigurationEntity> Configurations { get; set; } = default!;
    }
}