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
    [Module("Analytic", Category = "Accounting", Depends = new[] { "base", "mail", "uom" })]
    public partial class AccountAnalyticAccountAppService : GenericAppService<AccountAnalyticAccount>, IAccountAnalyticAccountAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public AccountAnalyticAccountAppService(IRepository<AccountAnalyticAccount, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<AccountAnalyticAccount> CopyDataAsync(AccountAnalyticAccountCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py, METHOD: action_view_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewMrpBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: action_view_mrp_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: action_view_mrp_production) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewProjectsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py, METHOD: action_view_projects) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: analytic_account.py, METHOD: action_view_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewVendorBillAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py, METHOD: action_view_vendor_bill) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewWorkorderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: action_view_workorder) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync(AccountAnalyticAccountWebReadRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: web_read) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}