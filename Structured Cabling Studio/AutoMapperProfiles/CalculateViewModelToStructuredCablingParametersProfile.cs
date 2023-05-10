using AutoMapper;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.AutoMapperProfiles
{
    public class CalculateViewModelToStructuredCablingParametersProfile : Profile
	{
		public CalculateViewModelToStructuredCablingParametersProfile()
			=> CreateMap<CalculateViewModel, StructuredCablingParameters>()
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
