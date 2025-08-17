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
    [Module("StockAccount", Depends = new[] { "stock", "account" })]
    public class StockValuationLayerAppService : GenericApplicationService<StockValuationLayer>, IStockValuationLayerAppService
    {

        public StockValuationLayerAppService(IRepository<StockValuationLayer, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<StockValuationLayer> CandidateSortKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: stock_valuation_layer.py) ---
            // def _candidate_sort_key(self):
            // self.ensure_one()
            // res = super()._candidate_sort_key()
            // if self.product_id in self.env.context.get('product_unbuild_map', ()):
            //     unbuild = self.env.context['product_unbuild_map'][self.product_id]
            //     # Give priority to the SVL that produced `self.product_id`
            //     res += (self.stock_move_id.id not in unbuild.mo_id.move_finished_ids.ids,)
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _candidate_sort_key(self):
            // self.ensure_one()
            // return tuple()
            */
            return default;
        }

        protected async Task<StockValuationLayer> ChangeStandartPriceAccountingEntriesInternalAsync(object new_price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _change_standart_price_accounting_entries(self, new_price):
            // # Handle account moves.
            // product_accounts = {product.id: product.product_tmpl_id.get_product_accounts() for product in self.product_id}
            // company_id = self.env.company
            // am_vals_list = []
            // for layer in self:
            //     product = layer.product_id
            //     value = layer.value
            // 
            //     if not product.is_storable or product.valuation != 'real_time':
            //         continue
            // 
            //     # Sanity check.
            //     if not product_accounts[product.id].get('expense'):
            //         raise UserError(_('You must set a counterpart account on your product category.'))
            //     if not product_accounts[product.id].get('stock_valuation'):
            //         raise UserError(_('You don\'t have any stock valuation account defined on your product category. You must define one before processing this operation.'))
            // 
            //     if value < 0:
            //         debit_account_id = product_accounts[product.id]['expense'].id
            //         credit_account_id = product_accounts[product.id]['stock_valuation'].id
            //     else:
            //         debit_account_id = product_accounts[product.id]['stock_valuation'].id
            //         credit_account_id = product_accounts[product.id]['expense'].id
            // 
            //     name = _(
            //         '%(user)s changed cost from %(previous)s to %(new_price)s - %(record)s',
            //         user=self.env.user.name,
            //         previous=layer.lot_id.standard_price if layer.lot_id else product.standard_price,
            //         new_price=new_price,
            //         record=layer.lot_id.display_name or product.display_name
            //     )
            //     move_vals = {
            //         'journal_id': product_accounts[product.id]['stock_journal'].id,
            //         'company_id': company_id.id,
            //         'ref': product.default_code,
            //         'stock_valuation_layer_ids': [(6, None, [layer.id])],
            //         'move_type': 'entry',
            //         'line_ids': [(0, 0, {
            //             'name': name,
            //             'account_id': debit_account_id,
            //             'debit': abs(value),
            //             'credit': 0,
            //             'product_id': product.id,
            //             'quantity': 0,
            //         }), (0, 0, {
            //             'name': name,
            //             'account_id': credit_account_id,
            //             'debit': 0,
            //             'credit': abs(value),
            //             'product_id': product.id,
            //             'quantity': 0,
            //         })],
            //     }
            //     am_vals_list.append(move_vals)
            // 
            // account_moves = self.env['account.move'].sudo().create(am_vals_list)
            // if account_moves:
            //     account_moves._post()
            */
            return default;
        }

        protected async Task<StockValuationLayer> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _compute_warehouse_id(self):
            // for svl in self:
            //     if svl.stock_move_id.location_id.usage == "internal":
            //         svl.warehouse_id = svl.stock_move_id.location_id.warehouse_id.id
            //     else:
            //         svl.warehouse_id = svl.stock_move_id.location_dest_id.warehouse_id.id
            */
            return default;
        }

        protected async Task<StockValuationLayer> ConsumeAllInternalAsync(object qty_valued, object valued, object qty_to_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _consume_all(self, qty_valued, valued, qty_to_value):
            // """
            // The method consumes all svl to get the total qty/value. Then it deducts
            // the already consumed qty/value. Finally, it tries to consume the `qty_to_value`
            // The method returns the valued quantity and its valuation
            // """
            // if not self:
            //     return 0, 0
            // 
            // min_rounding = 1.0
            // qty_total = -qty_valued
            // value_total = -valued
            // new_valued_qty = 0
            // new_valuation = 0
            // 
            // for svl in self:
            //     rounding = svl.product_id.uom_id.rounding
            //     min_rounding = min(min_rounding, rounding)
            //     if float_is_zero(svl.quantity, precision_rounding=rounding):
            //         continue
            //     relevant_qty = abs(svl.quantity)
            //     returned_qty = sum([sm.product_uom._compute_quantity(sm.quantity, self.uom_id)
            //                         for sm in svl.stock_move_id.returned_move_ids if sm.state == 'done'])
            //     relevant_qty -= returned_qty
            //     if float_is_zero(relevant_qty, precision_rounding=rounding):
            //         continue
            //     qty_total += relevant_qty
            //     value_total += relevant_qty * ((svl.value + sum(svl.stock_valuation_layer_ids.mapped('value'))) / svl.quantity)
            // 
            // if float_compare(qty_total, 0, precision_rounding=min_rounding) > 0:
            //     unit_cost = value_total / qty_total
            //     new_valued_qty = min(qty_total, qty_to_value)
            //     new_valuation = unit_cost * new_valued_qty
            // 
            // return new_valued_qty, new_valuation
            */
            return default;
        }

        protected async Task<StockValuationLayer> ConsumeSpecificQtyInternalAsync(object qty_valued, object qty_to_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _consume_specific_qty(self, qty_valued, qty_to_value):
            // """
            // Iterate on the SVL to first skip the qty already valued. Then, keep
            // iterating to consume `qty_to_value` and stop
            // The method returns the valued quantity and its valuation
            // """
            // if not self:
            //     return 0, 0
            // 
            // qty_to_take_on_candidates = qty_to_value
            // tmp_value = 0  # to accumulate the value taken on the candidates
            // for candidate in self:
            //     rounding = candidate.product_id.uom_id.rounding
            //     if float_is_zero(candidate.quantity, precision_rounding=rounding):
            //         continue
            //     candidate_quantity = abs(candidate.quantity)
            //     returned_qty = sum([sm.product_uom._compute_quantity(sm.quantity, self.uom_id)
            //                         for sm in candidate.stock_move_id.returned_move_ids if sm.state == 'done'])
            //     candidate_quantity -= returned_qty
            //     if float_is_zero(candidate_quantity, precision_rounding=rounding):
            //         continue
            //     if not float_is_zero(qty_valued, precision_rounding=rounding):
            //         qty_ignored = min(qty_valued, candidate_quantity)
            //         qty_valued -= qty_ignored
            //         candidate_quantity -= qty_ignored
            //         if float_is_zero(candidate_quantity, precision_rounding=rounding):
            //             continue
            //     qty_taken_on_candidate = min(qty_to_take_on_candidates, candidate_quantity)
            // 
            //     qty_to_take_on_candidates -= qty_taken_on_candidate
            //     tmp_value += qty_taken_on_candidate * ((candidate.value + sum(candidate.stock_valuation_layer_ids.mapped('value'))) / candidate.quantity)
            //     if float_is_zero(qty_to_take_on_candidates, precision_rounding=rounding):
            //         break
            // 
            // return qty_to_value - qty_to_take_on_candidates, tmp_value
            */
            return default;
        }

        protected async Task<StockValuationLayer> GetLayerPriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_valuation_layer.py) ---
            // def _get_layer_price_unit(self):
            // """ For a subcontracted product, we want a way to get the subcontracting cost (the price on the PO)
            //     This override deducts the value of subcomponents from the layer price.
            // """
            // components_price = 0
            // production = self.stock_move_id.production_id
            // if production.subcontractor_id and production.state == 'done':
            //     # each layer has a quantity and price for each move, to get the correct component price for each move
            //     # we need to get the components used for each quantity
            //     for move in production.move_raw_ids:
            //         components_price += abs(sum(move.sudo().stock_valuation_layer_ids.mapped('value'))) / production.product_uom_qty
            // return super()._get_layer_price_unit() - components_price
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_valuation_layer.py) ---
            // def _get_layer_price_unit(self):
            // """ This function returns the value of product in a layer per unit, relative to the aml
            //     the function is designed to be overriden to add logic to price unit calculation
            // :param layer: the layer the price unit is derived from
            // """
            // return self.value / self.quantity
            */
            return default;
        }

        public async Task<StockValuationLayer> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def init(self):
            // tools.create_index(
            //     self._cr, 'stock_valuation_layer_index',
            //     self._table, ['product_id', 'remaining_qty', 'stock_move_id', 'company_id', 'create_date']
            // )
            // tools.create_index(
            //     self._cr, 'stock_valuation_company_product_index',
            //     self._table, ['product_id', 'company_id', 'id', 'value', 'quantity']
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockValuationLayer> OpenJournalEntryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def action_open_journal_entry(self):
            // self.ensure_one()
            // if not self.account_move_id:
            //     return
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'account.move',
            //     'res_id': self.account_move_id.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<StockValuationLayer> OpenReferenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def action_open_reference(self):
            // self.ensure_one()
            // if self.stock_move_id:
            //     action = self.stock_move_id.action_open_reference()
            //     if action['res_model'] != 'stock.move':
            //         return action
            // return {
            //     'res_model': self._name,
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, "form"]],
            //     'res_id': self.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockValuationLayer> SearchWarehouseIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _search_warehouse_id(self, operator, value):
            // layer_ids = self.search([
            //     '|',
            //     ('stock_move_id.location_dest_id.warehouse_id', operator, value),
            //     '&',
            //     ('stock_move_id.location_id.usage', '=', 'internal'),
            //     ('stock_move_id.location_id.warehouse_id', operator, value),
            // ]).ids
            // return [('id', 'in', layer_ids)]
            */
            return default;
        }

        protected async Task<StockValuationLayer> ShouldImpactPriceUnitReceiptValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _should_impact_price_unit_receipt_value(self):
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_valuation_layer.py) ---
            // def _should_impact_price_unit_receipt_value(self):
            // res = super()._should_impact_price_unit_receipt_value()
            // return res and not self.stock_landed_cost_id.vendor_bill_id
            */
            return default;
        }

        protected async Task<StockValuationLayer> ValidateAccountingEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _validate_accounting_entries(self):
            // am_vals = []
            // aml_to_reconcile = defaultdict(set)
            // move_ids = OrderedSet()
            // svl_move_list = defaultdict(int) 
            // for svl in self:
            //     if not svl.with_company(svl.company_id).product_id.valuation == 'real_time':
            //         continue
            //     if svl.currency_id.is_zero(svl.value):
            //         continue
            //     move = svl.stock_move_id
            //     if not move:
            //         move = svl.stock_valuation_layer_id.stock_move_id
            //     move_ids.add(move.id)
            //     svl_move_list[svl.id] = move.id
            // 
            // moves = self.env['stock.move'].browse(move_ids)
            // move_directions = moves._get_move_directions()
            // for svl in self:
            //     linked_move = moves.browse(svl_move_list[svl.id])
            //     if linked_move:
            //         am_vals += linked_move.with_context(move_directions=move_directions).with_company(svl.company_id)._account_entry_move(svl.quantity, svl.description, svl.id, svl.value)
            // 
            // if am_vals:
            //     account_moves = self.env['account.move'].sudo().create(am_vals)
            //     account_moves._post()
            // products_svl = groupby(self, lambda svl: (svl.product_id, svl.company_id.anglo_saxon_accounting))
            // for (product, anglo_saxon_accounting), svls in products_svl:
            //     svls = self.browse(svl.id for svl in svls)
            //     moves = svls.stock_move_id
            //     if anglo_saxon_accounting:
            //         moves._get_related_invoices()._stock_account_anglo_saxon_reconcile_valuation(product=product)
            //     moves = (moves | moves.origin_returned_move_id).with_prefetch(chain(moves._prefetch_ids, moves.origin_returned_move_id._prefetch_ids))
            //     for aml in moves._get_all_related_aml():
            //         if aml.reconciled or aml.move_id.state != "posted" or not aml.account_id.reconcile:
            //             continue
            //         aml_to_reconcile[(product, aml.account_id)].add(aml.id)
            // for aml_ids in aml_to_reconcile.values():
            //     self.env['account.move.line'].browse(aml_ids).reconcile()
            */
            return default;
        }

        protected async Task<StockValuationLayer> ValidateAnalyticAccountingEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def _validate_analytic_accounting_entries(self):
            // for svl in self:
            //     svl.stock_move_id._account_analytic_entry_move()
            */
            return default;
        }

        public async Task<StockValuationLayer> ValuationAtDateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py) ---
            // def action_valuation_at_date(self):
            // #  Handler called when the user clicked on the 'Valuation at Date' button.
            // #  Opens wizard to display, at choice, the products inventory or a computed
            // #  inventory at a given date.
            // context = {"pivot_measures": ["quantity", "value"]}
            // if ("default_product_id" in self.env.context):
            //     context["product_id"] = self.env.context["default_product_id"]
            // elif ("default_product_tmpl_id" in self.env.context):
            //     context["product_tmpl_id"] = self.env.context["default_product_tmpl_id"]
            // 
            // return {
            //     "res_model": "stock.quantity.history",
            //     "views": [[False, "form"]],
            //     "target": "new",
            //     "type": "ir.actions.act_window",
            //     "context": context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}