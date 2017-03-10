using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Models;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.Utils;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class MediaModelService : IMediaModelService
    {
        public MediaModel GetMediaModel(IPublishedContent imageContent)
        {
            var mediaModel = new MediaModel();

            if (imageContent != null)
            {
                mediaModel.NodeId = imageContent.Id;
                mediaModel.Url = imageContent.Url;
                mediaModel.AltText = imageContent.GetPropertyValue<string>(PropertyAliases.MediaModel.AltText);
            }

            return mediaModel;
        }

        public IEnumerable<MediaModel> GetMediaModels(IEnumerable<IPublishedContent> imageContentItems)
        {
            var mediaModels = new List<MediaModel>();

            if (imageContentItems.IsNullOrEmpty())
            {
                return mediaModels;
            }

            mediaModels.AddRange(imageContentItems.Select(GetMediaModel));
            return mediaModels;
        }
    }
}