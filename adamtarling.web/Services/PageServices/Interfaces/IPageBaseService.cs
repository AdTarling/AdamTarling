using adamtarling.web.ViewModels;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.PageServices.Interfaces
{
    public interface IPageBaseService
    {
        void PopulateBaseProperties(PageBaseViewModel viewModel, IPublishedContent pageContent);
    }
}
