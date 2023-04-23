using static StructuredCablingStudioCore.Parameters.Properties.Resources;
using static System.Convert;
using static System.Globalization.CultureInfo;

namespace StructuredCablingStudioCore.Parameters
{
    //Encapsulates in DiapasonContext class.

    /// <summary>
    /// Class for work with technological reserve coefficient value if it availability is disabled
    /// </summary>
    internal class NonTechnologicalReserveStrategy : ITechnologicalReserveStrategy
    {
        private double technologicalReserve;

        public NonTechnologicalReserveStrategy()
        {
            technologicalReserve = ToDouble(NonTechnologicalReserve_TechnologicalReserve, InvariantCulture);
        }

        /// <summary>
        /// Technological reserve coefficient value
        /// </summary>
        public double TechnologicalReserve
        {
            get => technologicalReserve;

            set => throw new StructuredCablingStudioCoreException("Technological reserve coefficient is not taken into account. Please check the settings.");
        }
    }
}
