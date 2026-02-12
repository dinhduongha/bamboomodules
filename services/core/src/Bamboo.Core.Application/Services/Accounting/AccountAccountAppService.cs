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
    public partial class AccountAccountAppService : GenericAppService<AccountAccount>, IAccountAccountAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountAccountAppService(IRepository<AccountAccount, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<AccountAccount> CopyDataAsync(AccountAccountCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAccount> CopyTranslationsAsync(AccountAccountCopyTranslationsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: copy_translations) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> GetAccountGroupAsync(AccountAccountGetAccountGroupRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: get_account_group) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAccount> OpenRelatedTaxesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: action_open_related_taxes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> SpreadsheetFetchBalanceTagAsync(AccountAccountSpreadsheetFetchBalanceTagRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: spreadsheet_fetch_balance_tag) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> SpreadsheetFetchDebitCreditAsync(AccountAccountSpreadsheetFetchDebitCreditRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: spreadsheet_fetch_debit_credit) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> SpreadsheetFetchPartnerBalanceAsync(AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: spreadsheet_fetch_partner_balance) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> SpreadsheetFetchResidualAmountAsync(AccountAccountSpreadsheetFetchResidualAmountRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: spreadsheet_fetch_residual_amount) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAccount> SpreadsheetMoveLineActionAsync(AccountAccountSpreadsheetMoveLineActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: spreadsheet_move_line_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAccount> UnmergeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: action_unmerge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}