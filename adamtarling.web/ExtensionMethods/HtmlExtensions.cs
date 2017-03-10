using System;
using System.Web;
using umbraco;

namespace adamtarling.web.ExtensionMethods
{
    public static class HtmlExtensions
    {
        public static HtmlString RemoveFirstParagraphTag(this IHtmlString text)
        {
            return text == null ? new HtmlString("") : new HtmlString(library.RemoveFirstParagraphTag(text.ToString()));
        }

        public static bool IsNullOrWhiteSpace(this IHtmlString htmlString)
        {
            return htmlString == null || String.IsNullOrWhiteSpace(htmlString.ToString());
        }
    }
}