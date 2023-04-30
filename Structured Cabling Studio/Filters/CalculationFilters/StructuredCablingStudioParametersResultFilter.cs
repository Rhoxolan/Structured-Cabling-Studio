using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class StructuredCablingStudioParametersResultFilter : IAsyncResultFilter
	{
		private readonly IMapper _mapper;

		public StructuredCablingStudioParametersResultFilter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(model);
				controller.ViewData["Diapasons"] = structuredCablingStudioParameters.Diapasons;
				var structuredCablingParameters = _mapper.Map<StructuredCablingParameters>(structuredCablingStudioParameters);
				context.HttpContext.Session.SetStructuredCablingParameters(structuredCablingParameters);
			}
			await next();
		}
	}
}