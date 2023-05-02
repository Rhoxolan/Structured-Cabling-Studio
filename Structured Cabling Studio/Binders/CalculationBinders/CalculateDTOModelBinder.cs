using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudio.DTOs.CalculateDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;

namespace StructuredCablingStudio.Binders.CalculationBinders
{
	public class CalculateDTOModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext?.HttpContext?.Session != null)
			{
				var calculateDTO = bindingContext.HttpContext.Session.GetCalculateDTO();
				calculateDTO ??= new CalculateDTO
				{
					MinPermanentLink = 25,
					MaxPermanentLink = 85,
					NumberOfPorts = 1,
					NumberOfWorkplaces = 10,
				};
				bindingContext.Result = ModelBindingResult.Success(calculateDTO);
			}
			return Task.CompletedTask;
		}
	}
}
