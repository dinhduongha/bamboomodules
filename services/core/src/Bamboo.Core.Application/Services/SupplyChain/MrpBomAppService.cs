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
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public partial class MrpBomAppService : GenericAppService<MrpBom>, IMrpBomAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public MrpBomAppService(IRepository<MrpBom, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        public async Task<MrpBom> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> CheckKitHasNotOrderpointAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: check_kit_has_not_orderpoint) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> ComputeBomDaysAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_compute_bom_days) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> ExplodeAsync(MrpBomExplodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: explode) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MrpBom> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> OnchangeBomStructureAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_bom_structure) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> OnchangeProductTmplIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_product_tmpl_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> OpenOperationFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_open_operation_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> SetBomOnOrderpointAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_set_bom_on_orderpoint) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpBom> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MrpBom> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}