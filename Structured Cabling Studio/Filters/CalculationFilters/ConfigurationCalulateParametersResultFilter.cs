using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class ConfigurationCalulateParametersResultFilter : IResultFilter
	{
		private readonly IMapper _mapper;

		public ConfigurationCalulateParametersResultFilter(IMapper mapper)
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
			if (model != null)
			{
				var configurationCalulateParameters = _mapper.Map<ConfigurationCalculateParameters>(model);
				var calculateParameters = _mapper.Map<CalculateParameters>(configurationCalulateParameters);
				context.HttpContext.Session.SetCalculateParameters(calculateParameters);
			}
		}
	}
}