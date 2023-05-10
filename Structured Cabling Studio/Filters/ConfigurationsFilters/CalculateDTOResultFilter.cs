using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs.ConfigurationsDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.ConfigurationsViewModels;

namespace StructuredCablingStudio.Filters.ConfigurationsFilters
{
    public class CalculateDTOResultFilter : IResultFilter
    {
        private readonly IMapper _mapper;

        public CalculateDTOResultFilter(IMapper mapper)
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
                var calculateDTO = _mapper.Map<CalculateDTO>(model);
                context.HttpContext.Session.SetCalculateDTO(calculateDTO);
            }
        }
    }
}