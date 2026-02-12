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
    public partial class AccountAnalyticLineAppService : GenericAppService<AccountAnalyticLine>, IAccountAnalyticLineAppService
    {
        protected readonly IAnalyticPlanFieldsMixinAppService _analyticPlanFieldsMixinAppService;
        public AccountAnalyticLineAppService(IRepository<AccountAnalyticLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticPlanFieldsMixinAppService analyticPlanFieldsMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticPlanFieldsMixinAppService = analyticPlanFieldsMixinAppService;
        }

        public override async Task<AccountAnalyticLine> CreateAsync(CreateRequestDto<AccountAnalyticLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<AccountAnalyticLine> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        [ApiModel]
        public async Task<AccountAnalyticLine> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAnalyticLine> GetUnusualDaysAsync(AccountAnalyticLineGetUnusualDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: get_unusual_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountAnalyticLine> GetViewsAsync(AccountAnalyticLineGetViewsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: get_views) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticLine> InvoiceFromTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: action_invoice_from_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticLine> OnChangeUnitAmountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: on_change_unit_amount) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticLine> OpenTimesheetViewPortalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: action_open_timesheet_view_portal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticLine> SaleOrderFromTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: action_sale_order_from_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        [ApiModel]
        public async Task<AccountAnalyticLine> ViewHeaderGetAsync(AccountAnalyticLineViewHeaderGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: view_header_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountAnalyticLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}