namespace StructuredCablingStudio.Models.ViewModels.CalculationViewModels
{
	public class CalculateViewModel
	{
		public string? ApprovedCalculation { get; set; }

		public string? ApprovedRestoreDefaults { get; set; }

		public bool IsStrictComplianceWithTheStandart { get; set; }

		public bool IsAnArbitraryNumberOfPorts { get; set; }

		public bool IsTechnologicalReserveAvailability { get; set; }

		public bool IsRecommendationsAvailability { get; set; }

		public bool IsCableHankMeterageAvailability { get; set; }
	}
}
