using System;
using adamtarling.web.Services.CoreSevices.Interfaces;
using adamtarling.web.ViewModels;
using adamtarling.web.Utils;
using Umbraco.Core;
using Umbraco.Web;
using adamtarling.web.Constants;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using adamtarling.web.ExtensionMethods;

namespace adamtarling.web.Services.CoreSevices
{
    public class EmailContentService : IEmailContentService
    {
        public EmailViewModel GetEmailViewModelFromGeneralEmail(string emailAppSettingNodeIdKey)
        {
            var emailViewModel = new EmailViewModel();

            if (emailAppSettingNodeIdKey.IsNullOrWhiteSpace())
            {
                return emailViewModel;
            }

            var emailContent = NodeUtils.GetContentFromAppSettingKey(emailAppSettingNodeIdKey);

            if (emailContent == null)
            {
                return emailViewModel;
            }

            emailViewModel.BaseUriString = UrlUtils.GetBaseUri() != null
                ? UrlUtils.GetBaseUri().ToString()
                : String.Empty;

            emailViewModel.EmailTitle = emailContent.GetPropertyValue<string>(PropertyAliases.Email.EmailTitle);
            emailViewModel.Subject = emailContent.GetPropertyValue<string>(PropertyAliases.Email.Subject);
            emailViewModel.FromDisplayName = emailContent.GetPropertyValue<string>(PropertyAliases.Email.FromDisplayName);
            emailViewModel.FromAddress = emailContent.GetPropertyValue<string>(PropertyAliases.Email.FromAddress);

            var toAddresses = emailContent.GetPropertyValue<string>(PropertyAliases.Email.ToAddress);
            emailViewModel.ToAddresses = GetToAddressesFromAddressString(toAddresses);
            emailViewModel.CopyTitle = emailContent.GetPropertyValue<string>(PropertyAliases.Email.CopyTitle);

            var copy = emailContent.GetPropertyValue<IHtmlString>(PropertyAliases.Email.Copy);
            emailViewModel.Copy = !copy.IsNullOrWhiteSpace()
                ? new HtmlString(copy.ToString().PrependRelativeHrefsWithBaseUri(emailViewModel.BaseUriString))
                : new HtmlString(String.Empty);

            return emailViewModel;
        }

        private IEnumerable<string> GetToAddressesFromAddressString(string toAddresses)
        {
            if (!toAddresses.IsNullOrWhiteSpace())
            {
                return toAddresses.Split(';').Select(p => p.Trim()).ToList();
            }

            return new List<string>();
        }
    }
}