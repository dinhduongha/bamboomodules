using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class ResCompanyAppService : GenericAppService<ResCompany>, IResCompanyAppService
    {
        protected readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        protected readonly IFormatVatLabelMixinAppService _formatVatLabelMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResCompanyAppService(IRepository<ResCompany, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IFormatAddressMixinAppService formatAddressMixinAppService, IFormatVatLabelMixinAppService formatVatLabelMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _formatVatLabelMixinAppService = formatVatLabelMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ResCompany> AllCompanyBranchesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: action_all_company_branches) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> CacheInvalidationFieldsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: cache_invalidation_fields) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> CloseStockValuationAsync(ResCompanyCloseStockValuationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: action_close_stock_valuation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> ComputeAccountTaxFiscalCountryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: compute_account_tax_fiscal_country) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> ComputeFiscalyearDatesAsync(ResCompanyComputeFiscalyearDatesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: compute_fiscalyear_dates) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResCompany> CreateAsync(CreateRequestDto<ResCompany> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: payment, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingDropshipPickingTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_picking_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingDropshipRuleAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_rule) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingDropshipSequenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_sequence) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingInventoryLossLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_inventory_loss_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingProductionLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_production_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingScrapLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_scrap_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingScrapSequenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_scrap_sequence) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingTransitLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_transit_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingUnbuildSequencesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: create_missing_unbuild_sequences) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> CreateMissingWarehouseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_warehouse) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GetChartOfAccountsOrFailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_chart_of_accounts_or_fail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> GetFiscalDatesAsync(ResCompanyGetFiscalDatesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: res_company.py, METHOD: get_fiscal_dates) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GetNewAccountCodeAsync(ResCompanyGetNewAccountCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_new_account_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GetNextBatchPaymentCommunicationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_next_batch_payment_communication) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GetUnaffectedEarningsAccountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_unaffected_earnings_account) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GoogleMapImgAsync(ResCompanyGoogleMapImgRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: google_map_img) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> GoogleMapLinkAsync(ResCompanyGoogleMapLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: google_map_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> IapEnrichAutoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: iap_enrich_auto) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> InstallL10nModulesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: install_l10n_modules) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: install_l10n_modules) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> OpenWebsiteThemeSelectorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: action_open_website_theme_selector) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> OpeningMovePostedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: opening_move_posted) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> ReflectCodePrefixChangeAsync(ResCompanyReflectCodePrefixChangeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: reflect_code_prefix_change) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> SaveOnboardingCompanyDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: action_save_onboarding_company_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> SaveOnboardingSaleTaxAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: action_save_onboarding_sale_tax) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> SettingInitBankAccountActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: setting_init_bank_account_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResCompany> SettingInitCreditCardAccountActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: setting_init_credit_card_account_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> StockAccountingValueAsync(ResCompanyStockAccountingValueRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: stock_accounting_value) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> StockValueAsync(ResCompanyStockValueRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: stock_value) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResCompany> ValidateLockDatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py, METHOD: validate_lock_dates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResCompany> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}