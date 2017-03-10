using adamtarling.web.Models;
using System.Collections.Generic;
using System.Web;

namespace adamtarling.web.ViewModels.Components
{
    public class InformationWithBackgroundViewModel : ComponentBaseViewModel
    {
        public string Title { get; set; }
        public IHtmlString Copy { get; set; }
        public IEnumerable<InformationTile> InformationTiles { get; set; }
    }
}