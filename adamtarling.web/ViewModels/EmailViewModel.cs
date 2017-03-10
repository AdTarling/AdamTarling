using System.Collections.Generic;
using System.Web;

namespace adamtarling.web.ViewModels
{
    public class EmailViewModel
    {
        public string BaseUriString { get; set; }
        public string EmailTitle { get; set; }
        public string Subject { get; set; }
        public string FromDisplayName { get; set; }
        public IEnumerable<string> ToAddresses { get; set; }
        public string FromAddress { get; set; }
        public string CopyTitle { get; set; }
        public IHtmlString Copy { get; set; }
        public string Name { get; set; }
    }
}