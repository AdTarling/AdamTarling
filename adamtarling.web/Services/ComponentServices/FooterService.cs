using adamtarling.web.Constants;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.ComponentServices
{
    public class FooterService : ComponentBaseService, IFooterService
    {
        private readonly IImageLinkService _imageLinkService;

        public FooterService()
        {
            _imageLinkService = new ImageLinkService();
        }

        public FooterViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new FooterViewModel();

            if (componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            viewModel.CopyrightCopy = componentContent.GetPropertyValue<string>(PropertyAliases.Footer.CopyrightCopy);
            viewModel.IconLinks = _imageLinkService
                                    .GetImageLinks(
                                        componentContent
                                        .GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.Footer.IconLinks));

            return viewModel;
        }
    }
}