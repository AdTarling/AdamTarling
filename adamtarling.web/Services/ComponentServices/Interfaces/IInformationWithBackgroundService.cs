using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices.Interfaces
{
    public interface IInformationWithBackgroundService
    {
        InformationWithBackgroundViewModel GetViewModel(IPublishedContent componentContent);
    }
}