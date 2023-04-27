using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ApprovedRestoreDefaultsActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if(model != null)
			{
				if (model.ApprovedRestoreDefaults == "approved")
				{
					model.IsStrictComplianceWithTheStandart = true;
					context.ModelState.SetModelValue(nameof(model.IsStrictComplianceWithTheStandart), model.IsStrictComplianceWithTheStandart, default);
					model.IsAnArbitraryNumberOfPorts = true;
					context.ModelState.SetModelValue(nameof(model.IsAnArbitraryNumberOfPorts), model.IsAnArbitraryNumberOfPorts, default);
					model.IsTechnologicalReserveAvailability = true;
					context.ModelState.SetModelValue(nameof(model.IsTechnologicalReserveAvailability), model.IsTechnologicalReserveAvailability, default);
					model.TechnologicalReserve = 1.1;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
					model.IsRecommendationsAvailability = true;
					context.ModelState.SetModelValue(nameof(model.IsRecommendationsAvailability), model.IsRecommendationsAvailability, default);
					model.IsCableRouteRunOutdoors = false;
					context.ModelState.SetModelValue(nameof(model.IsCableRouteRunOutdoors), model.IsCableRouteRunOutdoors, default);
					model.IsConsiderFireSafetyRequirements = true;
					context.ModelState.SetModelValue(nameof(model.IsConsiderFireSafetyRequirements), model.IsConsiderFireSafetyRequirements, default);
					model.IsCableShieldingNecessity = false;
					context.ModelState.SetModelValue(nameof(model.IsCableShieldingNecessity), model.IsCableShieldingNecessity, default);
					model.HasTenBase_T = false;
					context.ModelState.SetModelValue(nameof(model.HasTenBase_T), model.HasTenBase_T, default);
					model.HasFastEthernet = true;
					context.ModelState.SetModelValue(nameof(model.HasFastEthernet), model.HasFastEthernet, default);
					model.HasGigabitBASE_T = true;
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_T), model.HasGigabitBASE_T, default);
					model.HasGigabitBASE_TX = false;
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_TX), model.HasGigabitBASE_TX, default);
					model.HasTwoPointFiveGBASE_T = false;
					context.ModelState.SetModelValue(nameof(model.HasTwoPointFiveGBASE_T), model.HasTwoPointFiveGBASE_T, default);
					model.HasFiveGBASE_T = false;
					context.ModelState.SetModelValue(nameof(model.HasFiveGBASE_T), model.HasFiveGBASE_T, default);
					model.HasTenGE = false;
					context.ModelState.SetModelValue(nameof(model.HasTenGE), model.HasTenGE, default);
					model.ApprovedRestoreDefaults = "";
					context.ModelState.SetModelValue(nameof(model.ApprovedRestoreDefaults), model.ApprovedRestoreDefaults, default);
				}
			}
		}
	}
}
