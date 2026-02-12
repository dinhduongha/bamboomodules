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
    public partial class ProductProductAppService
    {

        protected async Task<ProductProduct> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: _can_return_content) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _can_return_content) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: product.py, METHOD: _can_return_content) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: product_product.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ChangeStandardPriceInternalAsync(object old_price)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _change_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckBarcodeUniquenessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckBaseUnitCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _check_base_unit_count) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_company_id) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckDuplicatedPackagingBarcodesInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_duplicated_packaging_barcodes) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckDuplicatedProductBarcodesInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_duplicated_product_barcodes) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckEventTicketServiceTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_product, FILE: product_product.py, METHOD: _check_event_ticket_service_tracking) ---
            */
            return default;
        }

        protected async Task<ProductProduct> CheckServiceTrackingForEventBoothsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_product.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeAllProductTagIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_all_product_tag_ids) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBaseUnitNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBaseUnitPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeBomPriceInternalAsync(object bom, object boms_to_recompute, object byproduct_bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _compute_bom_price) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: product_product.py, METHOD: _compute_bom_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCanImage1024BeZoomedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCanImageVariant1024BeZoomedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_can_image_variant_1024_be_zoomed) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeCombinationIndicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_combination_indices) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage1024InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_1024) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage128InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_128) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage256InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_256) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeImage512InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_512) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsInPurchaseOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_is_in_purchase_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsKitsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeIsProductVariantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeMonthlyDemandInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_monthly_demand) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeMrpProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeNbrMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeNbrReorderingRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePartnerRefInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_partner_ref) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePricelistRuleIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_pricelist_rule_ids) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_code) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductDocumentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInBomAndMoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_product_is_in_bom_and_mo) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInRepairInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _compute_product_is_in_repair) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductIsInSaleOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _compute_product_is_in_sale_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductLstPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_lst_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductMarginFieldsValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_margin, FILE: product_product.py, METHOD: _compute_product_margin_fields_values) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductPriceExtraInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_price_extra) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeProductWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _compute_product_website_url) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputePurchasedProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeQuantitiesDictInternalAsync(Guid lot_id, Guid owner_id, Guid package_id, object from_date, object to_date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_quantities_dict) ---
            --- METHOD SOURCE (MODULE: product_expiry, FILE: product_product.py, METHOD: _compute_quantities_dict) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_quantities) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeSalesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeShowQtyStatusButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeShowQtyUpdateButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeStandardPriceUpdateWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_product.py, METHOD: _compute_standard_price_update_warning) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeSuggestEstimatedPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_suggest_estimated_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeSuggestedQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _compute_suggested_quantity) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeTaxStringInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeUsedInBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeValidEanInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_valid_ean) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_value) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ComputeWriteDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_write_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> CountReturnedSnProductsDomainInternalAsync(object sn_lot, object or_domains)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _count_returned_sn_products_domain) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _count_returned_sn_products_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _count_returned_sn_products_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> CountReturnedSnProductsInternalAsync(object sn_lot)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _count_returned_sn_products) ---
            */
            return default;
        }

        protected async Task<List<Dictionary<string, object>>> FilterApplicableAttributesInternalAsync(Guid attributes_by_ptal_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _filter_applicable_attributes) ---
            */
            return default;
        }

        protected async Task<ProductProduct> FilterToUnlinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _filter_to_unlink) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _filter_to_unlink) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _filter_to_unlink) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetAttributesExtraPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetBarcodeSearchDomainInternalAsync(object barcodes_within_company, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_barcode_search_domain) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetBarcodesByCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_barcodes_by_company) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetBaseUnitPriceInternalAsync(object price)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetCombinationInfoVariantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _get_combination_info_variant) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetContextualDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_contextual_discount) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetContextualPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetDatesInfoInternalAsync(object date, object location, List<Guid> route_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_dates_info) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetDescriptionInternalAsync(Guid picking_type_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_description) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: product.py, METHOD: _get_description) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetDomainLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_domain_locations) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetDomainLocationsNewInternalAsync(List<Guid> location_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_domain_locations_new) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetExtraImage1920UrlsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _get_extra_image_1920_urls) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetFilteredSellersInternalAsync(Guid partner_id, object quantity, object date, Guid uom_id, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_filtered_sellers) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetImage1024UrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_comparison, FILE: product_product.py, METHOD: _get_image_1024_url) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetImage1920UrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _get_image_1920_url) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetImagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _get_images) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetInvoicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_invoice_policy) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _get_invoice_policy) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetLastInInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_last_in) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetLinesDomainInternalAsync(List<Guid> location_ids, List<Guid> warehouse_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _get_lines_domain) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetMaxQuantityInternalAsync(object website, object sale_order)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _get_max_quantity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> GetMonthlyDemandMovesLocationDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: product_product.py, METHOD: _get_monthly_demand_moves_location_domain) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _get_monthly_demand_moves_location_domain) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetMonthlyDemandRangeInternalAsync(object based_on)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _get_monthly_demand_range) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetNoVariantAttributesPriceExtraInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_no_variant_attributes_price_extra) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetOnlyQtyAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_only_qty_available) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetPickingDescriptionInternalAsync(Guid picking_type_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_picking_description) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetProductAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetProductDomainSearchOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_domain_search_order) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: product_product.py, METHOD: _get_product_domain_search_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetProductPlaceholderFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_product_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: product.py, METHOD: _get_product_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: product_product.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetProductPriceContextInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetQuantityInProgressInternalAsync(List<Guid> location_ids, List<Guid> warehouse_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _get_quantity_in_progress) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_quantity_in_progress) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetRemainingMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_remaining_moves) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetRulesFromLocationInternalAsync(object location, List<Guid> route_ids, object seen_rules)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_rules_from_location) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetStandardPriceAtDateInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_standard_price_at_date) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetTaxIncludedUnitPriceFromPriceInternalAsync(object product_price_unit, object product_taxes, object fiscal_position, object product_taxes_after_fp)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_tax_included_unit_price_from_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetTaxIncludedUnitPriceInternalAsync(object company, object currency, object document_date, object document_type, object is_refund_document, object product_uom, object product_currency, object product_price_unit, object product_taxes, object fiscal_position)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_tax_included_unit_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> GetValueFromLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_value_from_lots) ---
            */
            return default;
        }

        protected async Task<ProductProduct> HasStockNotificationInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _has_stock_notification) ---
            */
            return default;
        }

        protected async Task<ProductProduct> InversePricelistRuleIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _inverse_pricelist_rule_ids) ---
            */
            return default;
        }

        protected async Task<ProductProduct> InverseQtyAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        protected async Task<ProductProduct> InverseServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_product.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductProduct> IsAddToCartAllowedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _is_add_to_cart_allowed) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_product.py, METHOD: _is_add_to_cart_allowed) ---
            */
            return default;
        }

        protected async Task<ProductProduct> IsDeliveredTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py, METHOD: _is_delivered_timesheet) ---
            */
            return default;
        }

        protected async Task<ProductProduct> IsInWishlistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        protected async Task<ProductProduct> IsSoldOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        protected async Task<ProductProduct> IsVariantPossibleInternalAsync(object parent_combination)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _is_variant_possible) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: product_product.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_product.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        protected async Task<ProductProduct> MatchAllVariantValuesInternalAsync(List<Guid> product_template_attribute_value_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _match_all_variant_values) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeDefaultCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangePublicCategIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _onchange_public_categ_ids) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServiceFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeServiceTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_product.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeStandardPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTypeEventBoothInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_product.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        protected async Task<ProductProduct> OnchangeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareCategoriesForDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_comparison, FILE: product_product.py, METHOD: _prepare_categories_for_display) ---
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareSellersInternalAsync(object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: product.py, METHOD: _prepare_sellers) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _prepare_sellers) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: product.py, METHOD: _prepare_sellers) ---
            */
            return default;
        }

        protected async Task<ProductProduct> PrepareVariantValuesInternalAsync(object combination)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        protected async Task<ProductProduct> PriceComputeInternalAsync(object price_type, object uom, object currency, object company, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _price_compute) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> ReadGroupInternalAsync(object domain, object groupby, object aggregates, object having, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: product_margin, FILE: product_product.py, METHOD: _read_group) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ReadGroupSelectInternalAsync(object aggregate_spec, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: product_margin, FILE: product_product.py, METHOD: _read_group_select) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ReadGroupingSetsInternalAsync(object domain, object grouping_sets, object aggregates, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: product_margin, FILE: product_product.py, METHOD: _read_grouping_sets) ---
            */
            return default;
        }

        protected async Task<ProductProduct> RetrieveProductInternalAsync(object company, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _retrieve_product) ---
            */
            return default;
        }

        protected async Task<ProductProduct> RunAvcoInternalAsync(object at_date, object lot, object method)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _run_avco) ---
            */
            return default;
        }

        protected async Task<ProductProduct> RunFifoGetStackInternalAsync(object lot, object at_date, object location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _run_fifo_get_stack) ---
            */
            return default;
        }

        protected async Task<ProductProduct> RunFifoInternalAsync(object quantity, object lot, object at_date, object location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _run_fifo) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchAllProductTagIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_all_product_tag_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchFreeQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_free_qty) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIncomingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductProduct> SearchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsInPurchaseOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _search_is_in_purchase_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsInSelectedSectionOfOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_is_in_selected_section_of_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchIsKitsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchOutgoingQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInBomInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_product_is_in_bom) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInMoInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_product_is_in_mo) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInRepairInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _search_product_is_in_repair) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductIsInSaleOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _search_product_is_in_sale_order) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductQuantityInternalAsync(object @operator, object @value, object field)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_product_quantity) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchProductWithSuggestedQuantityInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _search_product_with_suggested_quantity) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchQtyAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchQtyAvailableNewInternalAsync(object @operator, object @value, Guid lot_id, Guid owner_id, Guid package_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_qty_available_new) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available_new) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SearchVirtualAvailableInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SelectSellerInternalAsync(Guid partner_id, object quantity, object date, Guid uom_id, object ordered_by, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _select_seller) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SendAvailabilityEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _send_availability_email) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SendAvailabilityStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _send_availability_status) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SetImage1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_image_1920) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SetPriceFromBomInternalAsync(object boms_to_recompute)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _set_price_from_bom) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SetProductLstPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_product_lst_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> SetTemplateFieldInternalAsync(object template_field, object variant_field)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_template_field) ---
            */
            return default;
        }

        protected async Task<ProductProduct> ToMarkupDataInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _to_markup_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        protected async Task<ProductProduct> TriggerUomWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _trigger_uom_warning) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _trigger_uom_warning) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _trigger_uom_warning) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _trigger_uom_warning) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: _unlink_except_active_pos_session) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkExceptLoyaltyProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_product.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UnlinkOrArchiveInternalAsync(object check_access)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _unlink_or_archive) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UpdateStandardPriceInternalAsync(object extra_value, object extra_quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _update_standard_price) ---
            */
            return default;
        }

        protected async Task<ProductProduct> UpdateUomInternalAsync(Guid to_uom_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _update_uom) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _update_uom) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _update_uom) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _update_uom) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: _update_uom) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _update_uom) ---
            */
            return default;
        }

        protected async Task<ProductProduct> WebsiteShowQuickAddInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: _website_show_quick_add) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_product.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }

        protected async Task<ProductProduct> WithValuationContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _with_valuation_context) ---
            */
            return default;
        }
    }
}