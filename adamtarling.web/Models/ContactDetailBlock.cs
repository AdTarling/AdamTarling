using System.Web;

namespace adamtarling.web.Models
{
    public class ContactDetailBlock
    {
        public MediaModel Icon { get; set; }
        public string Title { get; set; }
        public IHtmlString Copy { get; set; }
    }
}