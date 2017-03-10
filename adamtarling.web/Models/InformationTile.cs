using Umbraco.Core;

namespace adamtarling.web.Models
{
    public class InformationTile
    {
        public string Title { get; set; }
        public string Copy { get; set; }
        public MediaModel Icon { get; set; }
        public MediaModel Image { get; set; }
        
        public bool IsImageTile
        {
            get
            {
                return Image != null && !Image.Url.IsNullOrWhiteSpace();
            }
        } 
    }
}