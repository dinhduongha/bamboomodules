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
    public class StockPickingTypeAppService : GenericApplicationService<StockPickingType>, IStockPickingTypeAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public StockPickingTypeAppService(IRepository<StockPickingType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<StockPickingType> BatchAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def action_batch(self):
            // action = self.env['ir.actions.act_window']._for_xml_id("stock_picking_batch.stock_picking_batch_action")
            // if self.env.context.get("view_mode"):
            //     del action["mobile_view_mode"]
            //     del action["views"]
            //     action["view_mode"] = self.env.context["view_mode"]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPickingType> CheckActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _check_active(self):
            // for picking_type in self:
            //     if picking_type.active:
            //         continue
            //     pos_config = self.env['pos.config'].sudo().search([('picking_type_id', '=', picking_type.id)], limit=1)
            //     if pos_config:
            //         raise ValidationError(_("You cannot archive '%(picking_type)s' as it is used by POS configuration '%(config)s'.", picking_type=picking_type.name, config=pos_config.name))
            */
            return default;
        }

        protected async Task<StockPickingType> CheckDefaultLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _check_default_location(self):
            // for record in self:
            //     if record.code == 'mrp_operation' and record.default_location_dest_id.scrap_location:
            //         raise ValidationError(_("You cannot set a scrap location as the destination location for a manufacturing type operation."))
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeCountRepairInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_count_repair(self):
            // repair_picking_types = self.filtered(lambda picking: picking.code == 'repair_operation')
            // 
            // # By default, set count_repair_xxx to False
            // self.count_repair_ready = False
            // self.count_repair_confirmed = False
            // self.count_repair_under_repair = False
            // self.count_repair_late = False
            // 
            // # shortcut
            // if not repair_picking_types:
            //     return
            // 
            // picking_types = self.env['repair.order']._read_group(
            //     [
            //         ('picking_type_id', 'in', repair_picking_types.ids),
            //         ('state', 'in', ('confirmed', 'under_repair')),
            //     ],
            //     groupby=['picking_type_id', 'is_parts_available', 'state'],
            //     aggregates=['id:count']
            // )
            // 
            // late_repairs = self.env['repair.order']._read_group(
            //     [
            //         ('picking_type_id', 'in', repair_picking_types.ids),
            //         ('state', '=', 'confirmed'),
            //         '|',
            //         ('schedule_date', '<', fields.Date.today()),
            //         ('is_parts_late', '=', True),
            //     ],
            //     groupby=['picking_type_id'],
            //     aggregates=['__count']
            // )
            // late_repairs = {pt.id: late_count for pt, late_count in late_repairs}
            // 
            // counts = {}
            // for pt in picking_types:
            //     pt_count = counts.setdefault(pt[0].id, {})
            //     # Only confirmed repairs (not "under repair" ones) are considered as ready
            //     if pt[1] and pt[2] == 'confirmed':
            //         pt_count.setdefault('ready', 0)
            //         pt_count['ready'] += pt[3]
            //     pt_count.setdefault(pt[2], 0)
            //     pt_count[pt[2]] += pt[3]
            // 
            // for pt in repair_picking_types:
            //     if pt.id not in counts:
            //         continue
            //     pt.count_repair_ready = counts[pt.id].get('ready')
            //     pt.count_repair_confirmed = counts[pt.id].get('confirmed')
            //     pt.count_repair_under_repair = counts[pt.id].get('under_repair')
            //     pt.count_repair_late = late_repairs.get(pt.id, 0)
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_default_location_dest_id(self):
            // repair_picking_type = self.filtered(lambda pt: pt.code == 'repair_operation')
            // prod_locations = self.env['stock.location']._read_group(
            //     [('usage', '=', 'production'), ('company_id', 'in', repair_picking_type.company_id.ids)],
            //     ['company_id'],
            //     ['id:min'],
            // )
            // prod_locations = {l[0].id: l[1] for l in prod_locations}
            // for picking_type in repair_picking_type:
            //     picking_type.default_location_dest_id = prod_locations.get(picking_type.company_id.id)
            // super(PickingType, (self - repair_picking_type))._compute_default_location_dest_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_default_location_dest_id(self):
            // for picking_type in self:
            //     if not picking_type.warehouse_id:
            //         self.env['stock.warehouse']._warehouse_redirect_warning()
            //     stock_location = picking_type.warehouse_id.lot_stock_id
            //     if picking_type.code == 'outgoing':
            //         picking_type.default_location_dest_id = self.env.ref('stock.stock_location_customers').id
            //     else:
            //         picking_type.default_location_dest_id = stock_location.id
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_default_location_dest_id(self):
            // dropship_types = self.filtered(lambda pt: pt.code == 'dropship')
            // dropship_types.default_location_dest_id = self.env.ref('stock.stock_location_customers').id
            // 
            // super(StockPickingType, self - dropship_types)._compute_default_location_dest_id()
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultLocationSrcIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_default_location_src_id(self):
            // remaining_picking_type = self.env['stock.picking.type']
            // for picking_type in self:
            //     if picking_type.code != 'repair_operation':
            //         remaining_picking_type |= picking_type
            //         continue
            //     stock_location = picking_type.warehouse_id.lot_stock_id
            //     picking_type.default_location_src_id = stock_location.id
            // super(PickingType, remaining_picking_type)._compute_default_location_src_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_default_location_src_id(self):
            // for picking_type in self:
            //     if not picking_type.warehouse_id:
            //         self.env['stock.warehouse']._warehouse_redirect_warning()
            //     stock_location = picking_type.warehouse_id.lot_stock_id
            //     if picking_type.code == 'incoming':
            //         picking_type.default_location_src_id = self.env.ref('stock.stock_location_suppliers').id
            //     else:
            //         picking_type.default_location_src_id = stock_location.id
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_default_location_src_id(self):
            // dropship_types = self.filtered(lambda pt: pt.code == 'dropship')
            // dropship_types.default_location_src_id = self.env.ref('stock.stock_location_suppliers').id
            // 
            // super(StockPickingType, self - dropship_types)._compute_default_location_src_id()
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultProductLocationIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_default_product_location_id(self):
            // for picking_type in self:
            //     if picking_type.code == 'repair_operation':
            //         stock_location = picking_type.warehouse_id.lot_stock_id
            //         picking_type.default_product_location_src_id = stock_location.id
            //         picking_type.default_product_location_dest_id = stock_location.id
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultRecycleLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_default_recycle_location_dest_id(self):
            // for picking_type in self:
            //     if picking_type.code == 'repair_operation':
            //         stock_location = picking_type.warehouse_id.lot_stock_id
            //         picking_type.default_recycle_location_dest_id = stock_location.id
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDefaultRemoveLocationDestIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_default_remove_location_dest_id(self):
            // repair_picking_type = self.filtered(lambda pt: pt.code == 'repair_operation')
            // company_ids = repair_picking_type.company_id.ids
            // company_ids.append(False)
            // scrap_locations = self.env['stock.location']._read_group(
            //     [('scrap_location', '=', True), ('company_id', 'in', company_ids)],
            //     ['company_id'],
            //     ['id:min'],
            // )
            // scrap_locations = {l[0].id: l[1] for l in scrap_locations}
            // for picking_type in repair_picking_type:
            //     picking_type.default_remove_location_dest_id = scrap_locations.get(picking_type.company_id.id)
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_display_name(self):
            // """ Display 'Warehouse_name: PickingType_name' """
            // for picking_type in self:
            //     if picking_type.warehouse_id:
            //         picking_type.display_name = f"{picking_type.warehouse_id.name}: {picking_type.name}"
            //     else:
            //         picking_type.display_name = picking_type.name
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeHideReservationMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _compute_hide_reservation_method(self):
            // super()._compute_hide_reservation_method()
            // for picking_type in self:
            //     if picking_type == picking_type.warehouse_id.pos_type_id:
            //         picking_type.hide_reservation_method = True
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_hide_reservation_method(self):
            // for rec in self:
            //     rec.hide_reservation_method = rec.code == 'incoming'
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_is_favorite(self):
            // for picking_type in self:
            //     picking_type.is_favorite = self.env.user in picking_type.favorite_user_ids
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeIsRepairableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _compute_is_repairable(self):
            // for picking_type in self:
            //     if not picking_type.return_type_of_ids:
            //         picking_type.is_repairable = False
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeKanbanDashboardGraphInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_kanban_dashboard_graph(self):
            // grouped_records = self._get_aggregated_records_by_date()
            // 
            // summaries = {}
            // for picking_type_id, dates, data_series_name in grouped_records:
            //     summaries[picking_type_id] = {
            //         'data_series_name': data_series_name,
            //         'total_before': 0,
            //         'total_yesterday': 0,
            //         'total_today': 0,
            //         'total_day_1': 0,
            //         'total_day_2': 0,
            //         'total_after': 0,
            //     }
            //     for p_date in dates:
            //         date_category = self.env["stock.picking"].calculate_date_category(p_date)
            //         if date_category:
            //             summaries[picking_type_id]['total_' + date_category] += 1
            // 
            // self._prepare_graph_data(summaries)
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeMoveCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_move_count(self):
            // data = self.env['stock.move']._read_group(
            //     [('state', '=', 'assigned'), ('picking_type_id', 'in', self.ids)],
            //     ['picking_type_id'], ['__count']
            // )
            // count = {picking_type.id: count for picking_type, count in data}
            // for record in self:
            //     record['count_move_ready'] = count.get(record.id, 0)
            */
            return default;
        }

        protected async Task<StockPickingType> ComputePickingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_picking_count(self):
            // domains = {
            //     'count_picking_draft': [('state', '=', 'draft')],
            //     'count_picking_waiting': [('state', 'in', ('confirmed', 'waiting'))],
            //     'count_picking_ready': [('state', '=', 'assigned')],
            //     'count_picking': [('state', 'in', ('assigned', 'waiting', 'confirmed'))],
            //     'count_picking_late': [('state', 'in', ('assigned', 'waiting', 'confirmed')), '|', ('scheduled_date', '<', fields.Date.today()), ('has_deadline_issue', '=', True)],
            //     'count_picking_backorders': [('backorder_id', '!=', False), ('state', 'in', ('confirmed', 'assigned', 'waiting'))],
            // }
            // for field_name, domain in domains.items():
            //     data = self.env['stock.picking']._read_group(domain +
            //         [('state', 'not in', ('done', 'cancel')), ('picking_type_id', 'in', self.ids)],
            //         ['picking_type_id'], ['__count'])
            //     count = {picking_type.id: count for picking_type, count in data}
            //     for record in self:
            //         record[field_name] = count.get(record.id, 0)
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _compute_picking_count(self):
            // super()._compute_picking_count()
            // data = self.env['stock.picking.batch']._read_group(
            //     [('state', 'not in', ('done', 'cancel')), ('picking_type_id', 'in', self.ids)],
            //     ['picking_type_id', 'is_wave'], ['__count'])
            // count = {(picking_type.id, is_wave): count for picking_type, is_wave, count in data}
            // for record in self:
            //     record.count_picking_wave = count.get((record.id, True), 0)
            //     record.count_picking_batch = count.get((record.id, False), 0)
            */
            return default;
        }

        protected async Task<StockPickingType> ComputePrintLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_print_label(self):
            // for picking_type in self:
            //     if picking_type.code in ('incoming', 'internal'):
            //         picking_type.print_label = False
            //     elif picking_type.code == 'outgoing':
            //         picking_type.print_label = True
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeReadyItemsLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_ready_items_label(self):
            // for pt in self:
            //     label = _('To Process')
            //     match pt.code:
            //         case 'incoming':
            //             label = _('To Receive')
            //         case 'outgoing':
            //             label = _('To Deliver')
            //     pt.ready_items_label = label
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeShowPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_show_picking_type(self):
            // for record in self:
            //     record.show_picking_type = record.code in ['incoming', 'outgoing', 'internal']
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_show_picking_type(self):
            // super()._compute_show_picking_type()
            // for record in self:
            //     if record.code == "dropship":
            //         record.show_picking_type = True
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeUseCreateLotsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _compute_use_create_lots(self):
            // super()._compute_use_create_lots()
            // for picking_type in self:
            //     if picking_type.code == 'mrp_operation':
            //         picking_type.use_create_lots = True
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_use_create_lots(self):
            // for picking_type in self:
            //     if picking_type.code == 'incoming':
            //         picking_type.use_create_lots = True
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeUseExistingLotsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _compute_use_existing_lots(self):
            // super()._compute_use_existing_lots()
            // for picking_type in self:
            //     if picking_type.code == 'mrp_operation':
            //         picking_type.use_existing_lots = True
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_use_existing_lots(self):
            // for picking_type in self:
            //     if picking_type.code == 'outgoing':
            //         picking_type.use_existing_lots = True
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _compute_warehouse_id(self):
            // for picking_type in self:
            //     if picking_type.warehouse_id:
            //         continue
            //     if picking_type.company_id:
            //         warehouse = self.env['stock.warehouse'].search([('company_id', '=', picking_type.company_id.id)], limit=1)
            //         picking_type.warehouse_id = warehouse
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py) ---
            // def _compute_warehouse_id(self):
            // super()._compute_warehouse_id()
            // for picking_type in self:
            //     if picking_type.code == 'dropship':
            //         picking_type.warehouse_id = False
            */
            return default;
        }

        protected async Task<StockPickingType> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _compute_weight_uom_name(self):
            // for picking_type in self:
            //     picking_type.weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<StockPickingType> CopyDataAsync(Guid id, StockPickingTypeCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for picking, vals in zip(self, vals_list):
            //     if 'name' not in default:
            //         vals['name'] = _("%s (copy)", picking.name)
            //     if 'sequence_code' not in default and 'sequence_id' not in default:
            //         vals['sequence_code'] = _("%s (copy)", picking.sequence_code)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPickingType> GetActionInternalAsync(object action_xmlid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_action(self, action_xmlid):
            // action = self.env["ir.actions.actions"]._for_xml_id(action_xmlid)
            // context = {}
            // 
            // if self:
            //     action['display_name'] = self.display_name
            //     context.update({
            //         'search_default_picking_type_id': [self.id],
            //         'default_picking_type_id': self.id,
            //         'default_company_id': self.company_id.id,
            //     })
            // else:
            //     allowed_company_ids = self.env.context.get('allowed_company_ids', [])
            //     if allowed_company_ids:
            //         context.update({
            //             'default_company_id': allowed_company_ids[0],
            //         })
            // 
            // action_context = literal_eval(action['context'])
            // context = {**action_context, **context}
            // action['context'] = context
            // 
            // action['help'] = self.env['ir.ui.view']._render_template(
            //     'stock.help_message_template', {
            //         'picking_type_code': context.get('restricted_picking_type_code') or self.code,
            //     }
            // )
            // 
            // return action
            */
            return default;
        }

        protected async Task<StockPickingType> GetAggregatedRecordsByDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _get_aggregated_records_by_date(self):
            // production_picking_types = self.filtered(lambda picking: picking.code == 'mrp_operation')
            // other_picking_types = (self - production_picking_types)
            // 
            // records = super(StockPickingType, other_picking_types)._get_aggregated_records_by_date()
            // mrp_records = self.env['mrp.production']._read_group(
            //     [
            //         ('picking_type_id', 'in', production_picking_types.ids),
            //         ('state', '=', 'confirmed')
            //     ],
            //     ['picking_type_id'],
            //     ['date_start' + ':array_agg'],
            // )
            // # Make sure that all picking type IDs are represented, even if empty
            // picking_type_id_to_dates = {i: [] for i in production_picking_types.ids}
            // picking_type_id_to_dates.update({r[0].id: r[1] for r in mrp_records})
            // mrp_records = [(i, d, self.env._('Confirmed')) for i, d in picking_type_id_to_dates.items()]
            // return records + mrp_records
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def _get_aggregated_records_by_date(self):
            // repair_picking_types = self.filtered(lambda picking: picking.code == 'repair_operation')
            // other_picking_types = (self - repair_picking_types)
            // 
            // records = super(PickingType, other_picking_types)._get_aggregated_records_by_date()
            // repair_records = self.env['repair.order']._read_group(
            //     [
            //         ('picking_type_id', 'in', repair_picking_types.ids),
            //         ('state', '=', 'confirmed')
            //     ],
            //     ['picking_type_id'],
            //     ['schedule_date' + ':array_agg'],
            // )
            // # Make sure that all picking type IDs are represented, even if empty
            // picking_type_id_to_dates = {i: [] for i in repair_picking_types.ids}
            // picking_type_id_to_dates.update({r[0].id: r[1] for r in repair_records})
            // label = self.env._('Confirmed')
            // repair_records = [(i, d, label) for i, d in picking_type_id_to_dates.items()]
            // return records + repair_records
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _get_aggregated_records_by_date(self):
            // """
            // Returns a list, each element containing 3 values:
            // * picking type ID
            // * list of date fields values of all pickings with that picking type
            // * data series name, used to display it in the graph
            // """
            // records = self.env['stock.picking']._read_group(
            //     [
            //         ('picking_type_id', 'in', self.ids),
            //         ('state', 'in', ['assigned', 'waiting', 'confirmed'])
            //     ],
            //     ['picking_type_id'],
            //     ['scheduled_date' + ':array_agg'],
            // )
            // # Make sure that all picking type IDs are represented, even if empty
            // picking_type_id_to_dates = {i: [] for i in self.ids}
            // picking_type_id_to_dates.update({r[0].id: r[1] for r in records})
            // return [(i, d, self.env._('Transfers')) for i, d in picking_type_id_to_dates.items()]
            */
            return default;
        }

        protected async Task<StockPickingType> GetBatchAndWaveGroupByKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_batch_and_wave_group_by_keys(self):
            // return self._get_batch_group_by_keys() + self._get_wave_group_by_keys()
            */
            return default;
        }

        protected async Task<StockPickingType> GetBatchGroupByKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_batch_group_by_keys(self):
            // return super()._get_batch_group_by_keys() + ['batch_group_by_carrier']
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_batch_group_by_keys(self):
            // return ['batch_group_by_partner', 'batch_group_by_destination', 'batch_group_by_src_loc', 'batch_group_by_dest_loc']
            */
            return default;
        }

        protected async Task<StockPickingType> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_default_weight_uom(self):
            // return self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<StockPickingType> GetMoCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def _get_mo_count(self):
            // mrp_picking_types = self.filtered(lambda picking: picking.code == 'mrp_operation')
            // remaining = (self - mrp_picking_types)
            // remaining.count_mo_waiting = remaining.count_mo_todo = remaining.count_mo_late = False
            // remaining.count_mo_in_progress = remaining.count_mo_to_close = False
            // domains = {
            //     'count_mo_waiting': [('reservation_state', '=', 'waiting')],
            //     'count_mo_todo': [('state', '=', 'confirmed')],
            //     'count_mo_late': [('date_start', '<', fields.Date.today()), ('state', '=', 'confirmed')],
            //     'count_mo_in_progress': [('state', '=', 'progress')],
            //     'count_mo_to_close': [('state', '=', 'to_close')],
            // }
            // for key, domain in domains.items():
            //     data = self.env['mrp.production']._read_group(domain +
            //         [('state', 'not in', ('done', 'cancel')), ('picking_type_id', 'in', mrp_picking_types.ids)],
            //         ['picking_type_id'], ['__count'])
            //     count = {picking_type.id: count for picking_type, count in data}
            //     for record in mrp_picking_types:
            //         record[key] = count.get(record.id, 0)
            */
            return default;
        }

        public async Task<StockPickingType> GetMrpStockPickingPickingTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py) ---
            // def get_mrp_stock_picking_action_picking_type(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('mrp.mrp_production_action_picking_deshboard')
            // if self:
            //     action['display_name'] = self.display_name
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTreeBackorderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_backorder(self):
            // return self._get_action('stock.action_picking_tree_backorder')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTreeLateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_late(self):
            // return self._get_action('stock.action_picking_tree_late')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTreeReadyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_ready(self):
            // return self._get_action('stock.action_picking_tree_ready')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTreeWaitingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_tree_waiting(self):
            // return self._get_action('stock.action_picking_tree_waiting')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTypeMovesAnalysisAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_type_moves_analysis(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('stock.stock_move_action')
            // action['domain'] = expression.AND([
            //     action['domain'] or [], [('picking_type_id', '=', self.id)]
            // ])
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetPickingTypeReadyMovesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_action_picking_type_ready_moves(self):
            // return self._get_action('stock.action_get_picking_type_ready_moves')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetRepairStockPickingPickingTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def get_repair_stock_picking_action_picking_type(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('repair.action_picking_repair')
            // if self:
            //     action['display_name'] = self.display_name
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> GetStockPickingPickingTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def get_stock_picking_action_picking_type(self):
            // return self._get_action('stock.stock_picking_action_picking_type')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPickingType> GetWaveGroupByKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _get_wave_group_by_keys(self):
            // return ['wave_group_by_product', 'wave_group_by_category', 'wave_group_by_location']
            */
            return default;
        }

        protected async Task<StockPickingType> InverseIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _inverse_is_favorite(self):
            // sudoed_self = self.sudo()
            // to_fav = sudoed_self.filtered(
            //     lambda picking_type: self.env.user not in picking_type.favorite_user_ids
            // )
            // to_fav.write({'favorite_user_ids': [(4, self.env.uid)]})
            // (sudoed_self - to_fav).write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        protected async Task<StockPickingType> IsAutoBatchGroupedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _is_auto_batch_grouped(self):
            // self.ensure_one()
            // return self.auto_batch and any(self[key] for key in self._get_batch_group_by_keys())
            */
            return default;
        }

        protected async Task<StockPickingType> IsAutoWaveGroupedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _is_auto_wave_grouped(self):
            // self.ensure_one()
            // return self.auto_batch and any(self[key] for key in self._get_wave_group_by_keys())
            */
            return default;
        }

        protected async Task<StockPickingType> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', data['pos.config']['data'][0]['picking_type_id'])]
            */
            return default;
        }

        protected async Task<StockPickingType> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'use_create_lots', 'use_existing_lots']
            */
            return default;
        }

        protected async Task<StockPickingType> OnchangePickingCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _onchange_picking_code(self):
            // if self.code == 'internal' and not self.env.user.has_group('stock.group_stock_multi_locations'):
            //     return {
            //         'warning': {
            //             'message': _('You need to activate storage locations to be able to do internal operation types.')
            //         }
            //     }
            */
            return default;
        }

        protected async Task<StockPickingType> OnchangeSequenceCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _onchange_sequence_code(self):
            // if not self.sequence_code:
            //     return
            // domain = [('sequence_code', '=', self.sequence_code), '|', ('company_id', '=', self.company_id.id), ('company_id', '=', False)]
            // if self._origin.id:
            //     domain += [('id', '!=', self._origin.id)]
            // picking_type = self.env['stock.picking.type'].search(domain, limit=1)
            // if picking_type and picking_type.sequence_id != self.sequence_id:
            //     return {
            //         'warning': {
            //             'message': _(
            //                 "This sequence prefix is already being used by another operation type. It is recommended that you select a unique prefix "
            //                 "to avoid issues and/or repeated reference values or assign the existing reference sequence to this operation type.")
            //         }
            //     }
            */
            return default;
        }

        protected async Task<StockPickingType> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT picking_type_id FROM picking_type_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        protected async Task<StockPickingType> PrepareGraphDataInternalAsync(object summaries)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _prepare_graph_data(self, summaries):
            // """
            // Takes in summaries of picking types, each containing the name of the data
            // series and categories to display with their corresponding stock picking counts.
            // Converts each summary into data suitable for the dashboard graph and assigns
            // that data to the corresponding picking type from `self`.
            // 
            // If all values in a graph are 0, then they are assigned the "sample" type.
            // """
            // data_category_mapping = {
            //     'total_before': {'label': _('Before'), 'type': 'past'},
            //     'total_yesterday': {'label': _('Yesterday'), 'type': 'past'},
            //     'total_today': {'label': _('Today'), 'type': 'present'},
            //     'total_day_1': {'label': _('Tomorrow'), 'type': 'future'},
            //     'total_day_2': {'label': _('The day after tomorrow'), 'type': 'future'},
            //     'total_after': {'label': _('After'), 'type': 'future'},
            // }
            // 
            // for picking_type in self:
            //     picking_type_summary = summaries.get(picking_type.id)
            //     # Graph is empty if all its "total_*" values are 0
            //     empty = all(picking_type_summary[k] == 0 for k in data_category_mapping)
            //     graph_data = [{
            //         'key': _('Sample data') if empty else picking_type_summary['data_series_name'],
            //         # Passing the picking type ID allows for a redirection after clicking
            //         'picking_type_id': None if empty else picking_type.id,
            //         'values': [
            //             dict(v, value=picking_type_summary[k], type='sample' if empty else v['type'])
            //             for k, v in data_category_mapping.items()
            //         ],
            //     }]
            //     picking_type.kanban_dashboard_graph = json.dumps(graph_data)
            */
            return default;
        }

        public async Task<StockPickingType> RedirectToBarcodeInstallationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def action_redirect_to_barcode_installation(self):
            // action = self.env["ir.actions.act_window"]._for_xml_id("base.open_module_tree")
            // action["context"] = dict(literal_eval(action["context"]), search_default_name="Barcode")
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockPickingType> RepairOverviewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: repair, FILE: stock_picking.py) ---
            // def action_repair_overview(self):
            // routing_count = self.env['stock.picking.type'].search_count([('code', '=', 'repair_operation')])
            // if routing_count == 1:
            //     return self.env['ir.actions.actions']._for_xml_id('repair.action_repair_order_tree')
            // return self.env['ir.actions.actions']._for_xml_id('repair.action_repair_picking_type_kanban')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPickingType> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _search_display_name(self, operator, value):
            // # Try to reverse the `display_name` structure
            // parts = isinstance(value, str) and value.split(': ')
            // if parts and len(parts) == 2:
            //     return ['&', ('warehouse_id.name', operator, parts[0]), ('name', operator, parts[1])]
            // return super()._search_display_name(operator, value)
            */
            return default;
        }

        protected async Task<StockPickingType> SearchIsFavoriteInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_picking.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // return [('favorite_user_ids', 'in' if (operator == '=') == value else 'not in', self.env.uid)]
            */
            return default;
        }

        protected async Task<StockPickingType> ValidateAutoBatchGroupByInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py) ---
            // def _validate_auto_batch_group_by(self):
            // group_by_keys = self._get_batch_and_wave_group_by_keys()
            // for picking_type in self:
            //     if not picking_type.auto_batch:
            //         continue
            //     if not any(picking_type[key] for key in group_by_keys):
            //         raise ValidationError(_("If the Automatic Batches feature is enabled, at least one 'Group by' option must be selected."))
            */
            return default;
        }
    }
}