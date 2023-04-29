using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
	/// <summary>
	/// Presents the calculate method of structured cabling configuration without cable hank meterage
	/// </summary>
	internal class ConfigurationCalculateWithoutHankMeterage : IConfigurationCalculateStrategy
	{
		/// <summary>
		/// Calculation method of structured cabling configuration without cable hank meterage
		/// </summary>
		public CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, DateTime recordTime, double minPermanentLink, double maxPermanentLink,
			int numberOfWorkplaces, int numberOfPorts)
		{
			double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
			double totalCableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
			return new CablingConfiguration
			{
				RecordTime = recordTime,
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

		/// <summary>
		/// Value of the cable hank meterage
		/// </summary>
		public int? CableHankMeterage
		{
			get => null;
			set => throw new StructuredCablingStudioCoreException("Value of the cable hank meterage is not taken into account. Please check the settings.");
		}
	}
}
