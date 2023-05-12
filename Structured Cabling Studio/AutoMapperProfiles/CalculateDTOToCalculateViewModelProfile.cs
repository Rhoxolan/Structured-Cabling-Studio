using AutoMapper;
using StructuredCablingStudio.DTOs.CalculationDTOs;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.AutoMapperProfiles
{
    public class CalculateDTOToCalculateViewModelProfile : Profile
	{
		public CalculateDTOToCalculateViewModelProfile() => CreateMap<CalculateDTO, CalculateViewModel>().ReverseMap();
	}
}
