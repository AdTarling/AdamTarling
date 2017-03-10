using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices.Interfaces
{
    public interface IHeaderService
    {
        HeaderViewModel GetViewModel(IPublishedContent componentContent);
    }
}