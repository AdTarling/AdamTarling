using adamtarling.web.ViewModels;

namespace adamtarling.web.Services.CoreSevices.Interfaces
{
    public interface IEmailContentService
    {
        EmailViewModel GetEmailViewModelFromGeneralEmail(string emailAppSettingNodeIdKey);
    }
}