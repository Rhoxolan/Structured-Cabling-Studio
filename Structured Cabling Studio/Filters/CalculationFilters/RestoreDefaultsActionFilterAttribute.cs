using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class RestoreDefaultsActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if(model != null)
			{
				if (model.ApprovedRestoreDefaults == "approved")
				{
					StructuredCablingStudioParameters parameters = new StructuredCablingStudioParameters
					{
						IsStrictComplianceWithTheStandart = true,
						IsAnArbitraryNumberOfPorts = true,
						IsTechnologicalReserveAvailability = true,
						IsRecommendationsAvailability = true
					};
					parameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
					parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
					parameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
					parameters.RecommendationsArguments.ConnectionInterfaces = new List<ConnectionInterfaceStandard>
					{
						ConnectionInterfaceStandard.FastEthernet,
						ConnectionInterfaceStandard.GigabitBASE_T
					};
					model.TechnologicalReserve = parameters.TechnologicalReserve;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
					model.IsStrictComplianceWithTheStandart = parameters.IsStrictComplianceWithTheStandart.Value;
					context.ModelState.SetModelValue(nameof(model.IsStrictComplianceWithTheStandart), model.IsStrictComplianceWithTheStandart, default);
					model.IsAnArbitraryNumberOfPorts = parameters.IsAnArbitraryNumberOfPorts.Value;
					context.ModelState.SetModelValue(nameof(model.IsAnArbitraryNumberOfPorts), model.IsAnArbitraryNumberOfPorts, default);
					model.IsTechnologicalReserveAvailability = parameters.IsTechnologicalReserveAvailability.Value;
					context.ModelState.SetModelValue(nameof(model.IsTechnologicalReserveAvailability), model.IsTechnologicalReserveAvailability, default);
					model.IsRecommendationsAvailability = parameters.IsRecommendationsAvailability.Value;
					context.ModelState.SetModelValue(nameof(model.IsRecommendationsAvailability), model.IsRecommendationsAvailability, default);
					model.IsCableRouteRunOutdoors = parameters.RecommendationsArguments.IsolationType == IsolationType.Outdoor;
					context.ModelState.SetModelValue(nameof(model.IsCableRouteRunOutdoors), model.IsCableRouteRunOutdoors, default);
					model.IsConsiderFireSafetyRequirements = parameters.RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH;
					context.ModelState.SetModelValue(nameof(model.IsConsiderFireSafetyRequirements), model.IsConsiderFireSafetyRequirements, default);
					model.IsCableShieldingNecessity = parameters.RecommendationsArguments.ShieldedType == ShieldedType.FTP;
					context.ModelState.SetModelValue(nameof(model.IsCableShieldingNecessity), model.IsCableShieldingNecessity, default);
					model.HasTenBase_T = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasTenBase_T), model.HasTenBase_T, default);
					model.HasFastEthernet = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet);
					context.ModelState.SetModelValue(nameof(model.HasFastEthernet), model.HasFastEthernet, default);
					model.HasGigabitBASE_T = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_T), model.HasGigabitBASE_T, default);
					model.HasGigabitBASE_TX = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_TX);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_TX), model.HasGigabitBASE_TX, default);
					model.HasTwoPointFiveGBASE_T = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasTwoPointFiveGBASE_T), model.HasTwoPointFiveGBASE_T, default);
					model.HasFiveGBASE_T = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FiveGBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasFiveGBASE_T), model.HasFiveGBASE_T, default);
					model.HasTenGE = parameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenGE);
					context.ModelState.SetModelValue(nameof(model.HasTenGE), model.HasTenGE, default);
					model.ApprovedRestoreDefaults = "";
					context.ModelState.SetModelValue(nameof(model.ApprovedRestoreDefaults), model.ApprovedRestoreDefaults, default);
				}
			}
		}
	}
}
