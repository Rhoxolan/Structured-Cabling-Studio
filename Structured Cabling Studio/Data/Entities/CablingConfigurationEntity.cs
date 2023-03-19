using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Data.Entities
{
	public record CablingConfigurationEntity : CablingConfiguration
	{
		public uint Id { get; set; }
	}
}
