using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices.Interfaces
{
    public interface IInformationWithoutBackgroundVerticalService
    {
        InformationWithoutBackgroundVerticalViewModel GetViewModel(IPublishedContent componentContent);
    }
}
