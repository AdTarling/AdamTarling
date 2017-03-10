using adamtarling.web.Constants;
using adamtarling.web.Services.ComponentServices.Interfaces;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Services.ComponentServices
{
    public class InformationWithoutBackgroundService : ComponentBaseService, IInformationWithoutBackgroundService
    {
        private readonly IInformationTileService _informationTileService;

        public InformationWithoutBackgroundService()
        {
            _informationTileService = new InformationTileService();
        }

        public InformationWithoutBackgroundViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new InformationWithoutBackgroundViewModel();

            if(componentContent == null)
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