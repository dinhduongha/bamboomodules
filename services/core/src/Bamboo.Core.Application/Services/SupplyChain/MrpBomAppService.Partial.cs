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
    public partial class MrpBomAppService
    {

        [ApiModel]
        protected async Task<MrpBom> BomFindDomainInternalAsync(object products, object picking_type, Guid company_id, object bom_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpBom> BomFindInternalAsync(object products, object picking_type, Guid company_id, object bom_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find) ---
            */
            return default;
        }

        protected async Task<MrpBom> BomSubcontractFindInternalAsync(object product, object picking_type, Guid company_id, object bom_type, object subcontractor)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_bom.py, METHOD: _bom_subcontract_find) ---
            */
            return default;
        }

        protected async Task<MrpBom> CheckBomCycleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_cycle) ---
            */
            return default;
        }

        protected async Task<MrpBom> CheckBomLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_lines) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _check_bom_lines) ---
            */
            return default;
        }

        protected async Task<MrpBom> CheckSubcontractingNoOperationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_bom.py, METHOD: _check_subcontracting_no_operation) ---
            */
            return default;
        }

        protected async Task<MrpBom> CheckValidBatchSizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_valid_batch_size) ---
            */
            return default;
        }

        protected async Task<MrpBom> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MrpBom> ComputeOperationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_operation_count) ---
            */
            return default;
        }

        protected async Task<MrpBom> ComputePossibleProductTemplateAttributeValueIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_possible_product_template_attribute_value_ids) ---
            */
            return default;
        }

        protected async Task<MrpBom> ComputeShowSetBomButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_show_set_bom_button) ---
            */
            return default;
        }

        protected async Task<MrpBom> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        protected async Task<MrpBom> EnsureBomIsFreeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_bom.py, METHOD: _ensure_bom_is_free) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetDefaultProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_default_product_uom_id) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetExtraAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_extra_attachments) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetMailThreadDataAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<MrpBom> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        protected async Task<MrpBom> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpBom> RoundLastLineDoneInternalAsync(object lines_done)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _round_last_line_done) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py, METHOD: _round_last_line_done) ---
            */
            return default;
        }

        protected async Task<MrpBom> SetOutdatedBomInProductionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _set_outdated_bom_in_productions) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpBom> SkipForNoVariantInternalAsync(object product, object bom_attribule_values, object never_attribute_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _skip_for_no_variant) ---
            */
            return default;
        }

        protected async Task<MrpBom> UnlinkExceptRunningMoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _unlink_except_running_mo) ---
            */
            return default;
        }

        protected async Task<MrpBom> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }
    }
}