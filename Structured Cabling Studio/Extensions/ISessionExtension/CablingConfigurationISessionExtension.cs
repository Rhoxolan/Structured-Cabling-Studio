using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Extensions.ISessionExtension
{
	public static class CablingConfigurationISessionExtension
	{
		private static readonly string key = "cablingConfiguration";

		public static void SetCablingConfiguration(this ISession session, CablingConfiguration configuration)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			session.SetString(key, JsonSerializer.Serialize(configuration, options));
		}

		public static CablingConfiguration? GetCablingConfiguration(this ISession session)
		{
			string? str = session.GetString(key);
			if (str != null)
			{
				var options = new JsonSerializerOptions
				{
					WriteIndented = true,
					ReferenceHandler = ReferenceHandler.Preserve,
				};
				return JsonSerializer.Deserialize<CablingConfiguration>(str, options);
			}
			return null;
		}
	}
}
