using adamtarling.web.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IMediaModelService
    {
        MediaModel GetMediaModel(IPublishedContent imageContent);
        IEnumerable<MediaModel> GetMediaModels(IEnumerable<IPublishedContent> imageContentItems);
    }
}
