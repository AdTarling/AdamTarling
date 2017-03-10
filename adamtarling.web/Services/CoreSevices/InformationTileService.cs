using adamtarling.web.Constants;
using adamtarling.web.ExtensionMethods;
using adamtarling.web.Models;
using adamtarling.web.Services.CoreSevices.Interfaces;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.CoreSevices
{
    public class InformationTileService : IInformationTileService
    {
        private readonly IMediaModelService _mediaModelService;

        public InformationTileService()
        {
            _mediaModelService = new MediaModelService();
        }

        public IEnumerable<InformationTile> GetInformationTiles(IEnumerable<IPublishedContent> tilesContent)
        {
            var informationTiles = new List<InformationTile>();

            if(tilesContent.IsNullOrEmpty())
            {
                return informationTiles;
            }

            foreach(var tileContentItem in tilesContent)
            {
                informationTiles.Add(GetInformationTile(tileContentItem));
            }

            return informationTiles;
        }

        public InformationTile GetInformationTile(IPublishedContent tileContentItem)
        {
            var informationTile = new InformationTile();

            if(tileContentItem == null)
            {
                return informationTile;
            }

            informationTile.Image = _mediaModelService
                .GetMediaModel(tileContentItem.GetPropertyValue<IPublishedContent>(PropertyAliases.InformationTile.Image));

            if (!informationTile.IsImageTile)
            {
                informationTile.Title = tileContentItem.GetPropertyValue<string>(PropertyAliases.InformationTile.Title);
                informationTile.Copy = tileContentItem.GetPropertyValue<string>(PropertyAliases.InformationTile.Copy);
                informationTile.Icon = _mediaModelService
                    .GetMediaModel(tileContentItem.GetPropertyValue<IPublishedContent>(PropertyAliases.InformationTile.Icon));
            }

            return informationTile;
        }
    }
}