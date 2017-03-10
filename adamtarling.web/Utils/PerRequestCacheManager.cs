using adamtarling.web.Constants;
using System.Web;
using Umbraco.Web;

namespace adamtarling.web.Utils
{
    public static class PerRequestCacheManager
    {
        public static UmbracoHelper UmbracoHelper()
        {
            const string key = HttpContextItemsKeys.UmbracoHelperPerRequest;
            var umbracoHelperFromCache = HttpContext.Current.Items[key] as UmbracoHelper;

            return umbracoHelperFromCache ?? new UmbracoHelper(UmbracoContext.Current);
        }

        public static void SetValue(string key, object value)
        {
            HttpContext.Current.Items[key] = value;
        }

        public static T GetValue<T>(string key)
        {
            var valueFromCache = HttpContext.Current.Items[key];

            if (valueFromCache != null)
            {
                return (T)valueFromCache;
            }

            return default(T);
        }
    }
}