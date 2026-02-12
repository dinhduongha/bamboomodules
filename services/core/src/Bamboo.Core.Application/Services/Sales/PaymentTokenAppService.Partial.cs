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
    public partial class PaymentTokenAppService
    {

        protected async Task<PaymentToken> BuildDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _build_display_name) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_token.py, METHOD: _build_display_name) ---
            */
            return default;
        }

        protected async Task<PaymentToken> CheckPartnerIsNeverPublicInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _check_partner_is_never_public) ---
            */
            return default;
        }

        protected async Task<PaymentToken> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PaymentToken> GetAvailableTokensInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _get_available_tokens) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: payment_token.py, METHOD: _get_available_tokens) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentToken> GetSpecificCreateValuesInternalAsync(object provider_code, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _get_specific_create_values) ---
            */
            return default;
        }

        protected async Task<PaymentToken> HandleArchivingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_token.py, METHOD: _handle_archiving) ---
            */
            return default;
        }

        protected async Task<PaymentToken> RazorpayGetLimitExceedWarningInternalAsync(object amount, Guid currency_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_token.py, METHOD: _razorpay_get_limit_exceed_warning) ---
            */
            return default;
        }

        protected async Task<PaymentToken> StripeScaMigrateCustomerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_token.py, METHOD: _stripe_sca_migrate_customer) ---
            */
            return default;
        }
    }
}