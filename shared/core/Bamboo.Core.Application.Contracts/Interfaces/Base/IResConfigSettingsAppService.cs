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
        Task<ResConfigSettings> ButtonDisconnectThisDatabaseAsync(Guid id);
        Task<ResConfigSettings> ButtonOpenPeppolConfigWizardAsync(Guid id);
        Task<ResConfigSettings> ButtonPeppolDisconnectBranchFromParentAsync(Guid id);
        Task<ResConfigSettings> ButtonPeppolRegisterSenderAsReceiverAsync(Guid id);
        Task<ResConfigSettings> ButtonReconnectThisDatabaseAsync(Guid id);
        Task<ResConfigSettings> CancelAsync(Guid id);
        Task<ResConfigSettings> CrmAssignLeadsAsync(Guid id);
        Task<ResConfigSettings> CustomLinkActionAsync(Guid id);
        Task<ResConfigSettings> EditExternalHeaderAsync(Guid id);
        Task<ResConfigSettings> EuOssTaxMappingAsync(Guid id);
        Task<ResConfigSettings> ExecuteAsync(Guid id);
        Task<ResConfigSettings> GenerateQrCodesPageAsync(Guid id);
        Task<ResConfigSettings> GenerateQrCodesZipAsync(Guid id);
        Task<ResConfigSettings> GetConfigWarningAsync(Guid id, ResConfigSettingsGetConfigWarningRequestDto input);
        Task<ResConfigSettings> GetOptionNameAsync(Guid id, ResConfigSettingsGetOptionNameRequestDto input);
        Task<ResConfigSettings> GetOptionPathAsync(Guid id, ResConfigSettingsGetOptionPathRequestDto input);
        Task<ResConfigSettings> GetPosQrStandsAsync(Guid id);
        Task<ResConfigSettings> GetUriAsync(Guid id);
        Task<ResConfigSettings> GetValuesAsync(Guid id);
        Task<ResConfigSettings> OnchangeAdvLocationAsync(Guid id);
        Task<ResConfigSettings> OnchangeAnalyticAccountingAsync(Guid id);
        Task<ResConfigSettings> OnchangeModuleAccountBudgetAsync(Guid id);
        Task<ResConfigSettings> OpenAbandonedCartMailTemplateAsync(Guid id);
        Task<ResConfigSettings> OpenBlockedThirdPartyDomainsAsync(Guid id);
        Task<ResConfigSettings> OpenCloudStorageMigrationConfigurationsAsync(Guid id);
        Task<ResConfigSettings> OpenCompanyAsync(Guid id);
        Task<ResConfigSettings> OpenEmailLayoutAsync(Guid id);
        Task<ResConfigSettings> OpenExtraInfoAsync(Guid id);
        Task<ResConfigSettings> OpenFollowupLevelFormAsync(Guid id);
        Task<ResConfigSettings> OpenMailTemplatesAsync(Guid id);
        Task<ResConfigSettings> OpenNewUserDefaultGroupsAsync(Guid id);
        Task<ResConfigSettings> OpenPaymentMethodFormAsync(Guid id);
        Task<ResConfigSettings> OpenPeppolFormAsync(Guid id);
        Task<ResConfigSettings> OpenProductFeedsAsync(Guid id);
        Task<ResConfigSettings> OpenRobotsAsync(Guid id);
        Task<ResConfigSettings> OpenSaleMailTemplatesAsync(Guid id);
        Task<ResConfigSettings> OpenSmsTwilioAccountManageAsync(Guid id);
        Task<ResConfigSettings> OpenTemplateUserAsync(Guid id);
        Task<ResConfigSettings> PosCloseUiAsync(Guid id);
        Task<ResConfigSettings> PosConfigCreateNewAsync(Guid id);
        Task<ResConfigSettings> PosOpenUiAsync(Guid id);
        Task<ResConfigSettings> PosPrinterDialogAsync(Guid id);
        Task<ResConfigSettings> PreviewSelfOrderAppAsync(Guid id);
        Task<ResConfigSettings> RedirectToBuyAutocompleteCreditAsync(Guid id);
        Task<ResConfigSettings> RegenerateKioskKeyAsync(Guid id);
        Task<ResConfigSettings> ReloadTemplateAsync(Guid id);
        Task<ResConfigSettings> SetValuesAsync(Guid id);
        Task<ResConfigSettings> UpdateAccessTokensAsync(Guid id);
        Task<ResConfigSettings> UpdateTermsAsync(Guid id);
        Task<ResConfigSettings> ViewDeliveryProviderModulesAsync(Guid id);
        Task<ResConfigSettings> ViewInStoreDeliveryMethodsAsync(Guid id);
        Task<ResConfigSettings> WPaymentStartPaymentOnboardingAsync(Guid id);
        Task<ResConfigSettings> WebsiteCreateNewAsync(Guid id);
    }
}