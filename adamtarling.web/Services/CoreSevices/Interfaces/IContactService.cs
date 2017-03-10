using adamtarling.web.Models;
using adamtarling.web.ViewModels.Components;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IContactService
    {
        ResultModel ValidateContactForm(ContactFormViewModel contactFormViewModel);
    }
}