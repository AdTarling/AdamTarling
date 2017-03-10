using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Services.ComponentServices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components.Interfaces;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class ComponentBuilderService : IComponentBuilderService
    {
        public IEnumerable<IComponent> GetBodyComponents(IPublishedContent pageContent)
        {
            var components = new List<IComponent>();
            if(pageContent == null)
            {
                return components;
            }

            var bodyComponentContentItems = pageContent.GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.Global.BodyComponents);

            if (!bodyComponentContentItems.IsNullOrEmpty())
            {
                foreach (var bodyComponentContentItem in bodyComponentContentItems)
                {
                    components.Add(GetComponent(bodyComponentContentItem, pageContent));
                }
            }

            return components;
        }

        public IComponent GetComponent(IPublishedContent componentContent, IPublishedContent pageContent)
        {
            var documentTypeAlias = componentContent.DocumentTypeAlias;

            switch (documentTypeAlias)
            {
                case DocumentTypeAliases.Banner:
                    var bannerService = new BannerService();
                    return bannerService.GetViewModel(componentContent);

                case DocumentTypeAliases.InformationWithoutBackground:
                    var informationWithoutBackgroundService = new InformationWithoutBackgroundService();
                    return informationWithoutBackgroundService.GetViewModel(componentContent);

                case DocumentTypeAliases.InformationWithoutBackgroundVertical:
                    var informationWithBackgroundVerticalService = new InformationWithoutBackgroundVerticalService();
                    return informationWithBackgroundVerticalService.GetViewModel(componentContent);

                case DocumentTypeAliases.InformationWithBackground:
                    var informationWithBackgroundService = new InformationWithBackgroundService();
                    return informationWithBackgroundService.GetViewModel(componentContent);

                case DocumentTypeAliases.ContactForm:
                    var contactFormService = new ContactFormService();
                    return contactFormService.GetViewModel(componentContent);

                case DocumentTypeAliases.ContactDetails:
                    var contactDetailsService = new ContactDetailsService();
                    return contactDetailsService.GetViewModel(componentContent);

                case DocumentTypeAliases.Footer:
                    var footerService = new FooterService();
                    return footerService.GetViewModel(componentContent);
            }

            return null;
        }
    }
}