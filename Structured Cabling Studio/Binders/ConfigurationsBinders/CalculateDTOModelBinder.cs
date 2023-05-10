using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudio.DTOs.ConfigurationsDTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;

namespace StructuredCablingStudio.Binders.ConfigurationsBinders
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
