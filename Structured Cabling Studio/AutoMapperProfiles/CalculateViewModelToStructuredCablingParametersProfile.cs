using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class CalculateViewModelToStructuredCablingParametersProfile : Profile
	{
		public CalculateViewModelToStructuredCablingParametersProfile()
			=> CreateMap<CalculateViewModel, StructuredCablingParameters>();
	}
}
