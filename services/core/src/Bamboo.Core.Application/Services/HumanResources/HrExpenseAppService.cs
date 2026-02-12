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
    [Module("HrExpenseModule", Category = "HumanResources", Depends = new[] { "account", "web_tour", "hr" })]
    public partial class HrExpenseAppService : GenericAppService<HrExpense>, IHrExpenseAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrExpenseAppService(IRepository<HrExpense, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<HrExpense> ApproveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> ApproveDuplicatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve_duplicates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> AttachDocumentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: attach_document) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrExpense> CreateAsync(CreateRequestDto<HrExpense> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: hr_expense.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<HrExpense> CreateExpenseFromAttachmentsAsync(HrExpenseCreateExpenseFromAttachmentsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create_expense_from_attachments) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrExpense> GetEmptyListHelpAsync(HrExpenseGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrExpense> GetExpenseDashboardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_expense_dashboard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrExpense> MessageNewAsync(HrExpenseMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> OpenAccountMoveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_account_move) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> OpenSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: action_open_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> OpenSplitExpenseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_split_expense) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> PayAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_pay) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> PostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: hr_expense.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: action_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> RefuseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_refuse) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> ResetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_reset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> ShowSameReceiptExpenseIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_show_same_receipt_expense_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> SplitWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_split_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> SubmitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_submit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpense> UpdateActivitiesAndMailsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: update_activities_and_mails) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}