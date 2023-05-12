using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.DTOs.CalculationDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
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
            var controller = (Controller)context.Controller;
            var model = (CalculateViewModel?)controller.ViewData.Model;
            if (model != null)
            {
                var calculateDTO = _mapper.Map<CalculateDTO>(model);
                context.HttpContext.Session.SetCalculateDTO(calculateDTO);
            }
        }
    }
}