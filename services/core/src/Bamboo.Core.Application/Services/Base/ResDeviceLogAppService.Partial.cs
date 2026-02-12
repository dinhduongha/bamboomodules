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
    public partial class ResDeviceLogAppService
    {

        protected async Task<ResDeviceLog> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> ComputeIsCurrentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _compute_is_current) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> ComputeLinkedIpAddressesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _compute_linked_ip_addresses) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResDeviceLog> FromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _from) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> GcDeviceLogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _gc_device_log) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> IsMobileInternalAsync(object platform)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _is_mobile) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> QueryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _query) ---
            */
            return default;
        }

        protected async Task<ResDeviceLog> RevokeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _revoke) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResDeviceLog> SelectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _select) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResDeviceLog> UpdateDeviceInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _update_device) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResDeviceLog> WhereInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: _where) ---
            */
            return default;
        }

        private async Task<ResDeviceLog> _UpdateRevokedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_device.py, METHOD: __update_revoked) ---
            */
            return default;
        }
    }
}