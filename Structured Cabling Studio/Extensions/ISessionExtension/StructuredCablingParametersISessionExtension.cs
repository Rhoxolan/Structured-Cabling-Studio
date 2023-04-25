using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Extensions.ISessionExtension
{
	public static class StructuredCablingParametersISessionExtension
	{
		private static readonly string key = "parameters";

		public static void SetStructuredCablingParameters(this ISession session, (bool?, bool?, bool?, bool?, double, RecommendationsArguments) parameters)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
				IncludeFields = true
			};
			session.SetString(key, JsonSerializer.Serialize(parameters, options));
		}

		public static (bool? IsStrictСomplianceWithTheStandart, bool? IsAnArbitraryNumberOfPorts, bool? IsTechnologicalReserveAvailability,
			bool? IsRecommendationsAvailability, double TechnologicalReserve, RecommendationsArguments RecommendationsArguments)?
			GetStructuredCablingParameters(this ISession session)
		{
			throw new NotImplementedException();
		}
	}
}
