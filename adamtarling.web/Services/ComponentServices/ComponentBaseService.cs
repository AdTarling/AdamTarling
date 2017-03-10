using adamtarling.web.ViewModels.Components;
using Umbraco.Core.Models;

namespace adamtarling.web.Services.ComponentServices
{
    public class ComponentBaseService
    {
        public void PopulateComponentBaseProperties(ComponentBaseViewModel viewModel, IPublishedContent componentContent)
        {
            if(viewModel == null || componentContent == null)
            {
                return;
            }

            viewModel.DocumentTypeAlias = componentContent.DocumentTypeAlias;
            viewModel.AnchorTag = componentContent.Name;
        }
    }
}