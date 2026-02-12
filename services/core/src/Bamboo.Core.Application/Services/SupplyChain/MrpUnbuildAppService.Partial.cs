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
    public partial class MrpUnbuildAppService
    {

        protected async Task<MrpUnbuild> ComputeBomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_bom_id) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_id) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateConsumeMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_consume_moves) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateMoveFromBomLineInternalAsync(object product, object product_uom, object quantity, Guid bom_line_id, Guid byproduct_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_move_from_bom_line) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateMoveFromExistingMoveInternalAsync(object move, object factor, Guid location_id, Guid location_dest_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_move_from_existing_move) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> GenerateProduceMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_produce_moves) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> PrepareFinishedMoveLineValsInternalAsync(object finished_move)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _prepare_finished_move_line_vals) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> PrepareMoveLineValsInternalAsync(object move, object origin_move_line, object taken_quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _prepare_move_line_vals) ---
            */
            return default;
        }

        protected async Task<MrpUnbuild> UnlinkExceptDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _unlink_except_done) ---
            */
            return default;
        }
    }
}