using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResCompanyController
    {
        
        [HttpPost]
        [Route("{id}/action-all-company-branches")]
        public async Task<IActionResult> ActionAllCompanyBranchesAsync(Guid id)
        {
            var result = await _appService.AllCompanyBranchesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-website-theme-selector")]
        public async Task<IActionResult> ActionOpenWebsiteThemeSelectorAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteThemeSelectorAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-save-onboarding-company-data")]
        public async Task<IActionResult> ActionSaveOnboardingCompanyDataAsync(Guid id)
        {
            var result = await _appService.SaveOnboardingCompanyDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-save-onboarding-sale-tax")]
        public async Task<IActionResult> ActionSaveOnboardingSaleTaxAsync(Guid id)
        {
            var result = await _appService.SaveOnboardingSaleTaxAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cache-invalidation-fields")]
        public async Task<IActionResult> CacheInvalidationFieldsAsync(Guid id)
        {
            var result = await _appService.CacheInvalidationFieldsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-account-tax-fiscal-country")]
        public async Task<IActionResult> ComputeAccountTaxFiscalCountryAsync(Guid id)
        {
            var result = await _appService.ComputeAccountTaxFiscalCountryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-fiscalyear-dates")]
        public async Task<IActionResult> ComputeFiscalyearDatesAsync(Guid id, [FromBody] ResCompanyComputeFiscalyearDatesRequestDto input)
        {
            var result = await _appService.ComputeFiscalyearDatesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-dropship-picking-type")]
        public async Task<IActionResult> CreateMissingDropshipPickingTypeAsync(Guid id)
        {
            var result = await _appService.CreateMissingDropshipPickingTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-dropship-rule")]
        public async Task<IActionResult> CreateMissingDropshipRuleAsync(Guid id)
        {
            var result = await _appService.CreateMissingDropshipRuleAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-dropship-sequence")]
        public async Task<IActionResult> CreateMissingDropshipSequenceAsync(Guid id)
        {
            var result = await _appService.CreateMissingDropshipSequenceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-inventory-loss-location")]
        public async Task<IActionResult> CreateMissingInventoryLossLocationAsync(Guid id)
        {
            var result = await _appService.CreateMissingInventoryLossLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-production-location")]
        public async Task<IActionResult> CreateMissingProductionLocationAsync(Guid id)
        {
            var result = await _appService.CreateMissingProductionLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-scrap-location")]
        public async Task<IActionResult> CreateMissingScrapLocationAsync(Guid id)
        {
            var result = await _appService.CreateMissingScrapLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-scrap-sequence")]
        public async Task<IActionResult> CreateMissingScrapSequenceAsync(Guid id)
        {
            var result = await _appService.CreateMissingScrapSequenceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-transit-location")]
        public async Task<IActionResult> CreateMissingTransitLocationAsync(Guid id)
        {
            var result = await _appService.CreateMissingTransitLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-unbuild-sequences")]
        public async Task<IActionResult> CreateMissingUnbuildSequencesAsync(Guid id)
        {
            var result = await _appService.CreateMissingUnbuildSequencesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-missing-warehouse")]
        public async Task<IActionResult> CreateMissingWarehouseAsync(Guid id)
        {
            var result = await _appService.CreateMissingWarehouseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-chart-of-accounts-or-fail")]
        public async Task<IActionResult> GetChartOfAccountsOrFailAsync(Guid id)
        {
            var result = await _appService.GetChartOfAccountsOrFailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-fiscal-dates")]
        public async Task<IActionResult> GetFiscalDatesAsync(Guid id, [FromBody] ResCompanyGetFiscalDatesRequestDto input)
        {
            var result = await _appService.GetFiscalDatesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-new-account-code")]
        public async Task<IActionResult> GetNewAccountCodeAsync(Guid id, [FromBody] ResCompanyGetNewAccountCodeRequestDto input)
        {
            var result = await _appService.GetNewAccountCodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-next-batch-payment-communication")]
        public async Task<IActionResult> GetNextBatchPaymentCommunicationAsync(Guid id)
        {
            var result = await _appService.GetNextBatchPaymentCommunicationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unaffected-earnings-account")]
        public async Task<IActionResult> GetUnaffectedEarningsAccountAsync(Guid id)
        {
            var result = await _appService.GetUnaffectedEarningsAccountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync(Guid id, [FromBody] ResCompanyGoogleMapImgRequestDto input)
        {
            var result = await _appService.GoogleMapImgAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(Guid id, [FromBody] ResCompanyGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/iap-enrich-auto")]
        public async Task<IActionResult> IapEnrichAutoAsync(Guid id)
        {
            var result = await _appService.IapEnrichAutoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/install-l10n-modules")]
        public async Task<IActionResult> InstallL10nModulesAsync(Guid id)
        {
            var result = await _appService.InstallL10nModulesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/opening-move-posted")]
        public async Task<IActionResult> OpeningMovePostedAsync(Guid id)
        {
            var result = await _appService.OpeningMovePostedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reflect-code-prefix-change")]
        public async Task<IActionResult> ReflectCodePrefixChangeAsync(Guid id, [FromBody] ResCompanyReflectCodePrefixChangeRequestDto input)
        {
            var result = await _appService.ReflectCodePrefixChangeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/setting-init-bank-account-action")]
        public async Task<IActionResult> SettingInitBankAccountActionAsync(Guid id)
        {
            var result = await _appService.SettingInitBankAccountActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-lock-dates")]
        public async Task<IActionResult> ValidateLockDatesAsync(Guid id)
        {
            var result = await _appService.ValidateLockDatesAsync(id);
            return Ok(result);
        }
    }
}