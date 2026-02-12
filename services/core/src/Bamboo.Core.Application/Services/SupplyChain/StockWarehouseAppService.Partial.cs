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
    public partial class StockWarehouseAppService
    {

        protected async Task<StockWarehouse> CheckDeliveryResupplyInternalAsync(object new_location, object change_to_multiple)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _check_delivery_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> CheckMultiwarehouseGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _check_multiwarehouse_group) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> ComputeBuyToResupplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_buy_to_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> ComputeManufactureToResupplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _compute_manufacture_to_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateMissingLocationsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _create_missing_locations) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _create_missing_locations) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouse> CreateMissingPosPickingTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py, METHOD: _create_missing_pos_picking_types) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateGlobalRoutesRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _create_or_update_global_routes_rules) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateRouteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _create_or_update_route) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _create_or_update_route) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _create_or_update_route) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateSequencesAndPickingTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _create_or_update_sequences_and_picking_types) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> DefaultNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _default_name) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> FindExistingRuleOrCreateInternalAsync(object rules_list)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _find_existing_rule_or_create) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> FindOrCreateGlobalRouteInternalAsync(Guid xml_id, object route_name, object create, object raise_if_not_found)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _find_or_create_global_route) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> FormatRoutenameInternalAsync(object name, object route_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _format_routename) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> FormatRulenameInternalAsync(object from_loc, object dest_loc, object suffix)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _format_rulename) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GenerateGlobalRouteRulesValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _generate_global_route_rules_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _generate_global_route_rules_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py, METHOD: _generate_global_route_rules_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _generate_global_route_rules_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py, METHOD: _generate_global_route_rules_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _generate_global_route_rules_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetAllRoutesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_all_routes) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_all_routes) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_all_routes) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetGlobalRouteRulesValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_global_route_rules_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetInputOutputLocationsInternalAsync(object reception_steps, object delivery_steps)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_input_output_locations) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetInterWarehouseRouteValuesInternalAsync(object supplier_warehouse)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_inter_warehouse_route_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetLocationsValuesInternalAsync(object vals, object code)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_locations_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_locations_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouse> GetPartnerLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_partner_locations) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetPickingTypeCreateValuesInternalAsync(object max_sequence)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_warehouse.py, METHOD: _get_picking_type_create_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetPickingTypeUpdateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_warehouse.py, METHOD: _get_picking_type_update_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouse> GetProductionLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_production_location) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py, METHOD: _get_production_location) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetReceiveRoutesValuesInternalAsync(object installed_depends)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_receive_routes_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetReceiveRulesDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_receive_rules_dict) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRouteNameInternalAsync(object route_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_route_name) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_route_name) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRoutesValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_routes_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_routes_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_routes_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_routes_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRuleValuesInternalAsync(object route_values, object values, object name_suffix)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_rule_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSequenceValuesInternalAsync(object name, object code)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_sequence_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_sequence_values) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py, METHOD: _get_sequence_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py, METHOD: _get_sequence_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_sequence_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSubcontractingLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_subcontracting_location) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSubcontractingLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _get_subcontracting_locations) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSupplyPullRulesValuesInternalAsync(object route_values, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_supply_pull_rules_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> GetTransitLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _get_transit_locations) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> InverseBuyToResupplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _inverse_buy_to_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> InverseManufactureToResupplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _inverse_manufacture_to_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> PreparePickupLocationDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: stock_warehouse.py, METHOD: _prepare_pickup_location_data) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateDropshipSubcontractRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py, METHOD: _update_dropship_subcontract_rules) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateGlobalRouteResupplySubcontractorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _update_global_route_resupply_subcontractor) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationDeliveryInternalAsync(object new_delivery_step)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _update_location_delivery) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationManufactureInternalAsync(object new_manufacture_step)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _update_location_manufacture) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationReceptionInternalAsync(object new_reception_step)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _update_location_reception) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateNameAndCodeInternalAsync(object new_name, object new_code)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _update_name_and_code) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _update_name_and_code) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _update_name_and_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouse> UpdatePartnerDataInternalAsync(Guid partner_id, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _update_partner_data) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateReceptionDeliveryResupplyInternalAsync(object reception_new, object delivery_new)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _update_reception_delivery_resupply) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateResupplyRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: _update_resupply_rules) ---
            */
            return default;
        }

        protected async Task<StockWarehouse> ValidBarcodeInternalAsync(object barcode, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _valid_barcode) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouse> WarehouseRedirectWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: _warehouse_redirect_warning) ---
            */
            return default;
        }
    }
}