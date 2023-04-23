using static StructuredCablingStudioCore.Parameters.Properties.Resources;
using static System.Convert;

namespace StructuredCablingStudioCore.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determine of structured cabling configuration input standard parameters diapasons
    /// </summary>
    internal class StandartValuesStrategy : IStandartValuesStrategy
    {
        private (decimal Min, decimal Max) numberOfWorkplacesDiapason;
        private (decimal Min, decimal Max) cableHankMeterageDiapason;
        private (decimal Min, decimal Max) technologicalReserveDiapason;

        public StandartValuesStrategy()
        {
            numberOfWorkplacesDiapason = (ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Min, System.Globalization.CultureInfo.InvariantCulture), ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Max, System.Globalization.CultureInfo.InvariantCulture));
            cableHankMeterageDiapason = (ToDecimal(StandartValues_CableHankMeterageDiapason_Min, System.Globalization.CultureInfo.InvariantCulture), ToDecimal(StandartValues_CableHankMeterageDiapason_Max, System.Globalization.CultureInfo.InvariantCulture));
            technologicalReserveDiapason = (ToDecimal(StandartValues_TechnologicalReserveDiapason_Min, System.Globalization.CultureInfo.InvariantCulture), ToDecimal(StandartValues_TechnologicalReserveDiapason_Max, System.Globalization.CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Determines of workplaces count input diapason
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason
        {
            get => numberOfWorkplacesDiapason;
        }

        /// <summary>
        /// Determines diapason of cable hank meterage input
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason
        {
            get => cableHankMeterageDiapason;
        }

        /// <summary>
        /// Determines diapason of technological reserve value input
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason
        {
            get => technologicalReserveDiapason;
        }
    }
}
