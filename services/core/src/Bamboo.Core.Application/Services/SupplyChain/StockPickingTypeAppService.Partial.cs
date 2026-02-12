using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class StockPickingTypeAppService
    {

        protected async Task<StockPickingType> CheckActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _check_active) ---
            */
            return default;
        }

        protected async Task<StockPickingType> CheckDefaultLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _check_default_location) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeCountRepairInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_count_repair) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_default_location_dest_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_default_location_dest_id) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_default_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultLocationSrcIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_default_location_src_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_default_location_src_id) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_default_location_src_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultProductLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_default_product_location_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultRecycleLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_default_recycle_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultRemoveLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_default_remove_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDockIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py, METHOD: _compute_dock_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeHideReservationMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _compute_hide_reservation_method) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_hide_reservation_method) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeKanbanDashboardGraphInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_kanban_dashboard_graph) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeMoveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_move_count) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputePickingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_picking_count) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputePrintLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_print_label) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeShowPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_picking_type) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_show_picking_type) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeUseCreateLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _compute_use_create_lots) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_use_create_lots) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeUseExistingLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _compute_use_existing_lots) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_use_existing_lots) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_warehouse_id) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPickingType> GetActionInternalAsync(object action_xmlid)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_action) ---
            */
            return default;
        }

        protected async Task<StockPickingType> GetAggregatedRecordsByDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _get_aggregated_records_by_date) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _get_aggregated_records_by_date) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_aggregated_records_by_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> GetBatchAndWaveGroupByKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_batch_and_wave_group_by_keys) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> GetBatchGroupByKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _get_batch_group_by_keys) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_batch_group_by_keys) ---
            */
            return default;
        }

        protected async Task<StockPickingType> GetCodeReportNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_code_report_name) ---
            */
            return default;
        }

        protected async Task<StockPickingType> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _get_default_weight_uom) ---
            */
            return default;
        }

        protected async Task<StockPickingType> GetMoCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _get_mo_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> GetWaveGroupByKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_wave_group_by_keys) ---
            */
            return default;
        }

        protected async Task<StockPickingType> InverseIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> IsAutoBatchGroupedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _is_auto_batch_grouped) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> IsAutoWaveGroupedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _is_auto_wave_grouped) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<StockPickingType> OnchangePickingCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_picking_code) ---
            */
            return default;
        }

        protected async Task<StockPickingType> OnchangeSequenceCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_sequence_code) ---
            */
            return default;
        }

        protected async Task<StockPickingType> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        protected async Task<StockPickingType> PrepareGraphDataInternalAsync(object summaries)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _prepare_graph_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingType> SearchIsFavoriteInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_is_favorite) ---
            */
            return default;
        }

        protected async Task<StockPickingType> ValidateAutoBatchGroupByInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _validate_auto_batch_group_by) ---
            */
            return default;
        }
    }
}