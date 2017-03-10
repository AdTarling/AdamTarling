using adamtarling.web.ViewModels.Components.Interfaces;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IComponentBuilderService
    {
        IEnumerable<IComponent> GetBodyComponents(IPublishedContent pageContent);
    }
}
