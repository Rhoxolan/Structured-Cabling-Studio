using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class StructuredCablingStuidoParametersResultFilter : IResultFilter
	{
		private readonly IMapper _mapper;

		public StructuredCablingStuidoParametersResultFilter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public void OnResultExecuted(ResultExecutedContext context)
		{
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if(model != null)
			{
				var structuredCablingParameters = _mapper.Map<StructuredCablingParameters>(model);
				context.HttpContext.Session.SetStructuredCablingParameters(structuredCablingParameters);
				var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(structuredCablingParameters);
				controller.ViewData["Diapasons"] = structuredCablingStudioParameters.Diapasons;
			}
		}
	}
}