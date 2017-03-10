using System.Linq;
using Umbraco.Core;

namespace adamtarling.web.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string PrependRelativeHrefsWithBaseUri(this string value, string baseUri)
        {
            if (value.IsNullOrWhiteSpace() || baseUri.IsNullOrWhiteSpace())
            {
                return value;
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(value);

            var hrefNodes = doc.DocumentNode.SelectNodes("(//@href)[not(starts-with(.,'http://'))][not(starts-with(.,'https://'))]");
            if (!hrefNodes.IsNullOrEmpty())
            {
                var anchorTags = hrefNodes.Where(hnl => hnl.Name.Equals("a"));
                foreach (var anchorTag in anchorTags)
                {
                    var anchorTagHrefValue = anchorTag.Attributes["href"].Value;
                    if (!anchorTagHrefValue.Contains("mailto:"))
                    {
                        anchorTag.Attributes["href"].Value = baseUri + anchorTag.Attributes["href"].Value;
                    }
                }
            }

            return doc.DocumentNode.OuterHtml;
        }
    }
}