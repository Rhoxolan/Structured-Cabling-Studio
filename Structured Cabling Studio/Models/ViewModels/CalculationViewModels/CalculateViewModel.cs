using static System.String;

namespace StructuredCablingStudio.Models.ViewModels.CalculationViewModels
{
	public class CalculateViewModel
	{
		public string ApprovedCalculation { get; set; } = Empty;

		public string ApprovedRestoreDefaults { get; set; } = Empty;

		public bool IsStrictComplianceWithTheStandart { get; set; }

		public bool IsAnArbitraryNumberOfPorts { get; set; }

		public bool IsTechnologicalReserveAvailability { get; set; }

		public bool IsRecommendationsAvailability { get; set; }

		public bool IsCableHankMeterageAvailability { get; set; }

		public bool HasTenBase_T { get; set; }

		public bool HasFastEthernet { get; set; }

		public bool HasGigabitBASE_T { get; set; }

		public bool HasGigabitBASE_TX { get; set; }

		public bool HasTwoPointFiveGBASE_T { get; set; }

		public bool HasFiveGBASE_T { get; set; }

		public bool HasTenGE { get; set; }
	}
}
