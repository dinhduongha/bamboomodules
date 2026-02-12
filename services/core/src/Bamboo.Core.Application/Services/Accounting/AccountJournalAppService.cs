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
    public partial class AccountJournalAppService : GenericAppService<AccountJournal>, IAccountJournalAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailAliasMixinOptionalAppService _mailAliasMixinOptionalAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        public AccountJournalAppService(IRepository<AccountJournal, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailAliasMixinOptionalAppService mailAliasMixinOptionalAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailAliasMixinOptionalAppService = mailAliasMixinOptionalAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
        }

        public async Task<AccountJournal> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ButtonFetchInEinvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_fetch_in_einvoices) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py, METHOD: button_fetch_in_einvoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ButtonRefreshOutEinvoicesStatusAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_refresh_out_einvoices_status) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py, METHOD: button_refresh_out_einvoices_status) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ButtonUnsubscribeFromInvoiceNotificationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_unsubscribe_from_invoice_notifications) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ChecksToPrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: action_checks_to_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ConfigureBankJournalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: action_configure_bank_journal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CopyDataAsync(AccountJournalCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<AccountJournal> CreateAsync(CreateRequestDto<AccountJournal> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<AccountJournal> CreateBankStatementAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: create_bank_statement) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateCustomerPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: create_customer_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateDocumentFromAttachmentAsync(AccountJournalCreateDocumentFromAttachmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create_document_from_attachment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateNewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: action_create_new) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateSupplierPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: create_supplier_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateVendorBillAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: action_create_vendor_bill) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: open_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenBankDifferenceActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: open_bank_difference_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenInvalidStatementsActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: open_invalid_statements_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenPaymentsActionAsync(AccountJournalOpenPaymentsActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: open_payments_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenWithContextAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: open_action_with_context) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> PostAllEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: action_post_all_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> SetBankAccountAsync(AccountJournalSetBankAccountRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: set_bank_account) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ShowSequenceHolesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: show_sequence_holes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ShowUnhashedEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: show_unhashed_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ToCheckIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: to_check_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountJournal> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}