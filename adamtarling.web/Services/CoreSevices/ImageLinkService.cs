using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Models;
using adamtarling.web.Services.CoreSevices.Interfaces;
using Newtonsoft.Json.Linq;
using RJP.MultiUrlPicker.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class ImageLinkService : IImageLinkService
    {
        private readonly IMediaModelService _mediaModelService;

        public ImageLinkService()
        {
            _mediaModelService = new MediaModelService();
        }

        public IEnumerable<ImageLink> GetImageLinks(IEnumerable<IPublishedContent> imageLinkContent)
        {
            var imageLinks = new List<ImageLink>();

            if(imageLinkContent == null)
            {
                return imageLinks;
            }

            foreach (var imageLinkContentItem in imageLinkContent)
            {
                imageLinks.Add(GetImageLink(imageLinkContentItem));
            }

            return imageLinks;
        }

        public ImageLink GetImageLink(IPublishedContent imageLinkContentItem)
        {
            var imageLink = new ImageLink();

            if(imageLinkContentItem == null)
            {
                return imageLink;
            }

            imageLink.Image = _mediaModelService
                                .GetMediaModel(imageLinkContentItem
                                    .GetPropertyValue<IPublishedContent>(PropertyAliases.ImageLink.Image));

            var multiUrls = imageLinkContentItem.GetPropertyValue<MultiUrls>(PropertyAliases.ImageLink.Link);

            if (!multiUrls.IsNullOrEmpty())
            {
                imageLink.Link = multiUrls.FirstOrDefault();
            }

            return imageLink;
        }
    }
}