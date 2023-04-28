using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.DTOs
{
	public class StructuredCablingParameters
	{
		public bool IsStrictComplianceWithTheStandart { get; set; }

		public bool IsAnArbitraryNumberOfPorts { get; set; }
		
		public bool IsTechnologicalReserveAvailability { get; set; }

		public bool IsRecommendationsAvailability { get; set; }
		
		public double TechnologicalReserve { get; set; }

		public RecommendationsArguments RecommendationsArguments { get; set; } = new();
	}

	public class CalculateParameters
	{
		public bool IsCableHankMeterageAvailability { get; set; }
	}
}
