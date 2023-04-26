using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class StructuredCablingParametersToStructuredCablingStudioParametersProfile : Profile
	{
		public StructuredCablingParametersToStructuredCablingStudioParametersProfile()
			=> CreateMap<StructuredCablingParameters, StructuredCablingStudioParameters>()
			.ForMember(dst => dst.TechnologicalReserve, opt =>
			{
				opt.SetMappingOrder(5);
				opt.Condition(src => src.IsTechnologicalReserveAvailability);
			})
			.ReverseMap();
	}
}
