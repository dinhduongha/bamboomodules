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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class PurchaseBillLineMatchAppService
    {

        [ApiModel]
        protected async Task<PurchaseBillLineMatch> ActionCreateBillFromPoLinesInternalAsync(object partner, object po_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _action_create_bill_from_po_lines) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> ComputeAmountUntaxedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _compute_amount_untaxed_fields) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> ComputeProductUomPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _compute_product_uom_price) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> ComputeReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _compute_reference) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> InverseProductUomPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _inverse_product_uom_price) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> InverseProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _inverse_product_uom_qty) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseBillLineMatch> SelectAmLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _select_am_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseBillLineMatch> SelectPoLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _select_po_line) ---
            */
            return default;
        }

        protected async Task<PurchaseBillLineMatch> TableQueryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_bill_line_match.py, METHOD: _table_query) ---
            */
            return default;
        }
    }
}