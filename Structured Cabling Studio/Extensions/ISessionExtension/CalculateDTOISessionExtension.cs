using System.Text.Json.Serialization;
using System.Text.Json;
using StructuredCablingStudio.DTOs.CalculateDTOs;

namespace StructuredCablingStudio.Extensions.ISessionExtension
{
	public static class CalculateDTOISessionExtension
	{
		private static readonly string key = "calculateDTO";

		public static void SetCalculateDTO(this ISession session, CalculateDTO calculateDTO)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			session.SetString(key, JsonSerializer.Serialize(calculateDTO, options));
		}

		public static CalculateDTO? GetCalculateDTO(this ISession session)
		{
			string? str = session.GetString(key);
			if (str != null)
			{
				var options = new JsonSerializerOptions
				{
					WriteIndented = true,
					ReferenceHandler = ReferenceHandler.Preserve,
				};
				return JsonSerializer.Deserialize<CalculateDTO>(str, options);
			}
			return null;
		}
	}
}
