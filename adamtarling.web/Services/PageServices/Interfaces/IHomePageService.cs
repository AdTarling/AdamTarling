using adamtarling.web.ViewModels;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.PageServices.Interfaces
{
    public interface IHomePageService
    {
        HomePageViewModel GetViewModel(IPublishedContent pageContent);
    }
}
