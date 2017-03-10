using adamtarling.web.Models;
using System.Collections.Generic;

namespace adamtarling.web.ViewModels.Components
{
    public class HeaderViewModel
    {
        public IEnumerable<NavigationScrollLink> NavigationScrollLinks { get; set; }
    }
}