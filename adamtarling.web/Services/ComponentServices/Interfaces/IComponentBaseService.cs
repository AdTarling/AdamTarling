using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices.Interfaces
{
    public interface IComponentBaseService
    {
        void PopulateComponentBaseProperties(ComponentBaseViewModel viewModel, IPublishedContent componentContent);
    }
}
