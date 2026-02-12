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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockPickingAppService : GenericAppService<StockPicking>, IStockPickingAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public StockPickingAppService(IRepository<StockPicking, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockPicking> AddEntirePacksAsync(StockPickingAddEntirePacksRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_add_entire_packs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> AddOperationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_add_operations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> AssignAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_assign) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> AssignBatchUserAsync(StockPickingAssignBatchUserRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: assign_batch_user) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ButtonScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: button_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ButtonValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_picking.py, METHOD: button_validate) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: button_validate) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: button_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> CalculateDateCategoryAsync(StockPickingCalculateDateCategoryRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: calculate_date_category) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> CancelShipmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: cancel_shipment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<StockPicking> CreateAsync(CreateRequestDto<StockPicking> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<StockPicking> DateCategoryToDomainAsync(StockPickingDateCategoryToDomainRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: date_category_to_domain) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> DetailedOperationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: action_detailed_operations) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_detailed_operations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> DoPrintPickingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: do_print_picking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> DoUnreserveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: do_unreserve) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> GetClickGraphAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: get_action_click_graph) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: get_action_click_graph) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_click_graph) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> GetEmptyListHelpAsync(StockPickingGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> GetMultipleCarrierTrackingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: get_multiple_carrier_tracking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> GetPickingTreeIncomingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_incoming) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> GetPickingTreeInternalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_internal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPicking> GetPickingTreeOutgoingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_outgoing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> NextTransferAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_next_transfer) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> OpenLabelLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_open_label_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> OpenLabelTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_open_label_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> OpenWebsiteUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: open_website_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> PickingMoveTreeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_picking_move_tree) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> PrintReturnLabelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: print_return_label) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> PutInPackAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_put_in_pack) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> RepairReturnAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: action_repair_return) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SeeMoveScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_move_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SeePackageHistoriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_package_histories) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SeePackagesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_packages) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SeeReturnsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_returns) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SendToShipperAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: send_to_shipper) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ShouldPrintDeliveryAddressAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: should_print_delivery_address) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ShowSubcontractDetailsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: action_show_subcontract_details) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> SplitTransferAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_split_transfer) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ToggleIsLockedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_toggle_is_locked) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ViewBatchAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_view_batch) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: action_view_mrp_production) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ViewReceptionReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_view_reception_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ViewRepairsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: action_view_repairs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPicking> ViewSubcontractingSourcePurchaseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py, METHOD: action_view_subcontracting_source_purchase) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockPicking> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}