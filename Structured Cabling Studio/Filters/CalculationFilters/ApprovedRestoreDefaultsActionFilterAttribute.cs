using Microsoft.AspNetCore.Mvc.Filters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ApprovedRestoreDefaultsActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			string? modelValue = context.ModelState.GetValueOrDefault("ApprovedRestoreDefaults")?.RawValue?.ToString();
			if (modelValue == "approved")
			{
				context.ModelState.SetModelValue("ApprovedRestoreDefaults", "", default);
			}
		}
	}

	public class ApprovedCalculationActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			string? modelValue = context.ModelState.GetValueOrDefault("ApprovedCalculation")?.RawValue?.ToString();
			if (modelValue == "approved")
			{
				context.ModelState.SetModelValue("ApprovedCalculation", "", default);
			}
		}
	}

	public class IsStrictComplianceWithTheStandartActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsStrictComplianceWithTheStandart")?.RawValue;
			if (rawValue is not null)
			{
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						context.ModelState.SetModelValue("IsAnArbitraryNumberOfPorts", true, default);
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						context.ModelState.SetModelValue("IsAnArbitraryNumberOfPorts", true, default);
					}
				}
			}
		}
	}

	public class IsCableHankMeterageAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsCableHankMeterageAvailability")?.RawValue;
			if (rawValue is not null)
			{
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						context.ModelState.SetModelValue("CableHankMeterage", "", default);
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						context.ModelState.SetModelValue("CableHankMeterage", "", default);
					}
				}
			}
		}
	}

	public class IsTechnologicalReserveAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsTechnologicalReserveAvailability")?.RawValue;
			if (rawValue is not null)
			{
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						context.ModelState.SetModelValue("TechnologicalReserve", 1, default);
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						context.ModelState.SetModelValue("TechnologicalReserve", 1, default);
					}
				}
			}
		}
	}

	public class IsRecommendationsAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			object? rawValue = context.ModelState.GetValueOrDefault("IsRecommendationsAvailability")?.RawValue;
			if (rawValue is not null)
			{
				var valuesChanger = () =>
				{
					context.ModelState.SetModelValue("IsCableRouteRunOutdoors", false, default);
					context.ModelState.SetModelValue("IsConsiderFireSafetyRequirements", false, default);
					context.ModelState.SetModelValue("IsCableShieldingNecessity", false, default);
					context.ModelState.SetModelValue("HasTenBase_T", false, default);
					context.ModelState.SetModelValue("HasFastEthernet", false, default);
					context.ModelState.SetModelValue("HasGigabitBASE_T", false, default);
					context.ModelState.SetModelValue("HasGigabitBASE_TX", false, default);
					context.ModelState.SetModelValue("HasTwoPointFiveGBASE_T", false, default);
					context.ModelState.SetModelValue("HasFiveGBASE_T", false, default);
					context.ModelState.SetModelValue("HasTenGE", false, default);
				};
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						valuesChanger();
					}
				}
				if (rawValue is string)
				{
					string stringValue = (string)rawValue;
					if (stringValue == "false")
					{
						valuesChanger();
					}
				}
			}
		}
	}
}
