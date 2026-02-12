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
    [Module("Repair", Category = "SupplyChain", Depends = new[] { "sale_stock", "sale_management" })]
    public partial class RepairOrderAppService : GenericAppService<RepairOrder>, IRepairOrderAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public RepairOrderAppService(IRepository<RepairOrder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        public async Task<RepairOrder> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> AssignAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_assign) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ComputeLotIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_lot_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ComputeProductUomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_product_uom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<RepairOrder> CreateAsync(CreateRequestDto<RepairOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<RepairOrder> CreateSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_create_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ExplodeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: action_explode) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> GenerateSerialAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_generate_serial) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> OnchangeProductUomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: onchange_product_uom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> PrintRepairOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: print_repair_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> RepairCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> RepairCancelDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> RepairDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> RepairEndAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_end) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> RepairStartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_start) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> UnreserveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_unreserve) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ViewMrpProductionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: action_view_mrp_productions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_repair, FILE: repair_order.py, METHOD: action_view_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RepairOrder> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<RepairOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}