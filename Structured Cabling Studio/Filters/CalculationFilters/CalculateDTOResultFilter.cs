using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.DTOs.CalculateDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class CalculateDTOResultFilter : IAsyncResultFilter
	{
		private readonly IMapper _mapper;

		public CalculateDTOResultFilter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			var controller = (Calculation)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				var calculateDTO = _mapper.Map<CalculateDTO>(model);
				context.HttpContext.Session.SetCalculateDTO(calculateDTO);
			}
			await next();
		}
	}
}