using AutoMapper;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudioCore;

namespace StructuredCablingStudio.AutoMapperProfiles
{
	public class CablingConfigurationToCablingConfigurationEntityProfile : Profile
	{
		public CablingConfigurationToCablingConfigurationEntityProfile()
			=> CreateMap<CablingConfiguration, CablingConfigurationEntity>();
	}
}
