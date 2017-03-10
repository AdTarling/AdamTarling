using adamtarling.web.ViewModels.Components;
using Mvc.Mailer;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IEmailService
    {
        MvcMailMessage Contact(ContactFormViewModel contactFormViewModel);
        MvcMailMessage ContactConfirmation(ContactFormViewModel contactFormViewModel);
    }
}