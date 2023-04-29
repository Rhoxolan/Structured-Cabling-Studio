using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class CalculateParametersToConfigurationCalculateParametersProfile : Profile
	{
		public CalculateParametersToConfigurationCalculateParametersProfile()
			=> CreateMap<CalculateParameters, ConfigurationCalculateParameters>()
			.ForMember(dst => dst.CableHankMeterage, opt =>
			{
				opt.SetMappingOrder(2);
				opt.Condition(src => src.IsCableHankMeterageAvailability);
			})
			.ReverseMap();
	}
}
