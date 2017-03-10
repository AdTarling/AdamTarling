using adamtarling.web.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface INavigationScrollLinkService
    {
        IEnumerable<NavigationScrollLink> GetNavigationScrollLinks(IEnumerable<IPublishedContent> navigationScrollLinkContent);
        NavigationScrollLink GetNavigationScrollLink(IPublishedContent navigationScrollLinkContentItem);
    }
}