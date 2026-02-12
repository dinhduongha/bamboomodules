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
    [Module("Purchase", Category = "SupplyChain", Depends = new[] { "account" })]
    public partial class PurchaseOrderLineAppService : GenericAppService<PurchaseOrderLine>, IPurchaseOrderLineAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        public PurchaseOrderLineAppService(IRepository<PurchaseOrderLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        public async Task<PurchaseOrderLine> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrderLine> ChooseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: action_choose) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrderLine> ClearQuantitiesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: action_clear_quantities) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PurchaseOrderLine> CreateAsync(CreateRequestDto<PurchaseOrderLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: project_purchase, FILE: purchase_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PurchaseOrderLine> GetParentSectionLineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: get_parent_section_line) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrderLine> OnchangeProductIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: onchange_product_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrderLine> OpenOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: action_open_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrderLine> ProductForecastReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: action_product_forecast_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PurchaseOrderLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}