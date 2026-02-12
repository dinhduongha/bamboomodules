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
    public partial class ResUsersApikeysAppService
    {

        protected async Task<ResUsersApikeys> CheckCredentialsForUidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: auth_totp.py, METHOD: _check_credentials_for_uid) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> CheckCredentialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_credentials) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> CheckExpirationDateInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_expiration_date) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> GcUserApikeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _gc_user_apikeys) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> GenerateInternalAsync(object scope, object name, object expiration_date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _generate) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> GetTrustedDeviceAgeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: auth_totp.py, METHOD: _get_trusted_device_age) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeys> RemoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _remove) ---
            */
            return default;
        }
    }
}