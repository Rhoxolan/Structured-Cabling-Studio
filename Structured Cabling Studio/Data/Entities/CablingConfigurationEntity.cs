using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Data.Entities
{
	public record CablingConfigurationEntity : CablingConfiguration
	{
		public uint Id { get; set; }
		
		public ICollection<CableSelectionRecommendationEntity> CableSelectionRecommendations { get; set; } = default!;
	}

	public class CableSelectionRecommendationEntity
	{
		public uint Id { get; set; }

		public string Name { get; set; } = default!;

		public string Value { get; set; } = default!;

		public uint CablingConfigurationId { get; set; }

		public CablingConfigurationEntity CablingConfiguration { get; set; } = default!;
	}
}
