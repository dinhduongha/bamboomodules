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
    public partial class AccountPaymentMethodLineAppService
    {

        [ApiModel]
        protected async Task<AccountPaymentMethodLine> AutoToggleAccountToReconcileInternalAsync(Guid account_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_method.py, METHOD: _auto_toggle_account_to_reconcile) ---
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_method.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_method.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputePaymentProviderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py, METHOD: _compute_payment_provider_id) ---
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> EnsureUniqueNameForJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_method.py, METHOD: _ensure_unique_name_for_journal) ---
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> UnlinkExceptActiveProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py, METHOD: _unlink_except_active_provider) ---
            */
            return default;
        }
    }
}