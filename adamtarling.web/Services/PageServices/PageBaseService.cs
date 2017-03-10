using adamtarling.web.Constants;
using adamtarling.web.Services.CoreSevices;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.Services.PageServices.Interfaces;
using adamtarling.web.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Core;
using Umbraco.Web;
using adamtarling.web.Utils;

namespace adamtarling.web.Services.PageServices
{
    public class PageBaseService : IPageBaseService
    {
        private readonly IComponentBuilderService _componentService;

        public PageBaseService()
        {
            _componentService = new ComponentBuilderService();
        }

        public void PopulateBaseProperties(PageBaseViewModel viewModel, IPublishedContent pageContent)
        {
            if(viewModel == null || pageContent == null)
            {
                return;
            }

            var title = pageContent.GetPropertyValue<string>(PropertyAliases.Seo.Title);
            viewModel.Title = !title.IsNullOrWhiteSpace() 
                ? title
                : NodeUtils.GetRootNode().GetPropertyValue<string>(PropertyAliases.Seo.Title);

            var keywords = pageContent.GetPropertyValue<string>(PropertyAliases.Seo.Keywords);
            viewModel.Keywords = !keywords.IsNullOrWhiteSpace()
                ? keywords
                : NodeUtils.GetRootNode().GetPropertyValue<string>(PropertyAliases.Seo.Keywords);

            viewModel.BodyComponents = _componentService.GetBodyComponents(pageContent);
        }
    }
}