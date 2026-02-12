using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/base/ResCompany")]
    public partial class ResCompanyController : AbpController
    {
        protected readonly IResCompanyAppService _appService;
        public ResCompanyController(IResCompanyAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-all-company-branches")]
        public async Task<IActionResult> AllCompanyBranchesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AllCompanyBranchesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-stock-valuation")]
        public async Task<IActionResult> CloseStockValuationAsync([FromBody] ResCompanyCloseStockValuationRequestDto input)
        {
            var result = await _appService.CloseStockValuationAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-website-theme-selector")]
        public async Task<IActionResult> OpenWebsiteThemeSelectorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWebsiteThemeSelectorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-save-onboarding-company-data")]
        public async Task<IActionResult> SaveOnboardingCompanyDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaveOnboardingCompanyDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-save-onboarding-sale-tax")]
        public async Task<IActionResult> SaveOnboardingSaleTaxAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaveOnboardingSaleTaxAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cache-invalidation-fields")]
        public async Task<IActionResult> CacheInvalidationFieldsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CacheInvalidationFieldsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-account-tax-fiscal-country")]
        public async Task<IActionResult> ComputeAccountTaxFiscalCountryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeAccountTaxFiscalCountryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-fiscalyear-dates")]
        public async Task<IActionResult> ComputeFiscalyearDatesAsync([FromBody] ResCompanyComputeFiscalyearDatesRequestDto input)
        {
            var result = await _appService.ComputeFiscalyearDatesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-dropship-picking-type")]
        public async Task<IActionResult> CreateMissingDropshipPickingTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingDropshipPickingTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-dropship-rule")]
        public async Task<IActionResult> CreateMissingDropshipRuleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingDropshipRuleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-dropship-sequence")]
        public async Task<IActionResult> CreateMissingDropshipSequenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingDropshipSequenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-inventory-loss-location")]
        public async Task<IActionResult> CreateMissingInventoryLossLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingInventoryLossLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-production-location")]
        public async Task<IActionResult> CreateMissingProductionLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingProductionLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-scrap-location")]
        public async Task<IActionResult> CreateMissingScrapLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingScrapLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-scrap-sequence")]
        public async Task<IActionResult> CreateMissingScrapSequenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingScrapSequenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-transit-location")]
        public async Task<IActionResult> CreateMissingTransitLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingTransitLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-unbuild-sequences")]
        public async Task<IActionResult> CreateMissingUnbuildSequencesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingUnbuildSequencesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-missing-warehouse")]
        public async Task<IActionResult> CreateMissingWarehouseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMissingWarehouseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-chart-of-accounts-or-fail")]
        public async Task<IActionResult> GetChartOfAccountsOrFailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetChartOfAccountsOrFailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-fiscal-dates")]
        public async Task<IActionResult> GetFiscalDatesAsync([FromBody] ResCompanyGetFiscalDatesRequestDto input)
        {
            var result = await _appService.GetFiscalDatesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-new-account-code")]
        public async Task<IActionResult> GetNewAccountCodeAsync([FromBody] ResCompanyGetNewAccountCodeRequestDto input)
        {
            var result = await _appService.GetNewAccountCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-next-batch-payment-communication")]
        public async Task<IActionResult> GetNextBatchPaymentCommunicationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetNextBatchPaymentCommunicationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unaffected-earnings-account")]
        public async Task<IActionResult> GetUnaffectedEarningsAccountAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetUnaffectedEarningsAccountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync([FromBody] ResCompanyGoogleMapImgRequestDto input)
        {
            var result = await _appService.GoogleMapImgAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync([FromBody] ResCompanyGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("iap-enrich-auto")]
        public async Task<IActionResult> IapEnrichAutoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IapEnrichAutoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-l10n-modules")]
        public async Task<IActionResult> InstallL10nModulesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InstallL10nModulesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("opening-move-posted")]
        public async Task<IActionResult> OpeningMovePostedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpeningMovePostedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reflect-code-prefix-change")]
        public async Task<IActionResult> ReflectCodePrefixChangeAsync([FromBody] ResCompanyReflectCodePrefixChangeRequestDto input)
        {
            var result = await _appService.ReflectCodePrefixChangeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("setting-init-bank-account-action")]
        public async Task<IActionResult> SettingInitBankAccountActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SettingInitBankAccountActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("setting-init-credit-card-account-action")]
        public async Task<IActionResult> SettingInitCreditCardAccountActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SettingInitCreditCardAccountActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stock-accounting-value")]
        public async Task<IActionResult> StockAccountingValueAsync([FromBody] ResCompanyStockAccountingValueRequestDto input)
        {
            var result = await _appService.StockAccountingValueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stock-value")]
        public async Task<IActionResult> StockValueAsync([FromBody] ResCompanyStockValueRequestDto input)
        {
            var result = await _appService.StockValueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-lock-dates")]
        public async Task<IActionResult> ValidateLockDatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateLockDatesAsync(ids);
            return Ok(result);
        }
    }
    
}