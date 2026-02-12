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
    public partial class AccountPaymentAppService : GenericAppService<AccountPayment>, IAccountPaymentAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public AccountPaymentAppService(IRepository<AccountPayment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<AccountPayment> ButtonOpenBillsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_bills) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ButtonOpenInvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_invoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ButtonOpenJournalEntryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_journal_entry) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ButtonOpenStatementLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_statement_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ButtonRequestCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_request_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> CopyDataAsync(AccountPaymentCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> DoPrintChecksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: do_print_checks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: fields_get) ---
            */
            return await base.FieldsGetAsync(input);
        }

        public async Task<AccountPayment> MarkAsSentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: mark_as_sent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> OpenExpenseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py, METHOD: action_open_expense) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> PostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: action_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> PrintChecksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: print_checks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> RefundWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: action_refund_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> RejectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_reject) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> UnmarkAsSentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: unmark_as_sent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: account_payment.py, METHOD: action_view_pos_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> ViewRefundsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: action_view_refunds) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountPayment> VoidCheckAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: action_void_check) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountPayment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}