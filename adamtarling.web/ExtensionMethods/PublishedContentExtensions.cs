using adamtarling.web.Utils;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.ExtensionMethods
{
    public static class PublishedContentExtensions
    {
        public static IEnumerable<IPublishedContent> GetContentFromMultiNodeTreePicker(this IPublishedContent content, string pickerPropertyAlias)
        {
            var nodes = new List<IPublishedContent>();

            if (content == null)
            {
                return nodes;
            }

            var pickedIds = GetIdsFromMultiNodeTreePicker(content, pickerPropertyAlias);
            var umbracoHelper = PerRequestCacheManager.UmbracoHelper();

            nodes = pickedIds.Select(id => umbracoHelper.TypedContent(id)).Where(node => node != null).ToList();
            return nodes;
        }

        public static IEnumerable<int> GetIdsFromMultiNodeTreePicker(this IPublishedContent content, string pickerPropertyAlias)
        {
            if (content == null)
            {
                return new List<int>();
            }

            var pickedIdCsv = content.GetPropertyValue<string>(pickerPropertyAlias);
            if (pickedIdCsv.IsNullOrWhiteSpace())
            {
                return new List<int>();
            }

            try
            {
                return pickedIdCsv.Split(',').Select(int.Parse);
            }
            catch
            {
                return new List<int>();
            }
        }
    }
}