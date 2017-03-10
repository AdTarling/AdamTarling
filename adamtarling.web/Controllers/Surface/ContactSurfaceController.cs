using adamtarling.web.Constants;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.Utils;
using adamtarling.web.ViewModels.Components;
using System.Net;
using System.Web.Mvc;
using Umbraco.Web;

namespace adamtarling.web.Controllers.Surface
{
    public class ContactSurfaceController : BaseSurfaceController
    {
        private readonly IContactService _contactService;
        private readonly IEmailService _emailService;
        private readonly UmbracoHelper _umbracoHelper;

        public ContactSurfaceController()
        {
            _contactService = new ContactService();
            _emailService = new EmailService();
            _umbracoHelper = PerRequestCacheManager.UmbracoHelper();
        }

        [HttpPost]
        public ActionResult Submit(string name, string email, string phone, string message)
        {
            var contactFormViewModel = new ContactFormViewModel()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Message = message
            };

            var contactFormValidationResult = _contactService.ValidateContactForm(contactFormViewModel);

            if (!contactFormValidationResult.IsSuccess)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                if (Request.IsAjaxRequest())
                {
                    return Json(new
                    {
                        success = false,
                        message = contactFormValidationResult.Message
                    });
                }

                //set param
                return Redirect("/");
            }

            _emailService.Contact(contactFormViewModel).SendAsync().ConfigureAwait(true);
            _emailService.ContactConfirmation(contactFormViewModel).SendAsync().ConfigureAwait(true);
            Response.StatusCode = (int)HttpStatusCode.OK;

            if (Request.IsAjaxRequest())
            {
                return Json(new {
                    success = true,
                    message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactSubmitSuccess)
                });
            }

            //set param
            return Redirect("/");
        }
    }
}