using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
	/// <summary>
	/// Class, which encapsulates objects to work with parameters of structured cabling configuration calculating
	/// </summary>
	internal class ConfigurationCalculateContext
	{
		private IConfigurationCalculateStrategy? configurationCalculateStrategy;

		public ConfigurationCalculateContext()
		{
			configurationCalculateStrategy = null;
		}

		/// <summary>
		/// Calculating of structured cabling configuration
		/// </summary>
		/// <exception cref="StructuredCablingStudioCoreException"></exception>
		public CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, double minPermanentLink, double maxPermanentLink,
			int numberOfWorkplaces, int numberOfPorts)
		{
			if (configurationCalculateStrategy != null)
			{
				return configurationCalculateStrategy.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts);
			}
			throw new StructuredCablingStudioCoreException("Value of the need to consider of cable meterage in 1 hank is not initialized. Please check the parameters of calculation.");
		}

		/// <summary>
		/// Value of the cable hank meterage
		/// </summary>
		public int? CableHankMeterage
		{
			get
			{
				if (configurationCalculateStrategy is not null)
				{
					return configurationCalculateStrategy.CableHankMeterage;
				}
				throw new StructuredCablingStudioCoreException("Value of the need to consider of cable meterage in 1 hank is not initialized. Please check the parameters of calculation.");
			}
			set
			{
				if (configurationCalculateStrategy is not null)
				{
					configurationCalculateStrategy.CableHankMeterage = value;
				}
				throw new StructuredCablingStudioCoreException("Value of the need to consider of cable meterage in 1 hank is not initialized. Please check the parameters of calculation.");
			}

		}

		/// <summary>
		/// Set and get of the value of 1 hank cable meterage consider when structured cabling configuration calculates
		/// </summary>
		public bool? IsCableHankMeterageAvailability
		{
			get
			{
				if (configurationCalculateStrategy is ConfigurationCalculateWithHankMeterage)
				{
					return true;
				}
				if (configurationCalculateStrategy is ConfigurationCalculateWithoutHankMeterage)
				{
					return false;
				}
				throw new StructuredCablingStudioCoreException("The value of cable hank meterage availability is not initialized. Please check the settings.");
			}
			set
			{
				if (value is null)
				{
					configurationCalculateStrategy = null;
					return;
				}
				if (Equals(value, true))
				{
					configurationCalculateStrategy = new ConfigurationCalculateWithHankMeterage();
					return;
				}
				if (Equals(value, false))
				{
					configurationCalculateStrategy = new ConfigurationCalculateWithoutHankMeterage();
				}
			}
		}
	}
}