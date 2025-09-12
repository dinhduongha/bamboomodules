using System.Collections.Generic;

namespace Bamboo.Abp.LoginUi.Web;

public static class SocialLoginProviders
{
    public static string DefaultButtonClasses = "";

    public static Dictionary<string, LoginProviderUiInfoModel> Providers { get; } = new()
    {
        // https://github.com/dotnet/aspnetcore/tree/main/src/Security/Authentication
        { "Facebook", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-facebook-square" } },
        { "Google", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-google" } },
        { "Microsoft", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-microsoft" } },
        { "Twitter", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-twitter" } },

        // https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
        { "AdobeIO", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-adobe" } },
        { "Alipay", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-alipay" } },
        { "Amazon", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-amazon" } },
        // { "amoCRM", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Apple", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-apple" } },
        // { "ArcGIS", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Asana", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Autodesk", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Automatic", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Baidu", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Basecamp", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "BattleNet", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Beam", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-mixer" } },
        { "Mixer", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-mixer" } },
        { "Bitbucket", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-bitbucket" } },
        { "Buffer", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-buffer" } },
        // { "CiscoSpark", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Webex Teams", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Coinbase", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "DeviantArt", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-deviantart" } },
        { "Deezer", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-deezer" } },
        { "Discord", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-discord" } },
        { "Dropbox", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-dropbox" } },
        { "eBay", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-ebay" } },
        // { "EVEOnline", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "ExactOnline", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Fitbit", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Foursquare", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-foursquare" } },
        // { "Gitee", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "GitHub", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-github" } },
        { "GitLab", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-gitlab" } },
        { "Gitter", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-gitter" } },
        // { "Harvest", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "HealthGraph", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Runkeeper", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Imgur", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Instagram", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-instagram" } },
        // { "KakaoTalk", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Kloudless", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Lichess", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Line", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-line" } },
        { "LinkedIn", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-linkedin" } },
        { "MailChimp", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-mailchimp" } },
        // { "MailRu", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Mixcloud", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-mixcloud" } },
        // { "Moodle", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Myob", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "NetEase", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Nextcloud", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Notion", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Odnoklassniki", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-odnoklassniki" } },
        // { "Okta", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Onshape", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Patreon", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-patreon" } },
        { "Paypal", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-paypal" } },
        { "QQ", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-qq" } },
        // { "QuickBooks", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Reddit", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-reddit" } },
        { "Salesforce", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-salesforce" } },
        // { "ServiceChannel", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Shopify", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-shopify" } },
        { "Slack", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-slack" } },
        { "SoundCloud", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-soundcloud" } },
        { "Spotify", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-spotify" } },
        { "Stack Exchange", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-stack-exchange" } },
        { "Strava", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-strava" } },
        // { "Streamlabs", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "SuperOffice", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Trakt", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Twitch", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-twitch" } },
        { "Untappd", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-untappd" } },
        { "Vimeo", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-vimeo" } },
        // { "Visual Studio", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Azure DevOps", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Vkontakte", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Weibo", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-weibo" } },
        { "Weixin", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-weixin" } },
        { "WeChat", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-weixin" } },
        { "WordPress", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-wordpress" } },
        // { "WorkWeixin", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "WeCom", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        { "Yahoo", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-yahoo" } },
        { "Yammer", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-yammer" } },
        { "Yandex", new LoginProviderUiInfoModel { ButtonClasses = "fab fa-yandex" } },
        // { "Zalo", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
        // { "Zendesk", new LoginProviderUiInfoModel { ButtonClasses = "???" } },
    };
    
    public static string GetButtonClasses(string authenticationScheme)
    {
        return Providers.ContainsKey(authenticationScheme)
            ? Providers[authenticationScheme].ButtonClasses
            : DefaultButtonClasses;
    }
}