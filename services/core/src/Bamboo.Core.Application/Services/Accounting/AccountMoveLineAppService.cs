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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountMoveLineAppService : GenericAppService<AccountMoveLine>, IAccountMoveLineAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        public AccountMoveLineAppService(IRepository<AccountMoveLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        public async Task<AccountMoveLine> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> AssetCreateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: asset_create) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> AutomaticEntryAsync(AccountMoveLineAutomaticEntryRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_automatic_entry) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> CopyDataAsync(AccountMoveLineCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<AccountMoveLine> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<AccountMoveLine> FlushModelAsync(AccountMoveLineFlushModelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: flush_model) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> FlushRecordsetAsync(AccountMoveLineFlushRecordsetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: flush_recordset) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> GetColumnToExcludeForColspanCalculationAsync(AccountMoveLineGetColumnToExcludeForColspanCalculationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_column_to_exclude_for_colspan_calculation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMoveLine> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> GetInvoiceLineAccountAsync(AccountMoveLineGetInvoiceLineAccountRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: get_invoice_line_account) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> GetParentSectionLineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_parent_section_line) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> GetSectionSubtotalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_section_subtotal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMoveLine> GetViewsAsync(AccountMoveLineGetViewsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_views) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> InvalidateModelAsync(AccountMoveLineInvalidateModelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: invalidate_model) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> InvalidateRecordsetAsync(AccountMoveLineInvalidateRecordsetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: invalidate_recordset) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> OnchangeAssetCategoryIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: onchange_asset_category_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> OpenReconcileViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: open_reconcile_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> PaymentItemsRegisterPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_payment_items_register_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> ReconcileAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: reconcile) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> RegisterPaymentAsync(AccountMoveLineRegisterPaymentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_register_payment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMoveLine> RemoveMoveReconcileAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: remove_move_reconcile) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMoveLine> SearchFetchAsync(AccountMoveLineSearchFetchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: search_fetch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move_line.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<AccountMoveLine> UnreconcileMatchEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_unreconcile_match_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountMoveLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}