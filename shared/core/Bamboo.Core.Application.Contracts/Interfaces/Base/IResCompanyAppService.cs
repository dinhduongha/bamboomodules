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
    public interface IResCompanyAppService : IGenericApplicationService<ResCompany>
    {
        Task<ResCompany> AllCompanyBranchesAsync(Guid[] ids);
        Task<ResCompany> CacheInvalidationFieldsAsync(Guid[] ids);
        Task<ResCompany> CloseStockValuationAsync(ResCompanyCloseStockValuationRequestDto input);
        Task<ResCompany> ComputeAccountTaxFiscalCountryAsync(Guid[] ids);
        Task<ResCompany> ComputeFiscalyearDatesAsync(ResCompanyComputeFiscalyearDatesRequestDto input);
        Task<ResCompany> CreateMissingDropshipPickingTypeAsync(Guid[] ids);
        Task<ResCompany> CreateMissingDropshipRuleAsync(Guid[] ids);
        Task<ResCompany> CreateMissingDropshipSequenceAsync(Guid[] ids);
        Task<ResCompany> CreateMissingInventoryLossLocationAsync(Guid[] ids);
        Task<ResCompany> CreateMissingProductionLocationAsync(Guid[] ids);
        Task<ResCompany> CreateMissingScrapLocationAsync(Guid[] ids);
        Task<ResCompany> CreateMissingScrapSequenceAsync(Guid[] ids);
        Task<ResCompany> CreateMissingTransitLocationAsync(Guid[] ids);
        Task<ResCompany> CreateMissingUnbuildSequencesAsync(Guid[] ids);
        Task<ResCompany> CreateMissingWarehouseAsync(Guid[] ids);
        Task<ResCompany> GetChartOfAccountsOrFailAsync(Guid[] ids);
        Task<ResCompany> GetFiscalDatesAsync(ResCompanyGetFiscalDatesRequestDto input);
        Task<ResCompany> GetNewAccountCodeAsync(ResCompanyGetNewAccountCodeRequestDto input);
        Task<ResCompany> GetNextBatchPaymentCommunicationAsync(Guid[] ids);
        Task<ResCompany> GetUnaffectedEarningsAccountAsync(Guid[] ids);
        Task<ResCompany> GoogleMapImgAsync(ResCompanyGoogleMapImgRequestDto input);
        Task<ResCompany> GoogleMapLinkAsync(ResCompanyGoogleMapLinkRequestDto input);
        Task<ResCompany> IapEnrichAutoAsync(Guid[] ids);
        Task<ResCompany> InitAsync(Guid[] ids);
        Task<ResCompany> InstallL10nModulesAsync(Guid[] ids);
        Task<ResCompany> OpenWebsiteThemeSelectorAsync(Guid[] ids);
        Task<ResCompany> OpeningMovePostedAsync(Guid[] ids);
        Task<ResCompany> ReflectCodePrefixChangeAsync(ResCompanyReflectCodePrefixChangeRequestDto input);
        Task<ResCompany> SaveOnboardingCompanyDataAsync(Guid[] ids);
        Task<ResCompany> SaveOnboardingSaleTaxAsync(Guid[] ids);
        Task<ResCompany> SettingInitBankAccountActionAsync(Guid[] ids);
        Task<ResCompany> SettingInitCreditCardAccountActionAsync(Guid[] ids);
        Task<ResCompany> StockAccountingValueAsync(ResCompanyStockAccountingValueRequestDto input);
        Task<ResCompany> StockValueAsync(ResCompanyStockValueRequestDto input);
        Task<ResCompany> ValidateLockDatesAsync(Guid[] ids);
    }
}