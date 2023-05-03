using System.Collections.Generic;
using Volo.Abp.Account.Web.Pages.Account;

namespace Bamboo.Abp.LoginUi.Web.Pages.Components.ExternalLoginWidget;

// https://community.abp.io/posts/how-to-customize-the-login-page-for-mvc-razor-page-applications-9a40f3cd

public class ExternalLoginWidgetModel
{
    public IEnumerable<LoginModel.ExternalProviderModel> VisibleExternalProviders { get; set; }
    
    public string ReturnUrl { get; set; }
    
    public string ReturnUrlHash { get; set; }

    public ExternalLoginWidgetModel()
    {
        VisibleExternalProviders = new List<LoginModel.ExternalProviderModel>();
    }
    
    public ExternalLoginWidgetModel(IEnumerable<LoginModel.ExternalProviderModel> visibleExternalProviders, string returnUrl, string returnUrlHash)
    {
        VisibleExternalProviders = visibleExternalProviders;
        ReturnUrl = returnUrl;
        ReturnUrlHash = returnUrlHash;
    }
}