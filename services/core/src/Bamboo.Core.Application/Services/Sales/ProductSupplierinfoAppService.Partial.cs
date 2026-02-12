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
    public partial class ProductSupplierinfoAppService
    {

        protected async Task<ProductSupplierinfo> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeIsSubcontractorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: product.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeLastPurchaseDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_last_purchase_date) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputePriceDiscountedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _compute_price_discounted) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputePriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _compute_price) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _compute_product_id) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductTmplIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _compute_product_tmpl_id) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeShowSetSupplierButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_show_set_supplier_button) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> GetFilteredSupplierInternalAsync(Guid company_id, Guid product_id, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _get_filtered_supplier) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_filtered_supplier) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> OnchangePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> OnchangeProductTmplIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _onchange_product_tmpl_id) ---
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }
    }
}