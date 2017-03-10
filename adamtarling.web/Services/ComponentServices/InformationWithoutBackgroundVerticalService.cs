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
    public class InformationWithoutBackgroundVerticalService : ComponentBaseService, IInformationWithoutBackgroundVerticalService
    {
        private readonly IInformationTileService _informationTileService;

        public InformationWithoutBackgroundVerticalService()
        {
            _informationTileService = new InformationTileService();
        }

        public InformationWithoutBackgroundVerticalViewModel GetViewModel(IPublishedContent componentContent)
        {
            var viewModel = new InformationWithoutBackgroundVerticalViewModel();

            if (componentContent == null)
            {
                return viewModel;
            }

            PopulateComponentBaseProperties(viewModel, componentContent);

            viewModel.Title = componentContent
                .GetPropertyValue<string>(PropertyAliases.InformationWithoutBackgroundVertical.Title);
            viewModel.Copy = componentContent
                .GetPropertyValue<IHtmlString>(PropertyAliases.InformationWithoutBackgroundVertical.Copy);

            int containerSize;
            int.TryParse(ConfigurationManager.AppSettings[ConfigurationParameters.AppSettings.InformationTileContainerSize], out containerSize);
            viewModel.InformationTiles = _informationTileService
                .GetInformationTiles(componentContent.GetPropertyValue<IEnumerable<IPublishedContent>>(PropertyAliases.InformationWithoutBackgroundVertical.InformationTiles));

            return viewModel;
        }
    }
}