using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration
    /// </summary>
    internal interface IConfigurationCalculateStrategy
    {
        /// <summary>
        /// Calculation method of structured cabling configuration
        /// </summary>
        CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, DateTime recordTime, double minPermanentLink, double maxPermanentLink,
            int numberOfWorkplaces, int numberOfPorts);

        /// <summary>
        /// Value of the cable hank meterage
        /// </summary>
		int? CableHankMeterage { get; set; }
	}
}
