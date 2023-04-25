using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StructuredCablingStudio.Extensions.ModelStateDictionaryExtensions
{
	public static class CheckModelStateCheckBoxValueExtension
	{
		public static bool? CheckModelStateCheckBoxValue(this ModelStateDictionary dictionary, string key)
		{
			object? rawValue = dictionary.GetValueOrDefault(key)?.RawValue;
			if(rawValue is not null)
			{
				if (rawValue.GetType().IsArray)
				{
					var array = (Array)rawValue;
					var stringValues = new string[array.Length];
					if (stringValues[0] == "false")
					{
						return false;
					}
					if (stringValues[0] == "true")
					{
						return true;
					}
				}
				if (rawValue is string stringValue)
				{
					if (stringValue == "false")
					{
						return false;
					}
					if (stringValue == "true")
					{
						return true;
					}
				}
			}
			return null;
		}
	}
}
