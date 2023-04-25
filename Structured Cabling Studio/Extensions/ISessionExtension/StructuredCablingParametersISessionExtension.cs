using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudio.DTOs;

namespace StructuredCablingStudio.Extensions.ISessionExtension
{
	public static class StructuredCablingParametersISessionExtension
	{
		private static readonly string key = "parameters";

		public static void SetStructuredCablingParameters(this ISession session, StructuredCablingParameters parameters)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			session.SetString(key, JsonSerializer.Serialize(parameters, options));
		}

		public static StructuredCablingParameters? GetStructuredCablingParameters(this ISession session)
		{
			string? str = session.GetString(key);
			if (str != null)
			{
				var options = new JsonSerializerOptions
				{
					WriteIndented = true,
					ReferenceHandler = ReferenceHandler.Preserve,
				};
				return JsonSerializer.Deserialize<StructuredCablingParameters>(str, options);
			}
			return null;
		}
	}
}
