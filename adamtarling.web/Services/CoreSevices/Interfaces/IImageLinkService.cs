using adamtarling.web.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IImageLinkService
    {
        IEnumerable<ImageLink> GetImageLinks(IEnumerable<IPublishedContent> imageLinkContent);
        ImageLink GetImageLink(IPublishedContent imageLinkContentItem);
    }
}