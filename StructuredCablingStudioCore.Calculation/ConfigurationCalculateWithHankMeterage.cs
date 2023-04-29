using StructuredCablingStudioCore.Parameters;
using static StructuredCablingStudioCore.Calculation.Properties.Resources;
using static System.Convert;
using static System.Globalization.CultureInfo;

namespace StructuredCablingStudioCore.Calculation
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration with cable hank meterage
    /// </summary>
    internal class ConfigurationCalculateWithHankMeterage : IConfigurationCalculateStrategy
    {
		private int? cableHankMeterage;

        public ConfigurationCalculateWithHankMeterage()
        {
            cableHankMeterage = null;
		}

		/// <summary>
		/// Calculation method of structured cabling configuration with cable hank meterage
		/// </summary>
		/// <exception cref="StructuredCablingStudioCoreException"></exception>
		public CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, DateTime recordTime, double minPermanentLink, double maxPermanentLink,
            int numberOfWorkplaces, int numberOfPorts)
        {
			if (cableHankMeterage is null)
			{
				throw new StructuredCablingStudioCoreException("Structured cabling configuration calculating error! The value of cable meterage in 1 hank is not determined");
			}
			double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
            if (averagePermanentLink > cableHankMeterage)
            {
                throw new StructuredCablingStudioCoreException("Calculation is impossible! The value of average permanent link length more than the value of cable hank meterage");
            }
            double? cableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
            int? hankQuantity = (int)Math.Ceiling(numberOfWorkplaces * numberOfPorts / Math.Floor(cableHankMeterage.Value / averagePermanentLink));
            double totalCableQuantity = hankQuantity.Value * cableHankMeterage.Value;
            return new CablingConfiguration
            {
                RecordTime = recordTime,
                MinPermanentLink = minPermanentLink,
                MaxPermanentLink = maxPermanentLink,
                AveragePermanentLink = averagePermanentLink,
                NumberOfWorkplaces = numberOfWorkplaces,
                NumberOfPorts = numberOfPorts,
                CableQuantity = cableQuantity,
                CableHankMeterage = cableHankMeterage,
                HankQuantity = hankQuantity,
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
            get
            {
                if(cableHankMeterage != null)
                {
                    return cableHankMeterage;
                }
                cableHankMeterage = ToInt32(ConfigurationCalculateWithHankMeterage_CableHankMeterage_Default, InvariantCulture);
                return cableHankMeterage;
			}
            set
            {
                cableHankMeterage = value;
			}
        }
	}
}
