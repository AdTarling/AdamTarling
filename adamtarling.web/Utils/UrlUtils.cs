using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace adamtarling.web.Utils
{
    public static class UrlUtils
    {
        public static Uri GetBaseUri()
        {
            return new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
        }

        public static Uri GetFullUriWithoutQueryString()
        {
            return new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path));
        }

        public static string AddQueryStringPairsToUri(Uri uri, Dictionary<string, object> pairsToAdd)
        {
            var existingPairs = HttpUtility.ParseQueryString(uri.Query);

            foreach (var pairToAdd in pairsToAdd)
            {
                var existingPair = existingPairs[pairToAdd.Key];
                if (existingPair != null)
                {
                    existingPairs[pairToAdd.Key] = pairToAdd.Value.ToString();
                }
                else
                {
                    existingPairs.Add(pairToAdd.Key, pairToAdd.Value.ToString());
                }
            }

            return String.Format("{0}?{1}", uri.GetLeftPart(UriPartial.Path), existingPairs);
        }

        public static string AddQueryStringParameterToUri(Uri uri, string key, string value)
        {
            var queryStringCollection = HttpUtility.ParseQueryString(uri.Query);

            var segment = queryStringCollection[key];
            if (segment != null)
            {
                queryStringCollection[key] = value;
            }
            else
            {
                queryStringCollection.Add(key, value);
            }

            return String.Format("{0}?{1}", uri.GetLeftPart(UriPartial.Path), queryStringCollection);
        }

        public static T GetValueFromQueryString<T>(NameValueCollection queryString, string key)
        {
            var queryStringValue = queryString[key] ?? string.Empty;

            if (queryStringValue == string.Empty) return default(T);

            try
            {
                return (T)Convert.ChangeType(queryStringValue, typeof(T));
            }
            catch (Exception ex)
            {
            }

            return default(T);
        }
    }
}