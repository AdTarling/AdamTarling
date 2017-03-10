using adamtarling.web.ViewModels;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web;
using Newtonsoft.Json.Linq;
using adamtarling.web.Services.PageServices.Interfaces;
using adamtarling.web.Services.PageServices;

namespace adamtarling.web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomePageService _homePageService;

        public HomeController()
        {
            _homePageService = new HomePageService();
        }

        public override ActionResult Index(RenderModel model)
        {
            var viewModel = _homePageService.GetViewModel(model.Content);
            return base.Index(viewModel);
        }
    }
}