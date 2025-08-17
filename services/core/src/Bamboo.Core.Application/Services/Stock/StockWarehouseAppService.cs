using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Stock", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockWarehouseAppService : GenericApplicationService<StockWarehouse>, IStockWarehouseAppService
    {

        public StockWarehouseAppService(IRepository<StockWarehouse, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockWarehouse> CheckDeliveryResupplyInternalAsync(object new_location, object change_to_multiple)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _check_delivery_resupply(self, new_location, change_to_multiple):
            // """ Check if the resupply routes from this warehouse follow the changes of number of delivery steps
            // Check routes being delivery bu this warehouse and change the rule going to transit location """
            // Rule = self.env["stock.rule"]
            // routes = self.env['stock.route'].search([('supplier_wh_id', '=', self.id)])
            // rules = Rule.search(['&', '&', ('route_id', 'in', routes.ids), ('action', '!=', 'push'), ('location_dest_id.usage', '=', 'transit')])
            // rules.write({
            //     'location_src_id': new_location.id,
            //     'procure_method': change_to_multiple and "make_to_order" or "make_to_stock"})
            // if not change_to_multiple:
            //     # Remove the extra rule to resupply Output from Stock
            //     rules_to_archive = Rule.search([('route_id', 'in', routes.ids), ('action', '!=', 'push'),
            //                                    ('location_dest_id', '=', self.wh_output_stock_loc_id.id),
            //                                    ('picking_type_id', '=', self.pick_type_id.id)])
            //     rules_to_archive.active = False
            // 
            //     # If single delivery we should create the necessary MTO rules for the resupply
            //     routings = [self.Routing(self.lot_stock_id, location, self.out_type_id, 'pull') for location in rules.location_dest_id]
            //     mto_vals = self._get_global_route_rules_values().get('mto_pull_id')
            //     values = mto_vals['create_values']
            //     mto_rule_vals = self._get_rule_values(routings, values, name_suffix='MTO')
            // 
            //     for mto_rule_val in mto_rule_vals:
            //         Rule.create(mto_rule_val)
            // else:
            //     # Add the missing rules to resupply Output from Stock
            //     rules_to_unarchive = Rule.with_context(active_test=False).search([
            //         ('route_id', 'in', routes.ids), ('action', '!=', 'push'),
            //         ('location_dest_id', '=', self.wh_output_stock_loc_id.id),
            //         ('picking_type_id', '=', self.pick_type_id.id)])
            //     rules_to_unarchive.active = True
            //     found_routes = rules_to_unarchive.route_id
            // 
            //     missing_rule_vals = []
            //     for route in (routes - found_routes):
            //         missing_rule_vals += self._get_supply_pull_rules_values(
            //             [self.Routing(self.lot_stock_id, new_location, self.pick_type_id, 'pull')],
            //             values={'route_id': route.id})
            //     Rule.create(missing_rule_vals)
            // 
            //     # We need to delete all the MTO stock rules, otherwise they risk to be used in the system
            //     Rule.search([
            //         '&', ('route_id', '=', self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)'), create=False).id),
            //         ('location_dest_id.usage', '=', 'transit'),
            //         ('action', '!=', 'push'),
            //         ('location_src_id', '=', self.lot_stock_id.id)]).write({'active': False})
            */
            return default;
        }

        protected async Task<StockWarehouse> CheckMultiwarehouseGroupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _check_multiwarehouse_group(self):
            // cnt_by_company = self.env['stock.warehouse'].sudo()._read_group([('active', '=', True)], ['company_id'], aggregates=['__count'])
            // if cnt_by_company:
            //     max_count = max(count for company, count in cnt_by_company)
            //     group_user = self.env.ref('base.group_user')
            //     group_stock_multi_warehouses = self.env.ref('stock.group_stock_multi_warehouses')
            //     group_stock_multi_locations = self.env.ref('stock.group_stock_multi_locations')
            //     if max_count <= 1 and group_stock_multi_warehouses in group_user.implied_ids:
            //         group_user.write({'implied_ids': [(3, group_stock_multi_warehouses.id)]})
            //         group_stock_multi_warehouses.write({'users': [(3, user.id) for user in group_user.users]})
            //     if max_count > 1 and group_stock_multi_warehouses not in group_user.implied_ids:
            //         if group_stock_multi_locations not in group_user.implied_ids:
            //             self.env['res.config.settings'].create({
            //                 'group_stock_multi_locations': True,
            //             }).execute()
            //         group_user.write({'implied_ids': [(4, group_stock_multi_warehouses.id), (4, group_stock_multi_locations.id)]})
            */
            return default;
        }

        public async Task<StockWarehouse> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for warehouse, vals in zip(self, vals_list):
            //     if 'name' not in default:
            //         vals['name'] = _("%s (copy)", warehouse.name)
            //     if 'code' not in default:
            //         vals['code'] = _("COPY")
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<StockWarehouse> CreateAsync(StockWarehouse entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // res._update_subcontracting_locations_rules()
            // # if new warehouse has resupply enabled, enable global route
            // if any([vals.get('subcontracting_to_resupply', False) for vals in vals_list]):
            //     res._update_global_route_resupply_subcontractor()
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // # if new warehouse has resupply enabled, enable global route
            // if any([vals.get('subcontracting_dropshipping_to_resupply', False) for vals in vals_list]):
            //     res.update_global_route_dropship_subcontractor()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('company_id'):
            //         company = self.env['res.company'].browse(vals['company_id'])
            //         if 'name' not in vals:
            //             vals['name'] = company.name
            //         if 'code' not in vals:
            //             vals['code'] = company.name[:5]
            //         if 'partner_id' not in vals:
            //             vals['partner_id'] = company.partner_id.id
            //     # create view location for warehouse then create all locations
            //     loc_vals = {'name': vals.get('code'), 'usage': 'view',
            //                 'location_id': self.env.ref('stock.stock_location_locations').id}
            //     if vals.get('company_id'):
            //         loc_vals['company_id'] = vals.get('company_id')
            //     vals['view_location_id'] = self.env['stock.location'].create(loc_vals).id
            //     sub_locations = self._get_locations_values(vals)
            // 
            //     for field_name, values in sub_locations.items():
            //         values['location_id'] = vals['view_location_id']
            //         if vals.get('company_id'):
            //             values['company_id'] = vals.get('company_id')
            //         vals[field_name] = self.env['stock.location'].with_context(active_test=False).create(values).id
            // 
            // # actually create WH
            // warehouses = super().create(vals_list)
            // 
            // for warehouse, vals in zip(warehouses, vals_list):
            //     # create sequences and operation types
            //     new_vals = warehouse._create_or_update_sequences_and_picking_types()
            //     warehouse.write(new_vals)  # TDE FIXME: use super ?
            //     # create routes and push/stock rules
            //     route_vals = warehouse._create_or_update_route()
            //     warehouse.write(route_vals)
            // 
            //     # Update global route with specific warehouse rule.
            //     warehouse._create_or_update_global_routes_rules()
            // 
            //     # create route selectable on the product to resupply the warehouse from another one
            //     warehouse.create_resupply_routes(warehouse.resupply_wh_ids)
            // 
            //     # update partner data if partner assigned
            //     if vals.get('partner_id'):
            //         self._update_partner_data(vals['partner_id'], vals.get('company_id'))
            // 
            //     # manually update locations' warehouse since it didn't exist at their creation time
            //     view_location_id = self.env['stock.location'].browse(vals.get('view_location_id'))
            //     (view_location_id | view_location_id.with_context(active_test=False).child_ids).write({'warehouse_id': warehouse.id})
            // 
            // self._check_multiwarehouse_group()
            // 
            // return warehouses
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<StockWarehouse> CreateMissingLocationsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _create_missing_locations(self, vals):
            // super()._create_missing_locations(vals)
            // for company_id in self.company_id:
            //     location = self.env['stock.location'].search([('usage', '=', 'production'), ('company_id', '=', company_id.id)], limit=1)
            //     if not location:
            //         company_id._create_production_location()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _create_missing_locations(self, vals):
            // """ It could happen that the user delete a mandatory location or a
            // module with new locations was installed after some warehouses creation.
            // In this case, this function will create missing locations in order to
            // avoid mistakes during picking types and rules creation.
            // """
            // for warehouse in self:
            //     company_id = vals.get('company_id', warehouse.company_id.id)
            //     sub_locations = warehouse._get_locations_values(dict(vals, company_id=company_id), warehouse.code)
            //     missing_location = {}
            //     for location, location_values in sub_locations.items():
            //         if not warehouse[location] and location not in vals:
            //             location_values['location_id'] = vals.get('view_location_id', warehouse.view_location_id.id)
            //             location_values['company_id'] = company_id
            //             missing_location[location] = self.env['stock.location'].create(location_values).id
            //     if missing_location:
            //         warehouse.write(missing_location)
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateMissingPosPickingTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py) ---
            // def _create_missing_pos_picking_types(self):
            // warehouses = self.env['stock.warehouse'].search([('pos_type_id', '=', False)])
            // for warehouse in warehouses:
            //     new_vals = warehouse._create_or_update_sequences_and_picking_types()
            //     warehouse.write(new_vals)
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateGlobalRoutesRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _create_or_update_global_routes_rules(self):
            // """ Some rules are not specific to a warehouse(e.g MTO, Buy, ...)
            // however they contain rule(s) for a specific warehouse. This method will
            // update the rules contained in global routes in order to make them match
            // with the wanted reception, delivery,... steps.
            // """
            // for rule_field, rule_details in self._get_global_route_rules_values().items():
            //     values = rule_details.get('update_values', {})
            //     if self[rule_field]:
            //         self[rule_field].write(values)
            //     else:
            //         values.update(rule_details['create_values'])
            //         values.update({'warehouse_id': self.id})
            //         self[rule_field] = self.env['stock.rule'].create(values)
            // return True
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateRouteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _create_or_update_route(self):
            // """ Create or update the warehouse's routes.
            // _get_routes_values method return a dict with:
            //     - route field name (e.g: crossdock_route_id).
            //     - field that trigger an update on the route (key 'depends').
            //     - routing_key used in order to find rules contained in the route.
            //     - create values.
            //     - update values when a field in depends is modified.
            //     - rules default values.
            // This method do an iteration on each route returned and update/create
            // them. In order to update the rules contained in the route it will
            // use the get_rules_dict that return a dict:
            //     - a receptions/delivery,... step value as key (e.g  'pick_ship')
            //     - a list of routing object that represents the rules needed to
            //     fullfil the pupose of the route.
            // The routing_key from _get_routes_values is match with the get_rules_dict
            // key in order to create/update the rules in the route
            // (_find_existing_rule_or_create method is responsible for this part).
            // """
            // # Create routes and active/create their related rules.
            // routes = []
            // rules_dict = self.get_rules_dict()
            // for route_field, route_data in self._get_routes_values().items():
            //     # If the route exists update it
            //     if self[route_field]:
            //         route = self[route_field]
            //         if 'route_update_values' in route_data:
            //             route.write(route_data['route_update_values'])
            //         route.rule_ids.write({'active': False})
            //     # Create the route
            //     else:
            //         if 'route_update_values' in route_data:
            //             route_data['route_create_values'].update(route_data['route_update_values'])
            //         route = self.env['stock.route'].create(route_data['route_create_values'])
            //         self[route_field] = route
            //     # Get rules needed for the route
            //     routing_key = route_data.get('routing_key')
            //     rules = rules_dict[self.id][routing_key]
            //     if 'rules_values' in route_data:
            //         route_data['rules_values'].update({'route_id': route.id})
            //     else:
            //         route_data['rules_values'] = {'route_id': route.id}
            //     rules_list = self._get_rule_values(
            //         rules, values=route_data['rules_values'])
            //     # Create/Active rules
            //     self._find_existing_rule_or_create(rules_list)
            //     if route_data['route_create_values'].get('warehouse_selectable', False) or route_data['route_update_values'].get('warehouse_selectable', False):
            //         routes.append(self[route_field])
            // return {
            //     'route_ids': [(4, route.id) for route in routes],
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> CreateOrUpdateSequencesAndPickingTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _create_or_update_sequences_and_picking_types(self):
            // """ Create or update existing picking types for a warehouse.
            // Pikcing types are stored on the warehouse in a many2one. If the picking
            // type exist this method will update it. The update values can be found in
            // the method _get_picking_type_update_values. If the picking type does not
            // exist it will be created with a new sequence associated to it.
            // """
            // self.ensure_one()
            // IrSequenceSudo = self.env['ir.sequence'].sudo()
            // PickingType = self.env['stock.picking.type']
            // 
            // # choose the next available color for the operation types of this warehouse
            // all_used_colors = [res['color'] for res in PickingType.search_read([('warehouse_id', '!=', False), ('color', '!=', False)], ['color'], order='color')]
            // available_colors = [zef for zef in range(0, 12) if zef not in all_used_colors]
            // color = available_colors[0] if available_colors else 0
            // 
            // warehouse_data = {}
            // sequence_data = self._get_sequence_values()
            // 
            // # suit for each warehouse: reception, internal, pick, pack, ship
            // max_sequence = self.env['stock.picking.type'].search_read([('sequence', '!=', False)], ['sequence'], limit=1, order='sequence desc')
            // max_sequence = max_sequence and max_sequence[0]['sequence'] or 0
            // 
            // data = self._get_picking_type_update_values()
            // create_data, max_sequence = self._get_picking_type_create_values(max_sequence)
            // 
            // for picking_type, values in data.items():
            //     if self[picking_type]:
            //         self[picking_type].sudo().sequence_id.write({'company_id': self.company_id.id})
            //         self[picking_type].write(values)
            //     else:
            //         data[picking_type].update(create_data[picking_type])
            //         existing_sequence = IrSequenceSudo.search_count([('company_id', '=', sequence_data[picking_type]['company_id']), ('name', '=', sequence_data[picking_type]['name'])], limit=1)
            //         sequence = IrSequenceSudo.create(sequence_data[picking_type])
            //         if existing_sequence:
            //             sequence.name = _("%(name)s (copy)(%(id)s)", name=sequence.name, id=str(sequence.id))
            //         values.update(warehouse_id=self.id, color=color, sequence_id=sequence.id)
            //         warehouse_data[picking_type] = PickingType.create(values).id
            // 
            // if 'out_type_id' in warehouse_data:
            //     PickingType.browse(warehouse_data['out_type_id']).write({'return_picking_type_id': warehouse_data.get('in_type_id', False)})
            // if 'in_type_id' in warehouse_data:
            //     PickingType.browse(warehouse_data['in_type_id']).write({'return_picking_type_id': warehouse_data.get('out_type_id', False)})
            // return warehouse_data
            */
            return default;
        }

        public async Task<StockWarehouse> CreateResupplyRoutesAsync(Guid id, object supplier_warehouses)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def create_resupply_routes(self, supplier_warehouses):
            // Route = self.env['stock.route']
            // Rule = self.env['stock.rule']
            // 
            // dummy, output_location = self._get_input_output_locations(self.reception_steps, self.delivery_steps)
            // internal_transit_location, external_transit_location = self._get_transit_locations()
            // 
            // for supplier_wh in supplier_warehouses:
            //     transit_location = internal_transit_location if supplier_wh.company_id == self.company_id else external_transit_location
            //     if not transit_location:
            //         continue
            //     transit_location.active = True
            //     output_location = supplier_wh.lot_stock_id if supplier_wh.delivery_steps == 'ship_only' else supplier_wh.wh_output_stock_loc_id
            //     # Create extra MTO rule (only for 'ship only' because in the other cases MTO rules already exists)
            //     if supplier_wh.delivery_steps == 'ship_only':
            //         routing = [self.Routing(output_location, transit_location, supplier_wh.out_type_id, 'pull')]
            //         mto_vals = supplier_wh._get_global_route_rules_values().get('mto_pull_id')
            //         values = mto_vals['create_values']
            //         mto_rule_val = supplier_wh._get_rule_values(routing, values, name_suffix='MTO')
            //         Rule.create(mto_rule_val[0])
            // 
            //     inter_wh_route = Route.create(self._get_inter_warehouse_route_values(supplier_wh))
            // 
            //     pull_rules_list = supplier_wh._get_supply_pull_rules_values(
            //         [self.Routing(output_location, transit_location, supplier_wh.out_type_id, 'pull')],
            //         values={'route_id': inter_wh_route.id, 'location_dest_from_rule': True})
            //     if supplier_wh.delivery_steps != 'ship_only':
            //         # Replenish from Output location
            //         pull_rules_list += supplier_wh._get_supply_pull_rules_values(
            //             [self.Routing(supplier_wh.lot_stock_id, output_location, supplier_wh.pick_type_id, 'pull')],
            //             values={'route_id': inter_wh_route.id})
            //     pull_rules_list += self._get_supply_pull_rules_values(
            //         [self.Routing(transit_location, self.lot_stock_id, self.in_type_id, 'pull')],
            //         values={'route_id': inter_wh_route.id, 'propagate_warehouse_id': supplier_wh.id})
            //     for pull_rule_vals in pull_rules_list:
            //         Rule.create(pull_rule_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouse> DefaultNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _default_name(self):
            // count = self.env['stock.warehouse'].with_context(active_test=False).search_count([('company_id', '=', self.env.company.id)])
            // return "%s - warehouse # %s" % (self.env.company.name, count + 1) if count else self.env.company.name
            */
            return default;
        }

        protected async Task<StockWarehouse> FindExistingRuleOrCreateInternalAsync(object rules_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _find_existing_rule_or_create(self, rules_list):
            // """ This method will find existing rules or create new one. """
            // for rule_vals in rules_list:
            //     existing_rule = self.env['stock.rule'].search([
            //         ('picking_type_id', '=', rule_vals['picking_type_id']),
            //         ('location_src_id', '=', rule_vals['location_src_id']),
            //         ('location_dest_id', '=', rule_vals['location_dest_id']),
            //         ('route_id', '=', rule_vals['route_id']),
            //         ('action', '=', rule_vals['action']),
            //         ('active', '=', False),
            //     ])
            //     if not existing_rule:
            //         self.env['stock.rule'].create(rule_vals)
            //     else:
            //         existing_rule.write({'active': True})
            */
            return default;
        }

        protected async Task<StockWarehouse> FindOrCreateGlobalRouteInternalAsync(Guid xml_id, object route_name, object create, object raise_if_not_found)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _find_or_create_global_route(self, xml_id, route_name, create=True, raise_if_not_found=False):
            // """ return a route record set from an xml_id or its name. """
            // data_route = route = self.env.ref(xml_id, raise_if_not_found=False)
            // company = self.company_id[:1] or self.env.company
            // if not route or (route.sudo().company_id and route.sudo().company_id != company):
            //     route = self.env['stock.route'].with_context(active_test=False).search([
            //         ('name', 'like', route_name), ('company_id', 'in', [False, company.id])
            //     ], order='company_id', limit=1)
            // if not route:
            //     if raise_if_not_found:
            //         raise UserError(_('Can\'t find any generic route %s.', route_name))
            //     elif data_route and create:
            //         route = data_route.copy({'name': data_route.name, 'company_id': company.id, 'rule_ids': False})
            // return route
            */
            return default;
        }

        protected async Task<StockWarehouse> FormatRoutenameInternalAsync(object name, object route_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _format_routename(self, name=None, route_type=None):
            // if route_type:
            //     name = self._get_route_name(route_type)
            // return '%s: %s' % (self.name, name)
            */
            return default;
        }

        protected async Task<StockWarehouse> FormatRulenameInternalAsync(object from_loc, object dest_loc, object suffix)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _format_rulename(self, from_loc, dest_loc, suffix):
            // rulename = '%s: %s' % (self.code, from_loc.name)
            // if dest_loc:
            //     rulename += ' → %s' % (dest_loc.name)
            // if suffix:
            //     rulename += ' (' + suffix + ')'
            // return rulename
            */
            return default;
        }

        protected async Task<StockWarehouse> GenerateGlobalRouteRulesValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _generate_global_route_rules_values(self):
            // rules = super()._generate_global_route_rules_values()
            // production_location = self._get_production_location()
            // rules.update({
            //     'manufacture_pull_id': {
            //         'depends': ['manufacture_steps', 'manufacture_to_resupply'],
            //         'create_values': {
            //             'action': 'manufacture',
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'picking_type_id': self.manu_type_id.id,
            //             'route_id': self._find_or_create_global_route('mrp.route_warehouse0_manufacture', _('Manufacture')).id
            //         },
            //         'update_values': {
            //             'active': self.manufacture_to_resupply,
            //             'name': self._format_rulename(self.lot_stock_id, False, 'Production'),
            //             'location_dest_id': self.lot_stock_id.id,
            //             'propagate_cancel': self.manufacture_steps == 'pbm_sam'
            //         },
            //     },
            //     'manufacture_mto_pull_id': {
            //         'depends': ['manufacture_steps', 'manufacture_to_resupply'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)')).id,
            //             'location_dest_id': production_location.id,
            //             'location_src_id': self.lot_stock_id.id,
            //             'picking_type_id': self.manu_type_id.id
            //         },
            //         'update_values': {
            //             'name': self._format_rulename(self.lot_stock_id, production_location, 'MTO'),
            //             'active': self.manufacture_to_resupply,
            //         },
            //     },
            //     'pbm_mto_pull_id': {
            //         'depends': ['manufacture_steps', 'manufacture_to_resupply'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)')).id,
            //             'name': self._format_rulename(self.lot_stock_id, self.pbm_loc_id, 'MTO'),
            //             'location_dest_id': self.pbm_loc_id.id,
            //             'location_src_id': self.lot_stock_id.id,
            //             'picking_type_id': self.pbm_type_id.id
            //         },
            //         'update_values': {
            //             'active': self.manufacture_steps != 'mrp_one_step' and self.manufacture_to_resupply,
            //         }
            //     },
            // })
            // return rules
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _generate_global_route_rules_values(self):
            // rules = super()._generate_global_route_rules_values()
            // subcontract_location_id = self._get_subcontracting_location()
            // production_location_id = self._get_production_location()
            // rules.update({
            //     'subcontracting_mto_pull_id': {
            //         'depends': ['subcontracting_to_resupply'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)')).id,
            //             'name': self._format_rulename(self.lot_stock_id, subcontract_location_id, 'MTO'),
            //             'location_dest_id': subcontract_location_id.id,
            //             'location_src_id': self.lot_stock_id.id,
            //             'picking_type_id': self.subcontracting_resupply_type_id.id
            //         },
            //         'update_values': {
            //             'active': self.subcontracting_to_resupply
            //         }
            //     },
            //     'subcontracting_pull_id': {
            //         'depends': ['subcontracting_to_resupply'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('mrp_subcontracting.route_resupply_subcontractor_mto', _('Resupply Subcontractor on Order')).id,
            //             'name': self._format_rulename(subcontract_location_id, production_location_id, False),
            //             'location_dest_id': production_location_id.id,
            //             'location_src_id': subcontract_location_id.id,
            //             'picking_type_id': self.subcontracting_resupply_type_id.id
            //         },
            //         'update_values': {
            //             'active': self.subcontracting_to_resupply
            //         }
            //     },
            // })
            // return rules
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py) ---
            // def _generate_global_route_rules_values(self):
            // rules = super()._generate_global_route_rules_values()
            // subcontract_location_id = self._get_subcontracting_location()
            // production_location_id = self._get_production_location()
            // rules.update({
            //     'subcontracting_dropshipping_pull_id': {
            //         'depends': ['subcontracting_dropshipping_to_resupply'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping', _('Dropship Subcontractor on Order')).id,
            //             'name': self._format_rulename(subcontract_location_id, production_location_id, False),
            //             'location_dest_id': production_location_id.id,
            //             'location_src_id': subcontract_location_id.id,
            //             'picking_type_id': self.subcontracting_type_id.id
            //         },
            //         'update_values': {
            //             'active': self.subcontracting_dropshipping_to_resupply
            //         }
            //     },
            // })
            // return rules
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _generate_global_route_rules_values(self):
            // rules = super()._generate_global_route_rules_values()
            // location_id = self.lot_stock_id
            // rules.update({
            //     'buy_pull_id': {
            //         'depends': ['reception_steps', 'buy_to_resupply'],
            //         'create_values': {
            //             'action': 'buy',
            //             'picking_type_id': self.in_type_id.id,
            //             'group_propagation_option': 'none',
            //             'company_id': self.company_id.id,
            //             'route_id': self._find_or_create_global_route('purchase_stock.route_warehouse0_buy', _('Buy')).id,
            //             'propagate_cancel': self.reception_steps != 'one_step',
            //         },
            //         'update_values': {
            //             'active': self.buy_to_resupply,
            //             'name': self._format_rulename(location_id, False, 'Buy'),
            //             'location_dest_id': location_id.id,
            //             'propagate_cancel': self.reception_steps != 'one_step',
            //         }
            //     }
            // })
            // return rules
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py) ---
            // def _generate_global_route_rules_values(self):
            // rules = super()._generate_global_route_rules_values()
            // production_location = self._get_production_location()
            // rules.update({
            //     'repair_mto_pull_id': {
            //         'depends': ['repair_type_id'],
            //         'create_values': {
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'route_id': self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)')).id,
            //             'location_dest_id': self.repair_type_id.default_location_dest_id.id,
            //             'location_src_id': self.repair_type_id.default_location_src_id.id,
            //             'picking_type_id': self.repair_type_id.id
            //         },
            //         'update_values': {
            //             'name': self._format_rulename(self.lot_stock_id, production_location, 'MTO'),
            //             'active': True,
            //         },
            //     },
            // })
            // return rules
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _generate_global_route_rules_values(self):
            // # We use 0 since routing are order from stock to cust. If the routing
            // # order is modify, the mto rule will be wrong.
            // rule = self.get_rules_dict()[self.id][self.delivery_steps]
            // rule = [r for r in rule if r.from_loc == self.lot_stock_id][0]
            // location_id = rule.from_loc
            // location_dest_id = rule.dest_loc
            // picking_type_id = rule.picking_type
            // return {
            //     'mto_pull_id': {
            //         'depends': ['delivery_steps'],
            //         'create_values': {
            //             'active': True,
            //             'procure_method': 'make_to_order',
            //             'company_id': self.company_id.id,
            //             'action': 'pull',
            //             'auto': 'manual',
            //             'propagate_carrier': True,
            //             'route_id': self._find_or_create_global_route('stock.route_warehouse0_mto', _('Replenish on Order (MTO)')).id
            //         },
            //         'update_values': {
            //             'name': self._format_rulename(location_id, location_dest_id, 'MTO'),
            //             'location_dest_id': location_dest_id.id,
            //             'location_src_id': location_id.id,
            //             'picking_type_id': picking_type_id.id,
            //         }
            //     }
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetAllRoutesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_all_routes(self):
            // routes = super(StockWarehouse, self)._get_all_routes()
            // routes |= self.filtered(lambda self: self.manufacture_to_resupply and self.manufacture_pull_id and self.manufacture_pull_id.route_id).mapped('manufacture_pull_id').mapped('route_id')
            // return routes
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _get_all_routes(self):
            // routes = super(StockWarehouse, self)._get_all_routes()
            // routes |= self.filtered(lambda self: self.buy_to_resupply and self.buy_pull_id and self.buy_pull_id.route_id).mapped('buy_pull_id').mapped('route_id')
            // return routes
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_all_routes(self):
            // routes = self.mapped('route_ids') | self.mapped('mto_pull_id').mapped('route_id')
            // routes |= self.env["stock.route"].with_context(active_test=False).search([('supplied_wh_id', 'in', self.ids)])
            // return routes
            */
            return default;
        }

        public async Task<StockWarehouse> GetCurrentWarehousesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def get_current_warehouses(self):
            // return self.env['stock.warehouse'].search_read(fields=['id', 'name', 'code'])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouse> GetGlobalRouteRulesValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_global_route_rules_values(self):
            // """ Method used by _create_or_update_global_routes_rules. It's
            // purpose is to return a dict with this format.
            // key: The rule contained in a global route that have to be create/update
            // entry a dict with the following values:
            //     -depends: Field that impact the rule. When a field in depends is
            //     write on the warehouse the rule set as key have to be update.
            //     -create_values: values used in order to create the rule if it does
            //     not exist.
            //     -update_values: values used to update the route when a field in
            //     depends is modify on the warehouse.
            // """
            // vals = self._generate_global_route_rules_values()
            // # `route_id` might be `False` if the user has deleted it, in such case we
            // # should simply ignore the rule
            // return {k: v for k, v in vals.items() if v.get('create_values', {}).get('route_id', True) and v.get('update_values', {}).get('route_id', True)}
            */
            return default;
        }

        protected async Task<StockWarehouse> GetInputOutputLocationsInternalAsync(object reception_steps, object delivery_steps)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_input_output_locations(self, reception_steps, delivery_steps):
            // return (self.lot_stock_id if reception_steps == 'one_step' else self.wh_input_stock_loc_id,
            //         self.lot_stock_id if delivery_steps == 'ship_only' else self.wh_output_stock_loc_id)
            */
            return default;
        }

        protected async Task<StockWarehouse> GetInterWarehouseRouteValuesInternalAsync(object supplier_warehouse)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_inter_warehouse_route_values(self, supplier_warehouse):
            // return {
            //     'name': _('%(warehouse)s: Supply Product from %(supplier)s', warehouse=self.name, supplier=supplier_warehouse.name),
            //     'warehouse_selectable': True,
            //     'product_selectable': True,
            //     'product_categ_selectable': True,
            //     'supplied_wh_id': self.id,
            //     'supplier_wh_id': supplier_warehouse.id,
            //     'company_id': (self.company_id & supplier_warehouse.company_id).id,
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetLocationsValuesInternalAsync(object vals, object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_locations_values(self, vals, code=False):
            // values = super(StockWarehouse, self)._get_locations_values(vals, code=code)
            // def_values = self.default_get(['company_id', 'manufacture_steps'])
            // manufacture_steps = vals.get('manufacture_steps', def_values['manufacture_steps'])
            // code = vals.get('code') or code or ''
            // code = code.replace(' ', '').upper()
            // company_id = vals.get('company_id', def_values['company_id'])
            // values.update({
            //     'pbm_loc_id': {
            //         'name': _('Pre-Production'),
            //         'active': manufacture_steps in ('pbm', 'pbm_sam'),
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'PREPRODUCTION', company_id)
            //     },
            //     'sam_loc_id': {
            //         'name': _('Post-Production'),
            //         'active': manufacture_steps == 'pbm_sam',
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'POSTPRODUCTION', company_id)
            //     },
            // })
            // return values
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_locations_values(self, vals, code=False):
            // """ Update the warehouse locations. """
            // def_values = self.default_get(['reception_steps', 'delivery_steps'])
            // reception_steps = vals.get('reception_steps', def_values['reception_steps'])
            // delivery_steps = vals.get('delivery_steps', def_values['delivery_steps'])
            // code = vals.get('code') or code or ''
            // code = code.replace(' ', '').upper()
            // company_id = vals.get('company_id', self.default_get(['company_id'])['company_id'])
            // sub_locations = {
            //     'lot_stock_id': {
            //         'name': _('Stock'),
            //         'active': True,
            //         'usage': 'internal',
            //         'replenish_location': True,
            //         'barcode': self._valid_barcode(code + 'STOCK', company_id)
            //     },
            //     'wh_input_stock_loc_id': {
            //         'name': _('Input'),
            //         'active': reception_steps != 'one_step',
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'INPUT', company_id)
            //     },
            //     'wh_qc_stock_loc_id': {
            //         'name': _('Quality Control'),
            //         'active': reception_steps == 'three_steps',
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'QUALITY', company_id)
            //     },
            //     'wh_output_stock_loc_id': {
            //         'name': _('Output'),
            //         'active': delivery_steps != 'ship_only',
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'OUTPUT', company_id)
            //     },
            //     'wh_pack_stock_loc_id': {
            //         'name': _('Packing Zone'),
            //         'active': delivery_steps == 'pick_pack_ship',
            //         'usage': 'internal',
            //         'barcode': self._valid_barcode(code + 'PACKING', company_id)
            //     },
            // }
            // return sub_locations
            */
            return default;
        }

        protected async Task<StockWarehouse> GetPartnerLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_partner_locations(self):
            // ''' returns a tuple made of the browse record of customer location and the browse record of supplier location'''
            // Location = self.env['stock.location']
            // customer_loc = self.env.ref('stock.stock_location_customers', raise_if_not_found=False)
            // supplier_loc = self.env.ref('stock.stock_location_suppliers', raise_if_not_found=False)
            // if not customer_loc:
            //     customer_loc = Location.search([('usage', '=', 'customer')], limit=1)
            // if not supplier_loc:
            //     supplier_loc = Location.search([('usage', '=', 'supplier')], limit=1)
            // if not customer_loc and not supplier_loc:
            //     raise UserError(_('Can\'t find any customer or supplier location.'))
            // return customer_loc, supplier_loc
            */
            return default;
        }

        protected async Task<StockWarehouse> GetPickingTypeCreateValuesInternalAsync(object max_sequence)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // data, next_sequence = super(StockWarehouse, self)._get_picking_type_create_values(max_sequence)
            // data.update({
            //     'pbm_type_id': {
            //         'name': _('Pick Components'),
            //         'code': 'internal',
            //         'use_create_lots': True,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'default_location_dest_id': self.pbm_loc_id.id,
            //         'sequence': next_sequence + 1,
            //         'sequence_code': 'PC',
            //         'company_id': self.company_id.id,
            //     },
            //     'sam_type_id': {
            //         'name': _('Store Finished Product'),
            //         'code': 'internal',
            //         'use_create_lots': True,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.sam_loc_id.id,
            //         'default_location_dest_id': self.lot_stock_id.id,
            //         'sequence': next_sequence + 3,
            //         'sequence_code': 'SFP',
            //         'company_id': self.company_id.id,
            //     },
            //     'manu_type_id': {
            //         'name': _('Manufacturing'),
            //         'code': 'mrp_operation',
            //         'use_create_lots': True,
            //         'use_existing_lots': True,
            //         'sequence': next_sequence + 2,
            //         'sequence_code': 'MO',
            //         'company_id': self.company_id.id,
            //     },
            // })
            // return data, max_sequence + 4
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // data, next_sequence = super(StockWarehouse, self)._get_picking_type_create_values(max_sequence)
            // data.update({
            //     'subcontracting_type_id': {
            //         'name': _('Subcontracting'),
            //         'code': 'mrp_operation',
            //         'use_create_components_lots': True,
            //         'sequence': next_sequence + 2,
            //         'sequence_code': 'SBC',
            //         'company_id': self.company_id.id,
            //     },
            //     'subcontracting_resupply_type_id': {
            //         'name': _('Resupply Subcontractor'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_dest_id': self._get_subcontracting_location().id,
            //         'sequence': next_sequence + 3,
            //         'sequence_code': 'RES',
            //         'print_label': True,
            //         'company_id': self.company_id.id,
            //     }
            // })
            // return data, max_sequence + 4
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // picking_type_create_values, max_sequence = super(Warehouse, self)._get_picking_type_create_values(max_sequence)
            // picking_type_create_values.update({
            //     'pos_type_id': {
            //         'name': _('PoS Orders'),
            //         'code': 'outgoing',
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'default_location_dest_id': self.env.ref('stock.stock_location_customers').id,
            //         'sequence': max_sequence + 1,
            //         'sequence_code': 'POS',
            //         'company_id': self.company_id.id,
            //     }
            // })
            // return picking_type_create_values, max_sequence + 2
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // data, next_sequence = super(StockWarehouse, self)._get_picking_type_create_values(max_sequence)
            // prod_location = self._get_production_location()
            // scrap_location = self.env['stock.location'].search([('scrap_location', '=', True), ('company_id', 'in', [self.company_id.id, False])], limit=1)
            // data.update({
            //     'repair_type_id': {
            //         'name': _('Repairs'),
            //         'code': 'repair_operation',
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'default_location_dest_id': prod_location.id,
            //         'default_remove_location_dest_id':scrap_location.id,
            //         'default_recycle_location_dest_id': self.lot_stock_id.id,
            //         'sequence': next_sequence + 1,
            //         'sequence_code': 'RO',
            //         'company_id': self.company_id.id,
            //     },
            // })
            // return data, max_sequence + 2
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // """ When a warehouse is created this method return the values needed in
            // order to create the new picking types for this warehouse. Every picking
            // type are created at the same time than the warehouse howver they are
            // activated or archived depending the delivery_steps or reception_steps.
            // """
            // input_loc, output_loc = self._get_input_output_locations(self.reception_steps, self.delivery_steps)
            // return {
            //     'in_type_id': {
            //         'name': _('Receipts'),
            //         'code': 'incoming',
            //         'use_existing_lots': False,
            //         'sequence': max_sequence + 1,
            //         'sequence_code': 'IN',
            //         'company_id': self.company_id.id,
            //     }, 'out_type_id': {
            //         'name': _('Delivery Orders'),
            //         'code': 'outgoing',
            //         'use_create_lots': False,
            //         'sequence': max_sequence + 7,
            //         'sequence_code': 'OUT',
            //         'print_label': True,
            //         'company_id': self.company_id.id,
            //     }, 'pack_type_id': {
            //         'name': _('Pack'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.wh_pack_stock_loc_id.id,
            //         'default_location_dest_id': output_loc.id,
            //         'sequence': max_sequence + 6,
            //         'sequence_code': 'PACK',
            //         'company_id': self.company_id.id,
            //     }, 'pick_type_id': {
            //         'name': _('Pick'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'sequence': max_sequence + 5,
            //         'sequence_code': 'PICK',
            //         'company_id': self.company_id.id,
            //     }, 'qc_type_id': {
            //         'name': _('Quality Control'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.wh_input_stock_loc_id.id,
            //         'default_location_dest_id': self.wh_qc_stock_loc_id.id,
            //         'sequence': max_sequence + 2,
            //         'sequence_code': 'QC',
            //         'company_id': self.company_id.id,
            //     }, 'store_type_id': {
            //         'name': _('Storage'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_dest_id': self.lot_stock_id.id,
            //         'sequence': max_sequence + 3,
            //         'sequence_code': 'STOR',
            //         'company_id': self.company_id.id,
            //     }, 'int_type_id': {
            //         'name': _('Internal Transfers'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'default_location_dest_id': self.lot_stock_id.id,
            //         'active': self.env.user.has_group('stock.group_stock_multi_locations'),
            //         'sequence': max_sequence + 4,
            //         'sequence_code': 'INT',
            //         'company_id': self.company_id.id,
            //     }, 'xdock_type_id': {
            //         'name': _('Cross Dock'),
            //         'code': 'internal',
            //         'use_create_lots': False,
            //         'use_existing_lots': True,
            //         'default_location_src_id': self.wh_input_stock_loc_id.id,
            //         'default_location_dest_id': self.wh_output_stock_loc_id.id,
            //         'sequence': max_sequence + 8,
            //         'sequence_code': 'XD',
            //         'company_id': self.company_id.id,
            //     }
            // }, max_sequence + 9
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_warehouse.py) ---
            // def _get_picking_type_create_values(self, max_sequence):
            // data, next_sequence = super()._get_picking_type_create_values(max_sequence)
            // updatable_types = {k: v for (k, v) in data.items() if v.get('code') in ('incoming', 'outgoing')}
            // for picking_type in updatable_types.values():
            //     picking_type.update({
            //         'auto_batch': True,
            //         'batch_group_by_partner': True,
            //     })
            // return data, next_sequence
            */
            return default;
        }

        protected async Task<StockWarehouse> GetPickingTypeUpdateValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_picking_type_update_values(self):
            // data = super(StockWarehouse, self)._get_picking_type_update_values()
            // data.update({
            //     'pbm_type_id': {
            //         'active': self.manufacture_to_resupply and self.manufacture_steps in ('pbm', 'pbm_sam') and self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "PC",
            //     },
            //     'sam_type_id': {
            //         'active': self.manufacture_to_resupply and self.manufacture_steps == 'pbm_sam' and self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "SFP",
            //     },
            //     'manu_type_id': {
            //         'active': self.manufacture_to_resupply and self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "MANUF",
            //         'default_location_src_id': self.manufacture_steps in ('pbm', 'pbm_sam') and self.pbm_loc_id.id or self.lot_stock_id.id,
            //         'default_location_dest_id': self.manufacture_steps == 'pbm_sam' and self.sam_loc_id.id or self.lot_stock_id.id,
            //     },
            // })
            // return data
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_picking_type_update_values(self):
            // data = super(StockWarehouse, self)._get_picking_type_update_values()
            // subcontract_location_id = self._get_subcontracting_location()
            // production_location_id = self._get_production_location()
            // data.update({
            //     'subcontracting_type_id': {
            //         'active': False,
            //         'default_location_src_id': subcontract_location_id.id,
            //         'default_location_dest_id': production_location_id.id,
            //     },
            //     'subcontracting_resupply_type_id': {
            //         'default_location_src_id': self.lot_stock_id.id,
            //         'default_location_dest_id': subcontract_location_id.id,
            //         'barcode': self.code.replace(" ", "").upper() + "RESUP",
            //         'active': self.subcontracting_to_resupply and self.active
            //     },
            // })
            // return data
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py) ---
            // def _get_picking_type_update_values(self):
            // picking_type_update_values = super(Warehouse, self)._get_picking_type_update_values()
            // picking_type_update_values.update({
            //     'pos_type_id': {'default_location_src_id': self.lot_stock_id.id}
            // })
            // return picking_type_update_values
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py) ---
            // def _get_picking_type_update_values(self):
            // data = super(StockWarehouse, self)._get_picking_type_update_values()
            // data.update({
            //     'repair_type_id': {
            //         'active': self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "RO",
            //     },
            // })
            // return data
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_picking_type_update_values(self):
            // """ Return values in order to update the existing picking type when the
            // warehouse's delivery_steps or reception_steps are modify.
            // """
            // input_loc, output_loc = self._get_input_output_locations(self.reception_steps, self.delivery_steps)
            // return {
            //     'in_type_id': {
            //         'default_location_dest_id': input_loc.id,
            //         'barcode': self.code.replace(" ", "").upper() + "IN",
            //     },
            //     'out_type_id': {
            //         'default_location_src_id': output_loc.id,
            //         'barcode': self.code.replace(" ", "").upper() + "OUT",
            //     },
            //     'pick_type_id': {
            //         'active': self.delivery_steps != 'ship_only' and self.active,
            //         'default_location_dest_id': output_loc.id if self.delivery_steps == 'pick_ship' else self.wh_pack_stock_loc_id.id,
            //         'barcode': self.code.replace(" ", "").upper() + "PICK",
            //     },
            //     'pack_type_id': {
            //         'active': self.delivery_steps == 'pick_pack_ship' and self.active,
            //         'default_location_dest_id': output_loc.id,
            //         'barcode': self.code.replace(" ", "").upper() + "PACK",
            //     },
            //     'qc_type_id': {
            //         'active': self.reception_steps == 'three_steps' and self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "QC",
            //     },
            //     'store_type_id': {
            //         'active': self.reception_steps != 'one_step' and self.active,
            //         'default_location_src_id': input_loc.id if self.reception_steps == 'two_steps' else self.wh_qc_stock_loc_id.id,
            //         'barcode': self.code.replace(" ", "").upper() + "STOR",
            //     },
            //     'int_type_id': {
            //         'barcode': self.code.replace(" ", "").upper() + "INT",
            //     },
            //     'xdock_type_id': {
            //         'active': self.reception_steps != 'one_step' and self.delivery_steps != 'ship_only' and self.active,
            //         'barcode': self.code.replace(" ", "").upper() + "XD",
            //     }
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetProductionLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_production_location(self):
            // location = self.env['stock.location'].search([('usage', '=', 'production'), ('company_id', '=', self.company_id.id)], limit=1)
            // if not location:
            //     raise UserError(_('Can\'t find any production location.'))
            // return location
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py) ---
            // def _get_production_location(self):
            // location = self.env['stock.location'].search([('usage', '=', 'production'), ('company_id', '=', self.company_id.id)], limit=1)
            // if not location:
            //     raise UserError(_("Can't find any production location."))
            // return location
            */
            return default;
        }

        protected async Task<StockWarehouse> GetReceiveRoutesValuesInternalAsync(object installed_depends)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_receive_routes_values(self, installed_depends):
            // """ Return receive route values with 'procure_method': 'make_to_order'
            // in order to update warehouse routes.
            // 
            // This function has the same receive route values as _get_routes_values with the addition of
            // 'procure_method': 'make_to_order' to the 'rules_values'. This is expected to be used by
            // modules that extend stock and add actions that can trigger receive 'make_to_order' rules (i.e.
            // we don't want any of the generated rules by get_rules_dict to default to 'make_to_stock').
            // Additionally this is expected to be used in conjunction with _get_receive_rules_dict().
            // 
            // args:
            // installed_depends - string value of installed (warehouse) boolean to trigger updating of reception route.
            // """
            // return {
            //     'reception_route_id': {
            //         'routing_key': self.reception_steps,
            //         'depends': ['reception_steps', installed_depends],
            //         'route_update_values': {
            //             'name': self._format_routename(route_type=self.reception_steps),
            //             'active': self.active,
            //         },
            //         'route_create_values': {
            //             'product_categ_selectable': True,
            //             'warehouse_selectable': True,
            //             'product_selectable': False,
            //             'company_id': self.company_id.id,
            //             'sequence': 9,
            //         },
            //         'rules_values': {
            //             'active': True,
            //             'propagate_cancel': True,
            //             'procure_method': 'make_to_order',
            //         }
            //     }
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetReceiveRulesDictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _get_receive_rules_dict(self):
            // rules = super()._get_receive_rules_dict()
            // customer_loc, __ = self._get_partner_locations()
            // # Sets the right order for new warehouses: buy then push.
            // rules['crossdock'].insert(0, self.Routing(self.env['stock.location'], customer_loc, self.in_type_id, 'buy'))
            // return rules
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_receive_rules_dict(self):
            // """ Return receive route rules without initial pull rule in order to update warehouse routes.
            // 
            // This function has the same receive route rules as get_rules_dict without an initial pull rule.
            // This is expected to be used by modules that extend stock and add actions that can trigger receive
            // 'make_to_order' rules (i.e. we don't expect the receive route to be able to pull on its own anymore).
            // This is also expected to be used in conjuction with _get_receive_routes_values()
            // """
            // return {
            //     'one_step': [],
            //     'two_steps': [self.Routing(self.wh_input_stock_loc_id, self.lot_stock_id, self.store_type_id, 'push')],
            //     'three_steps': [
            //         self.Routing(self.wh_input_stock_loc_id, self.wh_qc_stock_loc_id, self.qc_type_id, 'push'),
            //         self.Routing(self.wh_qc_stock_loc_id, self.lot_stock_id, self.store_type_id, 'push')],
            //     'crossdock': [self.Routing(self.wh_input_stock_loc_id, self.wh_output_stock_loc_id, self.xdock_type_id, 'push')],
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRouteNameInternalAsync(object route_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_route_name(self, route_type):
            // names = {
            //     'mrp_one_step': _('Manufacture (1 step)'),
            //     'pbm': _('Pick components and then manufacture'),
            //     'pbm_sam': _('Pick components, manufacture and then store products (3 steps)'),
            // }
            // if route_type in names:
            //     return names[route_type]
            // else:
            //     return super(StockWarehouse, self)._get_route_name(route_type)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_route_name(self, route_type):
            // return self.env._(ROUTE_NAMES[route_type])
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRoutesValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_routes_values(self):
            // routes = super(StockWarehouse, self)._get_routes_values()
            // routes.update({
            //     'pbm_route_id': {
            //         'routing_key': self.manufacture_steps,
            //         'depends': ['manufacture_steps', 'manufacture_to_resupply'],
            //         'route_update_values': {
            //             'name': self._format_routename(route_type=self.manufacture_steps),
            //             'active': self.manufacture_steps != 'mrp_one_step',
            //         },
            //         'route_create_values': {
            //             'product_categ_selectable': True,
            //             'warehouse_selectable': True,
            //             'product_selectable': False,
            //             'company_id': self.company_id.id,
            //             'sequence': 10,
            //         },
            //         'rules_values': {
            //             'active': True,
            //         }
            //     }
            // })
            // routes.update(self._get_receive_routes_values('manufacture_to_resupply'))
            // return routes
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_routes_values(self):
            // routes = super(StockWarehouse, self)._get_routes_values()
            // routes.update({
            //     'subcontracting_route_id': {
            //         'routing_key': 'subcontract',
            //         'depends': ['subcontracting_to_resupply'],
            //         'route_create_values': {
            //             'product_categ_selectable': False,
            //             'warehouse_selectable': True,
            //             'product_selectable': False,
            //             'company_id': self.company_id.id,
            //             'sequence': 10,
            //             'name': self._format_routename(name=_('Resupply Subcontractor'))
            //         },
            //         'route_update_values': {
            //             'active': self.subcontracting_to_resupply,
            //         },
            //         'rules_values': {
            //             'active': self.subcontracting_to_resupply,
            //         }
            //     }
            // })
            // return routes
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _get_routes_values(self):
            // routes = super(StockWarehouse, self)._get_routes_values()
            // routes.update(self._get_receive_routes_values('buy_to_resupply'))
            // return routes
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: stock_warehouse.py) ---
            // def _get_routes_values(self):
            // routes = super()._get_routes_values()
            // if routes.get('crossdock_route_id'):
            //     routes['crossdock_route_id']['route_update_values']['sale_selectable'] = True
            //     routes['crossdock_route_id']['route_create_values']['sale_selectable'] = True
            // return routes
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_routes_values(self):
            // """ Return information in order to update warehouse routes.
            // - The key is a route field sotred as a Many2one on the warehouse
            // - This key contains a dict with route values:
            //     - routing_key: a key used in order to match rules from
            //     get_rules_dict function. It would be usefull in order to generate
            //     the route's rules.
            //     - route_create_values: When the Many2one does not exist the route
            //     is created based on values contained in this dict.
            //     - route_update_values: When a field contained in 'depends' key is
            //     modified and the Many2one exist on the warehouse, the route will be
            //     update with the values contained in this dict.
            //     - rules_values: values added to the routing in order to create the
            //     route's rules.
            // """
            // return {
            //     'reception_route_id': {
            //         'routing_key': self.reception_steps,
            //         'depends': ['reception_steps'],
            //         'route_update_values': {
            //             'name': self._format_routename(route_type=self.reception_steps),
            //             'active': self.active,
            //         },
            //         'route_create_values': {
            //             'product_categ_selectable': True,
            //             'warehouse_selectable': True,
            //             'product_selectable': False,
            //             'company_id': self.company_id.id,
            //             'sequence': 9,
            //         },
            //         'rules_values': {
            //             'active': True,
            //             'propagate_cancel': True,
            //         }
            //     },
            //     'delivery_route_id': {
            //         'routing_key': self.delivery_steps,
            //         'depends': ['delivery_steps'],
            //         'route_update_values': {
            //             'name': self._format_routename(route_type=self.delivery_steps),
            //             'active': self.active,
            //         },
            //         'route_create_values': {
            //             'product_categ_selectable': True,
            //             'warehouse_selectable': True,
            //             'product_selectable': False,
            //             'company_id': self.company_id.id,
            //             'sequence': 10,
            //         },
            //         'rules_values': {
            //             'active': True,
            //             'propagate_carrier': True
            //         }
            //     },
            //     'crossdock_route_id': {
            //         'routing_key': 'crossdock',
            //         'depends': ['delivery_steps', 'reception_steps'],
            //         'route_update_values': {
            //             'name': self._format_routename(route_type='crossdock'),
            //             'active': self.reception_steps != 'one_step' and self.delivery_steps != 'ship_only'
            //         },
            //         'route_create_values': {
            //             'product_selectable': False,
            //             'product_categ_selectable': False,
            //             'active': self.delivery_steps != 'ship_only' and self.reception_steps != 'one_step',
            //             'company_id': self.company_id.id,
            //             'sequence': 20,
            //         },
            //     }
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetRuleValuesInternalAsync(object route_values, object values, object name_suffix)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_rule_values(self, route_values, values=None, name_suffix=''):
            // first_rule = True
            // rules_list = []
            // for routing in route_values:
            //     route_rule_values = {
            //         'name': self._format_rulename(routing.from_loc, routing.dest_loc, name_suffix),
            //         'location_src_id': routing.from_loc.id,
            //         'location_dest_id': routing.dest_loc.id,
            //         'action': routing.action,
            //         'auto': 'manual',
            //         'picking_type_id': routing.picking_type.id,
            //         'procure_method': first_rule and 'make_to_stock' or 'make_to_order',
            //         'warehouse_id': self.id,
            //         'company_id': self.company_id.id,
            //     }
            //     route_rule_values.update(values or {})
            //     rules_list.append(route_rule_values)
            //     first_rule = False
            // if values and values.get('propagate_cancel') and rules_list:
            //     # In case of rules chain with cancel propagation set, we need to stop
            //     # the cancellation for the last step in order to avoid cancelling
            //     # any other move after the chain.
            //     # Example: In the following flow:
            //     # Input -> Quality check -> Stock -> Customer
            //     # We want that cancelling I->GC cancel QC -> S but not S -> C
            //     # which means:
            //     # Input -> Quality check should have propagate_cancel = True
            //     # Quality check -> Stock should have propagate_cancel = False
            //     rules_list[-1]['propagate_cancel'] = False
            // return rules_list
            */
            return default;
        }

        public async Task<StockWarehouse> GetRulesDictAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def get_rules_dict(self):
            // result = super(StockWarehouse, self).get_rules_dict()
            // production_location_id = self._get_production_location()
            // for warehouse in self:
            //     result[warehouse.id].update({
            //         'mrp_one_step': [],
            //         'pbm': [
            //             self.Routing(warehouse.lot_stock_id, warehouse.pbm_loc_id, warehouse.pbm_type_id, 'pull'),
            //             self.Routing(warehouse.pbm_loc_id, production_location_id, warehouse.manu_type_id, 'pull'),
            //         ],
            //         'pbm_sam': [
            //             self.Routing(warehouse.lot_stock_id, warehouse.pbm_loc_id, warehouse.pbm_type_id, 'pull'),
            //             self.Routing(warehouse.pbm_loc_id, production_location_id, warehouse.manu_type_id, 'pull'),
            //             self.Routing(warehouse.sam_loc_id, warehouse.lot_stock_id, warehouse.sam_type_id, 'push'),
            //         ],
            //     })
            //     result[warehouse.id].update(warehouse._get_receive_rules_dict())
            // return result
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def get_rules_dict(self):
            // result = super(StockWarehouse, self).get_rules_dict()
            // subcontract_location_id = self._get_subcontracting_location()
            // for warehouse in self:
            //     result[warehouse.id].update({
            //         'subcontract': [
            //             self.Routing(warehouse.lot_stock_id, subcontract_location_id, warehouse.subcontracting_resupply_type_id, 'pull'),
            //         ]
            //     })
            // return result
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def get_rules_dict(self):
            // result = super(StockWarehouse, self).get_rules_dict()
            // for warehouse in self:
            //     result[warehouse.id].update(warehouse._get_receive_rules_dict())
            // return result
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def get_rules_dict(self):
            // """ Define the rules source/destination locations, picking_type and
            // action needed for each warehouse route configuration.
            // """
            // customer_loc, supplier_loc = self._get_partner_locations()
            // return {
            //     warehouse.id: {
            //         'one_step': [self.Routing(supplier_loc, warehouse.lot_stock_id, warehouse.in_type_id, 'pull')],
            //         'two_steps': [
            //             self.Routing(supplier_loc, warehouse.lot_stock_id, warehouse.in_type_id, 'pull'),
            //             self.Routing(warehouse.wh_input_stock_loc_id, warehouse.lot_stock_id, warehouse.store_type_id, 'push')],
            //         'three_steps': [
            //             self.Routing(supplier_loc, warehouse.lot_stock_id, warehouse.in_type_id, 'pull'),
            //             self.Routing(warehouse.wh_input_stock_loc_id, warehouse.wh_qc_stock_loc_id, warehouse.qc_type_id, 'push'),
            //             self.Routing(warehouse.wh_qc_stock_loc_id, warehouse.lot_stock_id, warehouse.store_type_id, 'push')],
            //         'crossdock': [
            //             self.Routing(supplier_loc, customer_loc, warehouse.in_type_id, 'pull'),
            //             self.Routing(warehouse.wh_input_stock_loc_id, warehouse.wh_output_stock_loc_id, warehouse.xdock_type_id, 'push')],
            //         'ship_only': [self.Routing(warehouse.lot_stock_id, customer_loc, warehouse.out_type_id, 'pull')],
            //         'pick_ship': [
            //             self.Routing(warehouse.lot_stock_id, customer_loc, warehouse.pick_type_id, 'pull'),
            //             self.Routing(warehouse.wh_output_stock_loc_id, customer_loc, warehouse.out_type_id, 'push')],
            //         'pick_pack_ship': [
            //             self.Routing(warehouse.lot_stock_id, customer_loc, warehouse.pick_type_id, 'pull'),
            //             self.Routing(warehouse.wh_pack_stock_loc_id, warehouse.wh_output_stock_loc_id, warehouse.pack_type_id, 'push'),
            //             self.Routing(warehouse.wh_output_stock_loc_id, customer_loc, warehouse.out_type_id, 'push')],
            //         'company_id': warehouse.company_id.id,
            //     } for warehouse in self
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouse> GetSequenceValuesInternalAsync(object name, object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _get_sequence_values(self, name=False, code=False):
            // values = super(StockWarehouse, self)._get_sequence_values(name=name, code=code)
            // values.update({
            //     'pbm_type_id': {'name': _('%(name)s Sequence picking before manufacturing', name=self.name), 'prefix': self.code + '/' + (self.pbm_type_id.sequence_code or 'PC') + '/', 'padding': 5, 'company_id': self.company_id.id},
            //     'sam_type_id': {'name': _('%(name)s Sequence stock after manufacturing', name=self.name), 'prefix': self.code + '/' + (self.sam_type_id.sequence_code or 'SFP') + '/', 'padding': 5, 'company_id': self.company_id.id},
            //     'manu_type_id': {'name': _('%(name)s Sequence production', name=self.name), 'prefix': self.code + '/' + (self.manu_type_id.sequence_code or 'MO') + '/', 'padding': 5, 'company_id': self.company_id.id},
            // })
            // return values
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_sequence_values(self, name=False, code=False):
            // values = super(StockWarehouse, self)._get_sequence_values(name=name, code=code)
            // count = self.env['ir.sequence'].search_count([('prefix', '=like', self.code + '/SBC%/%')])
            // values.update({
            //     'subcontracting_type_id': {
            //         'name': _('%(name)s Sequence subcontracting', name=self.name),
            //         'prefix': self.code + '/' + (self.subcontracting_type_id.sequence_code or (('SBC' + str(count)) if count else 'SBC')) + '/',
            //         'padding': 5,
            //         'company_id': self.company_id.id
            //     },
            //     'subcontracting_resupply_type_id': {
            //         'name': _('%(name)s Sequence Resupply Subcontractor', name=self.name),
            //         'prefix': self.code + '/' + (self.subcontracting_resupply_type_id.sequence_code or (('RES' + str(count)) if count else 'RES')) + '/',
            //         'padding': 5,
            //         'company_id': self.company_id.id
            //     },
            // })
            // return values
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_warehouse.py) ---
            // def _get_sequence_values(self, name=False, code=False):
            // sequence_values = super(Warehouse, self)._get_sequence_values(name=name, code=code)
            // sequence_values.update({
            //     'pos_type_id': {
            //         'name': _('%(name)s Picking POS', name=self.name),
            //         'prefix': self.code + '/' + (self.pos_type_id.sequence_code or 'POS') + '/',
            //         'padding': 5,
            //         'company_id': self.company_id.id,
            //     }
            // })
            // return sequence_values
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_warehouse.py) ---
            // def _get_sequence_values(self, name=False, code=False):
            // values = super(StockWarehouse, self)._get_sequence_values(name=name, code=code)
            // values.update({
            //     'repair_type_id': {
            //         'name': _('%(name)s Sequence repair', name=self.name),
            //         'prefix': self.code + '/' + (self.repair_type_id.sequence_code or 'RO') + '/',
            //         'padding': 5,
            //         'company_id': self.company_id.id
            //         },
            // })
            // return values
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_sequence_values(self, name=False, code=False):
            // """ Each picking type is created with a sequence. This method returns
            // the sequence values associated to each picking type.
            // """
            // name = name if name else self.name
            // code = code if code else self.code
            // return {
            //     'in_type_id': {
            //         'name': _('%(name)s Sequence in', name=name),
            //         'prefix': code + '/' + (self.in_type_id.sequence_code or 'IN') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'out_type_id': {
            //         'name': _('%(name)s Sequence out', name=name),
            //         'prefix': code + '/' + (self.out_type_id.sequence_code or 'OUT') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'pack_type_id': {
            //         'name': _('%(name)s Sequence packing', name=name),
            //         'prefix': code + '/' + (self.pack_type_id.sequence_code or 'PACK') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'pick_type_id': {
            //         'name': _('%(name)s Sequence picking', name=name),
            //         'prefix': code + '/' + (self.pick_type_id.sequence_code or 'PICK') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'qc_type_id': {
            //         'name': _('%(name)s Sequence quality control', name=name),
            //         'prefix': code + '/' + (self.qc_type_id.sequence_code or 'QC') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'store_type_id': {
            //         'name': _('%(name)s Sequence storage', name=name),
            //         'prefix': code + '/' + (self.store_type_id.sequence_code or 'STOR') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'int_type_id': {
            //         'name': _('%(name)s Sequence internal', name=name),
            //         'prefix': code + '/' + (self.int_type_id.sequence_code or 'INT') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            //     'xdock_type_id': {
            //         'name': _('%(name)s Sequence cross dock', name=name),
            //         'prefix': code + '/' + (self.xdock_type_id.sequence_code or 'XD') + '/', 'padding': 5,
            //         'company_id': self.company_id.id,
            //     },
            // }
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSubcontractingLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_subcontracting_location(self):
            // return self.company_id.subcontracting_location_id
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSubcontractingLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _get_subcontracting_locations(self):
            // return self.env['stock.location'].search([
            //     ('company_id', 'in', self.company_id.ids),
            //     ('is_subcontracting_location', '=', True),
            // ])
            */
            return default;
        }

        protected async Task<StockWarehouse> GetSupplyPullRulesValuesInternalAsync(object route_values, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_supply_pull_rules_values(self, route_values, values=None):
            // pull_values = {}
            // pull_values.update(values)
            // pull_values['active'] = True
            // rules_list = self._get_rule_values(route_values, values=pull_values)
            // for pull_rules in rules_list:
            //     pull_rules['procure_method'] = self.lot_stock_id.id != pull_rules['location_src_id'] and 'make_to_order' or 'make_to_stock'  # first part of the resuply route is MTS
            // return rules_list
            */
            return default;
        }

        protected async Task<StockWarehouse> GetTransitLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_transit_locations(self):
            // return self.company_id.internal_transit_location_id, self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False) or self.env['stock.location']
            */
            return default;
        }

        protected async Task<StockWarehouse> GetWarehouseIdFromContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _get_warehouse_id_from_context(self):
            // """
            // Helper method used to extract a single id from the context.
            // 
            // The `warehouse_id` dummy field of the `product.template` model is meant to
            // to be used in the `product_template_search_form_view_stock` search view in
            // order to add a `warehouse` context key. That key can therefore be any of
            // the following types: Int, String, List(Int?, String?).
            // """
            // context_warehouse = self.env.context.get('warehouse_id', False)
            // if context_warehouse:
            //     if isinstance(context_warehouse, int):
            //         return context_warehouse
            //     elif isinstance(context_warehouse, list):
            //         relevant_context = list(filter(lambda key: isinstance(key, int), context_warehouse))
            //         if relevant_context:
            //             return relevant_context[0]
            // return False
            */
            return default;
        }

        protected async Task<StockWarehouse> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _onchange_company_id(self):
            // group_user = self.env.ref('base.group_user')
            // group_stock_multi_warehouses = self.env.ref('stock.group_stock_multi_warehouses')
            // group_stock_multi_location = self.env.ref('stock.group_stock_multi_locations')
            // if group_stock_multi_warehouses not in group_user.implied_ids and group_stock_multi_location not in group_user.implied_ids:
            //     return {
            //         'warning': {
            //             'title': _('Warning'),
            //             'message': _('Creating a new warehouse will automatically activate the Storage Locations setting')
            //         }
            //     }
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateDropshipSubcontractRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py) ---
            // def _update_dropship_subcontract_rules(self):
            // '''update (archive/unarchive) any warehouse subcontracting location dropship rules'''
            // subcontracting_locations = self._get_subcontracting_locations()
            // route_id = self._find_or_create_global_route('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping',
            //                                    _('Dropship Subcontractor on Order'))
            // warehouses_dropship = self.filtered(lambda w: w.subcontracting_dropshipping_to_resupply and w.active)
            // if warehouses_dropship:
            //     self.env['stock.rule'].with_context(active_test=False).search([
            //         ('route_id', '=', route_id.id),
            //         ('action', '=', 'pull'),
            //         ('warehouse_id', 'in', warehouses_dropship.ids),
            //         ('location_src_id', 'in', subcontracting_locations.ids)]).action_unarchive()
            // 
            // warehouses_no_dropship = self - warehouses_dropship
            // if warehouses_no_dropship:
            //     self.env['stock.rule'].search([
            //         ('route_id', '=', route_id.id),
            //         ('action', '=', 'pull'),
            //         ('warehouse_id', 'in', warehouses_no_dropship.ids),
            //         ('location_src_id', 'in', subcontracting_locations.ids)]).action_archive()
            */
            return default;
        }

        public async Task<StockWarehouse> UpdateGlobalRouteDropshipSubcontractorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py) ---
            // def update_global_route_dropship_subcontractor(self):
            // route_id = self._find_or_create_global_route('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping',
            //                                    _('Dropship Subcontractor on Order'))
            // # if route has no pull rules, it means all warehouses have Dropship Subcontractor disabled
            // # Pick type is per company so we need to check rules per company to archive it, however
            // # the route is global so we need to check all rules regardless of company
            // all_rules = route_id.sudo().rule_ids.filtered(lambda r: r.active)
            // for company in self.company_id:
            //     company_rules = all_rules.filtered(lambda r: r.company_id == company)
            //     company.dropship_subcontractor_pick_type_id.active = bool(company_rules.filtered(lambda r: r.action == 'pull'))
            // 
            // route_id.active = bool(all_rules.filtered(lambda r: r.action == 'pull'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouse> UpdateGlobalRouteResupplySubcontractorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _update_global_route_resupply_subcontractor(self):
            // route_id = self._find_or_create_global_route('mrp_subcontracting.route_resupply_subcontractor_mto',
            //                                    _('Resupply Subcontractor on Order'))
            // if not route_id.sudo().rule_ids.filtered(lambda r: r.active):
            //     route_id.active = False
            // else:
            //     route_id.active = True
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationDeliveryInternalAsync(object new_delivery_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _update_location_delivery(self, new_delivery_step):
            // self.mapped('wh_pack_stock_loc_id').write({'active': new_delivery_step == 'pick_pack_ship'})
            // self.mapped('wh_output_stock_loc_id').write({'active': new_delivery_step != 'ship_only'})
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationManufactureInternalAsync(object new_manufacture_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _update_location_manufacture(self, new_manufacture_step):
            // self.mapped('pbm_loc_id').write({'active': new_manufacture_step != 'mrp_one_step'})
            // self.mapped('sam_loc_id').write({'active': new_manufacture_step == 'pbm_sam'})
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateLocationReceptionInternalAsync(object new_reception_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _update_location_reception(self, new_reception_step):
            // self.mapped('wh_qc_stock_loc_id').write({'active': new_reception_step == 'three_steps'})
            // self.mapped('wh_input_stock_loc_id').write({'active': new_reception_step != 'one_step'})
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateNameAndCodeInternalAsync(object new_name, object new_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def _update_name_and_code(self, name=False, code=False):
            // res = super(StockWarehouse, self)._update_name_and_code(name, code)
            // # change the manufacture stock rule name
            // for warehouse in self:
            //     if warehouse.manufacture_pull_id and name:
            //         warehouse.manufacture_pull_id.write({'name': warehouse.manufacture_pull_id.name.replace(warehouse.name, name, 1)})
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def _update_name_and_code(self, name=False, code=False):
            // res = super(StockWarehouse, self)._update_name_and_code(name, code)
            // warehouse = self[0]
            // #change the buy stock rule name
            // if warehouse.buy_pull_id and name:
            //     warehouse.buy_pull_id.write({'name': warehouse.buy_pull_id.name.replace(warehouse.name, name, 1)})
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _update_name_and_code(self, new_name=False, new_code=False):
            // if new_code:
            //     self.mapped('lot_stock_id').mapped('location_id').write({'name': new_code})
            // if new_name:
            //     # TDE FIXME: replacing the route name ? not better to re-generate the route naming ?
            //     for warehouse in self:
            //         routes = warehouse.route_ids
            //         for route in routes:
            //             route.write({'name': route.name.replace(warehouse.name, new_name, 1)})
            //             for pull in route.rule_ids:
            //                 pull.write({'name': pull.name.replace(warehouse.name, new_name, 1)})
            //         if warehouse.mto_pull_id:
            //             warehouse.mto_pull_id.write({'name': warehouse.mto_pull_id.name.replace(warehouse.name, new_name, 1)})
            // for warehouse in self:
            //     sequence_data = warehouse._get_sequence_values(name=new_name, code=new_code)
            //     # `ir.sequence` write access is limited to system user
            //     if self.env.user.has_group('stock.group_stock_manager'):
            //         warehouse = warehouse.sudo()
            //     warehouse.in_type_id.sequence_id.write(sequence_data['in_type_id'])
            //     warehouse.qc_type_id.sequence_id.write(sequence_data['qc_type_id'])
            //     warehouse.store_type_id.sequence_id.write(sequence_data['store_type_id'])
            //     warehouse.out_type_id.sequence_id.write(sequence_data['out_type_id'])
            //     warehouse.pack_type_id.sequence_id.write(sequence_data['pack_type_id'])
            //     warehouse.pick_type_id.sequence_id.write(sequence_data['pick_type_id'])
            //     warehouse.int_type_id.sequence_id.write(sequence_data['int_type_id'])
            //     warehouse.xdock_type_id.sequence_id.write(sequence_data['xdock_type_id'])
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdatePartnerDataInternalAsync(Guid partner_id, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _update_partner_data(self, partner_id, company_id):
            // if not partner_id:
            //     return
            // ResCompany = self.env['res.company']
            // if company_id:
            //     transit_loc = ResCompany.browse(company_id).internal_transit_location_id.id
            //     self.env['res.partner'].browse(partner_id).with_company(company_id).write({'property_stock_customer': transit_loc, 'property_stock_supplier': transit_loc})
            // else:
            //     transit_loc = self.env.company.internal_transit_location_id.id
            //     self.env['res.partner'].browse(partner_id).write({'property_stock_customer': transit_loc, 'property_stock_supplier': transit_loc})
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateReceptionDeliveryResupplyInternalAsync(object reception_new, object delivery_new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _update_reception_delivery_resupply(self, reception_new, delivery_new):
            // """ Check if we need to change something to resupply warehouses and associated MTO rules """
            // for warehouse in self:
            //     dummy, output_loc = warehouse._get_input_output_locations(reception_new, delivery_new)
            //     if delivery_new and warehouse.delivery_steps != delivery_new and (warehouse.delivery_steps == 'ship_only' or delivery_new == 'ship_only'):
            //         change_to_multiple = warehouse.delivery_steps == 'ship_only'
            //         warehouse._check_delivery_resupply(output_loc, change_to_multiple)
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateResupplyRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _update_resupply_rules(self):
            // '''update (archive/unarchive) any warehouse subcontracting location resupply rules'''
            // subcontracting_locations = self._get_subcontracting_locations()
            // warehouses_to_resupply = self.filtered(lambda w: w.subcontracting_to_resupply and w.active)
            // if warehouses_to_resupply:
            //     self.env['stock.rule'].with_context(active_test=False).search([
            //         '&', ('picking_type_id', 'in', warehouses_to_resupply.subcontracting_resupply_type_id.ids),
            //         '|', ('location_src_id', 'in', subcontracting_locations.ids),
            //         ('location_dest_id', 'in', subcontracting_locations.ids)]).action_unarchive()
            // 
            // warehouses_not_to_resupply = self - warehouses_to_resupply
            // if warehouses_not_to_resupply:
            //     self.env['stock.rule'].search([
            //         '&', ('picking_type_id', 'in', warehouses_not_to_resupply.subcontracting_resupply_type_id.ids),
            //         '|', ('location_src_id', 'in', subcontracting_locations.ids),
            //         ('location_dest_id', 'in', subcontracting_locations.ids)]).action_archive()
            */
            return default;
        }

        protected async Task<StockWarehouse> UpdateSubcontractingLocationsRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def _update_subcontracting_locations_rules(self):
            // subcontracting_locations = self._get_subcontracting_locations()
            // subcontracting_locations._activate_subcontracting_location_rules()
            */
            return default;
        }

        protected async Task<StockWarehouse> ValidBarcodeInternalAsync(object barcode, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _valid_barcode(self, barcode, company_id):
            // location = self.env['stock.location'].with_context(active_test=False).search([
            //     ('barcode', '=', barcode),
            //     ('company_id', '=', company_id)
            // ])
            // return not location and barcode
            */
            return default;
        }

        public async Task<StockWarehouse> ViewAllRoutesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def action_view_all_routes(self):
            // routes = self._get_all_routes()
            // return {
            //     'name': _('Warehouse\'s Routes'),
            //     'domain': [('id', 'in', routes.ids)],
            //     'res_model': 'stock.route',
            //     'type': 'ir.actions.act_window',
            //     'view_id': False,
            //     'view_mode': 'list,form',
            //     'limit': 20,
            //     'context': dict(self._context, default_warehouse_selectable=True, default_warehouse_ids=self.ids)
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockWarehouse> WarehouseRedirectWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def _warehouse_redirect_warning(self):
            // warehouse_action = self.env.ref('stock.action_warehouse_form')
            // msg = _('Please create a warehouse for company %s.', self.env.company.display_name)
            // if not self.env.user.has_group('stock.group_stock_manager'):
            //     raise UserError('Please contact your administrator to configure your warehouse.')
            // raise RedirectWarning(msg, warehouse_action.id, _('Go to Warehouses'))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, StockWarehouse entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py) ---
            // def write(self, vals):
            // if any(field in vals for field in ('manufacture_steps', 'manufacture_to_resupply')):
            //     for warehouse in self:
            //         warehouse._update_location_manufacture(vals.get('manufacture_steps', warehouse.manufacture_steps))
            // return super(StockWarehouse, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // # if all warehouses have resupply disabled, disable global route, until its enabled on a warehouse
            // if 'subcontracting_to_resupply' in vals or 'active' in vals:
            //     if 'subcontracting_to_resupply' in vals:
            //         # ignore when warehouse archived since it will auto-archive all of its rules
            //         self._update_resupply_rules()
            //     self._update_global_route_resupply_subcontractor()
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // # if all warehouses have resupply disabled, disable global route, until its enabled on a warehouse
            // if 'subcontracting_dropshipping_to_resupply' in vals or 'active' in vals:
            //     if 'subcontracting_dropshipping_to_resupply' in vals:
            //         # ignore when warehouse archived since it will auto-archive all of its rules
            //         self._update_dropship_subcontract_rules()
            //     self.update_global_route_dropship_subcontractor()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py) ---
            // def write(self, vals):
            // if 'company_id' in vals:
            //     for warehouse in self:
            //         if warehouse.company_id.id != vals['company_id']:
            //             raise UserError(_("Changing the company of this record is forbidden at this point, you should rather archive it and create a new one."))
            // 
            // Route = self.env['stock.route']
            // warehouses = self.with_context(active_test=False)
            // warehouses._create_missing_locations(vals)
            // 
            // if vals.get('reception_steps'):
            //     warehouses._update_location_reception(vals['reception_steps'])
            // if vals.get('delivery_steps'):
            //     warehouses._update_location_delivery(vals['delivery_steps'])
            // if vals.get('reception_steps') or vals.get('delivery_steps'):
            //     warehouses._update_reception_delivery_resupply(vals.get('reception_steps'), vals.get('delivery_steps'))
            // 
            // if vals.get('resupply_wh_ids') and not vals.get('resupply_route_ids'):
            //     old_resupply_whs = {warehouse.id: warehouse.resupply_wh_ids for warehouse in warehouses}
            // 
            // # If another partner assigned
            // if vals.get('partner_id'):
            //     if vals.get('company_id'):
            //         warehouses._update_partner_data(vals['partner_id'], vals.get('company_id'))
            //     else:
            //         for warehouse in self:
            //             warehouse._update_partner_data(vals['partner_id'], warehouse.company_id.id)
            // 
            // if vals.get('code') or vals.get('name'):
            //     warehouses._update_name_and_code(vals.get('name'), vals.get('code'))
            // 
            // res = super().write(vals)
            // 
            // for warehouse in warehouses:
            //     # check if we need to delete and recreate route
            //     depends = [depend for depends in [value.get('depends', []) for value in warehouse._get_routes_values().values()] for depend in depends]
            //     if 'code' in vals or any(depend in vals for depend in depends):
            //         picking_type_vals = warehouse._create_or_update_sequences_and_picking_types()
            //         if picking_type_vals:
            //             warehouse.write(picking_type_vals)
            //     if any(depend in vals for depend in depends):
            //         route_vals = warehouse._create_or_update_route()
            //         if route_vals:
            //             warehouse.write(route_vals)
            //     # Check if a global rule(mto, buy, ...) need to be modify.
            //     # The field that impact those rules are listed in the
            //     # _get_global_route_rules_values method under the key named
            //     # 'depends'.
            //     global_rules = warehouse._get_global_route_rules_values()
            //     depends = [depend for depends in [value.get('depends', []) for value in global_rules.values()] for depend in depends]
            //     if any(rule in vals for rule in global_rules) or\
            //             any(depend in vals for depend in depends):
            //         warehouse._create_or_update_global_routes_rules()
            // 
            //     if 'active' in vals:
            //         picking_type_ids = self.env['stock.picking.type'].with_context(active_test=False).search([('warehouse_id', '=', warehouse.id)])
            //         move_ids = self.env['stock.move'].search([
            //             ('picking_type_id', 'in', picking_type_ids.ids),
            //             ('state', 'not in', ('done', 'cancel')),
            //         ])
            //         if move_ids:
            //             raise UserError(_(
            //                 'You still have ongoing operations for operation types %(operations)s in warehouse %(warehouse)s',
            //                 operations=format_list(self.env, move_ids.mapped('picking_type_id.name')),
            //                 warehouse=warehouse.name,
            //             ))
            //         else:
            //             picking_type_ids.write({'active': vals['active']})
            //         location_ids = self.env['stock.location'].with_context(active_test=False).search([('location_id', 'child_of', warehouse.view_location_id.id)])
            //         picking_type_using_locations = self.env['stock.picking.type'].search([
            //             ('default_location_src_id', 'in', location_ids.ids),
            //             ('default_location_dest_id', 'in', location_ids.ids),
            //             ('id', 'not in', picking_type_ids.ids),
            //         ])
            //         if picking_type_using_locations:
            //             raise UserError(_(
            //                 '%(operations)s have default source or destination locations within warehouse %(warehouse)s, therefore you cannot archive it.',
            //                 operations=format_list(self.env, picking_type_using_locations.mapped('name')),
            //                 warehouse=warehouse.name,
            //             ))
            //         warehouse.view_location_id.write({'active': vals['active']})
            // 
            //         rule_ids = self.env['stock.rule'].with_context(active_test=False).search([('warehouse_id', '=', warehouse.id)])
            //         # Only modify route that apply on this warehouse.
            //         warehouse.route_ids.filtered(lambda r: len(r.warehouse_ids) == 1).write({'active': vals['active']})
            //         rule_ids.write({'active': vals['active']})
            // 
            //         if warehouse.active:
            //             # Catch all warehouse fields that trigger a modfication on
            //             # routes, rules, picking types and locations (e.g the reception
            //             # steps). The purpose is to write on it in order to let the
            //             # write method set the correct field to active or archive.
            //             depends = set([])
            //             for rule_item in warehouse._get_global_route_rules_values().values():
            //                 for depend in rule_item.get('depends', []):
            //                     depends.add(depend)
            //             for rule_item in warehouse._get_routes_values().values():
            //                 for depend in rule_item.get('depends', []):
            //                     depends.add(depend)
            //             values = {'resupply_route_ids': [(4, route.id) for route in warehouse.resupply_route_ids]}
            //             for depend in depends:
            //                 values.update({depend: warehouse[depend]})
            //             warehouse.write(values)
            // 
            // if vals.get('resupply_wh_ids') and not vals.get('resupply_route_ids'):
            //     for warehouse in warehouses:
            //         new_resupply_whs = warehouse.resupply_wh_ids
            //         to_add = new_resupply_whs - old_resupply_whs[warehouse.id]
            //         to_remove = old_resupply_whs[warehouse.id] - new_resupply_whs
            //         if to_add:
            //             existing_routes = Route.search([
            //                 ('supplied_wh_id', '=', warehouse.id),
            //                 ('supplier_wh_id', 'in', to_add.ids),
            //                 ('active', '=', False)
            //             ])
            //             if existing_routes:
            //                 existing_routes.toggle_active()
            //             remaining_to_add = to_add - existing_routes.supplier_wh_id
            //             if remaining_to_add:
            //                 warehouse.create_resupply_routes(remaining_to_add)
            //         if to_remove:
            //             to_disable_route_ids = Route.search([
            //                 ('supplied_wh_id', '=', warehouse.id),
            //                 ('supplier_wh_id', 'in', to_remove.ids),
            //                 ('active', '=', True)
            //             ])
            //             to_disable_route_ids.toggle_active()
            // 
            // if 'active' in vals:
            //     self._check_multiwarehouse_group()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}