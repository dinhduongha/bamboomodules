using Bamboo.Core.Application.Contracts.DTOs;
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
    public class ProcurementGroupAppService : GenericApplicationService<ProcurementGroup>, IProcurementGroupAppService
    {

        public ProcurementGroupAppService(IRepository<ProcurementGroup, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ProcurementGroup> CheckIntercompLocationInternalAsync(object locations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _check_intercomp_location(self, locations):
            // if locations.filtered(lambda location: location.usage == 'transit'):
            //     inter_comp_location = self.env.ref('stock.stock_location_inter_company', raise_if_not_found=False)
            //     return inter_comp_location and inter_comp_location.id in locations.ids
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetMovesToAssignDomainInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _get_moves_to_assign_domain(self, company_id):
            // domain = super(ProcurementGroup, self)._get_moves_to_assign_domain(company_id)
            // domain = expression.AND([domain, [('production_id', '=', False)]])
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_moves_to_assign_domain(self, company_id):
            // moves_domain = [
            //     ('state', 'in', ['confirmed', 'partially_available']),
            //     ('product_uom_qty', '!=', 0.0),
            //     '|',
            //         ('reservation_date', '<=', fields.Date.today()),
            //         ('picking_type_id.reservation_method', '=', 'at_confirm'),
            // ]
            // if company_id:
            //     moves_domain = expression.AND([[('company_id', '=', company_id)], moves_domain])
            // return moves_domain
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetOrderpointDomainInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_orderpoint_domain(self, company_id=False):
            // domain = [('trigger', '=', 'auto'), ('product_id.active', '=', True)]
            // if company_id:
            //     domain += [('company_id', '=', company_id)]
            // return domain
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetPushRuleInternalAsync(Guid product_id, Guid location_dest_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_push_rule(self, product_id, location_dest_id, values):
            // """ Find a push rule for the location_dest_id, with a fallback to the parent locations if none could be found.
            // """
            // found_rule = self.env['stock.rule']
            // location = location_dest_id
            // while (not found_rule) and location:
            //     domain = [('location_src_id', '=', location.id), ('action', 'in', ('push', 'pull_push'))]
            //     if values.get('domain'):
            //         domain = expression.AND([domain, values['domain']])
            //     found_rule = self._search_rule(values.get('route_ids'), values.get('product_packaging_id'), product_id, values.get('warehouse_id'), domain)
            //     location = location.location_id
            // return found_rule
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetRuleDomainInternalAsync(object location, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_rule_domain(self, locations, values):
            // location_ids = locations.ids
            // # If the method is called to find rules towards the Inter-company location, also add the 'Customer' location in the domain.
            // # This is to avoid having to duplicate every rules that deliver to Customer to have the Inter-company part.
            // if self._check_intercomp_location(locations):
            //     location_ids.append(self.env.ref('stock.stock_location_customers', raise_if_not_found=False).id)
            // domain = ['&', ('location_dest_id', 'in', location_ids), ('action', '!=', 'push')]
            // # In case the method is called by the superuser, we need to restrict the rules to the
            // # ones of the company. This is not useful as a regular user since there is a record
            // # rule to filter out the rules based on the company.
            // if self.env.su and values.get('company_id'):
            //     company_ids = set(values.get('company_id').ids)
            //     if values.get('route_ids'):
            //         company_ids |= set(values['route_ids'].company_id.ids)
            //     domain_company = ['|', ('company_id', '=', False), ('company_id', 'child_of', list(company_ids))]
            //     domain = expression.AND([domain, domain_company])
            // return domain
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _get_rule_domain(self, location, values):
            // domain = super()._get_rule_domain(location, values)
            // if 'sale_line_id' in values and values.get('company_id'):
            //     domain = expression.AND([domain, [('company_id', '=', values['company_id'].id)]])
            // return domain
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetRuleInternalAsync(Guid product_id, Guid location_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_rule(self, product_id, location_id, values):
            // """ Find a pull rule for the location_id, fallback on the parent
            // locations if it could not be found.
            // """
            // result = self.env['stock.rule']
            // if not location_id:
            //     return result
            // locations = location_id
            // # Get the location hierarchy, starting from location_id up to its root location.
            // while locations[-1].location_id:
            //     locations |= locations[-1].location_id
            // domain = self._get_rule_domain(locations, values)
            // # Get a mapping (location_id, route_id) -> warehouse_id -> rule_id
            // rule_dict = self._search_rule_for_warehouses(
            //     values.get("route_ids", False),
            //     values.get("product_packaging_id", False),
            //     product_id,
            //     values.get("warehouse_id", locations.warehouse_id),
            //     domain,
            // )
            // 
            // def extract_rule(rule_dict, route_ids, warehouse_id, location_dest_id):
            //     rule = self.env['stock.rule']
            //     for route_id in sorted(route_ids, key=lambda r: r.sequence):
            //         sub_dict = rule_dict.get((location_dest_id.id, route_id.id))
            //         if not sub_dict:
            //             continue
            //         if not warehouse_id:
            //             rule = sub_dict[next(iter(sub_dict))]
            //         else:
            //             rule = sub_dict.get(warehouse_id.id)
            //             rule = rule or sub_dict[False]
            //         if rule:
            //             break
            //     return rule
            // 
            // def get_rule_for_routes(rule_dict, route_ids, packaging_id, product_id, warehouse_id, location_dest_id):
            //     res = self.env['stock.rule']
            //     if route_ids:
            //         res = extract_rule(rule_dict, route_ids, warehouse_id, location_dest_id)
            //     if not res and packaging_id:
            //         res = extract_rule(rule_dict, packaging_id.route_ids, warehouse_id, location_dest_id)
            //     if not res:
            //         res = extract_rule(rule_dict, product_id.route_ids | product_id.categ_id.total_route_ids, warehouse_id, location_dest_id)
            //     if not res and warehouse_id:
            //         res = extract_rule(rule_dict, warehouse_id.route_ids, warehouse_id, location_dest_id)
            //     return res
            // 
            // location = location_id
            // # Go through the location hierarchy again, this time breaking at the first valid stock.rule found
            // # in rules_by_location.
            // inter_comp_location_checked = False
            // while (not result) and location:
            //     candidate_locations = location
            //     if not inter_comp_location_checked and self._check_intercomp_location(location):
            //         # Add the intercomp location to candidate_locations as the intercomp domain was added
            //         # above in the call to _get_rule_domain.
            //         inter_comp_location = self.env.ref('stock.stock_location_customers', raise_if_not_found=False)
            //         candidate_locations |= inter_comp_location
            //         inter_comp_location_checked = True
            //     for candidate_location in candidate_locations:
            //         result = get_rule_for_routes(
            //             rule_dict,
            //             values.get("route_ids", self.env['stock.route']),
            //             values.get("product_packaging_id", self.env['product.packaging']),
            //             product_id,
            //             values.get("warehouse_id", candidate_location.warehouse_id),
            //             candidate_location,
            //         )
            //         if result:
            //             break
            //     else:
            //         location = location.location_id
            // return result
            */
            return default;
        }

        protected async Task<ProcurementGroup> GetSchedulerTasksToDoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // return super()._get_scheduler_tasks_to_do() + 1
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // return super()._get_scheduler_tasks_to_do() + 1
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _get_scheduler_tasks_to_do(self):
            // """ Number of task to be executed by the stock scheduler. This number will be given in log
            // message to know how many tasks succeeded."""
            // return 3
            */
            return default;
        }

        public async Task<ProcurementGroup> RunAsync(Guid id, ProcurementGroupRunRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def run(self, procurements, raise_user_error=True):
            // """ If 'run' is called on a kit, this override is made in order to call
            // the original 'run' method with the values of the components of that kit.
            // """
            // procurements_without_kit = []
            // product_by_company = defaultdict(OrderedSet)
            // for procurement in procurements:
            //     product_by_company[procurement.company_id].add(procurement.product_id.id)
            // kits_by_company = {
            //     company: self.env['mrp.bom']._bom_find(self.env['product.product'].browse(product_ids), company_id=company.id, bom_type='phantom')
            //     for company, product_ids in product_by_company.items()
            // }
            // for procurement in procurements:
            //     bom_kit = kits_by_company[procurement.company_id].get(procurement.product_id)
            //     if bom_kit:
            //         order_qty = procurement.product_uom._compute_quantity(procurement.product_qty, bom_kit.product_uom_id, round=False)
            //         qty_to_produce = (order_qty / bom_kit.product_qty)
            //         _dummy, bom_sub_lines = bom_kit.explode(procurement.product_id, qty_to_produce, never_attribute_values=procurement.values.get("never_product_template_attribute_value_ids"))
            //         for bom_line, bom_line_data in bom_sub_lines:
            //             bom_line_uom = bom_line.product_uom_id
            //             quant_uom = bom_line.product_id.uom_id
            //             # recreate dict of values since each child has its own bom_line_id
            //             values = dict(procurement.values, bom_line_id=bom_line.id)
            //             component_qty, procurement_uom = bom_line_uom._adjust_uom_quantities(bom_line_data['qty'], quant_uom)
            //             procurements_without_kit.append(self.env['procurement.group'].Procurement(
            //                 bom_line.product_id, component_qty, procurement_uom,
            //                 procurement.location_id, procurement.name,
            //                 procurement.origin, procurement.company_id, values))
            //     else:
            //         procurements_without_kit.append(procurement)
            // return super(ProcurementGroup, self).run(procurements_without_kit, raise_user_error=raise_user_error)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py) ---
            // def run(self, procurements, raise_user_error=True):
            // wh_by_comp = dict()
            // for procurement in procurements:
            //     routes = procurement.values.get('route_ids')
            //     if routes and any(r.action == 'buy' for r in routes.rule_ids):
            //         company = procurement.company_id
            //         if company not in wh_by_comp:
            //             wh_by_comp[company] = self.env['stock.warehouse'].search([('company_id', '=', company.id)])
            //         wh = wh_by_comp[company]
            //         procurement.values['route_ids'] |= wh.reception_route_id
            // return super().run(procurements, raise_user_error=raise_user_error)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def run(self, procurements, raise_user_error=True):
            // """Fulfil `procurements` with the help of stock rules.
            // 
            // Procurements are needs of products at a certain location. To fulfil
            // these needs, we need to create some sort of documents (`stock.move`
            // by default, but extensions of `_run_` methods allow to create every
            // type of documents).
            // 
            // :param procurements: the description of the procurement
            // :type list: list of `~odoo.addons.stock.models.stock_rule.ProcurementGroup.Procurement`
            // :param raise_user_error: will raise either an UserError or a ProcurementException
            // :type raise_user_error: boolan, optional
            // :raises UserError: if `raise_user_error` is True and a procurement isn't fulfillable
            // :raises ProcurementException: if `raise_user_error` is False and a procurement isn't fulfillable
            // """
            // 
            // def raise_exception(procurement_errors):
            //     if raise_user_error:
            //         dummy, errors = zip(*procurement_errors)
            //         raise UserError('\n'.join(errors))
            //     else:
            //         raise ProcurementException(procurement_errors)
            // actions_to_run = defaultdict(list)
            // procurement_errors = []
            // for procurement in procurements:
            //     procurement.values.setdefault('company_id', procurement.location_id.company_id)
            //     procurement.values.setdefault('priority', '0')
            //     procurement.values.setdefault('date_planned', procurement.values.get('date_planned', False) or fields.Datetime.now())
            //     if self._skip_procurement(procurement):
            //         continue
            //     rule = self._get_rule(procurement.product_id, procurement.location_id, procurement.values)
            //     if not rule:
            //         error = _('No rule has been found to replenish "%(product)s" in "%(location)s".\nVerify the routes configuration on the product.',
            //             product=procurement.product_id.display_name, location=procurement.location_id.display_name)
            //         procurement_errors.append((procurement, error))
            //     else:
            //         action = 'pull' if rule.action == 'pull_push' else rule.action
            //         actions_to_run[action].append((procurement, rule))
            // 
            // if procurement_errors:
            //     raise_exception(procurement_errors)
            // 
            // for action, procurements in actions_to_run.items():
            //     if hasattr(self.env['stock.rule'], '_run_%s' % action):
            //         try:
            //             getattr(self.env['stock.rule'], '_run_%s' % action)(procurements)
            //         except ProcurementException as e:
            //             procurement_errors += e.procurement_exceptions
            //     else:
            //         _logger.error("The method _run_%s doesn't exist on the procurement rules" % action)
            // 
            // if procurement_errors:
            //     raise_exception(procurement_errors)
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProcurementGroup> RunSchedulerAsync(Guid id, ProcurementGroupRunSchedulerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def run_scheduler(self, use_new_cursor=False, company_id=False):
            // """ Call the scheduler in order to check the running procurements (super method), to check the minimum stock rules
            // and the availability of moves. This function is intended to be run for all the companies at the same time, so
            // we run functions as SUPERUSER to avoid intercompanies and access rights issues. """
            // try:
            //     self._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // except Exception:
            //     _logger.error("Error during stock scheduler", exc_info=True)
            //     raise
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProcurementGroup> RunSchedulerTasksInternalAsync(object use_new_cursor, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // super(ProcurementGroup, self)._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // self.env['pos.session']._alert_old_session()
            // if 'scheduler_task_done' in self._context:
            //     task_done = self._context.get('scheduler_task_done', {'task_done': 0})['task_done'] + 1
            //     self._context['scheduler_task_done']['task_done'] = task_done
            // else:
            //     task_done = self._get_scheduler_tasks_to_do()
            // if use_new_cursor:
            //     self.env['ir.cron']._notify_progress(done=task_done, remaining=self._get_scheduler_tasks_to_do() - task_done)
            //     self.env.cr.commit()
            --- ODOO METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // super(ProcurementGroup, self)._run_scheduler_tasks(use_new_cursor=use_new_cursor, company_id=company_id)
            // self.env['stock.lot']._alert_date_exceeded()
            // if 'scheduler_task_done' in self._context:
            //     task_done = self._context.get('scheduler_task_done', {'task_done': 0})['task_done'] + 1
            //     self._context['scheduler_task_done']['task_done'] = task_done
            // else:
            //     task_done = self._get_scheduler_tasks_to_do()
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._notify_progress(done=task_done, remaining=self._get_scheduler_tasks_to_do() - task_done)
            //     self.env.cr.commit()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _run_scheduler_tasks(self, use_new_cursor=False, company_id=False):
            // task_done = 0
            // 
            // # Minimum stock rules
            // domain = self._get_orderpoint_domain(company_id=company_id)
            // orderpoints = self.env['stock.warehouse.orderpoint'].search(domain)
            // orderpoints.sudo()._procure_orderpoint_confirm(use_new_cursor=use_new_cursor, company_id=company_id, raise_user_error=False)
            // task_done += 1
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._notify_progress(done=task_done, remaining=self._get_scheduler_tasks_to_do() - task_done)
            //     self._cr.commit()
            // 
            // # Search all confirmed stock_moves and try to assign them
            // domain = self._get_moves_to_assign_domain(company_id)
            // moves_to_assign = self.env['stock.move'].search(domain, limit=None,
            //     order='reservation_date, priority desc, date asc, id asc')
            // for moves_chunk in split_every(1000, moves_to_assign.ids):
            //     self.env['stock.move'].browse(moves_chunk).sudo()._action_assign()
            //     if use_new_cursor:
            //         self._cr.commit()
            //         _logger.info("A batch of %d moves are assigned and committed", len(moves_chunk))
            // task_done += 1
            // 
            // if use_new_cursor:
            //     self.env['ir.cron']._notify_progress(done=task_done, remaining=self._get_scheduler_tasks_to_do() - task_done)
            //     self._cr.commit()
            // 
            // # Merge duplicated quants
            // self.env['stock.quant']._quant_tasks()
            // 
            // task_done += 1
            // if use_new_cursor:
            //     self.env['ir.cron']._notify_progress(done=task_done, remaining=self._get_scheduler_tasks_to_do() - task_done)
            //     self._cr.commit()
            // self._context.get('scheduler_task_done', {})['task_done'] = task_done
            */
            return default;
        }

        protected async Task<ProcurementGroup> SearchRuleForWarehousesInternalAsync(List<Guid> route_ids, Guid packaging_id, Guid product_id, List<Guid> warehouse_ids, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _search_rule_for_warehouses(self, route_ids, packaging_id, product_id, warehouse_ids, domain):
            // if warehouse_ids:
            //     domain = expression.AND([['|', ('warehouse_id', 'in', warehouse_ids.ids), ('warehouse_id', '=', False)], domain])
            // valid_route_ids = set()
            // if route_ids:
            //     valid_route_ids |= set(route_ids.ids)
            // if packaging_id:
            //     packaging_routes = packaging_id.route_ids
            //     valid_route_ids |= set(packaging_routes.ids)
            // valid_route_ids |= set((product_id.route_ids | product_id.categ_id.total_route_ids).ids)
            // if warehouse_ids:
            //     valid_route_ids |= set(warehouse_ids.route_ids.ids)
            // if valid_route_ids:
            //     domain = expression.AND([[('route_id', 'in', list(valid_route_ids))], domain])
            // res = self.env["stock.rule"]._read_group(
            //     domain,
            //     groupby=["location_dest_id", "warehouse_id", "route_id"],
            //     aggregates=["id:recordset"],
            //     order="route_sequence:min, sequence:min",
            // )
            // rule_dict = defaultdict(OrderedDict)
            // for group in res:
            //     rule_dict[group[0].id, group[2].id][group[1].id] = group[3].sorted(lambda rule: (rule.route_sequence, rule.sequence))[0]
            // return rule_dict
            */
            return default;
        }

        protected async Task<ProcurementGroup> SearchRuleInternalAsync(List<Guid> route_ids, Guid packaging_id, Guid product_id, Guid warehouse_id, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _search_rule(self, route_ids, packaging_id, product_id, warehouse_id, domain):
            // """ First find a rule among the ones defined on the procurement
            // group, then try on the routes defined for the product, finally fallback
            // on the default behavior
            // """
            // if warehouse_id:
            //     domain = expression.AND([['|', ('warehouse_id', '=', warehouse_id.id), ('warehouse_id', '=', False)], domain])
            // Rule = self.env['stock.rule']
            // res = self.env['stock.rule']
            // if route_ids:
            //     res = Rule.search(expression.AND([[('route_id', 'in', route_ids.ids)], domain]), order='route_sequence, sequence', limit=1)
            // if not res and packaging_id:
            //     packaging_routes = packaging_id.route_ids
            //     if packaging_routes:
            //         res = Rule.search(expression.AND([[('route_id', 'in', packaging_routes.ids)], domain]), order='route_sequence, sequence', limit=1)
            // if not res:
            //     product_routes = product_id.route_ids | product_id.categ_id.total_route_ids
            //     if product_routes:
            //         res = Rule.search(expression.AND([[('route_id', 'in', product_routes.ids)], domain]), order='route_sequence, sequence', limit=1)
            // if not res and warehouse_id:
            //     warehouse_routes = warehouse_id.route_ids
            //     if warehouse_routes:
            //         res = Rule.search(expression.AND([[('route_id', 'in', warehouse_routes.ids)], domain]), order='route_sequence, sequence', limit=1)
            // return res
            */
            return default;
        }

        protected async Task<ProcurementGroup> SkipProcurementInternalAsync(object procurement)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_rule.py) ---
            // def _skip_procurement(self, procurement):
            // return procurement.product_id.type != "consu" or float_is_zero(
            //     procurement.product_qty, precision_rounding=procurement.product_uom.rounding
            // )
            */
            return default;
        }
    }
}