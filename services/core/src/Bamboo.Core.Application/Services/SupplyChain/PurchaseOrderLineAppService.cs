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
    [Module("Purchase", Category = "SupplyChain", Depends = new[] { "account" })]
    public partial class PurchaseOrderLineAppService : GenericApplicationService<PurchaseOrderLine>, IPurchaseOrderLineAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        public PurchaseOrderLineAppService(IRepository<PurchaseOrderLine, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        public async Task<PurchaseOrderLine> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def action_add_from_catalog(self):
            // order = self.env['purchase.order'].browse(self.env.context.get('order_id'))
            // return order.with_context(child_field='order_line').action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> CheckOrderpointPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _check_orderpoint_picking_type(self):
            // warehouse_loc = self.order_id.picking_type_id.warehouse_id.view_location_id
            // dest_loc = self.move_dest_ids.location_id or self.orderpoint_id.location_id
            // if warehouse_loc and dest_loc and dest_loc.warehouse_id and not warehouse_loc.parent_path in dest_loc[0].parent_path:
            //     raise UserError(_('The warehouse of operation type (%(operation_type)s) is inconsistent with location (%(location)s) of reordering rule (%(reordering_rule)s) for product %(product)s. Change the operation type or cancel the request for quotation.',
            //                       product=self.product_id.display_name, operation_type=self.order_id.picking_type_id.display_name, location=self.orderpoint_id.location_id.display_name, reordering_rule=self.orderpoint_id.display_name))
            */
            return default;
        }

        public async Task<PurchaseOrderLine> ChooseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def action_choose(self):
            // order_lines = (self.order_id | self.order_id.alternative_po_ids).mapped('order_line')
            // order_lines = order_lines.filtered(lambda l: l.product_qty and l.product_id.id in self.product_id.ids and l.id not in self.ids)
            // if order_lines:
            //     return order_lines.action_clear_quantities()
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'title': _("Nothing to clear"),
            //         'message': _("There are no quantities to clear."),
            //         'sticky': False,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseOrderLine> ClearQuantitiesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def action_clear_quantities(self):
            // zeroed_lines = self.filtered(lambda l: l.state not in ['cancel', 'purchase'])
            // zeroed_lines.write({'product_qty': 0})
            // if len(self) > len(zeroed_lines):
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'title': _("Some not cleared"),
            //             'message': _("Some quantities were not cleared because their status is not a RFQ status."),
            //             'sticky': False,
            //         }
            //     }
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_allowed_uom_ids(self):
            // for line in self:
            //     line.allowed_uom_ids = line.product_id.uom_id | line.product_id.uom_ids | line.product_id.seller_ids.product_uom_id
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_amount(self):
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     company = line.company_id or self.env.company
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     AccountTax._round_base_lines_tax_details([base_line], company)
            //     line.price_subtotal = base_line['tax_details']['total_excluded_currency']
            //     line.price_total = base_line['tax_details']['total_included_currency']
            //     line.price_tax = line.price_total - line.price_subtotal
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAmountToInvoiceAtDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_amount_to_invoice_at_date(self):
            // for line in self:
            //     line.amount_to_invoice_at_date = (line.qty_received_at_date - line.qty_invoiced_at_date) * line.price_unit
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: purchase_order_line.py) ---
            // def _compute_analytic_distribution(self):
            // super()._compute_analytic_distribution()
            // ProjectProject = self.env['project.project']
            // for line in self:
            //     project_id = line.env.context.get('project_id')
            //     project = ProjectProject.browse(project_id) if project_id else line.order_id.project_id
            //     if line.display_type or not project:
            //         continue
            //     if line.analytic_distribution:
            //         applied_root_plans = self.env['account.analytic.account'].browse(
            //             list({int(account_id) for ids in line.analytic_distribution for account_id in ids.split(",")})
            //         ).root_plan_id
            //         if accounts_to_add := project._get_analytic_accounts().filtered(
            //                 lambda account: account.root_plan_id not in applied_root_plans
            //         ):
            //             line.analytic_distribution = {
            //                 f"{account_ids},{','.join(map(str, accounts_to_add.ids))}": percentage
            //                 for account_ids, percentage in line.analytic_distribution.items()
            //             }
            //     else:
            //         line.analytic_distribution = project._get_analytic_distribution()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_analytic_distribution(self):
            // for line in self:
            //     if not line.display_type:
            //         distribution = self.env['account.analytic.distribution.model']._get_distribution({
            //             "product_id": line.product_id.id,
            //             "product_categ_id": line.product_id.categ_id.id,
            //             "partner_id": line.order_id.partner_id.id,
            //             "partner_category_id": line.order_id.partner_id.category_id.ids,
            //             "company_id": line.company_id.id,
            //         })
            //         line.analytic_distribution = distribution or line.analytic_distribution
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeForecastedIssueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _compute_forecasted_issue(self):
            // for line in self:
            //     warehouse = line.order_id.picking_type_id.warehouse_id
            //     line.forecasted_issue = False
            //     if line.product_id:
            //         virtual_available = line.product_id.with_context(warehouse_id=warehouse.id, to_date=line.date_planned).virtual_available
            //         if line.state == 'draft':
            //             virtual_available += line.product_uom_qty
            //         if virtual_available < 0:
            //             line.forecasted_issue = True
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_parent_id(self):
            // purchase_order_lines = set(self)
            // for order, lines in self.grouped('order_id').items():
            //     if not order:
            //         lines.parent_id = False
            //         continue
            //     last_section = False
            //     last_sub = False
            //     for line in order.order_line.sorted('sequence'):
            //         if line.display_type == 'line_section':
            //             last_section = line
            //             if line in purchase_order_lines:
            //                 line.parent_id = False
            //             last_sub = False
            //         elif line.display_type == 'line_subsection':
            //             if line in purchase_order_lines:
            //                 line.parent_id = last_section
            //             last_sub = line
            //         elif line in purchase_order_lines:
            //             line.parent_id = last_sub or last_section
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceTotalCcInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _compute_price_total_cc(self):
            // for line in self:
            //     line.price_total_cc = line.price_subtotal / line.order_id.currency_rate
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitAndDatePlannedAndNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_and_date_planned_and_name(self):
            // for line in self:
            //     if not line.product_id or line.invoice_lines or not line.company_id or self.env.context.get('skip_uom_conversion') or (line.technical_price_unit != line.price_unit):
            //         continue
            //     params = line._get_select_sellers_params()
            // 
            //     if line.selected_seller_id or not line.date_planned:
            //         line.date_planned = line._get_date_planned(line.selected_seller_id).strftime(DEFAULT_SERVER_DATETIME_FORMAT)
            // 
            //     # If not seller, use the standard price. It needs a proper currency conversion.
            //     if not line.selected_seller_id:
            //         unavailable_seller = line.product_id.seller_ids.filtered(
            //             lambda s: s.partner_id == line.order_id.partner_id)
            //         if not unavailable_seller and line.price_unit and line.product_uom_id == line._origin.product_uom_id:
            //             # Avoid to modify the price unit if there is no price list for this partner and
            //             # the line has already one to avoid to override unit price set manually.
            //             continue
            //         line.discount = 0
            //         po_line_uom = line.product_uom_id or line.product_id.uom_id
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(
            //             line.product_id.uom_id._compute_price(line.product_id.standard_price, po_line_uom),
            //             line.product_id.supplier_taxes_id,
            //             line.tax_ids,
            //             line.company_id,
            //         )
            //         price_unit = line.product_id.cost_currency_id._convert(
            //             price_unit,
            //             line.currency_id,
            //             line.company_id,
            //             line.date_order or fields.Date.context_today(line),
            //             False
            //         )
            //         line.price_unit = line.technical_price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            // 
            //     elif line.selected_seller_id:
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(line.selected_seller_id.price, line.product_id.supplier_taxes_id, line.tax_ids, line.company_id) if line.selected_seller_id else 0.0
            //         price_unit = line.selected_seller_id.currency_id._convert(price_unit, line.currency_id, line.company_id, line.date_order or fields.Date.context_today(line), False)
            //         price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            //         line.price_unit = line.technical_price_unit = line.selected_seller_id.product_uom_id._compute_price(price_unit, line.product_uom_id)
            //         line.discount = line.selected_seller_id.discount or 0.0
            // 
            //     # record product names to avoid resetting custom descriptions
            //     default_names = []
            //     vendors = line.product_id._prepare_sellers(params=params)
            //     product_ctx = {'seller_id': None, 'partner_id': None, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //     default_names.append(line._get_product_purchase_description(line.product_id.with_context(product_ctx)))
            //     for vendor in vendors:
            //         product_ctx = {'seller_id': vendor.id, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //         default_names.append(line._get_product_purchase_description(line.product_id.with_context(product_ctx)))
            //     if not line.name or line.name in default_names:
            //         product_ctx = {'seller_id': line.selected_seller_id.id, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //         line.name = line._get_product_purchase_description(line.product_id.with_context(product_ctx))
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py) ---
            // def _compute_price_unit_and_date_planned_and_name(self):
            // po_lines_without_requisition = self.env['purchase.order.line']
            // for pol in self:
            //     if pol.product_id.id not in pol.order_id.requisition_id.line_ids.product_id.ids:
            //         po_lines_without_requisition |= pol
            //         continue
            // 
            //     line = None
            //     # Match the requisition line with exact UoM first, then product-only as fallback.
            //     for req_line in pol.order_id.requisition_id.line_ids:
            //         if req_line.product_id == pol.product_id:
            //             line = req_line
            //             if req_line.product_uom_id == pol.product_uom_id:
            //                 break
            // 
            //     pol.price_unit = line.product_uom_id._compute_price(line.price_unit, pol.product_uom_id)
            //     partner = pol.order_id.partner_id or pol.order_id.requisition_id.vendor_id
            //     params = {'order_id': pol.order_id}
            //     seller = pol.product_id._select_seller(
            //         partner_id=partner,
            //         quantity=pol.product_qty,
            //         date=pol.order_id.date_order and pol.order_id.date_order.date(),
            //         uom_id=line.product_uom_id,
            //         params=params)
            //     if not pol.date_planned:
            //         pol.date_planned = pol._get_date_planned(seller).strftime(DEFAULT_SERVER_DATETIME_FORMAT)
            //     product_ctx = {'seller_id': seller.id, 'lang': get_lang(pol.env, partner.lang).code}
            //     name = pol._get_product_purchase_description(pol.product_id.with_context(product_ctx))
            //     if line.product_description_variants:
            //         name += '\n' + line.product_description_variants
            //     pol.name = name
            // super(PurchaseOrderLine, po_lines_without_requisition)._compute_price_unit_and_date_planned_and_name()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitDiscountedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_discounted(self):
            // for line in self:
            //     line.price_unit_discounted = line.price_unit * (1 - line.discount / 100)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitProductUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_product_uom(self):
            // for line in self:
            //     line.price_unit_product_uom = not line.display_type and line.product_uom_id._compute_price(line.price_unit, line.product_id.uom_id)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_uom_qty(self):
            // for line in self:
            //     if line.product_id and line.product_id.uom_id != line.product_uom_id:
            //         line.product_uom_qty = line.product_uom_id._compute_quantity(line.product_qty, line.product_id.uom_id)
            //     else:
            //         line.product_uom_qty = line.product_qty
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePurchaseLineWarnMsgInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_purchase_line_warn_msg(self):
            // has_warning_group = self.env.user.has_group('purchase.group_warning_purchase')
            // for line in self:
            //     line.purchase_line_warn_msg = line.product_id.purchase_line_warn_msg if has_warning_group else ""
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyInvoicedAtDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_invoiced_at_date(self):
            // if not self._date_in_the_past():
            //     for line in self:
            //         line.qty_invoiced_at_date = line.qty_invoiced
            //     return
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced_at_date = invoiced_quantities[line]
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_invoiced(self):
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced = invoiced_quantities[line]
            // 
            //     # compute qty_to_invoice
            //     if line.order_id.state == 'purchase':
            //         if line.product_id.purchase_method == 'purchase':
            //             line.qty_to_invoice = line.product_qty - line.qty_invoiced
            //         else:
            //             line.qty_to_invoice = line.qty_received - line.qty_invoiced
            //     else:
            //         line.qty_to_invoice = 0
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedAtDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received_at_date(self):
            // if not self._date_in_the_past():
            //     for line in self:
            //         line.qty_received_at_date = line.qty_received
            //     return
            // received_quantities = self._prepare_qty_received()
            // for line in self:
            //     line.qty_received_at_date = received_quantities[line]
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received(self):
            // received_qties = self._prepare_qty_received()
            // for line in self:
            //     if not line.qty_received or line in received_qties:
            //         line.qty_received = received_qties[line]
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _compute_qty_received(self):
            // super()._compute_qty_received()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received_method(self):
            // for line in self:
            //     if line.product_id and line.product_id.type in ['consu', 'service']:
            //         line.qty_received_method = 'manual'
            //     else:
            //         line.qty_received_method = False
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _compute_qty_received_method(self):
            // super(PurchaseOrderLine, self)._compute_qty_received_method()
            // for line in self.filtered(lambda l: not l.display_type):
            //     if line.product_id.type == 'consu':
            //         line.qty_received_method = 'stock_moves'
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeSelectedSellerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_selected_seller_id(self):
            // for line in self:
            //     if line.product_id:
            //         params = line._get_select_sellers_params()
            //         seller = line.product_id._select_seller(
            //             partner_id=line.partner_id,
            //             quantity=abs(line.product_qty),
            //             date=line.order_id.date_order and line.order_id.date_order.date() or fields.Date.context_today(line),
            //             uom_id=line.product_uom_id,
            //             params=params)
            //         line.selected_seller_id = seller.id if seller else False
            //     else:
            //         line.selected_seller_id = False
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeTaxIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_tax_id(self):
            // for line in self:
            //     line = line.with_company(line.company_id)
            //     fpos = line.order_id.fiscal_position_id or line.order_id.fiscal_position_id._get_fiscal_position(line.order_id.partner_id)
            //     # filter taxes by company
            //     taxes = line.product_id.supplier_taxes_id._filter_taxes_by_company(line.company_id)
            //     line.tax_ids = fpos.map_tax(taxes)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ConvertToMiddleOfDayInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _convert_to_middle_of_day(self, date):
            // """Return a datetime which is the noon of the input date(time) according
            // to order user's time zone, convert to UTC time.
            // """
            // return self.order_id.get_order_timezone().localize(datetime.combine(date, time(12))).astimezone(UTC).replace(tzinfo=None)
            */
            return default;
        }

        public override async Task<PurchaseOrderLine> CreateAsync(PurchaseOrderLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: purchase_order_line.py) ---
            // def create(self, vals_list):
            // lines = super().create(vals_list)
            // lines._recompute_recordset(fnames=['analytic_distribution'])
            // return lines
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('display_type', self.default_get(['display_type'])['display_type']):
            //         values.update(product_id=False, price_unit=0, product_uom_qty=0, product_uom_id=False, date_planned=False)
            //     else:
            //         values.update(self._prepare_add_missing_fields(values))
            //     if values.get('price_unit') and not values.get('technical_price_unit'):
            //         values['technical_price_unit'] = values['price_unit']
            // 
            // lines = super().create(vals_list)
            // for line in lines:
            //     if line.product_id and line.order_id.state == 'purchase':
            //         msg = _("Extra line with %s ", line.product_id.display_name)
            //         line.order_id.message_post(body=msg)
            // return lines
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def create(self, vals_list):
            // lines = super().create(vals_list)
            // lines.filtered(lambda l: l.order_id.state == 'purchase')._create_or_update_picking()
            // return lines
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PurchaseOrderLine> CreateOrUpdatePickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _create_or_update_picking(self):
            // for line in self:
            //     if line.product_id and line.product_id.type == 'consu':
            //         rounding = line.product_uom_id.rounding
            //         if float_compare(line.product_qty, line.qty_invoiced, precision_rounding=rounding) < 0 and line.invoice_lines:
            //             # If the quantity is now below the invoiced quantity, create an activity on the vendor bill
            //             # inviting the user to create a refund.
            //             line.invoice_lines[0].move_id.activity_schedule(
            //                 'mail.mail_activity_data_warning',
            //                 note=_('The quantities on your purchase order indicate less than billed. You should ask for a refund.'),
            //                 user_id=self.env.uid,
            //             )
            // 
            //         # If the user increased quantity of existing line or created a new line
            //         # Give priority to the pickings related to the line
            //         moves_to_assign = line.order_id.picking_ids.move_ids.filtered(lambda m: not m.purchase_line_id and line.product_id == m.product_id)
            //         moves_to_assign.purchase_line_id = line.id
            //         line_pickings = line.move_ids.picking_id.filtered(lambda p: p.state not in ('done', 'cancel') and p.location_dest_id.usage in ('internal', 'transit', 'customer'))
            //         if line_pickings:
            //             picking = line_pickings[0]
            //         else:
            //             pickings = line.order_id.picking_ids.filtered(lambda x: x.state not in ('done', 'cancel') and x.location_dest_id.usage in ('internal', 'transit', 'customer'))
            //             picking = pickings and pickings[0] or False
            //         if not picking:
            //             if not line.product_qty > line.qty_received:
            //                 continue
            //             res = line.order_id._prepare_picking()
            //             picking = self.env['stock.picking'].create(res)
            // 
            //         moves = line._create_stock_moves(picking)
            //         moves._action_confirm()._action_assign()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> CreateStockMovesInternalAsync(object picking)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _create_stock_moves(self, picking):
            // values = []
            // for line in self.filtered(lambda l: not l.display_type):
            //     for val in line._prepare_stock_moves(picking):
            //         values.append(val)
            // 
            // return self.env['stock.move'].create(values)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> DateInThePastInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _date_in_the_past(self):
            // if not 'accrual_entry_date' in self.env.context:
            //     return False
            // accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            // return accrual_date < fields.Date.today()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> FindCandidateInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_id, object name, object origin, Guid company_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _find_candidate(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values):
            // """ Return the record in self where the procument with values passed as
            // args can be merged. If it returns an empty record then a new line will
            // be created.
            // """
            // description_picking = ''
            // if values.get('product_description_variants'):
            //     description_picking = values['product_description_variants']
            // lines = self.filtered(
            //     lambda l: l.propagate_cancel == values['propagate_cancel']
            //     and (l.orderpoint_id in [values['orderpoint_id'], False] if values['orderpoint_id'] and not values['move_dest_ids'] else True)
            //     and (l.product_uom_id == product_uom if values.get('force_uom') else True)
            // )
            // 
            // # In case 'product_description_variants' is in the values, we also filter on the PO line
            // # name. This way, we can merge lines with the same description. To do so, we need the
            // # product name in the context of the PO partner.
            // if lines and values.get('product_description_variants'):
            //     partner = self.mapped('order_id.partner_id')[:1]
            //     product_lang = product_id.with_context(
            //         lang=partner.lang,
            //         partner_id=partner.id,
            //     )
            //     name = product_lang.display_name
            //     if product_lang.description_purchase:
            //         name += '\n' + product_lang.description_purchase
            //     lines = lines.filtered(lambda l: (l.name == name + '\n' + description_picking) or (values.get('product_description_variants') in (product_lang.name, product_id.with_user(SUPERUSER_ID).name) and l.name == name))
            // return lines and lines.sorted(lambda l: l.orderpoint_id)[0] or self.env['purchase.order.line']
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _find_candidate(self, product_id, product_qty, product_uom, location_id, name, origin, company_id, values):
            // # if this is defined, this is a dropshipping line, so no
            // # this is to correctly map delivered quantities to the so lines
            // if not values.get('move_dest_ids') and values.get('sale_line_id'):
            //     lines = self.filtered(lambda po_line: po_line.sale_line_id.id == values['sale_line_id'])
            //     return super(PurchaseOrderLine, lines)._find_candidate(product_id, product_qty, product_uom, location_id, name, origin, company_id, values)
            // return super()._find_candidate(product_id, product_qty, product_uom, location_id, name, origin, company_id, values)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetDatePlannedInternalAsync(object seller, object po)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_date_planned(self, seller, po=False):
            // """Return the datetime value to use as Schedule Date (``date_planned``) for
            //    PO Lines that correspond to the given product.seller_ids,
            //    when ordered at `date_order_str`.
            // 
            //    :param Model seller: used to fetch the delivery delay (if no seller
            //                         is provided, the delay is 0)
            //    :param Model po: purchase.order, necessary only if the PO line is
            //                     not yet attached to a PO.
            //    :rtype: datetime
            //    :return: desired Schedule Date for the PO line
            // """
            // date_order = po.date_order if po else self.order_id.date_order
            // if date_order:
            //     return date_order + relativedelta(days=seller.delay if seller else 0)
            // else:
            //     return datetime.today() + relativedelta(days=seller.delay if seller else 0)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetGrossPriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_gross_price_unit(self):
            // self.ensure_one()
            // price_unit = self.price_unit
            // if self.discount:
            //     price_unit = price_unit * (1 - self.discount / 100)
            // if self.tax_ids:
            //     qty = self.product_qty or 1
            //     price_unit = self.tax_ids.compute_all(
            //         price_unit,
            //         currency=self.order_id.currency_id,
            //         quantity=qty,
            //         rounding_method='round_globally',
            //     )['total_void']
            //     price_unit = price_unit / qty
            // if self.product_uom_id.id != self.product_id.uom_id.id:
            //     price_unit *= self.product_id.uom_id.factor / self.product_uom_id.factor
            // return price_unit
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetInvoiceLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_invoice_lines(self):
            // self.ensure_one()
            // if self.env.context.get('accrual_entry_date'):
            //     accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            //     return self.invoice_lines.filtered(
            //         lambda l: l.move_id.invoice_date and l.move_id.invoice_date <= accrual_date
            //     )
            // else:
            //     return self.invoice_lines
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetMoveDestsInitialDemandInternalAsync(object move_dests)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _get_move_dests_initial_demand(self, move_dests):
            // kit_bom = self.env['mrp.bom']._bom_find(self.product_id, bom_type='phantom')[self.product_id]
            // if kit_bom:
            //     filters = {'incoming_moves': lambda m: True, 'outgoing_moves': lambda m: False}
            //     return move_dests._compute_kit_quantities(self.product_id, self.product_qty, kit_bom, filters)
            // return super()._get_move_dests_initial_demand(move_dests)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _get_move_dests_initial_demand(self, move_dests):
            // return self.product_id.uom_id._compute_quantity(
            //     sum(move_dests.filtered(lambda m: m.state != 'cancel' and m.location_dest_id.usage != 'supplier').mapped('product_qty')),
            //     self.product_uom_id, rounding_method='HALF-UP')
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetOutgoingIncomingMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _get_outgoing_incoming_moves(self):
            // outgoing_moves = self.env['stock.move']
            // incoming_moves = self.env['stock.move']
            // 
            // for move in self.move_ids.filtered(lambda r: r.state != 'cancel' and r.location_dest_usage != 'inventory' and self.product_id == r.product_id):
            //     if move._is_purchase_return() and (move.to_refund or not move.origin_returned_move_id):
            //         outgoing_moves |= move
            //     elif move.location_dest_id.usage != "supplier":
            //         if not move.origin_returned_move_id or (move.origin_returned_move_id and move.to_refund):
            //             incoming_moves |= move
            // 
            // return outgoing_moves, incoming_moves
            */
            return default;
        }

        public async Task<PurchaseOrderLine> GetParentSectionLineAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def get_parent_section_line(self):
            // if not self.display_type and self.parent_id.display_type == 'line_subsection':
            //     return self.parent_id.parent_id
            // 
            // return self.parent_id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> GetPoLineMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _get_po_line_moves(self):
            // self.ensure_one()
            // moves = self.move_ids.filtered(lambda m: m.product_id == self.product_id)
            // if self.env.context.get('accrual_entry_date'):
            //     accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            //     moves = moves.filtered(lambda r: fields.Date.context_today(r, r.date) <= accrual_date)
            // return moves
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetProductCatalogLinesDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_product_catalog_lines_data(self, **kwargs):
            // """ Return information about purchase order lines in `self`.
            // 
            // If `self` is empty, this method returns only the default value(s) needed for the product
            // catalog. In this case, the quantity that equals 0.
            // 
            // Otherwise, it returns a quantity and a price based on the product of the POL(s) and whether
            // the product is read-only or not.
            // 
            // A product is considered read-only if the order is considered read-only (see
            // ``PurchaseOrder._is_readonly`` for more details) or if `self` contains multiple records.
            // 
            // Note: This method cannot be called with multiple records that have different products linked.
            // 
            // :raise odoo.exceptions.ValueError: ``len(self.product_id) != 1``
            // :rtype: dict
            // :return: A dict with the following structure:
            //     {
            //         'quantity': float,
            //         'price': float,
            //         'readOnly': bool,
            //         'uomDisplayName': String,
            //         'packaging': dict,
            //         'warning': String,
            //     }
            // """
            // if len(self) == 1:
            //     catalog_info = self.order_id._get_product_price_and_data(self.product_id)
            //     catalog_info.update(
            //         quantity=self.product_qty,
            //         price=self.price_unit * (1 - self.discount / 100),
            //         readOnly=self.order_id._is_readonly(),
            //     )
            //     if self.product_id.uom_id != self.product_uom_id:
            //         catalog_info['uomDisplayName'] = self.product_uom_id.display_name
            //     return catalog_info
            // elif self:
            //     self.product_id.ensure_one()
            //     order_line = self[0]
            //     catalog_info = order_line.order_id._get_product_price_and_data(order_line.product_id)
            //     catalog_info['quantity'] = sum(self.mapped(
            //         lambda line: line.product_uom_id._compute_quantity(
            //             qty=line.product_qty,
            //             to_unit=line.product_id.uom_id,
            //     )))
            //     catalog_info['readOnly'] = True
            //     return catalog_info
            // return {'quantity': 0}
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetProductPurchaseDescriptionInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_product_purchase_description(self, product_lang):
            // self.ensure_one()
            // name = product_lang.display_name
            // if product_lang.description_purchase:
            //     name += '\n' + product_lang.description_purchase
            // 
            // return name
            --- ODOO METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py) ---
            // def _get_product_purchase_description(self, product):
            // name = super(PurchaseOrderLine, self)._get_product_purchase_description(product)
            // for no_variant_attribute_value in self.product_no_variant_attribute_value_ids:
            //     name += "\n" + no_variant_attribute_value.attribute_id.name + ': ' + no_variant_attribute_value.name
            // 
            // return name
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetQtyProcurementInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _get_qty_procurement(self):
            // self.ensure_one()
            // # Specific case when we change the qty on a PO for a kit product.
            // # We don't try to be too smart and keep a simple approach: we compare the quantity before
            // # and after update, and return the difference. We don't take into account what was already
            // # sent, or any other exceptional case.
            // bom = self.env['mrp.bom'].sudo()._bom_find(self.product_id, bom_type='phantom')[self.product_id]
            // if bom and 'previous_product_qty' in self.env.context:
            //     return self.env.context['previous_product_qty'].get(self.id, 0.0)
            // return super()._get_qty_procurement()
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _get_qty_procurement(self):
            // self.ensure_one()
            // qty = 0.0
            // outgoing_moves, incoming_moves = self._get_outgoing_incoming_moves()
            // for move in outgoing_moves:
            //     qty_to_compute = move.quantity if move.state == 'done' else move.product_uom_qty
            //     qty -= move.product_uom._compute_quantity(qty_to_compute, self.product_uom_id, rounding_method='HALF-UP')
            // for move in incoming_moves:
            //     qty_to_compute = move.quantity if move.state == 'done' else move.product_uom_qty
            //     qty += move.product_uom._compute_quantity(qty_to_compute, self.product_uom_id, rounding_method='HALF-UP')
            // return qty
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetSaleOrderLineProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _get_sale_order_line_product(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _get_sale_order_line_product(self):
            // return self.sale_line_id.product_id
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetSelectSellersParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_select_sellers_params(self):
            // self.ensure_one()
            // return {
            //     "order_id": self.order_id,
            //     "force_uom": True,
            // }
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetStockMovePriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _get_stock_move_price_unit(self):
            // self.ensure_one()
            // order = self.order_id
            // price_unit = self.price_unit_discounted
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // if self.tax_ids:
            //     qty = self.product_qty or 1
            //     price_unit = self.tax_ids.compute_all(
            //         price_unit,
            //         currency=self.order_id.currency_id,
            //         quantity=qty,
            //         product=self.product_id,
            //         partner=self.order_id.partner_id,
            //         rounding_method="round_globally",
            //     )['total_void']
            //     price_unit = price_unit / qty
            // if self.product_uom_id.id != self.product_id.uom_id.id:
            //     price_unit /= self.product_uom_id.factor
            //     price_unit *= self.product_id.uom_id.factor
            // if order.currency_id != order.company_id.currency_id:
            //     conversion_date = self.env.context.get('conversion_date', self.date_order) or fields.Date.today()
            //     price_unit = order.currency_id._convert(
            //         price_unit, order.company_id.currency_id, self.company_id, conversion_date, round=False)
            // return float_round(price_unit, precision_digits=price_unit_prec)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetUpstreamDocumentsAndResponsiblesInternalAsync(object visited)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _get_upstream_documents_and_responsibles(self, visited):
            // return [(self.order_id, self.order_id.user_id, visited)]
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> InverseQtyReceivedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _inverse_qty_received(self):
            // """ When writing on qty_received, if the value should be modify manually (`qty_received_method` = 'manual' only),
            //     then we put the value in `qty_received_manual`. Otherwise, `qty_received_manual` should be False since the
            //     received qty is automatically compute by other mecanisms.
            // """
            // for line in self:
            //     if line.qty_received_method == 'manual':
            //         line.qty_received_manual = line.qty_received
            //     else:
            //         line.qty_received_manual = 0.0
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> IsDropshippedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py) ---
            // def _is_dropshipped(self):
            // return self.order_id._is_dropshipped()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> MergePoLineInternalAsync(object rfq_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _merge_po_line(self, rfq_line):
            // self.product_qty += rfq_line.product_qty
            // self.price_unit = min(self.price_unit, rfq_line.price_unit)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _merge_po_line(self, rfq_line):
            // super()._merge_po_line(rfq_line)
            // self.move_dest_ids += rfq_line.move_dest_ids
            */
            return default;
        }

        public async Task<PurchaseOrderLine> OnchangeProductIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def onchange_product_id(self):
            // # TODO: Remove when onchanges are replaced with computes
            // if not self.product_id or (self.env.context.get('origin_po_id') and self.product_qty):
            //     return
            // 
            // # Reset date, price and quantity since _onchange_quantity will provide default values
            // self.price_unit = self.product_qty = self.technical_price_unit = 0.0
            // 
            // self._product_id_change()
            // 
            // self._suggest_quantity()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> OndeleteStockMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _ondelete_stock_moves(self):
            // modified_fields = ['qty_received_manual', 'qty_received_method']
            // self.flush_recordset(fnames=['qty_received', *modified_fields])
            // self.invalidate_recordset(fnames=modified_fields, flush=False)
            // query = f'''
            //     UPDATE {self._table}
            //     SET qty_received_manual = qty_received, qty_received_method = 'manual'
            //     WHERE id IN %(ids)s
            // '''
            // self.env.cr.execute(query, {'ids': self._ids or (None,)})
            // self.modified(modified_fields)
            */
            return default;
        }

        public async Task<PurchaseOrderLine> OpenOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def action_open_order(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'purchase.order',
            //     'res_id': self.order_id.id,
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> PrepareAccountMoveLineInternalAsync(object move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_account_move_line(self, move=False):
            // self.ensure_one()
            // aml_currency = move and move.currency_id or self.currency_id
            // date = move and move.date or fields.Date.today()
            // 
            // res = {
            //     'display_type': self.display_type or 'product',
            //     'name': self.env['account.move.line']._get_journal_items_full_name(self.name, self.product_id.display_name),
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom_id.id,
            //     'quantity': -self.qty_to_invoice if move and move.move_type == 'in_refund' else self.qty_to_invoice,
            //     'discount': self.discount,
            //     'price_unit': self.currency_id._convert(self.price_unit, aml_currency, self.company_id, date, round=False),
            //     'tax_ids': [(6, 0, self.tax_ids.ids)],
            //     'purchase_line_id': self.id,
            //     'is_downpayment': self.is_downpayment,
            // }
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _prepare_account_move_line(self, move=False):
            // res = super()._prepare_account_move_line(move=move)
            // if 'balance' not in res:
            //     total_wo_tax = self.tax_ids.with_context(round=False, round_base=False).compute_all(
            //         self.price_unit_discounted,
            //         currency=self.order_id.currency_id,
            //         quantity=self.qty_to_invoice,
            //         product=self.product_id
            //     )['total_excluded']
            //     res['balance'] = self.currency_id._convert(
            //         total_wo_tax,
            //         self.company_id.currency_id,
            //         round=False,
            //     )
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: purchase.py) ---
            // def _prepare_account_move_line(self, move=False):
            // res = super()._prepare_account_move_line(move)
            // res.update({'is_landed_costs_line': self.product_id.landed_cost_ok})
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareAddMissingFieldsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_add_missing_fields(self, values):
            // """ Deduce missing required fields from the onchange """
            // res = {}
            // onchange_fields = ['name', 'price_unit', 'product_qty', 'product_uom_id', 'tax_ids', 'date_planned']
            // if values.get('order_id') and values.get('product_id') and any(f not in values for f in onchange_fields):
            //     line = self.new(values)
            //     line.onchange_product_id()
            //     for field in onchange_fields:
            //         if field not in values:
            //             res[field] = line._fields[field].convert_to_write(line[field], line)
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self):
            // """ Convert the current record to a dictionary in order to use the generic taxes computation method
            // defined on account.tax.
            // 
            // :return: A python dictionary.
            // """
            // self.ensure_one()
            // company = self.order_id.company_id or self.env.company
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     tax_ids=self.tax_ids,
            //     quantity=self.product_qty,
            //     partner_id=self.order_id.partner_id,
            //     currency_id=self.order_id.currency_id or company.currency_id,
            //     rate=self.order_id.currency_rate,
            //     name=self.name,
            // )
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PreparePurchaseOrderLineFromProcurementInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values, object po)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _prepare_purchase_order_line_from_procurement(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, po):
            // line_description = ''
            // if values.get('product_description_variants'):
            //     line_description = values['product_description_variants']
            // supplier = values.get('supplier')
            // if not values.get('force_uom') and supplier.product_uom_id != product_uom:
            //     product_qty = product_uom._compute_quantity(product_qty, supplier.product_uom_id)
            //     product_uom = supplier.product_uom_id
            // res = self.with_context(procurement_values=values)._prepare_purchase_order_line(product_id, product_qty, product_uom, company_id, supplier.partner_id, po)
            // # We need to keep the vendor name set in _prepare_purchase_order_line. To avoid redundancy
            // # in the line name, we add the line_description only if different from the product name.
            // # This way, we shoud not lose any valuable information.
            // if line_description and product_id.name != line_description:
            //     res['name'] = (res['name'] + '\n' + line_description).strip()
            // res['date_planned'] = values.get('date_planned')
            // # The date must be day before or equal at the supplier target day
            // if po.partner_id.group_rfq == 'week' and po.partner_id.group_on != 'default':
            //     delta_days = (7 + int(po.partner_id.group_on) - res['date_planned'].isoweekday()) % 7
            //     res['date_planned'] = fields.Datetime.to_datetime(res['date_planned']) + relativedelta(days=delta_days)
            //     if not po.date_planned or po.date_planned >= res['date_planned']:
            //         # date_order was computed based on procurement date_planned. If the PO date_planned is
            //         # shifted, we also need to shift the date_order.
            //         po.date_order = fields.Datetime.to_datetime(po.date_order) + relativedelta(days=delta_days)
            // res['move_dest_ids'] = [(4, x.id) for x in values.get('move_dest_ids', [])]
            // res['location_final_id'] = location_dest_id.id
            // res['orderpoint_id'] = values.get('orderpoint_id', False) and values.get('orderpoint_id').id
            // res['propagate_cancel'] = values.get('propagate_cancel')
            // res['product_description_variants'] = values.get('product_description_variants')
            // res['product_no_variant_attribute_value_ids'] = values.get('never_product_template_attribute_value_ids')
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_purchase_order_line_from_procurement(self, product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, po):
            // res = super()._prepare_purchase_order_line_from_procurement(product_id, product_qty, product_uom, location_dest_id, name, origin, company_id, values, po)
            // # only set the sale line id in case of a dropshipping
            // if not values.get('move_dest_ids'):
            //     res['sale_line_id'] = values.get('sale_line_id', False)
            // return res
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PreparePurchaseOrderLineInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, Guid partner_id, object po)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_purchase_order_line(self, product_id, product_qty, product_uom, company_id, partner_id, po):
            // values = self.env.context.get('procurement_values', {})
            // uom_po_qty = product_uom._compute_quantity(product_qty, product_id.uom_id, rounding_method='HALF-UP')
            // # _select_seller is used if the supplier have different price depending
            // # the quantities ordered.
            // today = fields.Date.today()
            // seller = product_id.with_company(company_id)._select_seller(
            //     partner_id=partner_id,
            //     quantity=product_qty if values.get('force_uom') else uom_po_qty,
            //     date=po.date_order and max(po.date_order.date(), today) or today,
            //     uom_id=product_uom if values.get('force_uom') else product_id.uom_id,
            //     params={'force_uom': values.get('force_uom')}
            // )
            // if seller and (seller.product_uom_id or seller.product_tmpl_id.uom_id) != product_uom:
            //     uom_po_qty = product_id.uom_id._compute_quantity(uom_po_qty, seller.product_uom_id, rounding_method='HALF-UP')
            // 
            // tax_domain = self.env['account.tax']._check_company_domain(company_id)
            // product_taxes = product_id.supplier_taxes_id.filtered_domain(tax_domain)
            // taxes = po.fiscal_position_id.map_tax(product_taxes)
            // 
            // if seller:
            //     price_unit = (seller.product_uom_id._compute_price(seller.price, product_uom) if product_uom else seller.price)
            //     price_unit = self.env['account.tax']._fix_tax_included_price_company(
            //     price_unit, product_taxes, taxes, company_id)
            // else:
            //     price_unit = 0
            // if price_unit and seller and po.currency_id and seller.currency_id != po.currency_id:
            //     price_unit = seller.currency_id._convert(
            //         price_unit, po.currency_id, po.company_id, po.date_order or fields.Date.today())
            // 
            // product_lang = product_id.with_prefetch().with_context(
            //     lang=partner_id.lang,
            //     partner_id=partner_id.id,
            // )
            // name = product_lang.with_context(seller_id=seller.id).display_name
            // if product_lang.description_purchase:
            //     name += '\n' + product_lang.description_purchase
            // 
            // date_planned = self.order_id.date_planned or self._get_date_planned(seller, po=po)
            // discount = seller.discount or 0.0
            // 
            // return {
            //     'name': name,
            //     'product_qty': product_qty if product_uom else uom_po_qty,
            //     'product_id': product_id.id,
            //     'product_uom_id': product_uom.id or seller.product_uom_id.id,
            //     'price_unit': price_unit,
            //     'date_planned': date_planned,
            //     'tax_ids': [(6, 0, taxes.ids)],
            //     'order_id': po.id,
            //     'discount': discount,
            // }
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareQtyInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_qty_invoiced(self):
            // # Compute qty_invoiced
            // invoiced_qties = defaultdict(float)
            // for line in self:
            //     for inv_line in line._get_invoice_lines():
            //         if inv_line.move_id.state not in ['cancel'] or inv_line.move_id.payment_state == 'invoicing_legacy':
            //             if inv_line.move_id.move_type == 'in_invoice':
            //                 invoiced_qties[line] += inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom_id)
            //             elif inv_line.move_id.move_type == 'in_refund':
            //                 invoiced_qties[line] -= inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom_id)
            // return invoiced_qties
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareQtyReceivedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_qty_received(self):
            // received_qties = defaultdict(float)
            // for line in self:
            //     if line.qty_received_method == 'manual':
            //         received_qties[line] = line.qty_received_manual or 0.0
            //     else:
            //         received_qties[line] = 0.0
            // return received_qties
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _prepare_qty_received(self):
            // kit_invoiced_qties = defaultdict(float)
            // kit_lines = self.env['purchase.order.line']
            // lines_stock = self.filtered(lambda l: l.qty_received_method == 'stock_moves' and l.move_ids and l.state != 'cancel')
            // product_by_company = defaultdict(OrderedSet)
            // for line in lines_stock:
            //     product_by_company[line.company_id].add(line.product_id.id)
            // kits_by_company = {
            //     company: self.env['mrp.bom']._bom_find(self.env['product.product'].browse(product_ids), company_id=company.id, bom_type='phantom')
            //     for company, product_ids in product_by_company.items()
            // }
            // for line in lines_stock:
            //     kit_bom = kits_by_company[line.company_id].get(line.product_id)
            //     if kit_bom:
            //         moves = line.move_ids.filtered(lambda m: m.state == 'done' and m.location_dest_usage != 'inventory')
            //         order_qty = line.product_uom_id._compute_quantity(line.product_uom_qty, kit_bom.product_uom_id)
            //         filters = {
            //             'incoming_moves': lambda m:
            //                 m._is_incoming() and
            //                 (not m.origin_returned_move_id or (m.origin_returned_move_id and m.to_refund)),
            //             'outgoing_moves': lambda m:
            //                 m._is_outgoing() and m.to_refund,
            //         }
            //         kit_invoiced_qties[line] = moves._compute_kit_quantities(line.product_id, order_qty, kit_bom, filters)
            //         kit_lines += line
            // invoiced_qties = super(PurchaseOrderLine, self - kit_lines)._prepare_qty_received()
            // invoiced_qties.update(kit_invoiced_qties)
            // return invoiced_qties
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _prepare_qty_received(self):
            // from_stock_lines = self.filtered(lambda order_line: order_line.qty_received_method == 'stock_moves')
            // received_qties = super(PurchaseOrderLine, self - from_stock_lines)._prepare_qty_received()
            // for line in self:
            //     if line.qty_received_method == 'stock_moves':
            //         total = 0.0
            //         # In case of a BOM in kit, the products delivered do not correspond to the products in
            //         # the PO. Therefore, we can skip them since they will be handled later on.
            //         for move in line._get_po_line_moves():
            //             if move.state == 'done':
            //                 if move._is_purchase_return():
            //                     if not move.origin_returned_move_id or move.to_refund:
            //                         total -= move.product_uom._compute_quantity(move.quantity, line.product_uom_id, rounding_method='HALF-UP')
            //                 elif move.origin_returned_move_id and move.origin_returned_move_id._is_dropshipped() and not move._is_dropshipped_returned():
            //                     # Edge case: the dropship is returned to the stock, no to the supplier.
            //                     # In this case, the received quantity on the PO is set although we didn't
            //                     # receive the product physically in our stock. To avoid counting the
            //                     # quantity twice, we do nothing.
            //                     pass
            //                 elif move.origin_returned_move_id and move.origin_returned_move_id._is_purchase_return() and not move.to_refund:
            //                     pass
            //                 else:
            //                     total += move.product_uom._compute_quantity(move.quantity, line.product_uom_id, rounding_method='HALF-UP')
            //         line._track_qty_received(total)
            //         received_qties[line] = total
            // return received_qties
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareStockMoveValsInternalAsync(object picking, object price_unit, object product_uom_qty, object product_uom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _prepare_stock_move_vals(self, picking, price_unit, product_uom_qty, product_uom):
            // self.ensure_one()
            // self._check_orderpoint_picking_type()
            // product = self.product_id.with_context(lang=self.order_id.dest_address_id.lang or self.env.user.lang)
            // location_dest = self.env['stock.location'].browse(self.order_id._get_destination_location())
            // location_final = self.location_final_id or self.order_id._get_final_location_record()
            // if location_final and location_final._child_of(location_dest):
            //     location_dest = location_final
            // date_planned = self.date_planned or self.order_id.date_planned
            // return {
            //     'product_id': self.product_id.id,
            //     'date': date_planned,
            //     'date_deadline': date_planned,
            //     'location_id': self.order_id.partner_id.property_stock_supplier.id,
            //     'location_dest_id': location_dest.id,
            //     'location_final_id': location_final.id,
            //     'picking_id': picking.id,
            //     'partner_id': self.order_id.dest_address_id.id,
            //     'move_dest_ids': [(4, x) for x in self.move_dest_ids.ids],
            //     'state': 'draft',
            //     'purchase_line_id': self.id,
            //     'company_id': self.order_id.company_id.id,
            //     'price_unit': price_unit,
            //     'picking_type_id': self.order_id.picking_type_id.id,
            //     'reference_ids': [Command.set(self.order_id.reference_ids.ids)],
            //     'origin': self.order_id.name,
            //     'propagate_cancel': self.propagate_cancel,
            //     'warehouse_id': self.order_id.picking_type_id.warehouse_id.id,
            //     'product_uom_qty': product_uom_qty,
            //     'product_uom': product_uom.id,
            //     'sequence': self.sequence,
            // }
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareStockMovesInternalAsync(object picking)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py) ---
            // def _prepare_stock_moves(self, picking):
            // res = super()._prepare_stock_moves(picking)
            // if len(self.order_id.reference_ids.move_ids.production_group_id) == 1:
            //     for re in res:
            //         re['production_group_id'] = self.order_id.reference_ids.move_ids.production_group_id.id
            // sale_line_product = self._get_sale_order_line_product()
            // if sale_line_product:
            //     bom = self.env['mrp.bom']._bom_find(self.env['product.product'].browse(sale_line_product.id), company_id=picking.company_id.id, bom_type='phantom')
            //     # Was a kit sold?
            //     bom_kit = bom.get(sale_line_product)
            //     if bom_kit:
            //         _dummy, bom_sub_lines = bom_kit.explode(sale_line_product, self.sale_line_id.product_uom_qty)
            //         bom_kit_component = {line['product_id'].id: line.id for line, _ in bom_sub_lines}
            //         # Find the sml for the kit component
            //         for vals in res:
            //             if vals['product_id'] in bom_kit_component:
            //                 vals['bom_line_id'] = bom_kit_component[vals['product_id']]
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _prepare_stock_moves(self, picking):
            // """ Prepare the stock moves data for one order line. This function returns a list of
            // dictionary ready to be used in stock.move's create()
            // """
            // self.ensure_one()
            // res = []
            // if self.product_id.type != 'consu':
            //     return res
            // 
            // price_unit = self._get_stock_move_price_unit()
            // qty = self._get_qty_procurement()
            // 
            // move_dests = self.move_dest_ids or self.move_ids.move_dest_ids
            // move_dests = move_dests.filtered(lambda m: m.state != 'cancel' and not m._is_purchase_return())
            // 
            // if not move_dests:
            //     qty_to_attach = 0
            //     qty_to_push = self.product_qty - qty
            // else:
            //     move_dests_initial_demand = self._get_move_dests_initial_demand(move_dests)
            //     qty_to_attach = move_dests_initial_demand - qty
            //     qty_to_push = self.product_qty - move_dests_initial_demand
            // 
            // if self.product_uom_id.compare(qty_to_attach, 0.0) > 0:
            //     product_uom_qty, product_uom = self.product_uom_id._adjust_uom_quantities(qty_to_attach, self.product_id.uom_id)
            //     res.append(self._prepare_stock_move_vals(picking, price_unit, product_uom_qty, product_uom))
            // if not self.product_uom_id.is_zero(qty_to_push):
            //     product_uom_qty, product_uom = self.product_uom_id._adjust_uom_quantities(qty_to_push, self.product_id.uom_id)
            //     extra_move_vals = self._prepare_stock_move_vals(picking, price_unit, product_uom_qty, product_uom)
            //     extra_move_vals['move_dest_ids'] = False  # don't attach
            //     res.append(extra_move_vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py) ---
            // def _prepare_stock_moves(self, picking):
            // res = super()._prepare_stock_moves(picking)
            // for re in res:
            //     if self.sale_line_id and re.get('location_final_id'):
            //         final_loc = self.env['stock.location'].browse(re.get('location_final_id'))
            //         if final_loc.usage == 'customer' or final_loc.usage == 'transit':
            //             re['sale_line_id'] = self.sale_line_id.id
            //     if self.sale_line_id.route_ids:
            //         re['route_ids'] = [Command.link(route_id) for route_id in self.sale_line_id.route_ids.ids]
            // return res
            */
            return default;
        }

        public async Task<PurchaseOrderLine> ProductForecastReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def action_product_forecast_report(self):
            // self.ensure_one()
            // action = self.product_id.action_product_forecast_report()
            // action['context'] = {
            //     'active_id': self.product_id.id,
            //     'active_model': 'product.product',
            //     'move_to_match_ids': self.move_ids.filtered(lambda m: m.product_id == self.product_id).ids,
            //     'purchase_line_to_match_id': self.id,
            // }
            // warehouse = self.order_id.picking_type_id.warehouse_id
            // if warehouse:
            //     action['context']['warehouse_id'] = warehouse.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseOrderLine> ProductIdChangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _product_id_change(self):
            // if not self.product_id:
            //     return
            // 
            // self.product_uom_id = self.product_id.uom_id
            // product_lang = self.product_id.with_context(
            //     lang=get_lang(self.env, self.partner_id.lang).code,
            //     partner_id=None,
            //     company_id=self.company_id.id,
            // )
            // self.name = self._get_product_purchase_description(product_lang)
            // 
            // self._compute_tax_id()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> SuggestQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _suggest_quantity(self):
            // ''' Suggest a minimal quantity based on the seller
            // '''
            // if not self.product_id:
            //     return
            // date = self.order_id.date_order and self.order_id.date_order.date() or fields.Date.context_today(self)
            // seller_min_qty = self.product_id.seller_ids\
            //     .filtered(lambda r: r.partner_id == self.order_id.partner_id and
            //               (not r.product_id or r.product_id == self.product_id) and
            //               (not r.date_start or r.date_start <= date) and
            //               (not r.date_end or r.date_end >= date))\
            //     .sorted(key=lambda r: r.min_qty)
            // if seller_min_qty:
            //     self.product_qty = seller_min_qty[0].min_qty or 1.0
            //     self.product_uom_id = seller_min_qty[0].product_uom_id
            // else:
            //     self.product_qty = 1.0
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> TrackQtyReceivedInternalAsync(object new_qty)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _track_qty_received(self, new_qty):
            // self.ensure_one()
            // # don't track anything when coming from the accrued expense entry wizard, as it is only computing fields at a past date to get relevant amounts
            // # and doesn't actually change anything to the current record
            // if  self.env.context.get('accrual_entry_date'):
            //     return
            // if new_qty != self.qty_received and self.order_id.state == 'purchase':
            //     self.order_id.message_post_with_source(
            //         'purchase.track_po_line_qty_received_template',
            //         render_values={'line': self, 'qty_received': new_qty},
            //         subtype_xmlid='mail.mt_note',
            //     )
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def unlink(self):
            // self.move_ids._action_cancel()
            // 
            // # Unlink move_dests that have other created_purchase_line_ids instead of cancelling them
            // for line in self:
            //     moves_to_unlink = line.move_dest_ids.filtered(lambda m: len(m.created_purchase_line_ids.ids) > 1)
            //     if moves_to_unlink:
            //         moves_to_unlink.created_purchase_line_ids = [Command.unlink(line.id)]
            // 
            // ppg_cancel_lines = self.filtered(lambda line: line.propagate_cancel)
            // ppg_cancel_lines.move_dest_ids._action_cancel()
            // 
            // not_ppg_cancel_lines = self.filtered(lambda line: not line.propagate_cancel)
            // not_ppg_cancel_lines.move_dest_ids.write({'procure_method': 'make_to_stock'})
            // not_ppg_cancel_lines.move_dest_ids._recompute_state()
            // 
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<PurchaseOrderLine> UnlinkExceptPurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _unlink_except_purchase(self):
            // for line in self:
            //     if line.order_id.state == 'purchase' and line.display_type not in ['line_section', 'line_subsection', 'line_note']:
            //         state_description = {state_desc[0]: state_desc[1] for state_desc in self._fields['state']._description_selection(self.env)}
            //         raise UserError(_('Cannot delete a purchase order line which is in state “%s”.', state_description.get(line.state)))
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UpdateDatePlannedInternalAsync(object updated_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _update_date_planned(self, updated_date):
            // self.date_planned = updated_date
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _update_date_planned(self, updated_date):
            // move_to_update = self.move_ids.filtered(lambda m: m.state not in ['done', 'cancel'])
            // if not self.move_ids or move_to_update:  # Only change the date if there is no move done or none
            //     super()._update_date_planned(updated_date)
            // if move_to_update:
            //     self._update_move_date_deadline(updated_date)
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UpdateMoveDateDeadlineInternalAsync(object new_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _update_move_date_deadline(self, new_date):
            // """ Updates corresponding move picking line deadline dates that are not yet completed. """
            // moves_to_update = self.move_ids.filtered(lambda m: m.state not in ('done', 'cancel'))
            // if not moves_to_update:
            //     moves_to_update = self.move_dest_ids.filtered(lambda m: m.state not in ('done', 'cancel'))
            // for move in moves_to_update:
            //     move.date_deadline = new_date
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UpdateQtyReceivedMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def _update_qty_received_method(self):
            // """Update qty_received_method for old PO before install this module."""
            // self.search(['!', ('state', '=', 'purchase')])._compute_qty_received_method()
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _validate_analytic_distribution(self):
            // for line in self:
            //     if line.display_type:
            //         continue
            //     line._validate_distribution(
            //         product=line.product_id.id,
            //         business_domain='purchase_order',
            //         company_id=line.company_id.id,
            //     )
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PurchaseOrderLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def write(self, vals):
            // values = vals
            // if 'display_type' in values and self.filtered(lambda line: line.display_type != values.get('display_type')):
            //     raise UserError(_("You cannot change the type of a purchase order line. Instead you should delete the current line and create a new line of the proper type."))
            // 
            // if 'product_qty' in values:
            //     precision = self.env['decimal.precision'].precision_get('Product Unit')
            //     for line in self:
            //         if (
            //             line.order_id.state == "purchase"
            //             and float_compare(line.product_qty, values["product_qty"], precision_digits=precision) != 0
            //         ):
            //             line.order_id.message_post_with_source(
            //                 'purchase.track_po_line_template',
            //                 render_values={'line': line, 'product_qty': values['product_qty']},
            //                 subtype_xmlid='mail.mt_note',
            //             )
            // 
            // if 'qty_received' in values:
            //     for line in self:
            //         line._track_qty_received(values['qty_received'])
            // return super().write(values)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py) ---
            // def write(self, vals):
            // values = vals
            // if values.get('date_planned'):
            //     new_date = fields.Datetime.to_datetime(values['date_planned'])
            //     self.filtered(lambda l: not l.display_type)._update_move_date_deadline(new_date)
            // lines = self.filtered(lambda l: l.order_id.state == 'purchase'
            //                                 and not l.display_type)
            // 
            // previous_product_uom_qty = {line.id: line.product_uom_qty for line in lines}
            // previous_product_qty = {line.id: line.product_qty for line in lines}
            // result = super().write(values)
            // if 'price_unit' in values:
            //     for line in lines:
            //         # Avoid updating kit components' stock.move
            //         moves = line.move_ids.filtered(lambda s: s.state not in ('cancel', 'done') and s.product_id == line.product_id)
            //         moves.write({'price_unit': line._get_stock_move_price_unit()})
            // if 'product_qty' in values:
            //     lines = lines.filtered(lambda l: l.product_uom_id.compare(previous_product_qty[l.id], l.product_qty) != 0)
            //     lines.with_context(previous_product_qty=previous_product_uom_qty)._create_or_update_picking()
            // valuation_trigger = ['price_unit', 'product_qty', 'product_uom']
            // if any(field in valuation_trigger for field in values):
            //     self.move_ids.filtered(lambda m: m.is_valued)._set_value()
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}