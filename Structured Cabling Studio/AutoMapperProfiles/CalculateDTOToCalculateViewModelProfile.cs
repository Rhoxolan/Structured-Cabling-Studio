using AutoMapper;
using StructuredCablingStudio.DTOs.ConfigurationsDTOs;
using StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels;

namespace StructuredCablingStudio.AutoMapperProfiles
{
    public class CalculateDTOToCalculateViewModelProfile : Profile
	{
		public CalculateDTOToCalculateViewModelProfile() => CreateMap<CalculateDTO, CalculateViewModel>().ReverseMap();
	}
}
