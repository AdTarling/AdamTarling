using adamtarling.web.Constants;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.ComponentServices
{
    public class InformationWithBackgroundService : ComponentBaseService, IInformationWithBackgroundService
    {
        private readonly IInformationTileService _informationTileService;

        public InformationWithBackgroundService()
        {
            _informationTileService = new InformationTileService();
        }

        public InformationWithBackgroundViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new InformationWithBackgroundViewModel();

            if (componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            viewModel.Title = componentContent
                .GetPropertyValue<string>(PropertyAliases.InformationWithoutBackground.Title);
            viewModel.Copy = componentContent
                .GetPropertyValue<IHtmlString>(PropertyAliases.InformationWithoutBackground.Copy);
            viewModel.InformationTiles = _informationTileService
                .GetInformationTiles(componentContent.GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.InformationWithoutBackground.InformationTiles));

            return viewModel;
        }
    }
}