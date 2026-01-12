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
        Task<ResCompany> AllCompanyBranchesAsync(Guid id);
        Task<ResCompany> CacheInvalidationFieldsAsync(Guid id);
        Task<ResCompany> ComputeAccountTaxFiscalCountryAsync(Guid id);
        Task<ResCompany> ComputeFiscalyearDatesAsync(Guid id, ResCompanyComputeFiscalyearDatesRequestDto input);
        Task<ResCompany> CreateMissingDropshipPickingTypeAsync(Guid id);
        Task<ResCompany> CreateMissingDropshipRuleAsync(Guid id);
        Task<ResCompany> CreateMissingDropshipSequenceAsync(Guid id);
        Task<ResCompany> CreateMissingInventoryLossLocationAsync(Guid id);
        Task<ResCompany> CreateMissingProductionLocationAsync(Guid id);
        Task<ResCompany> CreateMissingScrapLocationAsync(Guid id);
        Task<ResCompany> CreateMissingScrapSequenceAsync(Guid id);
        Task<ResCompany> CreateMissingTransitLocationAsync(Guid id);
        Task<ResCompany> CreateMissingUnbuildSequencesAsync(Guid id);
        Task<ResCompany> CreateMissingWarehouseAsync(Guid id);
        Task<ResCompany> GetChartOfAccountsOrFailAsync(Guid id);
        Task<ResCompany> GetFiscalDatesAsync(Guid id, ResCompanyGetFiscalDatesRequestDto input);
        Task<ResCompany> GetNewAccountCodeAsync(Guid id, ResCompanyGetNewAccountCodeRequestDto input);
        Task<ResCompany> GetNextBatchPaymentCommunicationAsync(Guid id);
        Task<ResCompany> GetUnaffectedEarningsAccountAsync(Guid id);
        Task<ResCompany> GoogleMapImgAsync(Guid id, ResCompanyGoogleMapImgRequestDto input);
        Task<ResCompany> GoogleMapLinkAsync(Guid id, ResCompanyGoogleMapLinkRequestDto input);
        Task<ResCompany> IapEnrichAutoAsync(Guid id);
        Task<ResCompany> InitAsync(Guid id);
        Task<ResCompany> InstallL10nModulesAsync(Guid id);
        Task<ResCompany> OpenWebsiteThemeSelectorAsync(Guid id);
        Task<ResCompany> OpeningMovePostedAsync(Guid id);
        Task<ResCompany> ReflectCodePrefixChangeAsync(Guid id, ResCompanyReflectCodePrefixChangeRequestDto input);
        Task<ResCompany> SaveOnboardingCompanyDataAsync(Guid id);
        Task<ResCompany> SaveOnboardingSaleTaxAsync(Guid id);
        Task<ResCompany> SettingInitBankAccountActionAsync(Guid id);
        Task<ResCompany> ValidateLockDatesAsync(Guid id);
    }
}