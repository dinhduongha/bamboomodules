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
    public partial class DeliveryCarrierAppService
    {

        protected async Task<DeliveryCarrier> ApplyMarginsInternalAsync(object price, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _apply_margins) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> CheckInStoreDmHasWarehousesWhenPublishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _check_in_store_dm_has_warehouses_when_published) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> CheckTagsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _check_tags) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> CheckWarehousesHaveSameCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _check_warehouses_have_same_company) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeCanGenerateReturnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_can_generate_return) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeCurrencyInternalAsync(object order, object price, object conversion)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_currency) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeFixedPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_fixed_price) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeIsMondialrelayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeSupportsShippingInsuranceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_supports_shipping_insurance) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeVolumeUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetCommoditiesFromOrderInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_commodities_from_order) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetCommoditiesFromStockMoveLinesInternalAsync(object move_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_commodities_from_stock_move_lines) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetConversionCurrenciesInternalAsync(object order, object conversion)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_conversion_currencies) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDefaultCustomPackageCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_default_custom_package_code) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryDocPrefixInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_doc_prefix) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryLabelPrefixInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_label_prefix) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetDeliveryTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_type) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPackagesFromOrderInternalAsync(object order, object default_package_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_packages_from_order) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPackagesFromPickingInternalAsync(object picking, object default_package_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_packages_from_picking) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceAvailableInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_available) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceDictInternalAsync(object total, object weight, object volume, object quantity, object wv)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_dict) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> GetPriceFromPickingInternalAsync(object total, object weight, object volume, object quantity, object wv)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_from_picking) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> InStoreGetCloseLocationsInternalAsync(object partner_address, Guid product_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _in_store_get_close_locations) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> IsAvailableForOrderInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _is_available_for_order) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: _is_available_for_order) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchAddressInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_address) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchExcludedTagsInternalAsync(object source)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_excluded_tags) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchInternalAsync(object partner, object source)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchMustHaveTagsInternalAsync(object source)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_must_have_tags) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchVolumeInternalAsync(object source)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_volume) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> MatchWeightInternalAsync(object source)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_weight) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeCanGenerateReturnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_can_generate_return) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeCountryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_country_ids) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeIntegrationLevelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_integration_level) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> OnchangeReturnLabelOnDeliveryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_return_label_on_delivery) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> ProductPriceToCompanyCurrencyInternalAsync(object quantity, object product, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _product_price_to_company_currency) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> SearchIsMondialrelayInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: _search_is_mondialrelay) ---
            */
            return default;
        }

        protected async Task<DeliveryCarrier> SetProductFixedPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _set_product_fixed_price) ---
            */
            return default;
        }
    }
}