using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;
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
					var cablingParameters = new StructuredCablingStudioParameters
					{
						IsStrictComplianceWithTheStandart = true,
						IsAnArbitraryNumberOfPorts = true,
						IsTechnologicalReserveAvailability = true,
						IsRecommendationsAvailability = true
					};
					cablingParameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
					cablingParameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
					cablingParameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
					cablingParameters.RecommendationsArguments.ConnectionInterfaces = new List<ConnectionInterfaceStandard>
					{
						ConnectionInterfaceStandard.FastEthernet,
						ConnectionInterfaceStandard.GigabitBASE_T
					};
					var calculateParameters = new ConfigurationCalculateParameters
					{
						IsCableHankMeterageAvailability = true
					};
					model.TechnologicalReserve = cablingParameters.TechnologicalReserve;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
					model.IsStrictComplianceWithTheStandart = cablingParameters.IsStrictComplianceWithTheStandart.Value;
					context.ModelState.SetModelValue(nameof(model.IsStrictComplianceWithTheStandart), model.IsStrictComplianceWithTheStandart, default);
					model.IsAnArbitraryNumberOfPorts = cablingParameters.IsAnArbitraryNumberOfPorts.Value;
					context.ModelState.SetModelValue(nameof(model.IsAnArbitraryNumberOfPorts), model.IsAnArbitraryNumberOfPorts, default);
					model.IsTechnologicalReserveAvailability = cablingParameters.IsTechnologicalReserveAvailability.Value;
					context.ModelState.SetModelValue(nameof(model.IsTechnologicalReserveAvailability), model.IsTechnologicalReserveAvailability, default);
					model.IsRecommendationsAvailability = cablingParameters.IsRecommendationsAvailability.Value;
					context.ModelState.SetModelValue(nameof(model.IsRecommendationsAvailability), model.IsRecommendationsAvailability, default);
					model.IsCableRouteRunOutdoors = cablingParameters.RecommendationsArguments.IsolationType == IsolationType.Outdoor;
					context.ModelState.SetModelValue(nameof(model.IsCableRouteRunOutdoors), model.IsCableRouteRunOutdoors, default);
					model.IsConsiderFireSafetyRequirements = cablingParameters.RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH;
					context.ModelState.SetModelValue(nameof(model.IsConsiderFireSafetyRequirements), model.IsConsiderFireSafetyRequirements, default);
					model.IsCableShieldingNecessity = cablingParameters.RecommendationsArguments.ShieldedType == ShieldedType.FTP;
					context.ModelState.SetModelValue(nameof(model.IsCableShieldingNecessity), model.IsCableShieldingNecessity, default);
					model.HasTenBase_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasTenBase_T), model.HasTenBase_T, default);
					model.HasFastEthernet = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet);
					context.ModelState.SetModelValue(nameof(model.HasFastEthernet), model.HasFastEthernet, default);
					model.HasGigabitBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_T), model.HasGigabitBASE_T, default);
					model.HasGigabitBASE_TX = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_TX);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_TX), model.HasGigabitBASE_TX, default);
					model.HasTwoPointFiveGBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasTwoPointFiveGBASE_T), model.HasTwoPointFiveGBASE_T, default);
					model.HasFiveGBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FiveGBASE_T);
					context.ModelState.SetModelValue(nameof(model.HasFiveGBASE_T), model.HasFiveGBASE_T, default);
					model.HasTenGE = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenGE);
					context.ModelState.SetModelValue(nameof(model.HasTenGE), model.HasTenGE, default);
					model.ApprovedRestoreDefaults = "";
					context.ModelState.SetModelValue(nameof(model.ApprovedRestoreDefaults), model.ApprovedRestoreDefaults, default);
				}
			}
		}
	}
}
