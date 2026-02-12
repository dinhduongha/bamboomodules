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
    [Module("Sale", Category = "Sales", Depends = new[] { "sales_team", "account_payment", "utm" })]
    public partial class SaleOrderLineAppService : GenericAppService<SaleOrderLine>, ISaleOrderLineAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public SaleOrderLineAppService(IRepository<SaleOrderLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<SaleOrderLine> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrderLine> ComputeUomQtyAsync(SaleOrderLineComputeUomQtyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: compute_uom_qty) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: compute_uom_qty) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrderLine> CopyDataAsync(SaleOrderLineCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<SaleOrderLine> CreateAsync(CreateRequestDto<SaleOrderLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<SaleOrderLine> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<SaleOrderLine> GetDescriptionFollowingLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: get_description_following_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrderLine> GetParentSectionLineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: get_parent_section_line) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrderLine> HasValuedMoveIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: has_valued_move_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: has_valued_move_ids) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: has_valued_move_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<List<(Guid Id, string Name)>> NameSearchAsync(NameSearchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_service, FILE: sale_order_line.py, METHOD: name_search) ---
            */
            return await base.NameSearchAsync(input);
        }

        public async Task<SaleOrderLine> ReadConvertedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: read_converted) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<SaleOrderLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}