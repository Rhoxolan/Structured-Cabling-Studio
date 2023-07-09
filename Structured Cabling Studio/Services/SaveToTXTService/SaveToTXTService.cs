using Microsoft.Extensions.Localization;
using StructuredCablingStudioCore;
using System.Text;
using static System.String;
using static System.Text.Encoding;

namespace StructuredCablingStudio.Services.SaveToTXTService
{
	public class SaveToTXTService : ISaveToTXTService
	{
		private readonly IStringLocalizer<SaveToTXTService> _localizer;

		public SaveToTXTService(IStringLocalizer<SaveToTXTService> localizer)
		{
			_localizer = localizer;
		}

		public string GetFileName(CablingConfiguration cablingConfiguration)
		{
			return $"{_localizer["StructuredCablingConfiguration"]} " +
				$"{cablingConfiguration.RecordTime.Day:00}." +
				$"{cablingConfiguration.RecordTime.Month:00}." +
				$"{cablingConfiguration.RecordTime.Year} " +
				$"{cablingConfiguration.RecordTime.Hour:00}." +
				$"{cablingConfiguration.RecordTime.Minute:00}." +
				$"{cablingConfiguration.RecordTime.Second:00}.txt";
		}

		public byte[] SaveToTXT(CablingConfiguration cablingConfiguration)
		{
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
			return UTF8.GetBytes(cablingConfigurationSB.ToString());
		}
	}
}
