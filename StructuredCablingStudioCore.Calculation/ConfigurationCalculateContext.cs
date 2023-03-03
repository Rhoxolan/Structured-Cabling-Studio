using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
    /// <summary>
    /// Class, which encapsulates objects to work with parameters of structured cabling configuration calculating
    /// </summary>
    internal class ConfigurationCalculateContext
    {
        private IConfigurationCalculatorStrategy? configurationCalculatorStrategy;
        private ConfigurationCalculatorWithHankMeterage calculatorWithHankMeterage;
        private ConfigurationCalculatorWithoutHankMeterage calculatorWithoutHankMeterage;

        public ConfigurationCalculateContext()
        {
            configurationCalculatorStrategy = null;
            calculatorWithHankMeterage = new();
            calculatorWithoutHankMeterage = new();
        }

        /// <summary>
        /// Calculating of structured cabling configuration
        /// </summary>
        /// <exception cref="StructuredCablingStudioCoreException"></exception>
        public StructuredCablingConfiguration Calculate(StructuredCablingStudioParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
        {
            if (configurationCalculatorStrategy != null)
            {
                return configurationCalculatorStrategy.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);
            }
            throw new StructuredCablingStudioCoreException("Value of the need to consider of cable meterage in 1 hank is not initialized. Please check the parameters of calculation.");
        }

        /// <summary>
        /// The set of the value of 1 hank cable meterage consider when structured cabling configuration calculates
        /// </summary>
        public bool? IsCableHankMeterageAvailability
        {
            set
            {
                if (value is null)
                {
                    configurationCalculatorStrategy = null;
                    return;
                }
                if (Equals(value, true))
                {
                    configurationCalculatorStrategy = calculatorWithHankMeterage;
                    return;
                }
                if (Equals(value, false))
                {
                    configurationCalculatorStrategy = calculatorWithoutHankMeterage;
                }
            }
        }
    }
}