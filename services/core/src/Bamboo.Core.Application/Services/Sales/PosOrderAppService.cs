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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "stock_account", "barcodes", "web_editor", "digest", "phone_validation" })]
    public class PosOrderAppService : GenericApplicationService<PosOrder>, IPosOrderAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IPosBusMixinAppService _posBusMixinAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosOrderAppService(IRepository<PosOrder, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IPosBusMixinAppService posBusMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _posBusMixinAppService = posBusMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<PosOrder> AddLoyaltyHistoryLinesAsync(Guid id, PosOrderAddLoyaltyHistoryLinesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def add_loyalty_history_lines(self, coupon_data, coupon_updates):
            // id_mapping = {item['old_id']: int(item['id']) for item in coupon_updates}
            // history_lines_create_vals = []
            // for coupon in coupon_data:
            //     card_id = id_mapping.get(int(coupon['card_id'], False)) or int(coupon['card_id'])
            //     if not self.env['loyalty.card'].browse(card_id).exists():
            //         continue
            //     issued = coupon['won']
            //     cost = coupon['spent']
            //     if (issued or cost) and card_id > 0:
            //         history_lines_create_vals.append({
            //             'card_id': card_id,
            //             'order_model': self._name,
            //             'order_id': self.id,
            //             'description': _('Onsite %s', self.display_name),
            //             'used': cost,
            //             'issued': issued,
            //         })
            // self.env['loyalty.history'].create(history_lines_create_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> AddMailAttachmentInternalAsync(object name, object ticket, object basic_receipt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _add_mail_attachment(self, name, ticket, basic_ticket):
            // attachment = []
            // filename = 'Receipt-' + name + '.jpg'
            // receipt = self.env['ir.attachment'].create({
            //     'name': filename,
            //     'type': 'binary',
            //     'datas': ticket,
            //     'res_model': 'pos.order',
            //     'res_id': self.ids[0],
            //     'mimetype': 'image/jpeg',
            // })
            // attachment += [(4, receipt.id)]
            // if basic_ticket:
            //     filename = 'Receipt-' + name + '-1' + '.jpg'
            //     basic_receipt = self.env['ir.attachment'].create({
            //         'name': filename,
            //         'type': 'binary',
            //         'datas': basic_ticket,
            //         'res_model': 'pos.order',
            //         'res_id': self.ids[0],
            //         'mimetype': 'image/jpeg',
            //     })
            //     attachment += [(4, basic_receipt.id)]
            // 
            // 
            // if self.mapped('account_move'):
            //     report = self.env['ir.actions.report']._render_qweb_pdf("account.account_invoices", self.account_move.ids[0])
            //     filename = name + '.pdf'
            //     invoice = self.env['ir.attachment'].create({
            //         'name': filename,
            //         'type': 'binary',
            //         'datas': base64.b64encode(report[0]),
            //         'res_model': 'pos.order',
            //         'res_id': self.ids[0],
            //         'mimetype': 'application/x-pdf'
            //     })
            //     attachment += [(4, invoice.id)]
            // 
            // return attachment
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def _add_mail_attachment(self, name, ticket, basic_receipt):
            // attachment = super()._add_mail_attachment(name, ticket, basic_receipt)
            // gift_card_programs = self.config_id._get_program_ids().filtered(lambda p: p.program_type == 'gift_card' and
            //                                                                           p.pos_report_print_id)
            // if gift_card_programs:
            //     gift_cards = self.env['loyalty.card'].search([('source_pos_order_id', '=', self.id),
            //                                                   ('program_id', 'in', gift_card_programs.mapped('id'))])
            //     if gift_cards:
            //         for program in gift_card_programs:
            //             filtered_gift_cards = gift_cards.filtered(lambda gc: gc.program_id == program)
            //             if filtered_gift_cards:
            //                 action_report = program.pos_report_print_id
            //                 report = action_report._render_qweb_pdf(action_report.report_name, filtered_gift_cards.mapped('id'))
            //                 filename = name + '.pdf'
            //                 gift_card_pdf = self.env['ir.attachment'].create({
            //                     'name': filename,
            //                     'type': 'binary',
            //                     'datas': base64.b64encode(report[0]),
            //                     'store_fname': filename,
            //                     'res_model': 'pos.order',
            //                     'res_id': self.ids[0],
            //                     'mimetype': 'application/x-pdf'
            //                 })
            //                 attachment += [(4, gift_card_pdf.id)]
            // 
            // return attachment
            */
            return default;
        }

        public async Task<PosOrder> AddPaymentAsync(Guid id, PosOrderAddPaymentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def add_payment(self, data):
            // """Create a new payment for the order"""
            // self.ensure_one()
            // self.env['pos.payment'].create(data)
            // self.amount_paid = sum(self.payment_ids.mapped('amount'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> ApplyInvoicePaymentsInternalAsync(object is_reverse)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _apply_invoice_payments(self, is_reverse=False):
            // receivable_account = self.env["res.partner"]._find_accounting_partner(self.partner_id).with_company(self.company_id).property_account_receivable_id
            // payment_moves = self.payment_ids.sudo().with_company(self.company_id)._create_payment_moves(is_reverse)
            // if receivable_account.reconcile:
            //     invoice_receivables = self.account_move.line_ids.filtered(lambda line: line.account_id == receivable_account and not line.reconciled)
            //     if invoice_receivables:
            //         credit_line_ids = payment_moves._context.get('credit_line_ids', None)
            //         payment_receivables = payment_moves.mapped('line_ids').filtered(
            //             lambda line: (
            //                 (credit_line_ids and line.id in credit_line_ids) or
            //                 (not credit_line_ids and line.account_id == receivable_account and line.partner_id)
            //             )
            //         )
            //         (invoice_receivables | payment_receivables).sudo().with_company(self.company_id).reconcile()
            // return payment_moves
            */
            return default;
        }

        protected async Task<PosOrder> CheckExistingLoyaltyCardsInternalAsync(object coupon_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def _check_existing_loyalty_cards(self, coupon_data):
            // coupon_key_to_modify = []
            // for coupon_id, coupon_vals in coupon_data.items():
            //     partner_id = coupon_vals.get('partner_id', False)
            //     if partner_id:
            //         partner_coupons = self.env['loyalty.card'].search(
            //             [('partner_id', '=', partner_id), ('program_type', '=', 'loyalty')])
            //         existing_coupon_for_program = partner_coupons.filtered(lambda c: c.program_id.id == coupon_vals['program_id'])
            //         if existing_coupon_for_program:
            //             coupon_vals['coupon_id'] = existing_coupon_for_program[0].id
            //             coupon_key_to_modify.append([coupon_id, existing_coupon_for_program[0].id])
            // for old_key, new_key in coupon_key_to_modify:
            //     coupon_data[new_key] = coupon_data.pop(old_key)
            */
            return default;
        }

        protected async Task<PosOrder> CheckNextOnlinePaymentAmountInternalAsync(object amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def _check_next_online_payment_amount(self, amount):
            // self.ensure_one()
            // return tools.float_compare(amount, 0.0, precision_rounding=self.currency_id.rounding) >= 0 and tools.float_compare(amount, self.get_amount_unpaid(), precision_rounding=self.currency_id.rounding) <= 0
            */
            return default;
        }

        protected async Task<PosOrder> CleanPaymentLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _clean_payment_lines(self):
            // self.ensure_one()
            // self.payment_ids.unlink()
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def _clean_payment_lines(self):
            // self.ensure_one()
            // order_payments = self.env['pos.payment'].search(['&', ('pos_order_id', '=', self.id), ('online_account_payment_id', '=', False)])
            // order_payments.unlink()
            */
            return default;
        }

        protected async Task<PosOrder> CompleteValuesFromSessionInternalAsync(object session, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _complete_values_from_session(self, session, values):
            // values.setdefault('pricelist_id', session.config_id.pricelist_id.id)
            // values.setdefault('fiscal_position_id', session.config_id.default_fiscal_position_id.id)
            // values.setdefault('company_id', session.config_id.company_id.id)
            // return values
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _complete_values_from_session(self, session, values):
            // values = super(PosOrder, self)._complete_values_from_session(session, values)
            // values['crm_team_id'] = values['crm_team_id'] if values.get('crm_team_id') else session.config_id.crm_team_id.id
            // return values
            */
            return default;
        }

        protected async Task<PosOrder> ComputeAttendeeCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def _compute_attendee_count(self):
            // for order in self:
            //     order.attendee_count = len(order.lines.mapped('event_registration_ids'))
            */
            return default;
        }

        protected async Task<PosOrder> ComputeCashierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_order.py) ---
            // def _compute_cashier(self):
            // for order in self:
            //     if order.employee_id:
            //         order.cashier = order.employee_id.name
            //     else:
            //         order.cashier = order.user_id.name
            */
            return default;
        }

        protected async Task<PosOrder> ComputeContactDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_contact_details(self):
            // for order in self:
            //     order.email = order.partner_id.email or ""
            //     order.mobile = order._phone_format(number=order.partner_id.mobile or order.partner_id.phone or "",
            //                 country=order.partner_id.country_id)
            */
            return default;
        }

        protected async Task<PosOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(order.company_id.currency_id, order.currency_id, order.company_id, order.date_order.date())
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     date_order = order.date_order or fields.Datetime.now()
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(order.company_id.currency_id, order.currency_id, order.company_id, date_order.date())
            */
            return default;
        }

        protected async Task<PosOrder> ComputeHasRefundableLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_has_refundable_lines(self):
            // digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for order in self:
            //     order.has_refundable_lines = any([float_compare(line.qty, line.refunded_qty, digits) > 0 for line in order.lines])
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsEditedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_edited(self):
            // for order in self:
            //     order.is_edited = any(order.lines.mapped('is_edited')) or order.has_deleted_line
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_invoiced(self):
            // for order in self:
            //     order.is_invoiced = bool(order.account_move)
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsTotalCostComputedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_total_cost_computed(self):
            // for order in self:
            //     order.is_total_cost_computed = not False in order.lines.mapped('is_total_cost_computed')
            */
            return default;
        }

        protected async Task<PosOrder> ComputeMarginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_margin(self):
            // for order in self:
            //     if order.is_total_cost_computed:
            //         order.margin = sum(order.lines.mapped('margin'))
            //         amount_untaxed = order.currency_id.round(sum(line.price_subtotal for line in order.lines))
            //         order.margin_percent = not float_is_zero(amount_untaxed, precision_rounding=order.currency_id.rounding) and order.margin / amount_untaxed or 0
            //     else:
            //         order.margin = 0
            //         order.margin_percent = 0
            */
            return default;
        }

        protected async Task<PosOrder> ComputeOnlinePaymentMethodIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def _compute_online_payment_method_id(self):
            // for order in self:
            //     order.online_payment_method_id = order.config_id._get_cashier_online_payment_method()
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py) ---
            // def _compute_online_payment_method_id(self):
            // for order in self:
            //     if order.use_self_order_online_payment:
            //         # It is expected to use the self order online payment method.
            //         # If for any reason it is not defined, then the online payment
            //         # of the order is set to null to make the problem noticeable.
            //         order.online_payment_method_id = order.config_id.self_order_online_payment_method_id
            //     else:
            //         super(PosOrder, order)._compute_online_payment_method_id()
            */
            return default;
        }

        protected async Task<PosOrder> ComputeOrderNameInternalAsync(object session)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_order_name(self, session=None):
            // session = session or self.session_id
            // if self.refunded_order_id.exists():
            //     return _('%(refunded_order)s REFUND', refunded_order=self.refunded_order_id.name)
            // else:
            //     return session.config_id.sequence_id._next()
            */
            return default;
        }

        protected async Task<PosOrder> ComputePickingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_picking_count(self):
            // for order in self:
            //     order.picking_count = len(order.picking_ids)
            //     order.failed_pickings = bool(order.picking_ids.filtered(lambda p: p.state != 'done'))
            */
            return default;
        }

        protected async Task<PosOrder> ComputePricesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_prices(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     if not order.currency_id:
            //         raise UserError(_("You can't: create a pos order from the backend interface, or unset the pricelist, or create a pos.order in a python test with Form tool, or edit the form view in studio if no PoS order exist"))
            //     order.amount_paid = sum(payment.amount for payment in order.payment_ids)
            //     order.amount_return = -sum(payment.amount < 0 and payment.amount or 0 for payment in order.payment_ids)
            // 
            //     base_lines = order.lines._prepare_tax_base_line_values()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            // 
            //     cash_rounding = None
            //     if (
            //         order.config_id.cash_rounding
            //         and not order.config_id.only_round_cash_method
            //         and order.config_id.rounding_method
            //     ):
            //         cash_rounding = order.config_id.rounding_method
            // 
            //     tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id,
            //         company=order.company_id,
            //         cash_rounding=cash_rounding,
            //     )
            //     refund_factor = -1 if (order.amount_total < 0.0) else 1
            //     order.amount_tax = refund_factor * tax_totals['tax_amount_currency']
            //     order.amount_total = refund_factor * tax_totals['total_amount_currency']
            //     order.amount_difference = order.amount_paid - order.amount_total
            */
            return default;
        }

        protected async Task<PosOrder> ComputeRefundRelatedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_refund_related_fields(self):
            // for order in self:
            //     order.refund_orders_count = len(order.mapped('lines.refund_orderline_ids.order_id'))
            //     order.refunded_order_id = order.lines.refunded_orderline_id.order_id
            */
            return default;
        }

        protected async Task<PosOrder> ComputeTotalCostAtSessionClosingInternalAsync(object stock_moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_total_cost_at_session_closing(self, stock_moves):
            // """
            // Compute the margin at the end of the session. This method should be called to compute the remaining lines margin
            // containing a storable product with a fifo/avco cost method and then compute the order margin
            // """
            // for order in self:
            //     storable_fifo_avco_lines = order.lines.filtered(lambda l: l._is_product_storable_fifo_avco())
            //     storable_fifo_avco_lines._compute_total_cost(stock_moves)
            */
            return default;
        }

        protected async Task<PosOrder> ComputeTotalCostInRealTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_total_cost_in_real_time(self):
            // """
            // Compute the total cost of the order when it's processed by the server. It will compute the total cost of all the lines
            // if it's possible. If a margin of one of the order's lines cannot be computed (because of session_id.update_stock_at_closing),
            // then the margin of said order is not computed (it will be computed when closing the session).
            // """
            // for order in self:
            //     lines = order.lines
            //     if not order._should_create_picking_real_time():
            //         storable_fifo_avco_lines = lines.filtered(lambda l: l._is_product_storable_fifo_avco())
            //         lines -= storable_fifo_avco_lines
            //     stock_moves = order.picking_ids.move_ids
            //     lines._compute_total_cost(stock_moves)
            */
            return default;
        }

        protected async Task<PosOrder> ComputeTrackingNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_tracking_number(self):
            // for record in self:
            //     record.tracking_number = str((record.session_id.id % 10) * 100 + record.sequence_number % 100).zfill(3)
            */
            return default;
        }

        protected async Task<PosOrder> ComputeUseSelfOrderOnlinePaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py) ---
            // def _compute_use_self_order_online_payment(self):
            // for order in self:
            //     order.use_self_order_online_payment = bool(order.config_id.self_order_online_payment_method_id)
            */
            return default;
        }

        public async Task<PosOrder> ConfirmCouponProgramsAsync(Guid id, PosOrderConfirmCouponProgramsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def confirm_coupon_programs(self, coupon_data):
            // """
            // This is called after the order is created.
            // 
            // This will create all necessary coupons and link them to their line orders etc..
            // 
            // It will also return the points of all concerned coupons to be updated in the cache.
            // """
            // get_partner_id = lambda partner_id: partner_id and self.env['res.partner'].browse(partner_id).exists() and partner_id or False
            // # Keys are stringified when using rpc
            // coupon_data = {int(k): v for k, v in coupon_data.items()}
            // 
            // self._check_existing_loyalty_cards(coupon_data)
            // # Map negative id to newly created ids.
            // coupon_new_id_map = {k: k for k in coupon_data.keys() if k > 0}
            // 
            // # Create the coupons that were awarded by the order.
            // coupons_to_create = {k: v for k, v in coupon_data.items() if k < 0 and not v.get('giftCardId')}
            // coupon_create_vals = [{
            //     'program_id': p['program_id'],
            //     'partner_id': get_partner_id(p.get('partner_id', False)),
            //     'code': p.get('code') or p.get('barcode') or self.env['loyalty.card']._generate_code(),
            //     'points': 0,
            //     'expiration_date': p.get('date_to', False),
            //     'source_pos_order_id': self.id,
            //     'expiration_date': p.get('expiration_date')
            // } for p in coupons_to_create.values()]
            // 
            // # Pos users don't have the create permission
            // new_coupons = self.env['loyalty.card'].with_context(action_no_send_mail=True).sudo().create(coupon_create_vals)
            // 
            // # We update the gift card that we sold when the gift_card_settings = 'scan_use'.
            // gift_cards_to_update = [v for v in coupon_data.values() if v.get('giftCardId')]
            // updated_gift_cards = self.env['loyalty.card']
            // for coupon_vals in gift_cards_to_update:
            //     gift_card = self.env['loyalty.card'].browse(coupon_vals.get('giftCardId'))
            //     gift_card.write({
            //         'points': coupon_vals['points'],
            //         'source_pos_order_id': self.id,
            //         'partner_id': get_partner_id(coupon_vals.get('partner_id', False)),
            //     })
            //     updated_gift_cards |= gift_card
            // 
            // # Map the newly created coupons
            // for old_id, new_id in zip(coupons_to_create.keys(), new_coupons):
            //     coupon_new_id_map[new_id.id] = old_id
            // 
            // # We need a sudo here because this can trigger `_compute_order_count` that require access to `sale.order.line`
            // all_coupons = self.env['loyalty.card'].sudo().browse(coupon_new_id_map.keys()).exists()
            // lines_per_reward_code = defaultdict(lambda: self.env['pos.order.line'])
            // for line in self.lines:
            //     if not line.reward_identifier_code:
            //         continue
            //     lines_per_reward_code[line.reward_identifier_code] |= line
            // for coupon in all_coupons:
            //     if coupon.id in coupon_new_id_map:
            //         # Coupon existed previously, update amount of points.
            //         coupon.points += coupon_data[coupon_new_id_map[coupon.id]]['points']
            //     for reward_code in coupon_data[coupon_new_id_map[coupon.id]].get('line_codes', []):
            //         lines_per_reward_code[reward_code].coupon_id = coupon
            // # Send creation email
            // new_coupons.with_context(action_no_send_mail=False)._send_creation_communication()
            // # Reports per program
            // report_per_program = {}
            // coupon_per_report = defaultdict(list)
            // # Important to include the updated gift cards so that it can be printed. Check coupon_report.
            // for coupon in new_coupons | updated_gift_cards:
            //     if coupon.program_id not in report_per_program:
            //         report_per_program[coupon.program_id] = coupon.program_id.communication_plan_ids.\
            //             filtered(lambda c: c.trigger == 'create').pos_report_print_id
            //     for report in report_per_program[coupon.program_id]:
            //         coupon_per_report[report.id].append(coupon.id)
            // return {
            //     'coupon_updates': [{
            //         'old_id': coupon_new_id_map[coupon.id],
            //         'id': coupon.id,
            //         'points': coupon.points,
            //         'code': coupon.code,
            //         'program_id': coupon.program_id.id,
            //         'partner_id': coupon.partner_id.id,
            //     } for coupon in all_coupons if coupon.program_id.is_nominative],
            //     'program_updates': [{
            //         'program_id': program.id,
            //         'usages': program.sudo().total_order_count,
            //     } for program in all_coupons.program_id],
            //     'new_coupon_info': [{
            //         'program_name': coupon.program_id.name,
            //         'expiration_date': coupon.expiration_date,
            //         'code': coupon.code,
            //     } for coupon in new_coupons if (
            //         coupon.program_id.applies_on == 'future'
            //         # Don't send the coupon code for the gift card and ewallet programs.
            //         # It should not be printed in the ticket.
            //         and coupon.program_id.sudo().program_type not in ['gift_card', 'ewallet']
            //     )],
            //     'coupon_report': coupon_per_report,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> CountSaleOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _count_sale_order(self):
            // for order in self:
            //     order.sale_order_count = len(order.lines.mapped('sale_order_origin_id'))
            */
            return default;
        }

        public override async Task<PosOrder> CreateAsync(PosOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     session = self.env['pos.session'].browse(vals['session_id'])
            //     vals = self._complete_values_from_session(session, vals)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if 'use_self_order_online_payment' not in vals or vals['use_self_order_online_payment']:
            //         session = self.env['pos.session'].browse(vals['session_id'])
            //         config = session.config_id
            //         vals['use_self_order_online_payment'] = bool(config.self_order_online_payment_method_id)
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PosOrder> CreateInvoiceInternalAsync(object move_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_invoice(self, move_vals):
            // self.ensure_one()
            // invoice = self.env['account.move'].sudo()\
            //     .with_company(self.company_id)\
            //     .with_context(default_move_type=move_vals['move_type'], linked_to_pos=True)\
            //     .create(move_vals)
            // 
            // if self.config_id.cash_rounding:
            //     line_ids_commands = []
            //     rate = invoice.invoice_currency_rate
            //     sign = invoice.direction_sign
            //     amount_paid = (-1 if self.amount_total < 0.0 else 1) * self.amount_paid
            //     difference_currency = sign * (amount_paid - invoice.amount_total)
            //     difference_balance = invoice.company_currency_id.round(difference_currency / rate) if rate else 0.0
            //     if not self.currency_id.is_zero(difference_currency):
            //         rounding_line = invoice.line_ids.filtered(lambda line: line.display_type == 'rounding' and not line.tax_line_id)
            //         if rounding_line:
            //             line_ids_commands.append(Command.update(rounding_line.id, {
            //                 'amount_currency': rounding_line.amount_currency + difference_currency,
            //                 'balance': rounding_line.balance + difference_balance,
            //             }))
            //         else:
            //             if difference_currency > 0.0:
            //                 account = invoice.invoice_cash_rounding_id.loss_account_id
            //             else:
            //                 account = invoice.invoice_cash_rounding_id.profit_account_id
            //             line_ids_commands.append(Command.create({
            //                 'name': invoice.invoice_cash_rounding_id.name,
            //                 'amount_currency': difference_currency,
            //                 'balance': difference_balance,
            //                 'currency_id': invoice.currency_id.id,
            //                 'display_type': 'rounding',
            //                 'account_id': account.id,
            //             }))
            //         existing_terms_line = invoice.line_ids\
            //             .filtered(lambda line: line.display_type == 'payment_term')\
            //             .sorted(lambda line: -abs(line.amount_currency))[:1]
            //         line_ids_commands.append(Command.update(existing_terms_line.id, {
            //             'amount_currency': existing_terms_line.amount_currency - difference_currency,
            //             'balance': existing_terms_line.balance - difference_balance,
            //         }))
            //         with self.env['account.move']._check_balanced({'records': invoice}):
            //             invoice.with_context(skip_invoice_sync=True).line_ids = line_ids_commands
            // invoice.message_post(body=_("This invoice has been created from the point of sale session: %s", self._get_html_link()))
            // return invoice
            */
            return default;
        }

        protected async Task<PosOrder> CreateMiscReversalMoveInternalAsync(object payment_moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_misc_reversal_move(self, payment_moves):
            // """ Create a misc move to reverse this POS order and "remove" it from the POS closing entry.
            // This is done by taking data from the order and using it to somewhat replicate the resulting entry in order to
            // reverse partially the movements done ine the POS closing entry.
            // """
            // aml_values_list_per_nature = self._prepare_aml_values_list_per_nature()
            // move_lines = []
            // for aml_values_list in aml_values_list_per_nature.values():
            //     for aml_values in aml_values_list:
            //         aml_values['balance'] = -aml_values['balance']
            //         aml_values['amount_currency'] = -aml_values['amount_currency']
            //         move_lines.append(aml_values)
            // 
            // # Make a move with all the lines.
            // reversal_entry = self.env['account.move'].with_context(
            //     default_journal_id=self.config_id.journal_id.id,
            //     skip_invoice_sync=True,
            //     skip_invoice_line_sync=True,
            // ).create({
            //     'journal_id': self.config_id.journal_id.id,
            //     'date': fields.Date.context_today(self),
            //     'ref': _('Reversal of POS closing entry %(entry)s for order %(order)s from session %(session)s', entry=self.session_move_id.name, order=self.name, session=self.session_id.name),
            //     'line_ids': [(0, 0, aml_value) for aml_value in move_lines],
            //     'reversed_pos_order_id': self.id
            // })
            // reversal_entry.action_post()
            // 
            // pos_account_receivable = self.company_id.account_default_pos_receivable_account_id
            // account_receivable = self.payment_ids.payment_method_id.receivable_account_id
            // reversal_entry_receivable = reversal_entry.line_ids.filtered(lambda l: l.account_id in (pos_account_receivable + account_receivable))
            // payment_receivable = payment_moves.line_ids.filtered(lambda l: l.account_id in (pos_account_receivable + account_receivable))
            // lines_to_reconcile = defaultdict(lambda: self.env['account.move.line'])
            // for line in (reversal_entry_receivable | payment_receivable):
            //     lines_to_reconcile[line.account_id] |= line
            // for line in lines_to_reconcile.values():
            //     line.filtered(lambda l: not l.reconciled).reconcile()
            */
            return default;
        }

        protected async Task<PosOrder> CreateOrderPickingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_order_picking(self):
            // self.ensure_one()
            // if self.shipping_date:
            //     self.sudo().lines._launch_stock_rule_from_pos_order_lines()
            // else:
            //     if self._should_create_picking_real_time():
            //         picking_type = self.config_id.picking_type_id
            //         if self.partner_id.property_stock_customer:
            //             destination_id = self.partner_id.property_stock_customer.id
            //         elif not picking_type or not picking_type.default_location_dest_id:
            //             destination_id = self.env['stock.warehouse']._get_partner_locations()[0].id
            //         else:
            //             destination_id = picking_type.default_location_dest_id.id
            // 
            //         pickings = self.env['stock.picking']._create_picking_from_pos_order_lines(destination_id, self.lines, picking_type, self.partner_id)
            //         pickings.write({'pos_session_id': self.session_id.id, 'pos_order_id': self.id, 'origin': self.name})
            */
            return default;
        }

        protected async Task<PosOrder> CreatePmChangeLogInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_pm_change_log(self, vals):
            // if not vals.get('payment_ids'):
            //     return []
            // 
            // message_list = []
            // new_pms = vals.get('payment_ids', [])
            // for new_pm in new_pms:
            //     orm_command = new_pm[0]
            // 
            //     if orm_command == 0:
            //         payment_method_id = self.env['pos.payment.method'].browse(new_pm[2].get('payment_method_id'))
            //         amount = formatLang(self.env, new_pm[2].get('amount'), currency_obj=self.currency_id)
            //         message_list.append(_("Added %(payment_method)s with %(amount)s",
            //             payment_method=payment_method_id.name,
            //             amount=amount))
            //     elif orm_command == 1:
            //         pm_id = self.env['pos.payment'].browse(new_pm[1])
            //         old_pm = pm_id.payment_method_id.name
            //         old_amount = formatLang(self.env, pm_id.amount, currency_obj=pm_id.currency_id)
            //         new_amount = False
            //         new_payment_method = False
            // 
            //         if new_pm[2].get('payment_method_id'):
            //             new_payment_method = self.env['pos.payment.method'].browse(new_pm[2].get('payment_method_id'))
            //         if new_pm[2].get('amount'):
            //             new_amount = formatLang(self.env, new_pm[2].get('amount'), currency_obj=pm_id.currency_id)
            // 
            //         if new_payment_method and new_amount:
            //             message_list.append(_("%(old_pm)s changed to %(new_pm)s and from %(old_amount)s to %(new_amount)s",
            //                 old_pm=old_pm,
            //                 new_pm=new_payment_method.name,
            //                 old_amount=old_amount,
            //                 new_amount=new_amount))
            //         elif new_payment_method:
            //             message_list.append(_("%(old_pm)s changed to %(new_pm)s for %(old_amount)s",
            //                 old_pm=old_pm,
            //                 new_pm=new_payment_method.name,
            //                 old_amount=old_amount))
            //         elif new_amount:
            //             message_list.append(_("Amount for %(old_pm)s changed from %(old_amount)s to %(new_amount)s",
            //                 old_amount=old_amount,
            //                 new_amount=new_amount,
            //                 old_pm=old_pm))
            //     elif orm_command == 2:
            //         pm_id = self.env['pos.payment'].browse(new_pm[1])
            //         amount = formatLang(self.env, pm_id.amount, currency_obj=pm_id.currency_id)
            //         message_list.append(_("Removed %(payment_method)s with %(amount)s",
            //             payment_method=pm_id.payment_method_id.name,
            //             amount=amount))
            // 
            // return message_list
            */
            return default;
        }

        protected async Task<PosOrder> GeneratePosOrderInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _generate_pos_order_invoice(self):
            // moves = self.env['account.move']
            // 
            // for order in self:
            //     # Force company for all SUPERUSER_ID action
            //     if order.account_move:
            //         moves += order.account_move
            //         continue
            // 
            //     if not order.partner_id:
            //         raise UserError(_('Please provide a partner for the sale.'))
            // 
            //     move_vals = order._prepare_invoice_vals()
            //     new_move = order._create_invoice(move_vals)
            // 
            //     order.state = 'invoiced'
            //     new_move.sudo().with_company(order.company_id).with_context(**order._get_invoice_post_context())._post()
            // 
            //     moves += new_move
            //     payment_moves = order._apply_invoice_payments(order.session_id.state == 'closed')
            // 
            //     # Send and Print
            //     if self.env.context.get('generate_pdf', True):
            //         new_move.with_context(skip_invoice_sync=True)._generate_and_send()
            // 
            //     if order.session_id.state == 'closed':  # If the session isn't closed this isn't needed.
            //         # If a client requires the invoice later, we need to revers the amount from the closing entry, by making a new entry for that.
            //         order._create_misc_reversal_move(payment_moves)
            // 
            // if not moves:
            //     return {}
            // 
            // return {
            //     'name': _('Customer Invoice'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('account.view_move_form').id,
            //     'res_model': 'account.move',
            //     'context': "{'move_type':'out_invoice'}",
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'res_id': moves and moves.ids[0] or False,
            // }
            */
            return default;
        }

        public async Task<PosOrder> GetAmountUnpaidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def get_amount_unpaid(self):
            // self.ensure_one()
            // return self.currency_id.round(self._get_rounded_amount(self.amount_total) - self.amount_paid)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> GetAndSetOnlinePaymentsDataAsync(Guid id, PosOrderGetAndSetOnlinePaymentsDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def get_and_set_online_payments_data(self, next_online_payment_amount=False):
            // """ Allows to update the amount to pay for the next online payment and
            //     get online payments already made and how much remains to be paid.
            //     If next_online_payment_amount is different than False, updates the
            //     next online payment amount, otherwise, the next online payment amount
            //     is unchanged.
            //     If next_online_payment_amount is 0 and the order has no successful
            //     online payment, is in draft state, is not a restaurant order and the
            //     pos.config has no trusted config, then the order is deleted from the
            //     database, because it was probably added for the online payment flow.
            // """
            // self.ensure_one()
            // is_paid = self.state in ('paid', 'done', 'invoiced')
            // if is_paid:
            //     return {
            //         'id': self.id,
            //         'paid_order': self.read([], load=False)
            //     }
            // 
            // online_payments = self.sudo().env['pos.payment'].search_read(domain=['&', ('pos_order_id', '=', self.id), ('online_account_payment_id', '!=', False)], fields=['payment_method_id', 'amount'], load=False)
            // return_data = {
            //     'id': self.id,
            //     'online_payments': online_payments,
            //     'amount_unpaid': self.get_amount_unpaid(),
            // }
            // if not isinstance(next_online_payment_amount, bool):
            //     if tools.float_is_zero(next_online_payment_amount, precision_rounding=self.currency_id.rounding) and len(online_payments) == 0 and self.state == 'draft' and not self.config_id.module_pos_restaurant and len(self.config_id.trusted_config_ids) == 0:
            //         self.sudo()._clean_payment_lines() # Needed to delete the order
            //         return_data['deleted'] = True
            //     elif self._check_next_online_payment_amount(next_online_payment_amount):
            //         self.next_online_payment_amount = next_online_payment_amount
            // 
            // return return_data
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py) ---
            // def get_and_set_online_payments_data(self, next_online_payment_amount=False):
            // res = super().get_and_set_online_payments_data(next_online_payment_amount)
            // if 'paid_order' not in res and not res.get('deleted', False) and not isinstance(next_online_payment_amount, bool):
            //     # This method is only called in the POS frontend flow, not self order.
            //     # If the next online payment is 0, then the online payment of the frontend
            //     # flow is cancelled, and the default flow is self order if it is configured.
            //     self.use_self_order_online_payment = tools.float_is_zero(next_online_payment_amount, precision_rounding=self.currency_id.rounding) and self.config_id.self_order_online_payment_method_id
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> GetCheckedNextOnlinePaymentAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py) ---
            // def _get_checked_next_online_payment_amount(self):
            // self.ensure_one()
            // amount = self.next_online_payment_amount
            // return amount if self._check_next_online_payment_amount(amount) else False
            */
            return default;
        }

        protected async Task<PosOrder> GetFieldsForOrderLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def _get_fields_for_order_line(self):
            // fields = super(PosOrder, self)._get_fields_for_order_line()
            // fields.extend(['is_reward_line', 'reward_id', 'coupon_id', 'reward_identifier_code', 'points_cost'])
            // return fields
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _get_fields_for_order_line(self):
            // fields = super(PosOrder, self)._get_fields_for_order_line()
            // fields.extend([
            //     'sale_order_origin_id',
            //     'down_payment_details',
            //     'sale_order_line_id',
            // ])
            // return fields
            */
            return default;
        }

        protected async Task<PosOrder> GetInvoiceLinesValuesInternalAsync(object line_values, object pos_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_invoice_lines_values(self, line_values, pos_order_line):
            // return {
            //     'product_id': line_values['product_id'].id,
            //     'quantity': line_values['quantity'],
            //     'discount': line_values['discount'],
            //     'price_unit': line_values['price_unit'],
            //     'name': line_values['name'],
            //     'tax_ids': [(6, 0, line_values['tax_ids'].ids)],
            //     'product_uom_id': line_values['uom_id'].id,
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _get_invoice_lines_values(self, line_values, pos_line):
            // inv_line_vals = super()._get_invoice_lines_values(line_values, pos_line)
            // 
            // if pos_line.sale_order_origin_id:
            //     origin_line = pos_line.sale_order_line_id
            //     inv_line_vals["name"] = origin_line.name
            //     origin_line._set_analytic_distribution(inv_line_vals)
            // 
            // return inv_line_vals
            */
            return default;
        }

        protected async Task<PosOrder> GetInvoicePostContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_invoice_post_context(self):
            // return {"skip_invoice_sync": True}
            */
            return default;
        }

        protected async Task<PosOrder> GetOpenOrderInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_open_order(self, order):
            // return self.env["pos.order"].search([('uuid', '=', order.get('uuid'))], limit=1)
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py) ---
            // def _get_open_order(self, order):
            // config_id = self.env['pos.session'].browse(order.get('session_id')).config_id
            // if not config_id.module_pos_restaurant:
            //     return super()._get_open_order(order)
            // 
            // domain = []
            // if order.get('table_id', False) and order.get('state') == 'draft':
            //     domain += ['|', ('uuid', '=', order.get('uuid')), '&', ('table_id', '=', order.get('table_id')), ('state', '=', 'draft')]
            // else:
            //     domain += [('uuid', '=', order.get('uuid'))]
            // return self.env["pos.order"].search(domain, limit=1)
            */
            return default;
        }

        protected async Task<PosOrder> GetOrderLogRepresentationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_order_log_representation(order):
            // return dict((k, order.get(k)) for k in ("name", "uuid"))
            */
            return default;
        }

        protected async Task<PosOrder> GetPartnerBankIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_partner_bank_id(self):
            // bank_partner_id = False
            // if self.amount_total <= 0 and self.partner_id.bank_ids:
            //     bank_partner_id = self.partner_id.bank_ids[0].id
            // elif self.amount_total >= 0 and self.company_id.partner_id.bank_ids:
            //     bank_partner_id = self.company_id.partner_id.bank_ids[0].id
            // return bank_partner_id
            */
            return default;
        }

        protected async Task<PosOrder> GetPosAngloSaxonPriceUnitInternalAsync(object product, Guid partner_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_pos_anglo_saxon_price_unit(self, product, partner_id, quantity):
            // moves = self.filtered(lambda o: o.partner_id.id == partner_id)\
            //     .mapped('picking_ids.move_ids')\
            //     ._filter_anglo_saxon_moves(product)\
            //     .sorted(lambda x: x.date)
            // price_unit = product.with_company(self.company_id)._compute_average_price(0, quantity, moves)
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: pos_mrp, FILE: pos_order.py) ---
            // def _get_pos_anglo_saxon_price_unit(self, product, partner_id, quantity):
            // bom = product.env['mrp.bom']._bom_find(product, company_id=self.mapped('picking_ids.move_line_ids').company_id.id, bom_type='phantom')[product]
            // if not bom:
            //     return super()._get_pos_anglo_saxon_price_unit(product, partner_id, quantity)
            // _dummy, components = bom.explode(product, quantity)
            // total_price_unit = 0
            // for comp in components:
            //     price_unit = super()._get_pos_anglo_saxon_price_unit(comp[0].product_id, partner_id, comp[1]['qty'])
            //     price_unit = comp[0].product_id.uom_id._compute_price(price_unit, comp[0].product_uom_id)
            //     qty_per_kit = comp[1]['qty'] / bom.product_qty / (quantity or 1)
            //     total_price_unit += price_unit * qty_per_kit
            // return total_price_unit
            */
            return default;
        }

        protected async Task<PosOrder> GetRefundedOrdersInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_refunded_orders(self, order):
            // refunded_orderline_ids = [line[2]['refunded_orderline_id'] for line in order['lines'] if line[0] in [0, 1] and line[2].get('refunded_orderline_id')]
            // return self.env['pos.order.line'].browse(refunded_orderline_ids).mapped('order_id')
            */
            return default;
        }

        protected async Task<PosOrder> GetRoundedAmountInternalAsync(object amount, object force_round)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_rounded_amount(self, amount, force_round=False):
            // # TODO: add support for mix of cash and non-cash payments when both cash_rounding and only_round_cash_method are True
            // if self.config_id.cash_rounding \
            //    and (force_round or (not self.config_id.only_round_cash_method \
            //    or any(p.payment_method_id.is_cash_count for p in self.payment_ids))):
            //     amount = float_round(amount, precision_rounding=self.config_id.rounding_method.rounding, rounding_method=self.config_id.rounding_method.rounding_method)
            // currency = self.currency_id
            // return currency.round(amount) if currency else amount
            */
            return default;
        }

        protected async Task<PosOrder> GetValidSessionInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_valid_session(self, order):
            // PosSession = self.env['pos.session']
            // closed_session = PosSession.browse(order['session_id'])
            // 
            // _logger.warning('Session %s (ID: %s) was closed but received order %s (total: %s) belonging to it',
            //                 closed_session.name,
            //                 closed_session.id,
            //                 order['name'],
            //                 order['amount_total'])
            // 
            // open_session = PosSession.search([
            //     ('state', 'not in', ('closed', 'closing_control')),
            //     ('config_id', '=', closed_session.config_id.id)
            // ], limit=1)
            // 
            // if open_session:
            //     _logger.warning('Using open session %s for saving order %s', open_session.name, order['name'])
            //     return open_session
            // 
            // raise UserError(_('No open session available. Please open a new session to capture the order.'))
            */
            return default;
        }

        protected async Task<PosOrder> IsPosOrderPaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _is_pos_order_paid(self):
            // amount_total = self.amount_total
            // # If we are checking if a refund was paid and if it was a total refund, we take into account the amount paid on
            // # the original order. For a pertial refund, we take into account the value of the items returned.
            // if float_is_zero(self.refunded_order_id.amount_total + amount_total, precision_rounding=self.currency_id.rounding):
            //     amount_total = -self.refunded_order_id.amount_paid
            // return float_is_zero(self._get_rounded_amount(amount_total) - self.amount_paid, precision_rounding=self.currency_id.rounding)
            */
            return default;
        }

        protected async Task<PosOrder> LinkComboItemsInternalAsync(object combo_child_uuids_by_parent_uuid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _link_combo_items(self, combo_child_uuids_by_parent_uuid):
            // self.ensure_one()
            // 
            // for parent_uuid, child_uuids in combo_child_uuids_by_parent_uuid.items():
            //     parent_line = self.lines.filtered(lambda line: line.uuid == parent_uuid)
            //     if not parent_line:
            //         continue
            //     parent_line.combo_line_ids = [(6, 0, self.lines.filtered(lambda line: line.uuid in child_uuids).ids)]
            */
            return default;
        }

        protected async Task<PosOrder> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('state', '=', 'draft'), ('session_id', '=', data['pos.session']['data'][0]['id'])]
            */
            return default;
        }

        protected async Task<PosOrder> LoadPosSelfDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def _load_pos_self_data_domain(self, data):
            // return [('id', '=', False)]
            */
            return default;
        }

        protected async Task<PosOrder> MarkupListMessageInternalAsync(object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _markup_list_message(self, message):
            // body = Markup("<ul>")
            // for line in message:
            //     body += Markup("<li>")
            //     body += line
            //     body += Markup("</li>")
            // body += Markup("</ul>")
            // return body
            */
            return default;
        }

        protected async Task<PosOrder> OnchangeAmountAllInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_amount_all(self):
            // self._compute_prices()
            */
            return default;
        }

        protected async Task<PosOrder> OnchangePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_partner_id(self):
            // if self.partner_id:
            //     self.pricelist_id = self.partner_id.property_product_pricelist.id
            */
            return default;
        }

        public async Task<PosOrder> PosOrderCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_cancel(self):
            // cancellable_orders = self.filtered(lambda order: order.state == 'draft')
            // cancellable_orders.write({'state': 'cancel'})
            // return {
            //     'pos.order': cancellable_orders.read(self._load_pos_data_fields(self.config_id.ids[0]), load=False)
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py) ---
            // def action_pos_order_cancel(self):
            // result = super().action_pos_order_cancel()
            // if self.table_id:
            //     self.send_table_count_notification(self.table_id)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> PosOrderInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_invoice(self):
            // if len(self.company_id) > 1:
            //     raise UserError(_("You cannot invoice orders belonging to different companies."))
            // self.write({'to_invoice': True})
            // if self.company_id.anglo_saxon_accounting and self.session_id.update_stock_at_closing and self.session_id.state != 'closed':
            //     self._create_order_picking()
            // return self._generate_pos_order_invoice()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> PosOrderPaidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_paid(self):
            // self.ensure_one()
            // 
            // # TODO: add support for mix of cash and non-cash payments when both cash_rounding and only_round_cash_method are True
            // if not self.config_id.cash_rounding \
            //    or self.config_id.only_round_cash_method \
            //    and not any(p.payment_method_id.is_cash_count for p in self.payment_ids):
            //     total = self.amount_total
            // else:
            //     total = float_round(self.amount_total, precision_rounding=self.config_id.rounding_method.rounding, rounding_method=self.config_id.rounding_method.rounding_method)
            // 
            // isPaid = float_is_zero(total - self.amount_paid, precision_rounding=self.currency_id.rounding)
            // 
            // if not isPaid and not self.config_id.cash_rounding:
            //     raise UserError(_("Order %s is not fully paid.", self.name))
            // elif not isPaid and self.config_id.cash_rounding:
            //     currency = self.currency_id
            //     if self.config_id.rounding_method.rounding_method == "HALF-UP":
            //         maxDiff = currency.round(self.config_id.rounding_method.rounding / 2)
            //     else:
            //         maxDiff = currency.round(self.config_id.rounding_method.rounding)
            // 
            //     diff = currency.round(self.amount_total - self.amount_paid)
            //     if not abs(diff) <= maxDiff:
            //         raise UserError(_("Order %s is not fully paid.", self.name))
            // 
            // self.write({'state': 'paid'})
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_order.py) ---
            // def action_pos_order_paid(self):
            // res = super(PosOrder, self).action_pos_order_paid()
            // if not self.config_id.set_tip_after_payment:
            //     payment_lines = self.payment_ids.filtered(lambda line: line.payment_method_id.use_payment_terminal == 'adyen')
            //     for payment_line in payment_lines:
            //         payment_line._adyen_capture()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> PostChatterMessageInternalAsync(object body)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _post_chatter_message(self, body):
            // self.message_post(body=body)
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_order.py) ---
            // def _post_chatter_message(self, body):
            // body += Markup("<br/>")
            // body += _("Cashier %s", self.cashier)
            // self.message_post(body=body)
            */
            return default;
        }

        protected async Task<PosOrder> PrepareAmlValuesListPerNatureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_aml_values_list_per_nature(self):
            // self.ensure_one()
            // AccountTax = self.env['account.tax']
            // sign = 1 if self.amount_total < 0 else -1
            // commercial_partner = self.partner_id.commercial_partner_id
            // company_currency = self.company_id.currency_id
            // rate = self.currency_id._get_conversion_rate(self.currency_id, company_currency, self.company_id, self.date_order)
            // 
            // # Concert each order line to a dictionary containing business values. Also, prepare for taxes computation.
            // base_lines = self._prepare_tax_base_line_values()
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id)
            // tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            // 
            // total_balance = 0.0
            // total_amount_currency = 0.0
            // aml_vals_list_per_nature = defaultdict(list)
            // 
            // # Create the tax lines
            // for tax_line in tax_results['tax_lines_to_add']:
            //     tax_rep = self.env['account.tax.repartition.line'].browse(tax_line['tax_repartition_line_id'])
            //     aml_vals_list_per_nature['tax'].append({
            //         **tax_line,
            //         'tax_tag_invert': tax_rep.document_type == 'invoice',
            //     })
            //     total_amount_currency += tax_line['amount_currency']
            //     total_balance += tax_line['balance']
            // 
            // # Create the aml values for order lines.
            // for base_line_vals, update_base_line_vals in tax_results['base_lines_to_update']:
            //     order_line = base_line_vals['record']
            //     amount_currency = update_base_line_vals['amount_currency']
            //     balance = company_currency.round(amount_currency * rate)
            //     aml_vals_list_per_nature['product'].append({
            //         'name': order_line.full_product_name,
            //         'product_id': order_line.product_id.id,
            //         'quantity': order_line.qty * sign,
            //         'account_id': base_line_vals['account_id'].id,
            //         'partner_id': base_line_vals['partner_id'].id,
            //         'currency_id': base_line_vals['currency_id'].id,
            //         'tax_ids': [(6, 0, base_line_vals['tax_ids'].ids)],
            //         'tax_tag_ids': update_base_line_vals['tax_tag_ids'],
            //         'amount_currency': amount_currency,
            //         'balance': balance,
            //         'tax_tag_invert': not base_line_vals['is_refund'],
            //     })
            //     total_amount_currency += amount_currency
            //     total_balance += balance
            // 
            // # Cash rounding.
            // cash_rounding = self.config_id.rounding_method
            // if self.config_id.cash_rounding and cash_rounding and (not self.config_id.only_round_cash_method or any(p.payment_method_id.is_cash_count for p in self.payment_ids)):
            //     amount_currency = cash_rounding.compute_difference(self.currency_id, total_amount_currency)
            //     if not self.currency_id.is_zero(amount_currency):
            //         balance = company_currency.round(amount_currency * rate)
            // 
            //         if cash_rounding.strategy == 'biggest_tax':
            //             biggest_tax_aml_vals = None
            //             for aml_vals in aml_vals_list_per_nature['tax']:
            //                 if not biggest_tax_aml_vals or float_compare(-sign * aml_vals['amount_currency'], -sign * biggest_tax_aml_vals['amount_currency'], precision_rounding=self.currency_id.rounding) > 0:
            //                     biggest_tax_aml_vals = aml_vals
            //             if biggest_tax_aml_vals:
            //                 biggest_tax_aml_vals['amount_currency'] += amount_currency
            //                 biggest_tax_aml_vals['balance'] += balance
            //         elif cash_rounding.strategy == 'add_invoice_line':
            //             if -sign * amount_currency > 0.0 and cash_rounding.loss_account_id:
            //                 account_id = cash_rounding.loss_account_id.id
            //             else:
            //                 account_id = cash_rounding.profit_account_id.id
            //             aml_vals_list_per_nature['cash_rounding'].append({
            //                 'name': cash_rounding.name,
            //                 'account_id': account_id,
            //                 'partner_id': commercial_partner.id,
            //                 'currency_id': self.currency_id.id,
            //                 'amount_currency': amount_currency,
            //                 'balance': balance,
            //                 'display_type': 'rounding',
            //             })
            // 
            // # Stock.
            // if self.company_id.anglo_saxon_accounting and self.picking_ids.ids:
            //     stock_moves = self.env['stock.move'].sudo().search([
            //         ('picking_id', 'in', self.picking_ids.ids),
            //         ('product_id.categ_id.property_valuation', '=', 'real_time')
            //     ])
            //     for stock_move in stock_moves:
            //         expense_account = stock_move.product_id._get_product_accounts()['expense']
            //         stock_output_account = stock_move.product_id.categ_id.property_stock_account_output_categ_id
            //         balance = -sum(stock_move.stock_valuation_layer_ids.mapped('value'))
            //         aml_vals_list_per_nature['stock'].append({
            //             'name': _("Stock input for %s", stock_move.product_id.name),
            //             'account_id': expense_account.id,
            //             'partner_id': commercial_partner.id,
            //             'currency_id': self.company_id.currency_id.id,
            //             'amount_currency': balance,
            //             'balance': balance,
            //         })
            //         aml_vals_list_per_nature['stock'].append({
            //             'name': _("Stock output for %s", stock_move.product_id.name),
            //             'account_id': stock_output_account.id,
            //             'partner_id': commercial_partner.id,
            //             'currency_id': self.company_id.currency_id.id,
            //             'amount_currency': -balance,
            //             'balance': -balance,
            //         })
            // 
            // # sort self.payment_ids by is_split_transaction:
            // for payment_id in self.payment_ids:
            //     is_split_transaction = payment_id.payment_method_id.split_transactions
            //     if is_split_transaction:
            //         reversed_move_receivable_account_id = self.partner_id.property_account_receivable_id
            //     else:
            //         reversed_move_receivable_account_id = payment_id.payment_method_id.receivable_account_id or self.company_id.account_default_pos_receivable_account_id
            // 
            //     aml_vals_entry_found = [aml_entry for aml_entry in aml_vals_list_per_nature['payment_terms']
            //                             if aml_entry['account_id'] == reversed_move_receivable_account_id.id
            //                             and not aml_entry['partner_id']]
            // 
            //     if aml_vals_entry_found and not is_split_transaction:
            //         aml_vals_entry_found[0]['amount_currency'] += self.session_id._amount_converter(payment_id.amount, self.date_order, False)
            //         aml_vals_entry_found[0]['balance'] += payment_id.amount
            //     else:
            //         aml_vals_list_per_nature['payment_terms'].append({
            //             'partner_id': commercial_partner.id if is_split_transaction else False,
            //             'name': f"{reversed_move_receivable_account_id.code} {reversed_move_receivable_account_id.code}",
            //             'account_id': reversed_move_receivable_account_id.id,
            //             'currency_id': self.currency_id.id,
            //             'amount_currency': payment_id.amount,
            //             'balance': self.session_id._amount_converter(payment_id.amount, self.date_order, False),
            //         })
            // 
            // return aml_vals_list_per_nature
            */
            return default;
        }

        protected async Task<PosOrder> PrepareComboLineUuidsInternalAsync(object order_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_combo_line_uuids(self, order_vals):
            // acc = {}
            // lines = [line[2] for line in order_vals['lines'] if line[0] in [0, 1]]
            // 
            // for line in lines:
            //     if combo_line_ids := line.get('combo_line_ids'):
            //         acc[line['uuid']] = [l['uuid'] for l in lines if l.get('id') in combo_line_ids]
            // 
            //     line['combo_line_ids'] = False
            //     line['combo_parent_id'] = False
            // 
            // return acc
            */
            return default;
        }

        protected async Task<PosOrder> PrepareInvoiceLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_invoice_lines(self):
            // """ Prepare a list of orm commands containing the dictionaries to fill the
            // 'invoice_line_ids' field when creating an invoice.
            // 
            // :return: A list of Command.create to fill 'invoice_line_ids' when calling account.move.create.
            // """
            // line_values_list = self._prepare_tax_base_line_values()
            // invoice_lines = []
            // for line_values in line_values_list:
            //     line = line_values['record']
            //     invoice_lines_values = self._get_invoice_lines_values(line_values, line)
            //     if line.product_id.type == 'combo':
            //         quantity = int(invoice_lines_values['quantity']) if invoice_lines_values['quantity'] == int(invoice_lines_values['quantity']) else invoice_lines_values['quantity']
            //         invoice_lines.append(Command.create({
            //             'display_type': 'line_section',
            //             'name': f'{line.product_id.name} x {quantity}',
            //         }))
            //         continue
            // 
            //     invoice_lines.append((0, None, invoice_lines_values))
            //     is_percentage = self.pricelist_id and any(
            //         self.pricelist_id.item_ids.filtered(
            //             lambda rule: rule.compute_price == "percentage")
            //     )
            //     if is_percentage and float_compare(line.price_unit, line.product_id.lst_price, precision_rounding=self.currency_id.rounding) < 0:
            //         invoice_lines.append((0, None, {
            //             'name': _('Price discount from %(original_price)s to %(discounted_price)s',
            //                       original_price=float_repr(line.product_id.lst_price, self.currency_id.decimal_places),
            //                       discounted_price=float_repr(line.price_unit, self.currency_id.decimal_places)),
            //             'display_type': 'line_note',
            //         }))
            //     if line.customer_note:
            //         invoice_lines.append((0, None, {
            //             'name': line.customer_note,
            //             'display_type': 'line_note',
            //         }))
            // 
            // return invoice_lines
            */
            return default;
        }

        protected async Task<PosOrder> PrepareInvoiceValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_invoice_vals(self):
            // self.ensure_one()
            // timezone = pytz.timezone(self._context.get('tz') or self.env.user.tz or 'UTC')
            // invoice_date = fields.Datetime.now() if self.session_id.state == 'closed' else self.date_order
            // pos_refunded_invoice_ids = []
            // for orderline in self.lines:
            //     if orderline.refunded_orderline_id and orderline.refunded_orderline_id.order_id.account_move:
            //         pos_refunded_invoice_ids.append(orderline.refunded_orderline_id.order_id.account_move.id)
            // 
            // vals = {
            //     'invoice_origin': self.name,
            //     'pos_refunded_invoice_ids': pos_refunded_invoice_ids,
            //     'pos_order_ids': self.ids,
            //     'journal_id': self.session_id.config_id.invoice_journal_id.id,
            //     'move_type': 'out_invoice' if self.amount_total >= 0 else 'out_refund',
            //     'ref': self.name,
            //     'partner_id': self.partner_id.address_get(['invoice'])['invoice'],
            //     'partner_bank_id': self._get_partner_bank_id(),
            //     'currency_id': self.currency_id.id,
            //     'invoice_user_id': self.user_id.id,
            //     'invoice_date': invoice_date.astimezone(timezone).date(),
            //     'fiscal_position_id': self.fiscal_position_id.id,
            //     'invoice_line_ids': self._prepare_invoice_lines(),
            //     'invoice_payment_term_id': False,
            //     'invoice_cash_rounding_id': self.config_id.rounding_method.id,
            // }
            // if self.refunded_order_id.account_move:
            //     vals['ref'] = _('Reversal of: %s', self.refunded_order_id.account_move.name)
            //     vals['reversed_entry_id'] = self.refunded_order_id.account_move.id
            // if self.floating_order_name:
            //     vals.update({'narration': self.floating_order_name})
            // return vals
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _prepare_invoice_vals(self):
            // invoice_vals = super(PosOrder, self)._prepare_invoice_vals()
            // invoice_vals['team_id'] = self.crm_team_id.id
            // sale_orders = self.lines.mapped('sale_order_origin_id')
            // if sale_orders:
            //     if sale_orders[0].partner_invoice_id.id != sale_orders[0].partner_shipping_id.id:
            //         invoice_vals['partner_shipping_id'] = sale_orders[0].partner_shipping_id.id
            //     else:
            //         addr = self.partner_id.address_get(['delivery'])
            //         invoice_vals['partner_shipping_id'] = addr['delivery']
            //     if sale_orders[0].payment_term_id and not sale_orders[0].payment_term_id.early_discount:
            //         invoice_vals['invoice_payment_term_id'] = sale_orders[0].payment_term_id.id
            //     else:
            //         invoice_vals['invoice_payment_term_id'] = False
            //     if sale_orders[0].partner_invoice_id != sale_orders[0].partner_id:
            //         invoice_vals['partner_id'] = sale_orders[0].partner_invoice_id.id
            // return invoice_vals
            */
            return default;
        }

        protected async Task<PosOrder> PrepareMailValuesInternalAsync(object email, object ticket, object basic_ticket)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_mail_values(self, email, ticket, basic_ticket):
            // message = Markup(
            //     _("<p>Dear %(client_name)s,<br/>Here is your Receipt %(is_invoiced)sfor \
            //     %(pos_name)s amounting in %(amount)s from %(company_name)s. </p>")
            // ) % {
            //     'client_name': self.partner_id.name or _('Customer'),
            //     'pos_name': self.name,
            //     'amount': self.currency_id.format(self.amount_total),
            //     'company_name': self.company_id.name,
            //     'is_invoiced': "and Invoice " if self.account_move else "",
            // }
            // 
            // return {
            //     'subject': _('Receipt %s', self.name),
            //     'body_html': message,
            //     'author_id': self.env.user.partner_id.id,
            //     'email_from': self.env.company.email or self.env.user.email_formatted,
            //     'email_to': email,
            //     'attachment_ids': self._add_mail_attachment(self.name, ticket, basic_ticket),
            // }
            */
            return default;
        }

        protected async Task<PosOrder> PrepareOrderLineInternalAsync(object order_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def _prepare_order_line(self, order_line):
            // order_line = super()._prepare_order_line(order_line)
            // if order_line.get('sale_order_origin_id'):
            //     order_line['sale_order_origin_id'] = {
            //         'id': order_line['sale_order_origin_id'][0],
            //         'name': order_line['sale_order_origin_id'][1],
            //     }
            // if order_line.get('sale_order_line_id'):
            //     order_line['sale_order_line_id'] = {
            //         'id': order_line['sale_order_line_id'][0],
            //     }
            // return order_line
            */
            return default;
        }

        protected async Task<PosOrder> PrepareRefundValuesInternalAsync(object current_session)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_refund_values(self, current_session):
            // self.ensure_one()
            // return {
            //     'name': _('%(name)s REFUND', name=self.name),
            //     'session_id': current_session.id,
            //     'date_order': fields.Datetime.now(),
            //     'pos_reference': self.pos_reference,
            //     'lines': False,
            //     'amount_tax': -self.amount_tax,
            //     'amount_total': -self.amount_total,
            //     'amount_paid': 0,
            //     'is_total_cost_computed': False
            // }
            */
            return default;
        }

        protected async Task<PosOrder> PrepareTaxBaseLineValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_tax_base_line_values(self):
            // """ Convert pos order lines into dictionaries that would be used to compute taxes later.
            // 
            // :param sign: An optional parameter to force the sign of amounts.
            // :return: A list of python dictionaries (see '_prepare_base_line_for_taxes_computation' in account.tax).
            // """
            // self.ensure_one()
            // return self.lines._prepare_tax_base_line_values()
            */
            return default;
        }

        public async Task<PosOrder> PrintEventBadgesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def print_event_badges(self):
            // return self.env.ref('event.action_report_event_registration_badge').report_action(self.lines.event_registration_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> PrintEventTicketsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def print_event_tickets(self):
            // return self.env.ref('event.action_report_event_registration_full_page_ticket').report_action(self.lines.event_registration_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> ProcessOrderInternalAsync(object order, object existing_order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_order(self, order, existing_order):
            // """Create or update an pos.order from a given dictionary.
            // 
            // :param dict order: dictionary representing the order.
            // :param existing_order: order to be updated or False.
            // :type existing_order: pos.order.
            // :returns: id of created/updated pos.order
            // :rtype: int
            // """
            // draft = True if order.get('state') == 'draft' else False
            // pos_session = self.env['pos.session'].browse(order['session_id'])
            // if pos_session.state == 'closing_control' or pos_session.state == 'closed':
            //     order['session_id'] = self._get_valid_session(order).id
            // 
            // if order.get('partner_id'):
            //     partner_id = self.env['res.partner'].browse(order['partner_id'])
            //     if not partner_id.exists():
            //         order.update({
            //             "partner_id": False,
            //             "to_invoice": False,
            //         })
            // 
            // pos_order = False
            // combo_child_uuids_by_parent_uuid = self._prepare_combo_line_uuids(order)
            // 
            // if not existing_order:
            //     pos_order = self.create({
            //         **{key: value for key, value in order.items() if key != 'name'},
            //         'pos_reference': order.get('name')
            //     })
            //     pos_order = pos_order.with_company(pos_order.company_id)
            // else:
            //     pos_order = existing_order
            // 
            //     # If the order is belonging to another session, it must be moved to the current session first
            //     if order.get('session_id') and order['session_id'] != pos_order.session_id.id:
            //         pos_order.write({'session_id': order['session_id']})
            // 
            //     # Save lines and payments before to avoid exception if a line is deleted
            //     # when vals change the state to 'paid'
            //     for field in ['lines', 'payment_ids']:
            //         if order.get(field):
            //             existing_record_ids = self.env[pos_order[field]._name].browse([r[1] for r in order[field] if r[1] != 0]).exists().ids
            //             existing_records_vals = [r for r in order[field] if r[0] not in [1, 2, 3, 4] or r[1] in existing_record_ids]
            //             pos_order.write({field: existing_records_vals})
            //             order[field] = []
            // 
            //     del order['uuid']
            //     del order['access_token']
            //     pos_order.write(order)
            // 
            // pos_order._link_combo_items(combo_child_uuids_by_parent_uuid)
            // self = self.with_company(pos_order.company_id)
            // self._process_payment_lines(order, pos_order, pos_session, draft)
            // return pos_order._process_saved_order(draft)
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def _process_order(self, order, existing_order):
            // res = super()._process_order(order, existing_order)
            // refunded_line_ids = [line[2].get('refunded_orderline_id') for line in order.get('lines') if line[0] in [0, 1] and line[2].get('refunded_orderline_id')]
            // refunded_orderlines = self.env['pos.order.line'].browse(refunded_line_ids)
            // event_to_cancel = []
            // 
            // for refunded_orderline in refunded_orderlines:
            //     if refunded_orderline.event_registration_ids:
            //         refund_qty = abs(sum(refunded_orderline.refund_orderline_ids.mapped('qty')))
            //         already_cancelled_qty = len(refunded_orderline.event_registration_ids.filtered(lambda r: r.state == 'cancel'))
            //         to_cancel_qty = refund_qty - already_cancelled_qty
            //         if to_cancel_qty > 0:
            //             event_to_cancel += refunded_orderline.event_registration_ids.filtered(lambda registration: registration.state != 'cancel').ids[:int(to_cancel_qty)]
            // 
            // if event_to_cancel:
            //     self.env['event.registration'].browse(event_to_cancel).write({'state': 'cancel'})
            // 
            // return res
            */
            return default;
        }

        protected async Task<PosOrder> ProcessPaymentLinesInternalAsync(object pos_order, object order, object pos_session, object draft)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_payment_lines(self, pos_order, order, pos_session, draft):
            // """Create account.bank.statement.lines from the dictionary given to the parent function.
            // 
            // If the payment_line is an updated version of an existing one, the existing payment_line will first be
            // removed before making a new one.
            // :param pos_order: dictionary representing the order.
            // :type pos_order: dict.
            // :param order: Order object the payment lines should belong to.
            // :type order: pos.order
            // :param pos_session: PoS session the order was created in.
            // :type pos_session: pos.session
            // :param draft: Indicate that the pos_order is not validated yet.
            // :type draft: bool.
            // """
            // prec_acc = order.currency_id.decimal_places
            // 
            // # Recompute amount paid because we don't trust the client
            // order.with_context(backend_recomputation=True).write({'amount_paid': sum(order.payment_ids.mapped('amount'))})
            // 
            // if not draft and not float_is_zero(pos_order['amount_return'], prec_acc):
            //     cash_payment_method = pos_session.payment_method_ids.filtered('is_cash_count')[:1]
            //     if not cash_payment_method:
            //         raise UserError(_("No cash statement found for this session. Unable to record returned cash."))
            //     return_payment_vals = {
            //         'name': _('return'),
            //         'pos_order_id': order.id,
            //         'amount': -pos_order['amount_return'],
            //         'payment_date': fields.Datetime.now(),
            //         'payment_method_id': cash_payment_method.id,
            //         'is_change': True,
            //     }
            //     order.add_payment(return_payment_vals)
            //     order._compute_prices()
            */
            return default;
        }

        protected async Task<PosOrder> ProcessSavedOrderInternalAsync(object draft)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_saved_order(self, draft):
            // self.ensure_one()
            // if not draft and self.state != 'cancel':
            //     try:
            //         self.action_pos_order_paid()
            //     except psycopg2.DatabaseError:
            //         # do not hide transactional errors, the order(s) won't be saved!
            //         raise
            //     except Exception as e:
            //         _logger.error('Could not fully process the POS Order: %s', tools.exception_to_unicode(e))
            //     self._create_order_picking()
            //     self._compute_total_cost_in_real_time()
            // 
            // if self.to_invoice and self.state == 'paid':
            //     self._generate_pos_order_invoice()
            // 
            // return self.id
            */
            return default;
        }

        public async Task<PosOrder> ReadPosDataAsync(Guid id, PosOrderReadPosDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def read_pos_data(self, data, config_id):
            // # If the previous session is closed, the order will get a new session_id due to _get_valid_session in _process_order
            // session_ids = set({order.get('session_id') for order in data})
            // is_new_session = any(order.get('session_id') not in session_ids for order in data)
            // 
            // return {
            //     'pos.order': self.read(self._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.session': self.session_id._load_pos_data({})['data'] if config_id and is_new_session else [],
            //     'pos.payment': self.payment_ids.read(self.payment_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.order.line': self.lines.read(self.lines._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.pack.operation.lot': self.lines.pack_lot_ids.read(self.lines.pack_lot_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     "product.attribute.custom.value": self.lines.custom_attribute_value_ids.read(self.lines.custom_attribute_value_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def read_pos_data(self, data, config_id):
            // results = super().read_pos_data(data, config_id)
            // paid_orders = self.filtered_domain([('state', 'in', ['paid', 'done', 'invoiced'])])
            // 
            // if not paid_orders:
            //     return results
            // 
            // lines_with_event = paid_orders.mapped('lines').filtered(lambda line: line.event_ticket_id)
            // event_event_fields = self.env['event.event']._load_pos_data_fields(paid_orders[0].config_id.id)
            // event_ticket_fields = self.env['event.event.ticket']._load_pos_data_fields(paid_orders[0].config_id.id)
            // event_registrations_fields = self.env['event.registration']._load_pos_data_fields(paid_orders[0].config_id.id)
            // event_registrations_answer_fields = self.env['event.registration.answer']._load_pos_data_fields(paid_orders[0].config_id.id)
            // results['event.registration'] = lines_with_event.event_registration_ids.read(event_registrations_fields, load=False)
            // results['event.event'] = lines_with_event.event_registration_ids.mapped('event_id').read(event_event_fields, load=False)
            // results['event.event.ticket'] = lines_with_event.event_registration_ids.mapped('event_ticket_id').read(event_ticket_fields, load=False)
            // results['event.registration.answer'] = lines_with_event.event_registration_ids.mapped('registration_answer_ids').read(event_registrations_answer_fields, load=False)
            // 
            // for registration in lines_with_event.event_registration_ids:
            //     if registration.email:
            //         registration.action_send_badge_email()
            // 
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> RefundAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def refund(self):
            // return {
            //     'name': _('Return Products'),
            //     'view_mode': 'form',
            //     'res_model': 'pos.order',
            //     'res_id': self._refund().ids[0],
            //     'view_id': False,
            //     'context': self.env.context,
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> RefundInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _refund(self):
            // """ Create a copy of order to refund them.
            // 
            // return The newly created refund orders.
            // """
            // refund_orders = self.env['pos.order']
            // for order in self:
            //     # When a refund is performed, we are creating it in a session having the same config as the original
            //     # order. It can be the same session, or if it has been closed the new one that has been opened.
            //     current_session = order.session_id.config_id.current_session_id
            //     if not current_session:
            //         raise UserError(_('To return product(s), you need to open a session in the POS %s', order.session_id.config_id.display_name))
            //     refund_order = order.copy(
            //         order._prepare_refund_values(current_session)
            //     )
            //     for line in order.lines:
            //         PosOrderLineLot = self.env['pos.pack.operation.lot']
            //         for pack_lot in line.pack_lot_ids:
            //             PosOrderLineLot += pack_lot.copy()
            //         line.copy(line._prepare_refund_data(refund_order, PosOrderLineLot))
            //     refund_orders |= refund_order
            // return refund_orders
            */
            return default;
        }

        public async Task<PosOrder> RemoveFromUiAsync(Guid id, PosOrderRemoveFromUiRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def remove_from_ui(self, server_ids):
            // """ Remove orders from the frontend PoS application
            // 
            // Remove orders from the server by id.
            // :param server_ids: list of the id's of orders to remove from the server.
            // :type server_ids: list.
            // :returns: list -- list of db-ids for the removed orders.
            // """
            // orders = self.search([('id', 'in', server_ids), ('state', '=', 'draft')])
            // orders.write({'state': 'cancel'})
            // # TODO Looks like delete cascade is a better solution.
            // orders.mapped('payment_ids').sudo().unlink()
            // orders.sudo().unlink()
            // return orders.ids
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py) ---
            // def remove_from_ui(self, server_ids):
            // tables = self.env['pos.order'].search([('id', 'in', server_ids)]).table_id
            // order_ids = super().remove_from_ui(server_ids)
            // self.send_table_count_notification(tables)
            // return order_ids
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def remove_from_ui(self, server_ids):
            // order_ids = self.env['pos.order'].browse(server_ids)
            // order_ids.state = 'cancel'
            // self._send_notification(order_ids)
            // return super().remove_from_ui(server_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> SearchPaidOrderIdsAsync(Guid id, PosOrderSearchPaidOrderIdsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def search_paid_order_ids(self, config_id, domain, limit, offset):
            // """Search for 'paid' orders that satisfy the given domain, limit and offset."""
            // default_domain = [('state', '!=', 'draft'), ('state', '!=', 'cancel')]
            // if domain == []:
            //     real_domain = AND([[['config_id', '=', config_id]], default_domain])
            // else:
            //     real_domain = AND([domain, default_domain])
            // orders = self.search(real_domain, limit=limit, offset=offset, order='create_date desc')
            // # We clean here the orders that does not have the same currency.
            // # As we cannot use currency_id in the domain (because it is not a stored field),
            // # we must do it after the search.
            // pos_config = self.env['pos.config'].browse(config_id)
            // orders = orders.filtered(lambda order: order.currency_id == pos_config.currency_id)
            // orderlines = self.env['pos.order.line'].search(['|', ('refunded_orderline_id.order_id', 'in', orders.ids), ('order_id', 'in', orders.ids)])
            // 
            // # We will return to the frontend the ids and the date of their last modification
            // # so that it can compare to the last time it fetched the orders and can ask to fetch
            // # orders that are not up-to-date.
            // # The date of their last modification is either the last time one of its orderline has changed,
            // # or the last time a refunded orderline related to it has changed.
            // orders_info = defaultdict(lambda: datetime.min)
            // for orderline in orderlines:
            //     key_order = orderline.order_id.id if orderline.order_id in orders \
            //                     else orderline.refunded_orderline_id.order_id.id
            //     if orders_info[key_order] < orderline.write_date:
            //         orders_info[key_order] = orderline.write_date
            // totalCount = self.search_count(real_domain)
            // return {'ordersInfo': list(orders_info.items())[::-1], 'totalCount': totalCount}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> SearchTrackingNumberInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _search_tracking_number(self, operator, value):
            // #search is made over the pos_reference field
            // #The pos_reference field is like 'Order 00001-001-0001'
            // if operator in ['ilike', '='] and isinstance(value, str):
            //     if value[0] == '%' and value[-1] == '%':
            //         value = value[1:-1]
            //     value = value.zfill(3)
            //     search = '% ____' + value[0] + '-___-__' + value[1:]
            //     return [('pos_reference', operator, search or '')]
            // else:
            //     raise NotImplementedError(_("Unsupported search operation"))
            */
            return default;
        }

        public async Task<PosOrder> SendMailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_send_mail(self):
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('point_of_sale.pos_email_marketing_template', raise_if_not_found=False)
            // return {
            //     'name': _('Send Email'),
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_composition_mode': 'mass_mail', 'default_template_id': template_id},
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> SendNotificationInternalAsync(List<Guid> order_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def _send_notification(self, order_ids):
            // config_ids = order_ids.config_id
            // for config in config_ids:
            //     config.notify_synchronisation(config.current_session_id.id, self.env.context.get('login_number', 0))
            //     config._notify('ORDER_STATE_CHANGED', {})
            */
            return default;
        }

        protected async Task<PosOrder> SendOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _send_order(self):
            // # This function is made to be overriden by pos_self_order_preparation_display
            // pass
            */
            return default;
        }

        public async Task<PosOrder> SendReceiptAsync(Guid id, PosOrderSendReceiptRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_send_receipt(self, email, ticket_image, basic_image):
            // self.env['mail.mail'].sudo().create(self._prepare_mail_values(email, ticket_image, basic_image)).send()
            // self.email = email
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> SendTableCountNotificationAsync(Guid id, PosOrderSendTableCountNotificationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py) ---
            // def send_table_count_notification(self, table_ids):
            //  # Cannot remove the method in stable
            // pass
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> SentMessageOnSmsAsync(Guid id, PosOrderSentMessageOnSmsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sms, FILE: pos_order.py) ---
            // def action_sent_message_on_sms(self, phone, _, basic_image=False):
            // if not (self and self.config_id.module_pos_sms and self.config_id.sms_receipt_template_id and phone):
            //     return
            // self.ensure_one()
            // sms_composer = self.env['sms.composer'].with_context(active_id=self.id).create(
            //     {
            //         'composition_mode': 'comment',
            //         'numbers': phone,
            //         'recipient_single_number_itf': phone,
            //         'template_id': self.config_id.sms_receipt_template_id.id,
            //         'res_model': 'pos.order'
            //     }
            // )
            // self.mobile = phone
            // sms_composer.action_send_sms()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> ShouldCreatePickingRealTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _should_create_picking_real_time(self):
            // return not self.session_id.update_stock_at_closing or (self.company_id.anglo_saxon_accounting and self.to_invoice)
            */
            return default;
        }

        public async Task<PosOrder> StockPickingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_stock_picking(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_picking_tree_ready')
            // action['display_name'] = _('Pickings')
            // action['context'] = {}
            // action['domain'] = [('id', 'in', self.picking_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> SyncFromUiAsync(Guid id, PosOrderSyncFromUiRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def sync_from_ui(self, orders):
            // """ Create and update Orders from the frontend PoS application.
            // 
            // Create new orders and update orders that are in draft status. If an order already exists with a status
            // different from 'draft' it will be discarded, otherwise it will be saved to the database. If saved with
            // 'draft' status the order can be overwritten later by this function.
            // 
            // :param orders: dictionary with the orders to be created.
            // :type orders: dict.
            // :param draft: Indicate if the orders are meant to be finalized or temporarily saved.
            // :type draft: bool.
            // :Returns: list -- list of db-ids for the created and updated orders.
            // """
            // sync_token = randrange(100_000_000)  # Use to differentiate 2 parallels calls to this function in the logs
            // _logger.info("PoS synchronisation #%d started for PoS orders references: %s", sync_token, [self._get_order_log_representation(order) for order in orders])
            // order_ids = []
            // for order in orders:
            //     order_log_name = self._get_order_log_representation(order)
            //     _logger.debug("PoS synchronisation #%d processing order %s order full data: %s", sync_token, order_log_name, pformat(order))
            // 
            //     if len(self._get_refunded_orders(order)) > 1:
            //         raise ValidationError(_('You can only refund products from the same order.'))
            // 
            //     existing_order = self._get_open_order(order)
            //     if existing_order and existing_order.state == 'draft':
            //         order_ids.append(self._process_order(order, existing_order))
            //         _logger.info("PoS synchronisation #%d order %s updated pos.order #%d", sync_token, order_log_name, order_ids[-1])
            //     elif not existing_order:
            //         order_ids.append(self._process_order(order, False))
            //         _logger.info("PoS synchronisation #%d order %s created pos.order #%d", sync_token, order_log_name, order_ids[-1])
            //     else:
            //         # In theory, this situation is unintended
            //         # In practice it can happen when "Tip later" option is used
            //         order_ids.append(existing_order.id)
            //         _logger.info("PoS synchronisation #%d order %s sync ignored for existing PoS order %s (state: %s)", sync_token, order_log_name, existing_order, existing_order.state)
            // 
            // # Sometime pos_orders_ids can be empty.
            // pos_order_ids = self.env['pos.order'].browse(order_ids)
            // config_id = pos_order_ids.config_id.ids[0] if pos_order_ids else False
            // 
            // for order in pos_order_ids:
            //     order._ensure_access_token()
            //     if not self.env.context.get('preparation'):
            //         order.config_id.notify_synchronisation(order.config_id.current_session_id.id, self.env.context.get('login_number', 0))
            // 
            // _logger.info("PoS synchronisation #%d finished", sync_token)
            // return pos_order_ids.read_pos_data(orders, config_id)
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py) ---
            // def sync_from_ui(self, orders):
            // result = super().sync_from_ui(orders)
            // 
            // if self.env.context.get('table_ids'):
            //     order_ids = [order['id'] for order in result['pos.order']]
            //     table_orders = self.search([
            //         "&",
            //         ('table_id', 'in', self.env.context['table_ids']),
            //         ('state', '=', 'draft'),
            //         ('id', 'not in', order_ids)
            //     ])
            // 
            //     if len(table_orders) > 0:
            //         config_id = table_orders[0].config_id.id
            //         result['pos.order'].extend(table_orders.read(table_orders._load_pos_data_fields(config_id), load=False))
            //         result['pos.payment'].extend(table_orders.payment_ids.read(table_orders.payment_ids._load_pos_data_fields(config_id), load=False))
            //         result['pos.order.line'].extend(table_orders.lines.read(table_orders.lines._load_pos_data_fields(config_id), load=False))
            //         result['pos.pack.operation.lot'].extend(table_orders.lines.pack_lot_ids.read(table_orders.lines.pack_lot_ids._load_pos_data_fields(config_id), load=False))
            //         result["product.attribute.custom.value"].extend(table_orders.lines.custom_attribute_value_ids.read(table_orders.lines.custom_attribute_value_ids._load_pos_data_fields(config_id), load=False))
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def sync_from_ui(self, orders):
            // data = super().sync_from_ui(orders)
            // if len(orders) == 0:
            //     return data
            // 
            // order_ids = self.browse([o['id'] for o in data["pos.order"]])
            // for order in order_ids:
            //     for line in order.lines.filtered(lambda l: l.product_id == order.config_id.down_payment_product_id and l.qty != 0 and (l.sale_order_origin_id or l.refunded_orderline_id.sale_order_origin_id)):
            //         sale_lines = line.sale_order_origin_id.order_line or line.refunded_orderline_id.sale_order_origin_id.order_line
            //         sale_order_origin = line.sale_order_origin_id or line.refunded_orderline_id.sale_order_origin_id
            //         if not any(line.display_type and line.is_downpayment for line in sale_lines):
            //             self.env['sale.order.line'].create(
            //                 self.env['sale.advance.payment.inv']._prepare_down_payment_section_values(sale_order_origin)
            //             )
            //         order_reference = line.name
            // 
            //         if order.partner_id.lang and order.partner_id.lang != line.env.lang:
            //             line = line.with_context(lang=order.partner_id.lang)
            // 
            //         sale_order_line_description = _("Down payment (ref: %(order_reference)s on \n %(date)s)", order_reference=order_reference, date=format_date(line.env, line.order_id.date_order))
            //         sale_line = self.env['sale.order.line'].create({
            //             'order_id': sale_order_origin.id,
            //             'product_id': line.product_id.id,
            //             'price_unit': line.price_unit,
            //             'product_uom_qty': 0,
            //             'tax_id': [(6, 0, line.tax_ids.ids)],
            //             'is_downpayment': True,
            //             'discount': line.discount,
            //             'sequence': sale_lines and sale_lines[-1].sequence + 2 or 10,
            //             'name': sale_order_line_description
            //         })
            //         line.sale_order_line_id = sale_line
            // 
            //     so_lines = order.lines.mapped('sale_order_line_id')
            // 
            //     if order.state != 'draft':
            //         # confirm the unconfirmed sale orders that are linked to the sale order lines
            //         sale_orders = so_lines.mapped('order_id')
            //         for sale_order in sale_orders.filtered(lambda so: so.state in ['draft', 'sent']):
            //             sale_order.action_confirm()
            // 
            //     # update the demand qty in the stock moves related to the sale order line
            //     # flush the qty_delivered to make sure the updated qty_delivered is used when
            //     # updating the demand value
            //     so_lines.flush_recordset(['qty_delivered'])
            //     # track the waiting pickings
            //     waiting_picking_ids = set()
            //     for so_line in so_lines:
            //         so_line_stock_move_ids = so_line.move_ids.group_id.stock_move_ids
            //         for stock_move in so_line.move_ids:
            //             picking = stock_move.picking_id
            //             if not picking.state in ['waiting', 'confirmed', 'assigned']:
            //                 continue
            // 
            //             def get_expected_qty_to_ship_later():
            //                 pos_pickings = so_line.pos_order_line_ids.order_id.picking_ids
            //                 if pos_pickings and all(pos_picking.state in ['confirmed', 'assigned'] for pos_picking in pos_pickings):
            //                     return sum((so_line._convert_qty(so_line, pos_line.qty, 'p2s') for pos_line in
            //                                 so_line.pos_order_line_ids if so_line.product_id.type != 'service'), 0)
            //                 return 0
            // 
            //             qty_delivered = max(so_line.qty_delivered, get_expected_qty_to_ship_later())
            //             new_qty = so_line.product_uom_qty - qty_delivered
            //             if float_compare(new_qty, 0, precision_rounding=stock_move.product_uom.rounding) <= 0:
            //                 new_qty = 0
            //             stock_move.product_uom_qty = so_line.compute_uom_qty(new_qty, stock_move, False)
            //             # If the product is delivered with more than one step, we need to update the quantity of the other steps
            //             for move in so_line_stock_move_ids.filtered(lambda m: m.state in ['waiting', 'confirmed', 'assigned'] and m.product_id == stock_move.product_id):
            //                 move.product_uom_qty = stock_move.product_uom_qty
            //                 waiting_picking_ids.add(move.picking_id.id)
            //             waiting_picking_ids.add(picking.id)
            // 
            //     def is_product_uom_qty_zero(move):
            //         return float_is_zero(move.product_uom_qty, precision_rounding=move.product_uom.rounding)
            // 
            //     # cancel the waiting pickings if each product_uom_qty of move is zero
            //     for picking in self.env['stock.picking'].browse(waiting_picking_ids):
            //         if all(is_product_uom_qty_zero(move) for move in picking.move_ids):
            //             picking.action_cancel()
            //         else:
            //             # We make sure that the original picking still has the correct quantity reserved
            //             picking.action_assign()
            // 
            // return data
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py) ---
            // def sync_from_ui(self, orders):
            // for order in orders:
            //     if order.get('id'):
            //         order_id = order['id']
            // 
            //         if isinstance(order_id, int):
            //             old_order = self.env['pos.order'].browse(order_id)
            //             if old_order.takeaway:
            //                 order['takeaway'] = old_order.takeaway
            // 
            // result = super().sync_from_ui(orders)
            // order_ids = self.browse([order['id'] for order in result['pos.order'] if order.get('id')])
            // self._send_notification(order_ids)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosOrder> UnlinkExceptDraftOrCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _unlink_except_draft_or_cancel(self):
            // for pos_order in self.filtered(lambda pos_order: pos_order.state not in ['draft', 'cancel']):
            //     raise UserError(_('In order to delete a sale, it must be new or cancelled.'))
            */
            return default;
        }

        public async Task<PosOrder> ValidateCouponProgramsAsync(Guid id, PosOrderValidateCouponProgramsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py) ---
            // def validate_coupon_programs(self, point_changes, new_codes):
            // """
            // This is called upon validating the order in the pos.
            // 
            // This will check the balance for any pre-existing coupon to make sure that the rewards are in fact all claimable.
            // This will also check that any set code for coupons do not exist in the database.
            // """
            // point_changes = {int(k): v for k, v in point_changes.items()}
            // coupon_ids_from_pos = set(point_changes.keys())
            // coupons = self.env['loyalty.card'].browse(coupon_ids_from_pos).exists().filtered('program_id.active')
            // coupon_difference = set(coupons.ids) ^ coupon_ids_from_pos
            // if coupon_difference:
            //     return {
            //         'successful': False,
            //         'payload': {
            //             'message': _('Some coupons are invalid. The applied coupons have been updated. Please check the order.'),
            //             'removed_coupons': list(coupon_difference),
            //         }
            //     }
            // for coupon in coupons:
            //     if float_compare(coupon.points, -point_changes[coupon.id], 2) == -1:
            //         return {
            //             'successful': False,
            //             'payload': {
            //                 'message': _('There are not enough points for the coupon: %s.', coupon.code),
            //                 'updated_points': {c.id: c.points for c in coupons}
            //             }
            //         }
            // # Check existing coupons
            // coupons = self.env['loyalty.card'].search([('code', 'in', new_codes)])
            // if coupons:
            //     return {
            //         'successful': False,
            //         'payload': {
            //             'message': _('The following codes already exist in the database, perhaps they were already sold?\n%s',
            //                 ', '.join(coupons.mapped('code'))),
            //         }
            //     }
            // return {
            //     'successful': True,
            //     'payload': {},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> ViewAttendeeListAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py) ---
            // def action_view_attendee_list(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("event.event_registration_action_tree")
            // action['domain'] = [('pos_order_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> ViewInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_invoice(self):
            // return {
            //     'name': _('Customer Invoice'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('account.view_move_form').id,
            //     'res_model': 'account.move',
            //     'context': "{'move_type':'out_invoice'}",
            //     'type': 'ir.actions.act_window',
            //     'res_id': self.account_move.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> ViewRefundOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_refund_orders(self):
            // return {
            //     'name': _('Refund Orders'),
            //     'view_mode': 'list,form',
            //     'res_model': 'pos.order',
            //     'type': 'ir.actions.act_window',
            //     'domain': [('id', 'in', self.mapped('lines.refund_orderline_ids.order_id').ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> ViewRefundedOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_refunded_order(self):
            // return {
            //     'name': _('Refunded Order'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('point_of_sale.view_pos_pos_form').id,
            //     'res_model': 'pos.order',
            //     'type': 'ir.actions.act_window',
            //     'res_id': self.refunded_order_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosOrder> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def action_view_sale_order(self):
            // self.ensure_one()
            // linked_orders = self.lines.mapped('sale_order_origin_id')
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Linked Sale Orders'),
            //     'res_model': 'sale.order',
            //     'view_mode': 'list,form',
            //     'domain': [('id', 'in', linked_orders.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PosOrder entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def write(self, vals):
            // for order in self:
            //     if vals.get('state') and vals['state'] == 'paid' and order.name == '/':
            //         vals['name'] = self._compute_order_name()
            //     if vals.get('mobile'):
            //         vals['mobile'] = order._phone_format(number=vals.get('mobile'),
            //                 country=order.partner_id.country_id or self.env.company.country_id)
            //     if vals.get('has_deleted_line') is not None and self.has_deleted_line:
            //         del vals['has_deleted_line']
            //     allowed_vals = ['paid', 'done', 'invoiced']
            //     if vals.get('state') and vals['state'] not in allowed_vals and order.state in allowed_vals:
            //         raise UserError(_('This order has already been paid. You cannot set it back to draft or edit it.'))
            // 
            // list_line = self._create_pm_change_log(vals)
            // res = super().write(vals)
            // for order in self:
            //     if vals.get('payment_ids'):
            //         order.with_context(backend_recomputation=True)._compute_prices()
            //         totally_paid_or_more = float_compare(order.amount_paid, self._get_rounded_amount(order.amount_total), precision_rounding=order.currency_id.rounding)
            //         if totally_paid_or_more < 0 and order.state in ['paid', 'done', 'invoiced']:
            //             raise UserError(_('The paid amount is different from the total amount of the order.'))
            //         elif totally_paid_or_more > 0 and order.state == 'paid':
            //             list_line.append(_("Warning, the paid amount is higher than the total amount. (Difference: %s)", formatLang(self.env, order.amount_paid - order.amount_total, currency_obj=order.currency_id)))
            //         if order.nb_print > 0 and vals.get('payment_ids'):
            //             raise UserError(_('You cannot change the payment of a printed order.'))
            // 
            // if len(list_line) > 0:
            //     body = _("Payment changes:")
            //     body += self._markup_list_message(list_line)
            //     for order in self:
            //         if vals.get('payment_ids'):
            //             order.message_post(body=body)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py) ---
            // def write(self, vals):
            // # Because use_self_order_online_payment is not intended to be changed manually,
            // # avoid to raise an error.
            // if 'use_self_order_online_payment' not in vals:
            //     return super().write(vals)
            // 
            // can_change_self_order_domain = [('state', '=', 'draft')]
            // if vals['use_self_order_online_payment']:
            //     can_change_self_order_domain = expression.AND([can_change_self_order_domain, [('config_id.self_order_online_payment_method_id', '!=', False)]])
            // 
            // can_change_self_order_orders = self.filtered_domain(can_change_self_order_domain)
            // cannot_change_self_order_orders = self - can_change_self_order_orders
            // 
            // res = True
            // if can_change_self_order_orders:
            //     res = super(PosOrder, can_change_self_order_orders).write(vals) and res
            // if cannot_change_self_order_orders:
            //     clean_vals = vals.copy()
            //     clean_vals.pop('use_self_order_online_payment', None)
            //     res = super(PosOrder, cannot_change_self_order_orders).write(clean_vals) and res
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py) ---
            // def write(self, vals):
            // if 'crm_team_id' in vals:
            //     vals['crm_team_id'] = vals['crm_team_id'] if vals.get('crm_team_id') else self.session_id.crm_team_id.id
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}