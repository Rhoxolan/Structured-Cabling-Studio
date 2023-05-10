using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.Binders.ConfigurationsBinders
{
    public class ConfigurationCalculateParametersModelBinder : IModelBinder
    {
        private readonly IMapper _mapper;

        public ConfigurationCalculateParametersModelBinder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext?.HttpContext?.Session != null)
            {
                var calculateParameters = bindingContext.HttpContext.Session.GetCalculateParameters();
                ConfigurationCalculateParameters parameters;
                if (calculateParameters != null)
                {
                    parameters = _mapper.Map<ConfigurationCalculateParameters>(calculateParameters);
                }
                else
                {
                    parameters = new ConfigurationCalculateParameters
                    {
                        IsCableHankMeterageAvailability = true
                    };
                    bindingContext.HttpContext.Session.SetCalculateParameters(_mapper.Map<CalculateParameters>(parameters));
                }
                bindingContext.Result = ModelBindingResult.Success(parameters);
            }
            return Task.CompletedTask;
        }
    }
}
