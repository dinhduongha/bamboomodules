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
    public partial class StockPickingBatchAppService
    {

        protected async Task<StockPickingBatch> AreMovesAutoMergeableInternalAsync(object num_of_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _are_moves_auto_mergeable) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ArePickingsAutoMergeableInternalAsync(object num_of_pickings)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _are_pickings_auto_mergeable) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeAllowedPickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_allowed_picking_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeCapacityPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_capacity_percentage) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeDockIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_dock_id) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeDriverIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_driver_id) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeEndDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_end_date) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeEstimatedShippingCapacityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_estimated_shipping_capacity) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeMoveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_move_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeMoveLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_move_line_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_scheduled_date) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeShowAllocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_show_allocation) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeShowLotsTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_show_lots_text) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeVehicleCategoryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_vehicle_category_id) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeVolumeUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> GetMergedBatchValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _get_merged_batch_vals) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _get_merged_batch_vals) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> IsLineAutoMergeableInternalAsync(object num_of_moves, object num_of_pickings, object weight)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_line_auto_mergeable) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_line_auto_mergeable) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> IsPickingAutoMergeableInternalAsync(object picking)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_picking_auto_mergeable) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_picking_auto_mergeable) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPickingBatch> PrepareNameInternalAsync(object picking_type, object sequence_code, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _prepare_name) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> SanityCheckInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _sanity_check) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> SearchMoveLineIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _search_move_line_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> SetMoveLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _set_move_line_ids) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> SetMovesDestinationToDockInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: _set_moves_destination_to_dock) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<StockPickingBatch> UnlinkIfNotDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _unlink_if_not_done) ---
            */
            return default;
        }
    }
}