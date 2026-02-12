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
    public partial class PosPaymentAppService
    {

        protected async Task<PosPayment> AdyenCaptureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment.py, METHOD: _adyen_capture) ---
            */
            return default;
        }

        protected async Task<PosPayment> CheckAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _check_amount) ---
            */
            return default;
        }

        protected async Task<PosPayment> CheckPaymentMethodIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _check_payment_method_id) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py, METHOD: _check_payment_method_id) ---
            */
            return default;
        }

        protected async Task<PosPayment> ComputeCashierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_payment.py, METHOD: _compute_cashier) ---
            */
            return default;
        }

        protected async Task<PosPayment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PosPayment> CreatePaymentMovesInternalAsync(object is_reverse)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _create_payment_moves) ---
            */
            return default;
        }

        protected async Task<PosPayment> GetReceivableLinesForInvoiceReconciliationInternalAsync(object receivable_account)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _get_receivable_lines_for_invoice_reconciliation) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPayment> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        protected async Task<PosPayment> UpdatePaymentLineForTipInternalAsync(object tip_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_payment.py, METHOD: _update_payment_line_for_tip) ---
            --- METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment.py, METHOD: _update_payment_line_for_tip) ---
            */
            return default;
        }
    }
}