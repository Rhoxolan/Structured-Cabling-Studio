namespace StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels
{
    public class CalculateViewModel
    {
        public string? RecordTime { get; set; }

        public double MinPermanentLink { get; set; }

        public double MaxPermanentLink { get; set; }

        public int NumberOfWorkplaces { get; set; }

        public int NumberOfPorts { get; set; }

        public int? CableHankMeterage { get; set; }

        public double TechnologicalReserve { get; set; }

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
