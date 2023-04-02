using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Data.Entities
{
    public record CablingConfigurationEntity(uint Id) : CablingConfiguration
    {
        public User User { get; set; } = default!;
    }
}
