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
    public partial class HrExpenseSheetAppService : GenericAppService<HrExpenseSheet>, IHrExpenseSheetAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrExpenseSheetAppService(IRepository<HrExpenseSheet, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<HrExpenseSheet> ActivityUpdateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: activity_update) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> ApproveExpenseSheetsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_approve_expense_sheets) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> OpenAccountMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_open_account_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> OpenExpenseViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_open_expense_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> OpenSaleOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: action_open_sale_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> RefuseExpenseSheetsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_refuse_expense_sheets) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> RegisterPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_register_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> ResetExpenseSheetsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_reset_expense_sheets) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: action_reset_expense_sheets) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> SetToPaidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: set_to_paid) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> SetToPostedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: set_to_posted) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> SheetMovePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_sheet_move_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrExpenseSheet> SubmitSheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: action_submit_sheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}