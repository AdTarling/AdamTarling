using adamtarling.web.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IInformationTileService
    {
        IEnumerable<InformationTile> GetInformationTiles(IEnumerable<IPublishedContent> tilesContent);
        InformationTile GetInformationTile(IPublishedContent tileContentItem);
    }
}