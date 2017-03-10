using adamtarling.web.Models;
using System.Collections.Generic;

namespace adamtarling.web.ViewModels.Components
{
    public class BannerViewModel : ComponentBaseViewModel
    {
        public HeaderViewModel HeaderViewModel { get; set; }
        public MediaModel BackgroundImage { get; set; }
        public IEnumerable<BannerSlide> BannerSlides { get; set; }
    }
}