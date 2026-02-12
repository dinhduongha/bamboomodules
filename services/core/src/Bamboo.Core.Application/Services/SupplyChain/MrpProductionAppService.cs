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
    public partial class MrpProductionAppService : GenericAppService<MrpProduction>, IMrpProductionAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public MrpProductionAppService(IRepository<MrpProduction, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        public async Task<MrpProduction> AssignAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_assign) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ButtonMarkDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_mark_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ButtonPlanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_plan) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ButtonScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ButtonUnbuildAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unbuild) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_unbuild.py, METHOD: button_unbuild) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ButtonUnplanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unplan) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ClearLotProducingIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_clear_lot_producing_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_production.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> CopyDataAsync(MrpProductionCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> DoUnreserveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: do_unreserve) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> GenerateBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_bom) ---
            --- METHOD SOURCE (MODULE: project_mrp, FILE: mrp_production.py, METHOD: action_generate_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> GenerateSerialAsync(MrpProductionGenerateSerialRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_serial) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MrpProduction> GetEmptyListHelpAsync(MrpProductionGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> MergeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_merge) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: action_merge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> OpenLabelLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> OpenLabelTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> PlanWithComponentsAvailabilityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_plan_with_components_availability) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> PreButtonMarkDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: pre_button_mark_done) ---
            --- METHOD SOURCE (MODULE: mrp_product_expiry, FILE: mrp_production.py, METHOD: pre_button_mark_done) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: pre_button_mark_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ProductForecastReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_product_forecast_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> SeeMoveScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_see_move_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> SetQtyProducingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: set_qty_producing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> SplitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_split) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> SplitSubcontractingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: action_split_subcontracting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> StartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_start) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ToggleIsLockedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_toggle_is_locked) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> UpdateBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_update_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewAnalyticAccountsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: mrp_production.py, METHOD: action_view_analytic_accounts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMoDeliveryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mo_delivery) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMoveWipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: action_view_move_wip) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMrpProductionBackordersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_backorders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMrpProductionChildsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_childs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMrpProductionSourcesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_sources) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewMrpProductionUnbuildsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_unbuilds) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_production.py, METHOD: action_view_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewReceptionReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_reception_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewRepairOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: production.py, METHOD: action_view_repair_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewSaleOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_production.py, METHOD: action_view_sale_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpProduction> ViewSerialNumbersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_serial_numbers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MrpProduction> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: mrp_production.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}