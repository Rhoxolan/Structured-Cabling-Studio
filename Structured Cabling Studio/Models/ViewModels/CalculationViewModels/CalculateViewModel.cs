using System.ComponentModel.DataAnnotations;

namespace StructuredCablingStudio.Models.ViewModels.CalculationViewModels
{
	public class CalculateViewModel
	{
		public string? RecordTime { get; set; }

		public double MinPermanentLink { get; set; } = 25;

		public double MaxPermanentLink { get; set; } = 75;

		public int NumberOfWorkplaces { get; set; } = 10;

		public int NumberOfPorts { get; set; } = 2;

		public double? CableHankMeterage { get; set; } = 305;

		public string? ApprovedCalculation { get; set; }

		public string? ApprovedRestoreDefaults { get; set; }

		public bool IsStrictComplianceWithTheStandart { get; set; }

		public bool IsAnArbitraryNumberOfPorts { get; set; }

		public bool IsTechnologicalReserveAvailability { get; set; }

		public bool IsRecommendationsAvailability { get; set; }

		public bool IsCableHankMeterageAvailability { get; set; }

		public bool IsCableRouteRunOutdoors { get; set; }

		public bool IsConsiderFireSafetyRequirements { get; set; }

		public bool IsCableShieldingNecessity { get; set; }

		public bool HasTenBase_T { get; set; }

		public bool HasFastEthernet { get; set; }

		public bool HasGigabitBASE_T { get; set; }

		public bool HasGigabitBASE_TX { get; set; }

		public bool HasTwoPointFiveGBASE_T { get; set; }

		public bool HasFiveGBASE_T { get; set; }

		public bool HasTenGE { get; set; }
	}
}
