using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.Filters.ConfigurationsFilters
{
    public class ConfigurationCalculateParametersResultFilter : IResultFilter
    {
        private readonly IMapper _mapper;

        public ConfigurationCalculateParametersResultFilter(IMapper mapper)
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
                var configurationCalculateParameters = _mapper.Map<ConfigurationCalculateParameters>(model);
                var calculateParameters = _mapper.Map<CalculateParameters>(configurationCalculateParameters);
                context.HttpContext.Session.SetCalculateParameters(calculateParameters);
            }
        }
    }
}