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
    public partial class RestaurantTableAppService
    {

        protected async Task<RestaurantTable> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<RestaurantTable> GetIdentifierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py, METHOD: _get_identifier) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RestaurantTable> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RestaurantTable> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RestaurantTable> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RestaurantTable> LoadPosSelfDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py, METHOD: _load_pos_self_data_fields) ---
            */
            return default;
        }

        protected async Task<RestaurantTable> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: _unlink_except_active_pos_session) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RestaurantTable> UpdateIdentifierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py, METHOD: _update_identifier) ---
            */
            return default;
        }
    }
}