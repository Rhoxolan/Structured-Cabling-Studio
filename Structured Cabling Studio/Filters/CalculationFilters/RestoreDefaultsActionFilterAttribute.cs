using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class RestoreDefaultsActionFilterAttribute : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await next();
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
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
					model.IsCableHankMeterageAvailability = calculateParameters.IsCableHankMeterageAvailability.Value;
					model.CableHankMeterage = calculateParameters.CableHankMeterage;
					model.TechnologicalReserve = cablingParameters.TechnologicalReserve;
					model.IsStrictComplianceWithTheStandart = cablingParameters.IsStrictComplianceWithTheStandart.Value;
					model.IsAnArbitraryNumberOfPorts = cablingParameters.IsAnArbitraryNumberOfPorts.Value;
					model.IsTechnologicalReserveAvailability = cablingParameters.IsTechnologicalReserveAvailability.Value;
					model.IsRecommendationsAvailability = cablingParameters.IsRecommendationsAvailability.Value;
					model.IsCableRouteRunOutdoors = cablingParameters.RecommendationsArguments.IsolationType == IsolationType.Outdoor;
					model.IsConsiderFireSafetyRequirements = cablingParameters.RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH;
					model.IsCableShieldingNecessity = cablingParameters.RecommendationsArguments.ShieldedType == ShieldedType.FTP;
					model.HasTenBase_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T);
					model.HasFastEthernet = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet);
					model.HasGigabitBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_T);
					model.HasGigabitBASE_TX = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_TX);
					model.HasTwoPointFiveGBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
					model.HasFiveGBASE_T = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FiveGBASE_T);
					model.HasTenGE = cablingParameters.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenGE);
					model.ApprovedRestoreDefaults = "";
					context.ModelState.SetModelValue(nameof(model.IsCableHankMeterageAvailability), model.IsCableHankMeterageAvailability, default);
					context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
					context.ModelState.SetModelValue(nameof(model.IsStrictComplianceWithTheStandart), model.IsStrictComplianceWithTheStandart, default);
					context.ModelState.SetModelValue(nameof(model.IsAnArbitraryNumberOfPorts), model.IsAnArbitraryNumberOfPorts, default);
					context.ModelState.SetModelValue(nameof(model.IsTechnologicalReserveAvailability), model.IsTechnologicalReserveAvailability, default);
					context.ModelState.SetModelValue(nameof(model.IsRecommendationsAvailability), model.IsRecommendationsAvailability, default);
					context.ModelState.SetModelValue(nameof(model.IsCableRouteRunOutdoors), model.IsCableRouteRunOutdoors, default);
					context.ModelState.SetModelValue(nameof(model.IsConsiderFireSafetyRequirements), model.IsConsiderFireSafetyRequirements, default);
					context.ModelState.SetModelValue(nameof(model.IsCableShieldingNecessity), model.IsCableShieldingNecessity, default);
					context.ModelState.SetModelValue(nameof(model.HasTenBase_T), model.HasTenBase_T, default);
					context.ModelState.SetModelValue(nameof(model.HasFastEthernet), model.HasFastEthernet, default);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_T), model.HasGigabitBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_TX), model.HasGigabitBASE_TX, default);
					context.ModelState.SetModelValue(nameof(model.HasTwoPointFiveGBASE_T), model.HasTwoPointFiveGBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasFiveGBASE_T), model.HasFiveGBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasTenGE), model.HasTenGE, default);
					context.ModelState.SetModelValue(nameof(model.ApprovedRestoreDefaults), model.ApprovedRestoreDefaults, default);
				}
			}
		}
	}
}
