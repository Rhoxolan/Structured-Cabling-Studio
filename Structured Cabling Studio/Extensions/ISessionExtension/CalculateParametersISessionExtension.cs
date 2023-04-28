using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudio.DTOs;

namespace StructuredCablingStudio.Extensions.ISessionExtension
{
	public static class CalculateParametersISessionExtension
	{
		private static readonly string key = "calculateParameters";

		public static void SetCalculateParameters(this ISession session, CalculateParameters parameters)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			session.SetString(key, JsonSerializer.Serialize(parameters, options));
		}

		public static CalculateParameters? GetCalculateParameters(this ISession session)
		{
			string? str = session.GetString(key);
			if (str != null)
			{
				var options = new JsonSerializerOptions
				{
					WriteIndented = true,
					ReferenceHandler = ReferenceHandler.Preserve,
				};
				return JsonSerializer.Deserialize<CalculateParameters>(str, options);
			}
			return null;
		}
	}
}
