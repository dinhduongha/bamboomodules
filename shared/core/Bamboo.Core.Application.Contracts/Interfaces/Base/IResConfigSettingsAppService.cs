using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResConfigSettingsAppService : IGenericApplicationService<ResConfigSettings>
    {
        Task<ResConfigSettings> ButtonDisconnectThisDatabaseAsync(Guid[] ids);
        Task<ResConfigSettings> ButtonOpenPeppolConfigWizardAsync(Guid[] ids);
        Task<ResConfigSettings> ButtonPeppolDisconnectBranchFromParentAsync(Guid[] ids);
        Task<ResConfigSettings> ButtonPeppolRegisterSenderAsReceiverAsync(Guid[] ids);
        Task<ResConfigSettings> ButtonReconnectThisDatabaseAsync(Guid[] ids);
        Task<ResConfigSettings> CancelAsync(Guid[] ids);
        Task<ResConfigSettings> CrmAssignLeadsAsync(Guid[] ids);
        Task<ResConfigSettings> CustomLinkActionAsync(Guid[] ids);
        Task<ResConfigSettings> EditExternalHeaderAsync(Guid[] ids);
        Task<ResConfigSettings> EuOssTaxMappingAsync(Guid[] ids);
        Task<ResConfigSettings> ExecuteAsync(Guid[] ids);
        Task<ResConfigSettings> GenerateQrCodesPageAsync(Guid[] ids);
        Task<ResConfigSettings> GenerateQrCodesZipAsync(Guid[] ids);
        Task<ResConfigSettings> GetConfigWarningAsync(ResConfigSettingsGetConfigWarningRequestDto input);
        Task<ResConfigSettings> GetOptionNameAsync(ResConfigSettingsGetOptionNameRequestDto input);
        Task<ResConfigSettings> GetOptionPathAsync(ResConfigSettingsGetOptionPathRequestDto input);
        Task<ResConfigSettings> GetPosQrStandsAsync(Guid[] ids);
        Task<ResConfigSettings> GetUriAsync(Guid[] ids);
        Task<ResConfigSettings> GetValuesAsync(Guid[] ids);
        Task<ResConfigSettings> OnchangeAdvLocationAsync(Guid[] ids);
        Task<ResConfigSettings> OnchangeAnalyticAccountingAsync(Guid[] ids);
        Task<ResConfigSettings> OnchangeModuleAccountBudgetAsync(Guid[] ids);
        Task<ResConfigSettings> OpenAbandonedCartMailTemplateAsync(Guid[] ids);
        Task<ResConfigSettings> OpenBlockedThirdPartyDomainsAsync(Guid[] ids);
        Task<ResConfigSettings> OpenCloudStorageMigrationConfigurationsAsync(Guid[] ids);
        Task<ResConfigSettings> OpenCompanyAsync(Guid[] ids);
        Task<ResConfigSettings> OpenEmailLayoutAsync(Guid[] ids);
        Task<ResConfigSettings> OpenExtraInfoAsync(Guid[] ids);
        Task<ResConfigSettings> OpenFollowupLevelFormAsync(Guid[] ids);
        Task<ResConfigSettings> OpenMailTemplatesAsync(Guid[] ids);
        Task<ResConfigSettings> OpenNewUserDefaultGroupsAsync(Guid[] ids);
        Task<ResConfigSettings> OpenPaymentMethodFormAsync(Guid[] ids);
        Task<ResConfigSettings> OpenPeppolFormAsync(Guid[] ids);
        Task<ResConfigSettings> OpenProductFeedsAsync(Guid[] ids);
        Task<ResConfigSettings> OpenRobotsAsync(Guid[] ids);
        Task<ResConfigSettings> OpenSaleMailTemplatesAsync(Guid[] ids);
        Task<ResConfigSettings> OpenSmsTwilioAccountManageAsync(Guid[] ids);
        Task<ResConfigSettings> OpenTemplateUserAsync(Guid[] ids);
        Task<ResConfigSettings> PosCloseUiAsync(Guid[] ids);
        Task<ResConfigSettings> PosConfigCreateNewAsync(Guid[] ids);
        Task<ResConfigSettings> PosOpenUiAsync(Guid[] ids);
        Task<ResConfigSettings> PosPrinterDialogAsync(Guid[] ids);
        Task<ResConfigSettings> PreviewSelfOrderAppAsync(Guid[] ids);
        Task<ResConfigSettings> RedirectToBuyAutocompleteCreditAsync(Guid[] ids);
        Task<ResConfigSettings> RegenerateKioskKeyAsync(Guid[] ids);
        Task<ResConfigSettings> ReloadTemplateAsync(Guid[] ids);
        Task<ResConfigSettings> SetValuesAsync(Guid[] ids);
        Task<ResConfigSettings> UpdateAccessTokensAsync(Guid[] ids);
        Task<ResConfigSettings> UpdateTermsAsync(Guid[] ids);
        Task<ResConfigSettings> ViewDeliveryProviderModulesAsync(Guid[] ids);
        Task<ResConfigSettings> ViewInStoreDeliveryMethodsAsync(Guid[] ids);
        Task<ResConfigSettings> WPaymentStartPaymentOnboardingAsync(Guid[] ids);
        Task<ResConfigSettings> WebsiteCreateNewAsync(Guid[] ids);
    }
}