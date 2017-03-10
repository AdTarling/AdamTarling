using adamtarling.web.Constants;
using System.Configuration;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace adamtarling.web.Utils
{
    public static class NodeUtils
    {
        public static IPublishedContent GetRootNode()
        {
            var umbracoHelper = PerRequestCacheManager.UmbracoHelper();
            var siteRoot = umbracoHelper.TypedContentAtRoot().FirstOrDefault();
            return siteRoot;
        }

        public static IPublishedContent GetRootNode(IPublishedContent currentPage)
        {
            var siteRoot = currentPage.AncestorsOrSelf().FirstOrDefault(node => node.Level == ConfigurationParameters.SiteRootLevel);
            return siteRoot;
        }

        public static IPublishedContent GetRootNode(int? currentPageNodeId)
        {
            var umbracoHelper = PerRequestCacheManager.UmbracoHelper();
            var siteRoot = umbracoHelper.TypedContent(currentPageNodeId)
                .AncestorsOrSelf().FirstOrDefault(node => node.Level == ConfigurationParameters.SiteRootLevel);

            return siteRoot;
        }

        public static IPublishedContent GetNodeByXpath(string xpath)
        {
            var umbracoHelper = PerRequestCacheManager.UmbracoHelper();
            var node = umbracoHelper.TypedContentSingleAtXPath(xpath);
            return node;
        }

        public static IPublishedContent GetFirstNodeMatchingDocumentType(string documentTypeAlias)
        {
            var documentTypeFirstNode =
                GetRootNode().Children.FirstOrDefault(n => n.DocumentTypeAlias.Equals(documentTypeAlias));
            return documentTypeFirstNode;
        }

        public static IPublishedContent GetContentFromAppSettingKey(string appSettingKey)
        {
            IPublishedContent content = null;
            var value = ConfigurationManager.AppSettings[appSettingKey];
            int id;

            if (int.TryParse(value, out id))
            {
                var helper = PerRequestCacheManager.UmbracoHelper();
                content = helper.TypedContent(id);
            }

            return content;
        }

        public static IPublishedContent GetContentById(int id)
        {
            IPublishedContent content = null;

            if (id > default(int))
            {
                var helper = PerRequestCacheManager.UmbracoHelper();
                content = helper.TypedContent(id);
            }

            return content;
        }

        public static int GetContentId(string webConfigSetting)
        {
            var value = ConfigurationManager.AppSettings[webConfigSetting];
            int id;

            int.TryParse(value, out id);
            return id;
        }

        public static int? GetDomainRootNodeId()
        {
            return UmbracoContext.Current.PublishedContentRequest.UmbracoDomain.RootContentId;
        }
    }
}