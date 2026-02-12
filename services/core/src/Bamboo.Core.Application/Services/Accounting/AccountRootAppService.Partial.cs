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
    public partial class AccountRootAppService
    {

        protected async Task<AccountRoot> ComputeRootInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_root.py, METHOD: _compute_root) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountRoot> FromAccountCodeInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_root.py, METHOD: _from_account_code) ---
            */
            return default;
        }

        protected async Task<object> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_root.py, METHOD: _search) ---
            */
            return default;
        }
    }
}