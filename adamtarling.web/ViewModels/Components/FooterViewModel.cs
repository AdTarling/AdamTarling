using adamtarling.web.Models;
using System.Collections.Generic;

namespace adamtarling.web.ViewModels.Components
{
    public class FooterViewModel : ComponentBaseViewModel
    {
        public string CopyrightCopy { get; set; }
        public IEnumerable<ImageLink> IconLinks { get; set; }
    }
}