using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class StructuredCablingParametersProfile : Profile
	{
		public StructuredCablingParametersProfile() => CreateMap<StructuredCablingParameters, StructuredCablingStudioParameters>()
			.ForMember(dst => dst.TechnologicalReserve, opt => opt.SetMappingOrder(5))
			.ReverseMap();
	}

	public class CalculateViewModelProfile : Profile
	{
		public CalculateViewModelProfile() => CreateMap<CalculateViewModel, StructuredCablingStudioParameters>()
			.ReverseMap();
	}
}
