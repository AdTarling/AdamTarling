using adamtarling.web.ViewModels;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace adamtarling.web.Controllers
{
    public class BaseController : RenderMvcController
    {
        public ActionResult Index(PageBaseViewModel viewModel)
        {
            return CurrentTemplate(viewModel);
        }
    }
}