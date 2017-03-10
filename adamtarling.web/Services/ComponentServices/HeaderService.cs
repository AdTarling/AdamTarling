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
    public class HeaderService : ComponentBaseService, IHeaderService
    {
        private readonly INavigationScrollLinkService _navigationScrollLinkService;

        public HeaderService()
        {
            _navigationScrollLinkService = new NavigationScrollLinkService();
        }

        public HeaderViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new HeaderViewModel();

            if(componentContent == null)
            {
                return viewModel;
            }

            var navigationScrollLinkContent = componentContent
                .GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.Header.NavigationScrollLinks);
            viewModel.NavigationScrollLinks = _navigationScrollLinkService.GetNavigationScrollLinks(navigationScrollLinkContent);

            return viewModel;
        }
    }
}