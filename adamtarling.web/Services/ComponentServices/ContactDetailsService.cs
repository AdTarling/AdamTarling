using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Models;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.ComponentServices
{
    public class ContactDetailsService : ComponentBaseService, IContactDetailsService
    {
        private readonly IMediaModelService _mediaModelService;

        public ContactDetailsService()
        {
            _mediaModelService = new MediaModelService();
        }

        public ContactDetailsViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new ContactDetailsViewModel()
            {
                ContactDetailBlocks = new List<ContactDetailBlock>()
            };

            if (componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            viewModel.Title = componentContent.GetPropertyValue<string>(PropertyAliases.ContactDetails.Title);
            viewModel.Copy = componentContent.GetPropertyValue<string>(PropertyAliases.ContactDetails.Copy);
            viewModel.ContactDetailBlocks = GetContactDetailBlocks(componentContent.GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.ContactDetails.ContactDetailBlocks));

            return viewModel;
        }

        private IEnumerable<ContactDetailBlock> GetContactDetailBlocks(IEnumerable<IPublishedContent> contactDetailsBlocksContent)
        {
            var contactDetailBlocks = new List<ContactDetailBlock>();

            if (contactDetailsBlocksContent.IsNullOrEmpty())
            {
                return contactDetailBlocks;
            }

            foreach (var contactDetailBlocksContentItem in contactDetailsBlocksContent)
            {
                contactDetailBlocks.Add(new ContactDetailBlock
                {
                    Icon = _mediaModelService
                    .GetMediaModel(contactDetailBlocksContentItem
                        .GetPropertyValue<IPublishedContent>(PropertyAliases.ContactDetailBlock.Icon)),
                    Title = contactDetailBlocksContentItem.GetPropertyValue<string>(PropertyAliases.ContactDetailBlock.Title),
                    Copy = contactDetailBlocksContentItem.GetPropertyValue<IHtmlString>(PropertyAliases.ContactDetailBlock.Copy)
                });
            }

            return contactDetailBlocks;
        }
    }
}