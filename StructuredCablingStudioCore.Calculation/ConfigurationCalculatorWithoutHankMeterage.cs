using StructuredCablingStudioCore.Parameters;
using System.Text;

namespace StructuredCablingStudioCore.Calculation
{
	/// <summary>
	/// Presents the calculate method of structured cabling configuration without cable hank meterage
	/// </summary>
	internal class ConfigurationCalculatorWithoutHankMeterage : IConfigurationCalculatorStrategy
	{
		/// <summary>
		/// Calculation method of structured cabling configuration without cable hank meterage
		/// </summary>
		public CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
		{
			double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
			double totalCableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
			return new CablingConfiguration
			{
				RecordTime = DateTime.Now,
				MinPermanentLink = minPermanentLink,
				MaxPermanentLink = maxPermanentLink,
				AveragePermanentLink = averagePermanentLink,
				NumberOfWorkplaces = numberOfWorkplaces,
				NumberOfPorts = numberOfPorts,
				TotalCableQuantity = totalCableQuantity,
				Recommendations = new()
				{
					["Insulation Type"] = parameters.CableSelectionRecommendations.RecommendationIsolationType,
					["Insulation Material"] = parameters.CableSelectionRecommendations.RecommendationIsolationMaterial,
					["Standart"] = parameters.CableSelectionRecommendations.RecommendationCableStandard,
					["Shielding"] = parameters.CableSelectionRecommendations.RecommendationShieldedType
				}
			};
		}
	}
}
