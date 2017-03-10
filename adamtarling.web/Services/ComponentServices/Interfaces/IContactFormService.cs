using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices.Interfaces
{
    public interface IContactFormService
    {
        ContactFormViewModel GetViewModel(IPublishedContent componentContent);
    }
}