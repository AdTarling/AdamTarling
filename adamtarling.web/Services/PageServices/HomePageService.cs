using adamtarling.web.Services.PageServices.Interfaces;
using adamtarling.web.ViewModels;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.PageServices
{
    public class HomePageService : PageBaseService, IHomePageService
    {
        public HomePageViewModel GetViewModel(IPublishedContent pageContent)
        {
            var viewModel = new HomePageViewModel();
            PopulateBaseProperties(viewModel, pageContent);
            return viewModel;
        }
    }
}