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
    public partial class PurchaseRequisitionAppService
    {

        protected async Task<PurchaseRequisition> CheckDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _check_dates) ---
            */
            return default;
        }

        protected async Task<PurchaseRequisition> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<PurchaseRequisition> ComputeOrdersNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_orders_number) ---
            */
            return default;
        }

        protected async Task<PurchaseRequisition> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase_requisition.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        protected async Task<PurchaseRequisition> OnchangeVendorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _onchange_vendor) ---
            */
            return default;
        }

        protected async Task<PurchaseRequisition> UnlinkIfDraftOrCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _unlink_if_draft_or_cancel) ---
            */
            return default;
        }
    }
}