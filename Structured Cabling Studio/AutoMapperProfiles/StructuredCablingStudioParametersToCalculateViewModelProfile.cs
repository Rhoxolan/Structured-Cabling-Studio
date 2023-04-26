using AutoMapper;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
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
			});
	}
}
