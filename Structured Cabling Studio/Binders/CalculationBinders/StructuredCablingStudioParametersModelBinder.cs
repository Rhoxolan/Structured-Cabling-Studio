using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudioCore.Parameters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class StructuredCablingStudioParametersModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}
			string sessionKey = "parameters";
			if(bindingContext.HttpContext.Session != null)
			{
				string? data = bindingContext.HttpContext.Session.GetString(sessionKey);
				if (data != null)
				{
					var options = new JsonSerializerOptions
					{
						WriteIndented = true,
						ReferenceHandler = ReferenceHandler.Preserve
					};
					(bool? IsStrictСomplianceWithTheStandart,
					bool? IsAnArbitraryNumberOfPorts,
					bool? IsTechnologicalReserveAvailability,
					bool? IsRecommendationsAvailability,
					double TechnologicalReserve,
					RecommendationsArguments RecommendationsArguments)? deserializableParameters
					= JsonSerializer.Deserialize<(bool?, bool?, bool?, bool?, double, RecommendationsArguments)>(data, options);
					StructuredCablingStudioParameters parameters = new();
				}
			}
			throw new NotImplementedException();
		}
	}
}
