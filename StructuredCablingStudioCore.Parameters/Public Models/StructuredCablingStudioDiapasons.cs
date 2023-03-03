namespace StructuredCablingStudioCore.Parameters
{
    /// <summary>
    /// Presents input diapasons of structured cabling configuration calculate parameters
    /// </summary>
    public class StructuredCablingStudioDiapasons
    {
        /// <summary>
        /// Input diapason of permanent link minimum value
        /// </summary>
        public required StructuredCablingStudioInputDiapason MinPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Input diapason of permanent link maximum value
        /// </summary>
        public required StructuredCablingStudioInputDiapason MaxPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Input diapason of ports count per 1 workplace
        /// </summary>
        public required StructuredCablingStudioInputDiapason NumberOfPortsDiapason { get; init; }

        /// <summary>
        /// Input diapason of workplaces count
        /// </summary>
        public required StructuredCablingStudioInputDiapason NumberOfWorkplacesDiapason { get; init; }

        /// <summary>
        /// Input diapason of cable hank meterage
        /// </summary>
        public required StructuredCablingStudioInputDiapason CableHankMeterageDiapason { get; init; }

        /// <summary>
        /// Input diapason of technological reserve value
        /// </summary>
        public required StructuredCablingStudioInputDiapason TechnologicalReserveDiapason { get; init; }
    }
}
