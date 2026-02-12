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
    public partial class UomUomAppService
    {

        protected async Task<UomUom> AdjustUomQuantitiesInternalAsync(object qty, object quant_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _adjust_uom_quantities) ---
            */
            return default;
        }

        protected async Task<UomUom> CheckFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _check_factor) ---
            */
            return default;
        }

        protected async Task<UomUom> CheckQtyInternalAsync(object product_qty, Guid uom_id, object rounding_method)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _check_qty) ---
            */
            return default;
        }

        protected async Task<UomUom> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<UomUom> ComputeFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_factor) ---
            */
            return default;
        }

        protected async Task<UomUom> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: uom_uom.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        protected async Task<float> ComputePriceInternalAsync(float price, object to_unit)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_price) ---
            */
            return default;
        }

        protected async Task<float> ComputeQuantityInternalAsync(float qty, object to_unit, bool round, object rounding_method, bool raise_if_failure)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_quantity) ---
            */
            return default;
        }

        protected async Task<UomUom> ComputeRoundingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_rounding) ---
            */
            return default;
        }

        protected async Task<UomUom> ComputeSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _compute_sequence) ---
            */
            return default;
        }

        protected async Task<UomUom> DomainProductUomsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: uom_uom.py, METHOD: _domain_product_uoms) ---
            */
            return default;
        }

        protected async Task<UomUom> FilterProtectedUomsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _filter_protected_uoms) ---
            */
            return default;
        }

        protected async Task<UomUom> GetUneceCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: uom_uom.py, METHOD: _get_unece_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<UomUom> GetUomFromUneceCodeInternalAsync(object unece_code)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: uom_uom.py, METHOD: _get_uom_from_unece_code) ---
            */
            return default;
        }

        protected async Task<bool> HasCommonReferenceInternalAsync(object other_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _has_common_reference) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<UomUom> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: uom.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<UomUom> OnchangeCriticalFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _onchange_critical_fields) ---
            */
            return default;
        }

        protected async Task<UomUom> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        protected async Task<UomUom> UnprotectedUomXmlIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: uom_uom.py, METHOD: _unprotected_uom_xml_ids) ---
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: _unprotected_uom_xml_ids) ---
            */
            return default;
        }
    }
}