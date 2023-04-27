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
			.AfterMap((src, dst) =>
			{
				dst.RecommendationsArguments.ShieldedType = src.RecommendationsArguments.ShieldedType;
				dst.RecommendationsArguments.IsolationMaterial = src.RecommendationsArguments.IsolationMaterial;
				dst.RecommendationsArguments.IsolationType = src.RecommendationsArguments.IsolationType;
				dst.RecommendationsArguments.ConnectionInterfaces = src.RecommendationsArguments.ConnectionInterfaces;
			})
			.ReverseMap();
	}
}
