using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class StructuredCablingParametersProfile : Profile
	{
		public StructuredCablingParametersProfile() => CreateMap<StructuredCablingParameters, StructuredCablingStudioParameters>()
			.ForMember(dst => dst.TechnologicalReserve, opt => opt.SetMappingOrder(5))
			.ReverseMap();
	}
}
