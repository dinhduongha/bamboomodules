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
    public partial class LoyaltyProgramAppService
    {

        protected async Task<LoyaltyProgram> CheckDateFromDateToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _check_date_from_date_to) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> CheckPricelistCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _check_pricelist_currency) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeCouponCountDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_coupon_count_display) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeCouponCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_coupon_count) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeFromProgramTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_from_program_type) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeIsNominativeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_is_nominative) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeIsPaymentProgramInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_is_payment_program) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeMailTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_mail_template_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_order_count) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePaymentProgramDiscountProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_payment_program_discount_product_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePortalPointNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_portal_point_name) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePosConfigIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_config_ids) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePosOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_order_count) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePosReportPrintIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_report_print_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeShowNonPublishedProductWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_show_non_published_product_warning) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeTotalOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ConstrainsRewardIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _constrains_reward_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> GetTemplateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _get_template_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: _get_template_values) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> GetValidProductsInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _get_valid_products) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> InverseMailTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _inverse_mail_template_id) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> InversePosReportPrintIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _inverse_pos_report_print_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> ProgramItemsNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _program_items_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyProgram> ProgramTypeDefaultValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _program_type_default_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: _program_type_default_values) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> UnlinkExceptActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _unlink_except_active) ---
            */
            return default;
        }

        protected async Task<LoyaltyProgram> UnrelevantRecordsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _unrelevant_records) ---
            */
            return default;
        }
    }
}