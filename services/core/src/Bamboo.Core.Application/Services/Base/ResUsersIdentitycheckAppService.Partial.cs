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
    public partial class ResUsersIdentitycheckAppService
    {

        protected async Task<ResUsersIdentitycheck> CheckIdentityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users_identitycheck.py, METHOD: _check_identity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_identity) ---
            */
            return default;
        }

        protected async Task<ResUsersIdentitycheck> GetDefaultAuthMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users_identitycheck.py, METHOD: _get_default_auth_method) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_default_auth_method) ---
            */
            return default;
        }
    }
}