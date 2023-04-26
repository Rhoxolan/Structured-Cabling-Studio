using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class StructuredCablingStudioParametersModelBinder : IModelBinder
	{
		private readonly IMapper _mapper;

		public StructuredCablingStudioParametersModelBinder(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext?.HttpContext?.Session != null)
			{
				var cablingParameters = bindingContext.HttpContext.Session.GetStructuredCablingParameters();
				StructuredCablingStudioParameters parameters;
				if (cablingParameters != null)
				{
					parameters = _mapper.Map<StructuredCablingStudioParameters>(cablingParameters);
				}
				else
				{
					parameters = new StructuredCablingStudioParameters
					{
						IsStrictComplianceWithTheStandart = true,
						IsAnArbitraryNumberOfPorts = true,
						IsTechnologicalReserveAvailability = true,
						TechnologicalReserve = 1.1,
						IsRecommendationsAvailability = true
					};
					parameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
					parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
					parameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
					parameters.RecommendationsArguments.ConnectionInterfaces = new List<ConnectionInterfaceStandard>
					{
						ConnectionInterfaceStandard.FastEthernet,
						ConnectionInterfaceStandard.GigabitBASE_T
					};
					bindingContext.HttpContext.Session.SetStructuredCablingParameters(_mapper.Map<StructuredCablingParameters>(parameters));
				}
				bindingContext.Result = ModelBindingResult.Success(parameters);
			}
			return Task.CompletedTask;
		}
	}
}
