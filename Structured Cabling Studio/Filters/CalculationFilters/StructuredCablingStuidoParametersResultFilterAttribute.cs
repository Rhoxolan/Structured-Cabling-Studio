using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class StructuredCablingStuidoParametersResultFilterAttribute : Attribute, IResultFilter
	{
		public void OnResultExecuting(ResultExecutingContext context)
		{
			bool? isStrictComplianceWithTheStandart = context.ModelState.CheckModelStateCheckBoxValue("IsStrictComplianceWithTheStandart");
			bool? isAnArbitraryNumberOfPorts = context.ModelState.CheckModelStateCheckBoxValue("IsAnArbitraryNumberOfPorts");
			bool? isTechnologicalReserveAvailability = context.ModelState.CheckModelStateCheckBoxValue("IsTechnologicalReserveAvailability");
			bool? isRecommendationsAvailability = context.ModelState.CheckModelStateCheckBoxValue("IsRecommendationsAvailability");
			double technologicalReserve = Convert.ToDouble(context.ModelState.GetValueOrDefault("TechnologicalReserve")?.RawValue);
			bool? isCableRouteRunOutdoors = context.ModelState.CheckModelStateCheckBoxValue("IsCableRouteRunOutdoors");
			bool? isConsiderFireSafetyRequirements = context.ModelState.CheckModelStateCheckBoxValue("IsConsiderFireSafetyRequirements");
			bool? isCableShieldingNecessity = context.ModelState.CheckModelStateCheckBoxValue("IsCableShieldingNecessity");
			bool? hasTenBase_T = context.ModelState.CheckModelStateCheckBoxValue("HasTenBase_T");
			bool? hasFastEthernet = context.ModelState.CheckModelStateCheckBoxValue("HasFastEthernet");
			bool? hasGigabitBASE_T = context.ModelState.CheckModelStateCheckBoxValue("HasGigabitBASE_T");
			bool? hasGigabitBASE_TX = context.ModelState.CheckModelStateCheckBoxValue("HasGigabitBASE_TX");
			bool? hasTwoPointFiveGBASE_T = context.ModelState.CheckModelStateCheckBoxValue("HasTwoPointFiveGBASE_T");
			bool? hasFiveGBASE_T = context.ModelState.CheckModelStateCheckBoxValue("HasFiveGBASE_T");
			bool? hasTenGE = context.ModelState.CheckModelStateCheckBoxValue("HasTenGE");
			if (isStrictComplianceWithTheStandart != null && isAnArbitraryNumberOfPorts != null && isTechnologicalReserveAvailability != null &&
				isRecommendationsAvailability != null && technologicalReserve != 0 && isCableRouteRunOutdoors != null &&
				isConsiderFireSafetyRequirements != null && isCableShieldingNecessity != null && hasTenBase_T != null &&
				hasFastEthernet != null && hasGigabitBASE_T != null && hasGigabitBASE_TX != null &&
				hasTwoPointFiveGBASE_T != null && hasFiveGBASE_T != null && hasTenGE != null)
			{
				StructuredCablingParameters parameters = new StructuredCablingParameters
				{
					IsStrictСomplianceWithTheStandart = isStrictComplianceWithTheStandart.Value,
					IsAnArbitraryNumberOfPorts = isAnArbitraryNumberOfPorts.Value,
					IsTechnologicalReserveAvailability = isTechnologicalReserveAvailability.Value,
					IsRecommendationsAvailability = isRecommendationsAvailability.Value,
					TechnologicalReserve = technologicalReserve
				};
				if (isCableRouteRunOutdoors.Value)
				{
					parameters.RecommendationsArguments.IsolationType = IsolationType.Outdoor;
				}
				else
				{
					parameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
				}
				if (isConsiderFireSafetyRequirements.Value)
				{
					parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
				}
				else
				{
					parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.PVC;
				}
				//Продолжить
			}
		}

		public void OnResultExecuted(ResultExecutedContext context)
		{
		}
	}
}
