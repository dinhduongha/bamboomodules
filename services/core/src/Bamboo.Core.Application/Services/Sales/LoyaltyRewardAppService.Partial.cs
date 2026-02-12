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
    public partial class LoyaltyRewardAppService
    {

        protected async Task<LoyaltyReward> CheckRewardProductIdNoComboInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _check_reward_product_id_no_combo) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeAllDiscountProductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_all_discount_product_ids) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_description) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_reward.py, METHOD: _compute_description) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeIsGlobalDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_is_global_discount) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeMultiProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_multi_product) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeRewardProductDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_reward_product_domain) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeRewardProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_reward_product_uom_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeUserHasDebugInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _compute_user_has_debug) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> CreateMissingDiscountLineProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _create_missing_discount_line_products) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> FindAllCategoryChildrenInternalAsync(Guid category_id, List<Guid> child_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _find_all_category_children) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyReward> GetActiveProductsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _get_active_products_domain) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountModeSelectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _get_discount_mode_select) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountProductDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _get_discount_product_domain) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountProductValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _get_discount_product_values) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _get_discount_product_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_reward.py, METHOD: _get_discount_product_values) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetRewardProductDomainFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _get_reward_product_domain_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyReward> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyReward> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyReward> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ParseDomainInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _parse_domain) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> ReplaceIlikeWithInInternalAsync(object domain_str)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: _replace_ilike_with_in) ---
            */
            return default;
        }

        protected async Task<LoyaltyReward> SearchRewardProductIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: _search_reward_product_ids) ---
            */
            return default;
        }
    }
}