using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using StructuredCablingStudioCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using static System.Text.Encoding;
using static System.String;
using StructuredCablingStudio.Loggers;

namespace StructuredCablingStudio.Controllers
{
	public class Calculation : Controller
	{
		private readonly IStringLocalizer<Calculation> _localizer;
		private readonly ICustomFileLogger _customLogger;

		public Calculation(IStringLocalizer<Calculation> localizer, ICustomFileLogger customLogger)
		{
			_localizer = localizer;
			_customLogger = customLogger;
		}

		public IActionResult Calculate()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the Calculate page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[Authorize]
		public IActionResult History()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the History page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		public IActionResult Information()
		{
			_customLogger.Log("pagesloading.log",
				$"The loading of the Information page was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			return View();
		}

		[HttpPost]
		public IActionResult SaveToTXT(string serializedCablingConfiguration)
		{
			_customLogger.Log("cablingconfigurationstxtsaving.log",
				$"The saving to txt of the cabling configuration was requested from the " +
				$"{HttpContext.Connection.RemoteIpAddress?.ToString()} ip-address");
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				ReferenceHandler = ReferenceHandler.Preserve,
			};
			var cablingConfiguration = JsonSerializer.Deserialize<CablingConfiguration>(serializedCablingConfiguration, options);
			if (cablingConfiguration != null)
			{
				var fileName = $"{_localizer["StructuredCablingConfiguration"]} " +
					$"{cablingConfiguration.RecordTime.Day:00}." +
					$"{cablingConfiguration.RecordTime.Month:00}." +
					$"{cablingConfiguration.RecordTime.Year} " +
					$"{cablingConfiguration.RecordTime.Hour:00}." +
					$"{cablingConfiguration.RecordTime.Minute:00}." +
					$"{cablingConfiguration.RecordTime.Second:00}.txt";
				StringBuilder cablingConfigurationSB = new();
				cablingConfigurationSB.AppendLine(_localizer["CreatedIn"]);
				cablingConfigurationSB.AppendLine();
				cablingConfigurationSB.AppendLine();
				cablingConfigurationSB.AppendLine($"{_localizer["RecordTime"]} {cablingConfiguration.RecordTime.ToShortDateString()} " +
					$"{cablingConfiguration.RecordTime.ToLongTimeString()}");
				cablingConfigurationSB.AppendLine($"{_localizer["MinPermanentLink"]} {cablingConfiguration.MinPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["MaxPermanentLink"]} {cablingConfiguration.MaxPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["AveragePermanentLink"]} {cablingConfiguration.MaxPermanentLink:F2} " +
					$"{_localizer["m"]}");
				cablingConfigurationSB.AppendLine($"{_localizer["NumberOfWorkplaces"]} {cablingConfiguration.NumberOfWorkplaces}");
				cablingConfigurationSB.AppendLine($"{_localizer["NumberOfPorts"]} {cablingConfiguration.NumberOfPorts}");
				if (cablingConfiguration.CableHankMeterage != null)
				{
					cablingConfigurationSB.AppendLine($"{_localizer["CableQuantity"]} {cablingConfiguration.CableQuantity:F2} " +
						$"{_localizer["m"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["CableHankMeterage"]} {cablingConfiguration.CableHankMeterage:F2} " +
						$"{_localizer["m"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["HankQuantity"]} {cablingConfiguration.HankQuantity}");
				}
				cablingConfigurationSB.AppendLine($"{_localizer["TotalCableQuantity"]} {cablingConfiguration.TotalCableQuantity} " +
					$"{_localizer["m"]}");
				if (!IsNullOrEmpty(cablingConfiguration.Recommendations["Insulation Type"]) &&
					!IsNullOrEmpty(cablingConfiguration.Recommendations["Insulation Material"]) &&
					!IsNullOrEmpty(cablingConfiguration.Recommendations["Shielding"]))
				{
					cablingConfigurationSB.AppendLine();
					cablingConfigurationSB.AppendLine(_localizer["CableSelectionRecommendations"]);
					cablingConfigurationSB.AppendLine($"{_localizer["Insulation Type"]} {cablingConfiguration.Recommendations["Insulation Type"]}");
					cablingConfigurationSB.AppendLine($"{_localizer["Insulation Material"]} {cablingConfiguration.Recommendations["Insulation Material"]}");
					if (!IsNullOrEmpty(cablingConfiguration.Recommendations["Standart"]))
					{
						cablingConfigurationSB.AppendLine($"{_localizer["Standart"]} {cablingConfiguration.Recommendations["Standart"]}");
					}
					cablingConfigurationSB.AppendLine($"{_localizer["Shielding"]} {cablingConfiguration.Recommendations["Shielding"]}");
				}
				var stream = new MemoryStream(UTF8.GetBytes(cablingConfigurationSB.ToString()));
				return File(stream, "text/plain", fileName);
			}
			return NoContent();
		}
	}
}