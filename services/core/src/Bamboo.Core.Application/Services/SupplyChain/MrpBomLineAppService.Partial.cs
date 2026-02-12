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
    public partial class MrpBomLineAppService
    {

        protected async Task<MrpBomLine> ComputeAttachmentsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_attachments_count) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> ComputeChildBomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_child_bom_id) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> ComputeChildLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_child_line_ids) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> GetCostShareInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _get_cost_share) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> GetDefaultProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_default_product_uom_id) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> GetLineCostShareInternalAsync(object product, object boms_done)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _get_line_cost_share) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> GetProductCatalogLinesDataInternalAsync(object @default)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> PrepareBomDoneValuesInternalAsync(object quantity, object product, object original_quantity, object boms_done)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _prepare_bom_done_values) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _prepare_bom_done_values) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> PrepareLineDoneValuesInternalAsync(object quantity, object product, object original_quantity, object parent_line, object boms_done)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _prepare_line_done_values) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _prepare_line_done_values) ---
            */
            return default;
        }

        protected async Task<MrpBomLine> SkipBomLineInternalAsync(object product, object never_attribute_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _skip_bom_line) ---
            */
            return default;
        }
    }
}