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
    public partial class PosCategoryAppService
    {

        protected async Task<PosCategory> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_category.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<PosCategory> CheckCategoryRecursionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _check_category_recursion) ---
            */
            return default;
        }

        protected async Task<PosCategory> CheckHourInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _check_hour) ---
            */
            return default;
        }

        protected async Task<PosCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PosCategory> ComputeHasImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _compute_has_image) ---
            */
            return default;
        }

        protected async Task<PosCategory> GetDescendantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _get_descendants) ---
            */
            return default;
        }

        protected async Task<List<string>> GetHierarchyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _get_hierarchy) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosCategory> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosCategory> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<PosCategory> UnlinkExceptSessionOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py, METHOD: _unlink_except_session_open) ---
            */
            return default;
        }
    }
}