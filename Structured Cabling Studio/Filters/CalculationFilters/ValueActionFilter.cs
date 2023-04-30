using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ValueActionFilter : IAsyncActionFilter
	{
		private readonly IMapper _mapper;

		public ValueActionFilter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await next();
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(model);
				if (model.TechnologicalReserve != structuredCablingStudioParameters.TechnologicalReserve)
				{
					model.TechnologicalReserve = structuredCablingStudioParameters.TechnologicalReserve;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
				}
				var configurationCalculateParameters = _mapper.Map<ConfigurationCalculateParameters>(model);
				if (model.CableHankMeterage != configurationCalculateParameters.CableHankMeterage)
				{
					model.CableHankMeterage = configurationCalculateParameters.CableHankMeterage;
					context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
				}
				if (model.CableHankMeterage != null && model.CableHankMeterage.Value != 0)
				{
					var ceiledAveragePermanentLink = (int)Math.Ceiling((model.MinPermanentLink + model.MaxPermanentLink) / 2 * model.TechnologicalReserve);
					if (model.CableHankMeterage < ceiledAveragePermanentLink)
					{
						model.CableHankMeterage = ceiledAveragePermanentLink;
						context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
					}
				}
			}
		}
	}
}
