using adamtarling.web.ViewModels.Components.Interfaces;
using System.Collections.Generic;

namespace adamtarling.web.ViewModels
{
    public class PageBaseViewModel
    {
        public string Title { get; set; }
        public string Keywords { get; set; }
        public IEnumerable<IComponent> BodyComponents { get; set; }
        public IComponent FooterComponent { get; set; }
    }
}