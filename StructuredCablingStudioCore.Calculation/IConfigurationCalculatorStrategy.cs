using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration
    /// </summary>
    internal interface IConfigurationCalculatorStrategy
    {
        /// <summary>
        /// Calculation method of structured cabling configuration
        /// </summary>
        CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, int? cableHankMeterage);
    }
}
