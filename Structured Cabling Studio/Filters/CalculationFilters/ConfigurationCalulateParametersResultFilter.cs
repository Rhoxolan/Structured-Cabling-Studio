using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ConfigurationCalulateParametersResultFilter : IAsyncResultFilter
	{
		private readonly IMapper _mapper;

		public ConfigurationCalulateParametersResultFilter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				var configurationCalulateParameters = _mapper.Map<ConfigurationCalculateParameters>(model);
				var calculateParameters = _mapper.Map<CalculateParameters>(configurationCalulateParameters);
				context.HttpContext.Session.SetCalculateParameters(calculateParameters);
			}
			await next();
		}
	}
}