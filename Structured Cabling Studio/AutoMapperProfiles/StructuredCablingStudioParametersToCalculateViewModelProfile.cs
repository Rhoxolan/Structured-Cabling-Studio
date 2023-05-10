using AutoMapper;
using StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
    public class StructuredCablingStudioParametersToCalculateViewModelProfile : Profile
	{
		public StructuredCablingStudioParametersToCalculateViewModelProfile()
			=> CreateMap<StructuredCablingStudioParameters, CalculateViewModel>()
			.AfterMap((src, dst) =>
			{
				dst.IsCableRouteRunOutdoors = src.RecommendationsArguments.IsolationType == IsolationType.Outdoor;
				dst.IsConsiderFireSafetyRequirements = src.RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH;
				dst.IsCableShieldingNecessity = src.RecommendationsArguments.ShieldedType == ShieldedType.FTP;
				dst.HasTenBase_T = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T);
				dst.HasFastEthernet = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet);
				dst.HasGigabitBASE_T = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_T);
				dst.HasGigabitBASE_TX = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.GigabitBASE_TX);
				dst.HasTwoPointFiveGBASE_T = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
				dst.HasFiveGBASE_T = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FiveGBASE_T);
				dst.HasTenGE = src.RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenGE);
			})
			.ReverseMap()
			.ForMember(dst => dst.TechnologicalReserve, opt =>
			{
				opt.SetMappingOrder(5);
				opt.Condition(src => src.IsTechnologicalReserveAvailability);
			})
			.AfterMap((src, dst) =>
			{
				dst.RecommendationsArguments.IsolationType = src.IsCableRouteRunOutdoors ? IsolationType.Outdoor : IsolationType.Indoor;
				dst.RecommendationsArguments.IsolationMaterial = src.IsConsiderFireSafetyRequirements ? IsolationMaterial.LSZH : IsolationMaterial.PVC;
				dst.RecommendationsArguments.ShieldedType = src.IsCableShieldingNecessity ? ShieldedType.FTP : ShieldedType.UTP;
				if (src.HasTenBase_T)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TenBASE_T);
				}
				if (src.HasFastEthernet)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.FastEthernet);
				}
				if (src.HasGigabitBASE_T)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.GigabitBASE_T);
				}
				if (src.HasGigabitBASE_TX)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.GigabitBASE_TX);
				}
				if (src.HasTwoPointFiveGBASE_T)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
				}
				if (src.HasFiveGBASE_T)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.FiveGBASE_T);
				}
				if (src.HasTenGE)
				{
					dst.RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TenGE);
				}
			});
	}
}
