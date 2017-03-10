using adamtarling.web.Constants;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using Mvc.Mailer;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace adamtarling.web.Services.CoreSevices
{
    public class EmailService : MailerBase, IEmailService
    {
        private readonly IEmailContentService _emailContentService;

        public EmailService()
        {
            _emailContentService = new EmailContentService();
        }

        public virtual MvcMailMessage Contact(ContactFormViewModel contactFormViewModel)
        {
            var emailViewModel =
                _emailContentService.GetEmailViewModelFromGeneralEmail(ConfigurationParameters.AppSettings.EmailContact);
            emailViewModel.Name = contactFormViewModel.Name;

            MasterName = ViewNames.Views.Email.MasterEmail;
            ViewData = new ViewDataDictionary(emailViewModel);
            return Populate(x =>
            {
                x.Subject = emailViewModel.Subject;
                x.ViewName = ViewNames.Views.Email.Contact;
                x.To.Add(emailViewModel.ToAddresses.First());
                x.From = new MailAddress(contactFormViewModel.Email, contactFormViewModel.Name);
            });
        }

        public virtual MvcMailMessage ContactConfirmation(ContactFormViewModel contactFormViewModel)
        {
            var emailViewModel =
                _emailContentService.GetEmailViewModelFromGeneralEmail(ConfigurationParameters.AppSettings.EmailContactConfirmation);
            emailViewModel.Name = contactFormViewModel.Name;

            MasterName = ViewNames.Views.Email.MasterEmail;
            ViewData = new ViewDataDictionary(emailViewModel);
            return Populate(x =>
            {
                x.Subject = emailViewModel.Subject;
                x.ViewName = ViewNames.Views.Email.ContactConfirmation;
                x.To.Add(contactFormViewModel.Email);
                x.From = new MailAddress(emailViewModel.FromAddress, emailViewModel.FromDisplayName);
            });
        }
    }
}