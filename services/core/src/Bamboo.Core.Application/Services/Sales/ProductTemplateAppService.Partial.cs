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
    public partial class ProductTemplateAppService
    {

        protected async Task<ProductTemplate> AddArchivedCombinationsInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _add_archived_combinations) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> AllowPublishRatingStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> ApplyTaxesToPriceInternalAsync(object price, object currency, object product_taxes, object taxes, object product_or_template, object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _apply_taxes_to_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _auto_init) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> BaseDomainItemIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CanBeAddedToCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _can_be_added_to_cart) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CartesianProductInternalAsync(object product_template_attribute_values_per_line, object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckBarcodeUniquenessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckComboIdsNotEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckComboInclusionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _check_combo_inclusions) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckIncompatibleTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_incompatible_types) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckPrintImagesAreSetBeforePublishingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _check_print_images_are_set_before_publishing) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckProjectAndTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _check_project_and_template) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckSaleComboIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckSaleProductCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_sale_product_company) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckServiceToPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_service_to_purchase) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckServiceTrackingForEventBoothsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckUomNotInInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _check_uom_not_in_invoice) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CheckVendorForServiceToPurchaseInternalAsync(object sellers)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_vendor_for_service_to_purchase) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> CompleteInverseExclusionsInternalAsync(object exclusions)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBaseUnitPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCanBeExpensedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_can_be_expensed) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCanImage1024BeZoomedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCostCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCostMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeDefaultCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeExpensePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeExpensePolicyTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy_tooltip) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeGelatoMissingImagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_missing_images) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeGelatoProductUidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_product_uid) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeHasAvailableRouteIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_has_available_route_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeHasConfigurableAttributesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeInvoicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_invoice_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeIsDynamicallyCreatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeIsKitsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeIsProductVariantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeLotValuatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_lot_valuated) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeMrpProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeNbrMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeNbrReorderingRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeNextSerialInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_next_serial) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductDocumentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductVariantCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeProductVariantIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePublishDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_publish_date) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchaseMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchase_method) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchaseOkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputePurchasedProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeQuantitiesDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeSalesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeSelfOrderVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _compute_self_order_visible) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeSerialPrefixFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_serial_prefix_format) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_type) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_service_type) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeServiceUpsellThresholdRatioInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_service_upsell_threshold_ratio) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeShowQtyStatusButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeShowQtyUpdateButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeStandardPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTaskTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_task_template) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTaxStringInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTemplateFieldFromVariantFieldInternalAsync(object fname, object @default)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_tracking) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeUsedInBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeValidProductTemplateAttributeLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_valuation) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVariantsDefaultCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_variants_default_code) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVisibleExpensePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVolumeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeVolumeUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ConstructTaxStringInternalAsync(object price)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _construct_tax_string) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CreateAttributesFromGelatoInfoInternalAsync(object template_info)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CreateFirstProductVariantInternalAsync(object log_warning)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CreatePrintImagesFromGelatoInfoInternalAsync(object template_info)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_print_images_from_gelato_info) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CreateProductVariantInternalAsync(object combination, object log_warning)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> CreateVariantIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> DefaultPosSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _default_pos_sequence) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> DefaultResponsibleIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _default_responsible_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> DefaultWebsiteSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> DemoConfigureVariantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> DomainPricelistRuleIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> EnsureUnusedInPosInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _ensure_unused_in_pos) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> FilterCombinationsImpossibleByConfigInternalAsync(object combination_tuples, object ignore_no_variant)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultPurchaseTaxInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_purchase_tax) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultSaleTaxInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_sale_tax) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ForceDefaultTaxInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_tax) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetActionViewRelatedPutawayRulesInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_action_view_related_putaway_rules) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetAdditionalConfiguratorDataInternalAsync(object product_or_template, object date, object currency, object pricelist)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAdditionnalCombinationInfoInternalAsync(object product_or_template, object quantity, object uom, object date, object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            --- METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetAlternativeProductFilterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_alternative_product_filter) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAssetAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: product.py, METHOD: _get_asset_accounts) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttributeExclusionsInternalAsync(object parent_combination, object parent_name, List<Guid> combination_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttributeValueDomainInternalAsync(object attribute_value_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_attribute_value_domain) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAttributesExtraPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetAvailableUomsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetBaseUnitPriceInternalAsync(object price)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetClosestPossibleCombinationInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetClosestPossibleCombinationsInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetCombinationInfoInternalAsync(object combination, Guid product_id, object add_qty, Guid uom_id, object only_template)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetConfiguratorDisplayPriceInternalAsync(object product_or_template, object quantity, object date, object currency, object pricelist)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetConfiguratorPriceInternalAsync(object product_or_template, object quantity, object date, object currency, object pricelist)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetContextualPriceInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetContextualPricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetDefaultUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetFirstPossibleCombinationInternalAsync(object parent_combination, object necessary_values)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetFirstPossibleVariantIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGeneralToServiceInternalAsync(object invoice_policy, object service_type)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGeneralToServiceMapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service_map) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetGoogleAnalyticsDataInternalAsync(object product, object combination_info)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_google_analytics_data) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetImageHolderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_image_holder) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetImagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_images) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetIncompatibleTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_incompatible_types) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetLengthUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetLengthUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetListPriceInternalAsync(object price)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_list_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetMappedAttributeNamesInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetOnchangeServicePolicyUpdatesInternalAsync(object service_tracking, object service_policy, Guid project_id, Guid project_template_id)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_onchange_service_policy_updates) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetOwnAttributeExclusionsInternalAsync(List<Guid> combination_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetParentAttributeExclusionsInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleCombinationsInternalAsync(object parent_combination, object necessary_values)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleVariantsInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPossibleVariantsSortedInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_possible_variants_sorted) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetPreviewedAttributeValuesInternalAsync(object category, object product_query_params)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_previewed_attribute_values) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductDocumentDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductPlaceholderFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductPriceContextInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetProductTypesAllowZeroPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: product.py, METHOD: _get_product_types_allow_zero_price) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetProductUrlInternalAsync(object category, object query_params, object grouped_attributes_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_url) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetRelatedFieldsVariantTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetRibbonInternalAsync(object price_vals, object auto_assign_ribbons, object variant)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_ribbon) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetSaleableTrackingTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetSalesPricesInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_sales_prices) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetServiceToGeneralInternalAsync(object service_policy)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetServiceToGeneralMapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetSuitableImageSizeInternalAsync(object columns, object x_size, object y_size)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_suitable_image_size) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetTemplateMatrixInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py, METHOD: _get_template_matrix) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVariantForCombinationInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetVariantIdForCombinationInternalAsync(object filtered_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetVolumeUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetVolumeUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWebsiteAccessoryProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_accessory_product) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> GetWebsiteAlternativeProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_alternative_product) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetWeightUomIdFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> GetWeightUomNameFromIrConfigParameterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> HasIsCustomValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_is_custom_values) ---
            */
            return default;
        }

        protected async Task<bool> HasMultipleUomsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> HasNoVariantAttributesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_no_variant_attributes) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> InitColumnInternalAsync(object column_name)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _init_column) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseGelatoProductUidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _inverse_gelato_product_uid) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseQtyAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseSerialPrefixFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_serial_prefix_format) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> InverseServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> IsAddToCartPossibleInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _is_add_to_cart_possible) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> IsCombinationPossibleByConfigInternalAsync(object combination, object ignore_no_variant)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> IsCombinationPossibleInternalAsync(object combination, object parent_combination, object ignore_no_variant)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> IsInWishlistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> IsSoldOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: product_template.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> LoadPosDataSearchReadInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> LoadPosSelfDataReadInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> LoadProductWithDomainInternalAsync(object domain, object load_archived, object offset, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_product_with_domain) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnChangeAvailableInPosInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _on_change_available_in_pos) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeAvailableInPosInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_available_in_pos) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeBuyRouteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _onchange_buy_route) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeDefaultCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeSaleOkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_sale_ok) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceToPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _onchange_service_to_purchase) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeServiceTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeStandardPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeEventBoothInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeEventInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _onchange_type_event) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> OnchangeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareInvoicingTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareServiceTrackingTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> PrepareVariantValuesInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> PriceComputeInternalAsync(object price_type, object uom, object currency, object company, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ProcessPosSelfUiProductsInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _process_pos_self_ui_products) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ProcessPosUiProductProductInternalAsync(object products, Guid config_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _process_pos_ui_product_product) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> RatingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ReadGroupCategIdInternalAsync(object categories, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchBarcodeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductTemplate> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchIncomingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchIsKitsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchOutgoingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchQtyAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchRenderResultsPricesInternalAsync(object mapping, object combination_info)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results_prices) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchStandardPriceInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchValuationInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _search_valuation) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SearchVirtualAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SelectionServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _selection_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _selection_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ServiceTrackingBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: event_product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBaseUnitCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_count) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetBaseUnitIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_id) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetDefaultCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetProductVariantFieldInternalAsync(object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetStandardPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetVolumeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> SetWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ShouldOpenProductQuantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _should_open_product_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _should_open_product_quants) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> ToMarkupDataInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> UnlinkExceptLoyaltyProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> UnlinkExceptOpenSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _unlink_except_open_session) ---
            */
            return default;
        }

        protected async Task<ProductTemplate> WebsiteShowQuickAddInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }
    }
}