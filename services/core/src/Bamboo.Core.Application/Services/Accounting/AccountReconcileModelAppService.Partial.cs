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
    public partial class AccountReconcileModelAppService
    {

        protected async Task<AccountReconcileModel> CheckMatchLabelParamInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _check_match_label_param) ---
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputeCanBeProposedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _compute_can_be_proposed) ---
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputePartnerMappingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _compute_partner_mapping) ---
            */
            return default;
        }
    }
}