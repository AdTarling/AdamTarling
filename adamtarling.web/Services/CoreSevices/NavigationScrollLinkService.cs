using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Models;
using adamtarling.web.Services.CoreSevices.Interfaces;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class NavigationScrollLinkService : INavigationScrollLinkService
    {
        public IEnumerable<NavigationScrollLink> GetNavigationScrollLinks(IEnumerable<IPublishedContent> navigationScrollLinkContent)
        {
            var navigationScrollLinks = new List<NavigationScrollLink>();

            if (navigationScrollLinkContent.IsNullOrEmpty())
            {
                return navigationScrollLinks;
            }

            foreach (var navigationScrollLinkItem in navigationScrollLinkContent)
            {
                navigationScrollLinks.Add(GetNavigationScrollLink(navigationScrollLinkItem));
            }

            return navigationScrollLinks;
        }

        public NavigationScrollLink GetNavigationScrollLink(IPublishedContent navigationScrollLinkContentItem)
        {
            var navigationScrollLink = new NavigationScrollLink();

            if(navigationScrollLinkContentItem == null)
            {
                return navigationScrollLink;
            }

            navigationScrollLink.Name = navigationScrollLinkContentItem.Name;
            navigationScrollLink.AnchorTag = navigationScrollLinkContentItem.Name;

            return navigationScrollLink;
        }
    }
}