using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class CalculateParametersToConfigurationCalculateParametersProfile : Profile
	{
		public CalculateParametersToConfigurationCalculateParametersProfile()
			=> CreateMap<CalculateParameters, ConfigurationCalculateParameters>()
			.ReverseMap();
	}
}
