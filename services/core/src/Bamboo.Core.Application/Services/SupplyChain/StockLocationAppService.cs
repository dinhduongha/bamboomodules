using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockLocationAppService : GenericApplicationService<StockLocation>, IStockLocationAppService
    {

        public StockLocationAppService(IRepository<StockLocation, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockLocation> CheckAccessPutawayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py) ---
            // def _check_access_putaway(self):
            // """ Use sudo mode for subcontractor """
            // if self.env.user.partner_id.is_subcontractor:
            //     return self.sudo()
            // else:
            //     return super()._check_access_putaway()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _check_access_putaway(self):
            // return self
            */
            return default;
        }

        protected async Task<StockLocation> CheckCanBeUsedInternalAsync(object product, object quantity, object package, object location_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _check_can_be_used(self, product, quantity=0, package=None, location_qty=0):
            // """Check if product/package can be stored in the location. Quantity
            // should in the default uom of product, it's only used when no package is
            // specified."""
            // self.ensure_one()
            // if self.storage_category_id:
            //     forecast_weight = self._get_weight(self.env.context.get('exclude_sml_ids', set()))[self]['forecast_weight']
            //     # check if enough space
            //     if package and package.package_type_id:
            //         # check weight
            //         package_smls = self.env['stock.move.line'].search([('result_package_id', '=', package.id), ('state', 'not in', ['done', 'cancel'])])
            //         if self.storage_category_id.max_weight < forecast_weight + sum(package_smls.mapped(lambda sml: sml.quantity_product_uom * sml.product_id.weight)):
            //             return False
            //         # check if enough space
            //         package_capacity = self.storage_category_id.package_capacity_ids.filtered(lambda pc: pc.package_type_id == package.package_type_id)
            //         if package_capacity and location_qty >= package_capacity.quantity:
            //             return False
            //     else:
            //         # check weight
            //         if self.storage_category_id.max_weight < forecast_weight + product.weight * quantity:
            //             return False
            //         product_capacity = self.storage_category_id.product_capacity_ids.filtered(lambda pc: pc.product_id == product)
            //         # To handle new line without quantity in order to avoid suggesting a location already full
            //         if product_capacity and location_qty >= product_capacity.quantity:
            //             return False
            //         if product_capacity and quantity + location_qty > product_capacity.quantity:
            //             return False
            //     positive_quant = self.quant_ids.filtered(lambda q: q.product_id.uom_id.compare(q.quantity, 0) > 0)
            //     # check if only allow new product when empty
            //     if self.storage_category_id.allow_new_product == "empty" and positive_quant:
            //         return False
            //     # check if only allow same product
            //     if self.storage_category_id.allow_new_product == "same":
            //         # In case it's a package, `product` is not defined, so try to get
            //         # the package products from the context
            //         product = product or self.env.context.get('products')
            //         if (positive_quant and positive_quant.product_id != product) or len(product) > 1:
            //             return False
            //         if self.env['stock.move.line'].search_count([
            //             ('product_id', '!=', product.id),
            //             ('state', 'not in', ('done', 'cancel')),
            //             ('location_dest_id', '=', self.id),
            //         ], limit=1):
            //             return False
            // return True
            */
            return default;
        }

        protected async Task<StockLocation> CheckReplenishLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _check_replenish_location(self):
            // for loc in self:
            //     if loc.replenish_location:
            //         # cannot have parent/child location set as replenish as well
            //         replenish_wh_location = self.search([('id', '!=', loc.id), ('replenish_location', '=', True), '|', ('location_id', 'child_of', loc.id), ('location_id', 'parent_of', loc.id)], limit=1)
            //         if replenish_wh_location:
            //             raise ValidationError(_('Another parent/sub replenish location %s exists, if you wish to change it, uncheck it first', replenish_wh_location.name))
            */
            return default;
        }

        protected async Task<StockLocation> CheckScrapLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _check_scrap_location(self):
            // for record in self:
            //     if record.usage == 'inventory' and self.env['stock.picking.type'].search_count([('code', '=', 'mrp_operation'), ('default_location_dest_id', '=', record.id)], limit=1):
            //         raise ValidationError(_("You cannot set a location as a scrap location when it is assigned as a destination location for a manufacturing type operation."))
            */
            return default;
        }

        protected async Task<StockLocation> CheckSubcontractingLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py) ---
            // def _check_subcontracting_location(self):
            // for location in self:
            //     if location == location.company_id.subcontracting_location_id:
            //         raise ValidationError(_("You cannot alter the company's subcontracting location"))
            //     if location.is_subcontract() and location.usage != 'internal':
            //         raise ValidationError(_("In order to manage stock accurately, subcontracting locations must be type Internal, linked to the appropriate company."))
            */
            return default;
        }

        protected async Task<StockLocation> ChildOfInternalAsync(object other_location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _child_of(self, other_location):
            // self.ensure_one()
            // return self.parent_path.startswith(other_location.parent_path)
            */
            return default;
        }

        protected async Task<StockLocation> ComputeChildInternalLocationIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_child_internal_location_ids(self):
            // # batch reading optimization is not possible because the field has recursive=True
            // for loc in self:
            //     loc.child_internal_location_ids = self.search([('id', 'child_of', loc.id), ('usage', '=', 'internal')])
            */
            return default;
        }

        protected async Task<StockLocation> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_complete_name(self):
            // for location in self:
            //     if location.location_id and location.usage != 'view':
            //         location.complete_name = '%s/%s' % (location.location_id.complete_name, location.name)
            //     else:
            //         location.complete_name = location.name
            */
            return default;
        }

        protected async Task<StockLocation> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // for location in self:
            //     has_parent = location.location_id and location.usage != 'view'
            //     if location.env.context.get('formatted_display_name') and has_parent:
            //         location.display_name = f"--{location.location_id.complete_name}/--{location.name}"
            //     elif has_parent:
            //         location.display_name = f"{location.location_id.complete_name}/{location.name}"
            */
            return default;
        }

        protected async Task<StockLocation> ComputeEquipmentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_maintenance, FILE: stock_location.py) ---
            // def _compute_equipment_count(self):
            // equipment_data = self.env['maintenance.equipment']._read_group([('location_id', 'in', self.ids)], ['location_id'], ['__count'])
            // mapped_data = {location.id: count for location, count in equipment_data}
            // for location in self:
            //     location.equipment_count = mapped_data.get(location.id, 0)
            */
            return default;
        }

        protected async Task<StockLocation> ComputeIsEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_is_empty(self):
            // groups = self.env['stock.quant']._read_group(
            //     [('location_id.usage', 'in', ('internal', 'transit')),
            //      ('location_id', 'in', self.ids)],
            //     ['location_id'], ['quantity:sum'])
            // groups = dict(groups)
            // for location in self:
            //     location.is_empty = groups.get(location, 0) <= 0
            */
            return default;
        }

        protected async Task<StockLocation> ComputeIsValuedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py) ---
            // def _compute_is_valued(self):
            // for location in self:
            //     if location._should_be_valued():
            //         location.is_valued_internal = True
            //         location.is_valued_external = False
            //     else:
            //         location.is_valued_internal = False
            //         location.is_valued_external = True
            */
            return default;
        }

        protected async Task<StockLocation> ComputeNextInventoryDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_next_inventory_date(self):
            // for location in self:
            //     if location.company_id and location.usage in ['internal', 'transit'] and location.cyclic_inventory_frequency > 0:
            //         try:
            //             if location.last_inventory_date:
            //                 days_until_next_inventory = location.cyclic_inventory_frequency - (fields.Date.today() - location.last_inventory_date).days
            //                 if days_until_next_inventory <= 0:
            //                     location.next_inventory_date = fields.Date.today() + timedelta(days=1)
            //                 else:
            //                     location.next_inventory_date = location.last_inventory_date + timedelta(days=location.cyclic_inventory_frequency)
            //             else:
            //                 location.next_inventory_date = fields.Date.today() + timedelta(days=location.cyclic_inventory_frequency)
            //         except OverflowError:
            //             raise UserError(_("The selected Inventory Frequency (Days) creates a date too far into the future."))
            //     else:
            //         location.next_inventory_date = False
            */
            return default;
        }

        protected async Task<StockLocation> ComputeReplenishLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_replenish_location(self):
            // for loc in self:
            //     if loc.usage != 'internal':
            //         loc.replenish_location = False
            */
            return default;
        }

        protected async Task<StockLocation> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_warehouse_id(self):
            // warehouses = self.env['stock.warehouse'].search([('view_location_id', 'parent_of', self.ids)])
            // warehouses = warehouses.sorted(lambda w: w.view_location_id.parent_path, reverse=True)
            // view_by_wh = OrderedDict((wh.view_location_id.id, wh.id) for wh in warehouses)
            // self.warehouse_id = False
            // for loc in self:
            //     if not loc.parent_path:
            //         continue
            //     path = set(int(loc_id) for loc_id in loc.parent_path.split('/')[:-1])
            //     for view_location_id in view_by_wh:
            //         if view_location_id in path:
            //             loc.warehouse_id = view_by_wh[view_location_id]
            //             break
            */
            return default;
        }

        protected async Task<StockLocation> ComputeWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_weight(self):
            // weight_by_location = self._get_weight()
            // for location in self:
            //     location.net_weight = weight_by_location[location]['net_weight']
            //     location.forecast_weight = weight_by_location[location]['forecast_weight']
            */
            return default;
        }

        public async Task<StockLocation> CopyDataAsync(Guid id, StockLocationCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for location, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", location.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLocation> GetNextInventoryDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _get_next_inventory_date(self):
            // """ Used to get the next inventory date for a quant located in this location. It is
            // based on:
            // 1. Does the location have a cyclic inventory set?
            // 2. If not 1, then is there an annual inventory date set (for its company)?
            // 3. If not 1 and 2, then quants have no next inventory date."""
            // if self.usage not in ['internal', 'transit']:
            //     return False
            // next_inventory_date = False
            // company_inventory_date = False
            // 
            // if self.company_id.annual_inventory_month:
            //     today = fields.Date.today()
            //     annual_inventory_month = int(self.company_id.annual_inventory_month)
            //     # Manage 0 and negative annual_inventory_day
            //     annual_inventory_day = max(self.company_id.annual_inventory_day, 1)
            //     max_day = calendar.monthrange(today.year, annual_inventory_month)[1]
            //     # Manage annual_inventory_day bigger than last_day
            //     annual_inventory_day = min(annual_inventory_day, max_day)
            //     company_inventory_date = today.replace(
            //         month=annual_inventory_month, day=annual_inventory_day)
            //     if company_inventory_date <= today:
            //         # Manage leap year with the february
            //         max_day = calendar.monthrange(today.year + 1, annual_inventory_month)[1]
            //         annual_inventory_day = min(annual_inventory_day, max_day)
            //         company_inventory_date = company_inventory_date.replace(
            //             day=annual_inventory_day, year=today.year + 1)
            // if self.next_inventory_date:
            //     next_inventory_date = min(self.next_inventory_date, company_inventory_date) if company_inventory_date else self.next_inventory_date
            // elif self.company_id.annual_inventory_month:
            //     next_inventory_date = company_inventory_date
            // return next_inventory_date
            */
            return default;
        }

        protected async Task<StockLocation> GetPutawayStrategyInternalAsync(object product, object quantity, object package, object packaging, object additional_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _get_putaway_strategy(self, product, quantity=0, package=None, packaging=None, additional_qty=None):
            // """Returns the location where the product has to be put, if any compliant
            // putaway strategy is found. Otherwise returns self.
            // The quantity should be in the default UOM of the product, it is used when
            // no package is specified.
            // """
            // self = self._check_access_putaway()
            // products = self.env.context.get('products', self.env['product.product'])
            // products |= product
            // # find package type on package or packaging
            // package_type = self.env['stock.package.type']
            // if package:
            //     package_type = package.package_type_id
            // elif packaging:
            //     package_type = packaging.package_type_id
            // 
            // categ = products.categ_id if len(products.categ_id) == 1 else self.env['product.category']
            // categs = categ
            // while categ.parent_id:
            //     categ = categ.parent_id
            //     categs |= categ
            // 
            // putaway_rules = self.putaway_rule_ids.filtered(lambda rule:
            //                                                (not rule.product_id or rule.product_id in products) and
            //                                                (not rule.category_id or rule.category_id in categs) and
            //                                                (not rule.package_type_ids or package_type in rule.package_type_ids))
            // 
            // putaway_rules = putaway_rules.sorted(lambda rule: (bool(rule.package_type_ids),
            //                                                    bool(rule.product_id),
            //                                                    bool(rule.category_id == categs[:1]),  # same categ, not a parent
            //                                                    bool(rule.category_id)),
            //                                      reverse=True)
            // 
            // putaway_location = None
            // locations = self.env.context.get("locations")
            // if not locations:
            //     locations = self.child_internal_location_ids
            // if putaway_rules:
            //     # get current product qty (qty in current quants and future qty on assigned ml) of all child locations
            //     qty_by_location = defaultdict(lambda: 0)
            //     if locations.storage_category_id:
            //         if package and package.package_type_id:
            //             move_line_data = self.env['stock.move.line']._read_group([
            //                 ('id', 'not in', list(self.env.context.get('exclude_sml_ids', set()))),
            //                 ('result_package_id.package_type_id', '=', package_type.id),
            //                 ('state', 'not in', ['draft', 'cancel', 'done']),
            //             ], ['location_dest_id'], ['result_package_id:count_distinct'])
            //             quant_data = self.env['stock.quant']._read_group([
            //                 ('package_id.package_type_id', '=', package_type.id),
            //                 ('location_id', 'in', locations.ids),
            //             ], ['location_id'], ['package_id:count_distinct'])
            //             qty_by_location.update({location_dest.id: count for location_dest, count in move_line_data})
            //             for location, count in quant_data:
            //                 qty_by_location[location.id] += count
            //         else:
            //             move_line_data = self.env['stock.move.line']._read_group([
            //                 ('id', 'not in', list(self.env.context.get('exclude_sml_ids', set()))),
            //                 ('product_id', '=', product.id),
            //                 ('location_dest_id', 'in', locations.ids),
            //                 ('state', 'not in', ['draft', 'done', 'cancel'])
            //             ], ['location_dest_id'], ['quantity:array_agg', 'product_uom_id:recordset'])
            //             quant_data = self.env['stock.quant']._read_group([
            //                 ('product_id', '=', product.id),
            //                 ('location_id', 'in', locations.ids),
            //             ], ['location_id'], ['quantity:sum'])
            // 
            //             qty_by_location.update({location.id: quantity_sum for location, quantity_sum in quant_data})
            //             for location_dest, quantity_list, uoms in move_line_data:
            //                 current_qty = sum(ml_uom._compute_quantity(float(qty), product.uom_id) for qty, ml_uom in zip(quantity_list, uoms))
            //                 qty_by_location[location_dest.id] += current_qty
            // 
            //     if additional_qty:
            //         for location_id, qty in additional_qty.items():
            //             qty_by_location[location_id] += qty
            //     putaway_location = putaway_rules._get_putaway_location(product, quantity, package, packaging, qty_by_location)
            // 
            // if not putaway_location:
            //     putaway_location = locations[0] if locations and self.usage == 'view' else self
            // 
            // return putaway_location
            */
            return default;
        }

        protected async Task<StockLocation> GetWeightInternalAsync(List<Guid> excluded_sml_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _get_weight(self, excluded_sml_ids=False):
            // """Returns a dictionary with the net and forecasted weight of the location.
            // param excluded_sml_ids: set of stock.move.line ids to exclude from the computation
            // """
            // if not excluded_sml_ids:
            //     excluded_sml_ids = set()
            // Product = self.env['product.product']
            // StockMoveLine = self.env['stock.move.line']
            // 
            // quants = self.env['stock.quant']._read_group(
            //     [('location_id', 'in', self.ids)],
            //     groupby=['location_id', 'product_id'], aggregates=['quantity:sum'],
            // )
            // base_domain = Domain('state', 'not in', ['draft', 'done', 'cancel']) & Domain('id', 'not in', tuple(excluded_sml_ids))
            // outgoing_move_lines = StockMoveLine._read_group(
            //     Domain('location_id', 'in', self.ids) & base_domain,
            //     groupby=['location_id', 'product_id'], aggregates=['quantity_product_uom:sum'],
            // )
            // incoming_move_lines = StockMoveLine._read_group(
            //     Domain('location_dest_id', 'in', self.ids) & base_domain,
            //     groupby=['location_dest_id', 'product_id'], aggregates=['quantity_product_uom:sum']
            // )
            // 
            // products = Product.union(*(product for __, product, __ in quants + outgoing_move_lines + incoming_move_lines))
            // products.fetch(['weight'])
            // 
            // result = defaultdict(lambda: defaultdict(float))
            // for loc, product, quantity_sum in quants:
            //     weight = quantity_sum * product.weight
            //     result[loc]['net_weight'] += weight
            //     result[loc]['forecast_weight'] += weight
            // 
            // for loc, product, quantity_product_uom_sum in outgoing_move_lines:
            //     result[loc]['forecast_weight'] -= quantity_product_uom_sum * product.weight
            // 
            // for dest_loc, product, quantity_product_uom_sum in incoming_move_lines:
            //     result[dest_loc]['forecast_weight'] += quantity_product_uom_sum * product.weight
            // 
            // return result
            */
            return default;
        }

        protected async Task<StockLocation> IsOutgoingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _is_outgoing(self):
            // self.ensure_one()
            // if self.usage == 'customer':
            //     return True
            // # Can also be True if location is inter-company transit
            // inter_comp_location = self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False)
            // return self._child_of(inter_comp_location)
            */
            return default;
        }

        public async Task<StockLocation> IsSubcontractAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py) ---
            // def is_subcontract(self):
            // subcontracting_location = self.company_id.subcontracting_location_id
            // return subcontracting_location and self._child_of(subcontracting_location)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLocation> SearchIsEmptyInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _search_is_empty(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // location_ids = [
            //     location.id
            //     for location, in self.env['stock.quant']._read_group(
            //         [('location_id.usage', 'in', ['internal', 'transit'])],
            //         ['location_id'],
            //         having=[('quantity:sum', '>', 0)]
            //     )
            // ]
            // return [('id', 'not in', location_ids)]
            */
            return default;
        }

        protected async Task<StockLocation> SearchIsValuedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py) ---
            // def _search_is_valued(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(self.env._("Invalid search operator or value"))
            // positive_operator = (operator == '=' and value) or (operator == '!=' and not value)
            // domain = Domain([('company_id', '!=', False), ('usage', 'in', ['internal', 'transit'])])
            // if positive_operator:
            //     return domain
            // return ~domain
            */
            return default;
        }

        protected async Task<StockLocation> ShouldBeValuedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py) ---
            // def _should_be_valued(self):
            // """ This method returns a boolean reflecting whether the products stored in `self` should
            // be considered when valuating the stock of a company.
            // """
            // self.ensure_one()
            // return bool(self.company_id) and self.usage in ['internal', 'transit']
            */
            return default;
        }

        public async Task<StockLocation> ShouldBypassReservationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def should_bypass_reservation(self):
            // self.ensure_one()
            // return self.usage in ('supplier', 'customer', 'inventory', 'production')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockLocation> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _unlink_except_master_data(self):
            // inter_company_location = self.env.ref('stock.stock_location_inter_company')
            // if inter_company_location in self:
            //     raise ValidationError(_('The %s location is required by the Inventory app and cannot be deleted, but you can archive it.', inter_company_location.name))
            */
            return default;
        }

        public async Task<StockLocation> ViewEquipmentsRecordsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_maintenance, FILE: stock_location.py) ---
            // def action_view_equipments_records(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("maintenance.hr_equipment_action")
            // action['domain'] = [('location_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}