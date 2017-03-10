using adamtarling.web.Constants;
using adamtarling.web.Models;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.Utils;
using adamtarling.web.ViewModels.Components;
using System;
using System.Net.Mail;
using Umbraco.Core;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class ContactService : IContactService
    {
        private readonly UmbracoHelper _umbracoHelper;

        public ContactService()
        {
            _umbracoHelper = PerRequestCacheManager.UmbracoHelper();
        }

        public ResultModel ValidateContactForm(ContactFormViewModel contactFormViewModel)
        {
            var resultModel = new ResultModel()
            {
                Message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactDefault)
            };

            if(contactFormViewModel == null)
            {
                return resultModel;
            }

            if (contactFormViewModel.Name.IsNullOrWhiteSpace())
            {
                resultModel.Message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactNameEmpty);
                return resultModel;
            }

            if (contactFormViewModel.Email.IsNullOrWhiteSpace())
            {
                resultModel.Message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactEmailEmpty);
                return resultModel;
            }

            if (!IsEmailValidFormat(contactFormViewModel.Email))
            {
                resultModel.Message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactEmailInvalid);
                return resultModel;
            }

            if (contactFormViewModel.Message.IsNullOrWhiteSpace())
            {
                resultModel.Message = _umbracoHelper.GetDictionaryValue(DictionaryKeys.ResultMessages.ContactMessageEmpty);
                return resultModel;
            }

            resultModel.IsSuccess = true;
            return resultModel;
        }

        private bool IsEmailValidFormat(string emailaddress)
        {
            try
            {
                var mailAddress = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}