using AutoMapper;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class StructuredCablingStudioParametersToCalculateViewModelProfile : Profile
	{
		public StructuredCablingStudioParametersToCalculateViewModelProfile()
			=> CreateMap<StructuredCablingStudioParameters, CalculateViewModel>();
	}
}
