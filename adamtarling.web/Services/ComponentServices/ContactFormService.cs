using adamtarling.web.Constants;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Utils;
using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.ComponentServices
{
    public class ContactFormService : ComponentBaseService, IContactFormService
    {
        private readonly UmbracoHelper _umbracoHelper;
        
        public ContactFormService()
        {
            _umbracoHelper = PerRequestCacheManager.UmbracoHelper();
        }

        public ContactFormViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new ContactFormViewModel()
            {
                NameLabel = _umbracoHelper.GetDictionaryValue(DictionaryKeys.FormLabels.Name),
                EmailLabel = _umbracoHelper.GetDictionaryValue(DictionaryKeys.FormLabels.Email),
                PhoneLabel = _umbracoHelper.GetDictionaryValue(DictionaryKeys.FormLabels.Phone),
                MessageLabel = _umbracoHelper.GetDictionaryValue(DictionaryKeys.FormLabels.Message),
                SubmitButtonLabel = _umbracoHelper.GetDictionaryValue(DictionaryKeys.FormLabels.SubmitButton)
            };

            if(componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            viewModel.Title = componentContent.GetPropertyValue<string>(PropertyAliases.ContactForm.Title);
            viewModel.Copy = componentContent.GetPropertyValue<string>(PropertyAliases.ContactForm.Copy);
            viewModel.LocationParameterString = componentContent
                .GetPropertyValue<string>(PropertyAliases.ContactForm.LocationParameterString);

            return viewModel;
        }
    }
}