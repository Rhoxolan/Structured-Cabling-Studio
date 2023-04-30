using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.Controllers;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class DiapasonActionFilter : IAsyncActionFilter
	{
		private readonly IMapper _mapper;

		public DiapasonActionFilter(IMapper mapper)
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
				if (model.MinPermanentLink > (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Max)
				{
					model.MinPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Max;
					context.ModelState.SetModelValue(nameof(model.MinPermanentLink), model.MinPermanentLink, default);
				}
				if (model.MinPermanentLink < (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Min)
				{
					model.MinPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Min;
					context.ModelState.SetModelValue(nameof(model.MinPermanentLink), model.MinPermanentLink, default);
				}
				if (model.MaxPermanentLink > (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Max)
				{
					model.MaxPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Max;
					context.ModelState.SetModelValue(nameof(model.MaxPermanentLink), model.MaxPermanentLink, default);
				}
				if (model.MaxPermanentLink < (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Min)
				{
					model.MaxPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Min;
					context.ModelState.SetModelValue(nameof(model.MaxPermanentLink), model.MaxPermanentLink, default);
				}
				if (model.NumberOfWorkplaces > (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Max)
				{
					model.NumberOfWorkplaces = (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Max;
					context.ModelState.SetModelValue(nameof(model.NumberOfWorkplaces), model.NumberOfWorkplaces, default);
				}
				if (model.NumberOfWorkplaces < (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Min)
				{
					model.NumberOfWorkplaces = (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Min;
					context.ModelState.SetModelValue(nameof(model.NumberOfWorkplaces), model.NumberOfWorkplaces, default);
				}
				if (model.NumberOfPorts > (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Max)
				{
					model.NumberOfPorts = (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Max;
					context.ModelState.SetModelValue(nameof(model.NumberOfPorts), model.NumberOfPorts, default);
				}
				if (model.NumberOfPorts < (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Min)
				{
					model.NumberOfPorts = (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Min;
					context.ModelState.SetModelValue(nameof(model.NumberOfPorts), model.NumberOfPorts, default);
				}
				if (model.CableHankMeterage != null)
				{
					if (model.CableHankMeterage.Value > (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Max)
					{
						model.CableHankMeterage = (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Max;
						context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
					}
					if (model.CableHankMeterage.Value < (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Min)
					{
						model.CableHankMeterage = (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Min;
						context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
					}
				}
				if (model.TechnologicalReserve > (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Max)
				{
					model.TechnologicalReserve = (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Max;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
				}
				if (model.TechnologicalReserve < (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Min)
				{
					model.TechnologicalReserve = (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Min;
					context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
				}
			}
		}
	}
}
