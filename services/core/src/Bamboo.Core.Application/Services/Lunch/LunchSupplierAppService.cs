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
    [Module("Lunch", Depends = new[] { "mail" })]
    public class LunchSupplierAppService : GenericApplicationService<LunchSupplier>, ILunchSupplierAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public LunchSupplierAppService(IRepository<LunchSupplier, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<LunchSupplier> AvailableOnDateInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _available_on_date(self, date):
            // self.ensure_one()
            // 
            // fieldname = WEEKDAY_TO_NAME[date.weekday()]
            // return not (self.recurrency_end_date and date.date() >= self.recurrency_end_date) and self[fieldname]
            */
            return default;
        }

        protected async Task<LunchSupplier> CancelFutureDaysInternalAsync(object weekdays)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _cancel_future_days(self, weekdays):
            // weekdays_n = [WEEKDAY_TO_NAME.index(wd) for wd in weekdays]
            // self.env['lunch.order'].search([
            //     ('supplier_id', 'in', self.ids),
            //     ('state', 'in', ('new', 'ordered')),
            //     ('date', '>=', fields.Date.context_today(self.with_context(tz=self.tz))),
            // ]).filtered(lambda lo: lo.date.weekday() in weekdays_n).write({'state': 'cancelled'})
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeAvailableTodayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _compute_available_today(self):
            // now = fields.Datetime.now().replace(tzinfo=pytz.UTC)
            // 
            // for supplier in self:
            //     supplier_date = now.astimezone(pytz.timezone(supplier.tz))
            //     supplier.available_today = supplier._available_on_date(supplier_date)
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeButtonsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _compute_buttons(self):
            // self.env.cr.execute("""
            //     SELECT supplier_id, state, COUNT(*)
            //       FROM lunch_order
            //      WHERE supplier_id IN %s
            //        AND state in ('ordered', 'sent')
            //        AND date = %s
            //        AND active
            //   GROUP BY supplier_id, state
            // """, (tuple(self.ids), fields.Date.context_today(self)))
            // supplier_orders = defaultdict(dict)
            // for order in self.env.cr.fetchall():
            //     supplier_orders[order[0]][order[1]] = order[2]
            // for supplier in self:
            //     supplier.show_order_button = supplier_orders[supplier.id].get('ordered', False)
            //     supplier.show_confirm_button = supplier_orders[supplier.id].get('sent', False)
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _compute_display_name(self):
            // for supplier in self:
            //     if supplier.phone:
            //         supplier.display_name = f'{supplier.name} {supplier.phone}'
            //     else:
            //         supplier.display_name = supplier.name
            */
            return default;
        }

        protected async Task<LunchSupplier> ComputeOrderDeadlinePassedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _compute_order_deadline_passed(self):
            // now = fields.Datetime.now().replace(tzinfo=pytz.UTC)
            // 
            // for supplier in self:
            //     if supplier.send_by == 'mail':
            //         now = now.astimezone(pytz.timezone(supplier.tz))
            //         email_time = pytz.timezone(supplier.tz).localize(datetime.combine(
            //             fields.Date.context_today(supplier),
            //             float_to_time(supplier.automatic_email_time, supplier.moment)))
            //         supplier.order_deadline_passed = supplier.available_today and now > email_time
            //     else:
            //         supplier.order_deadline_passed = not supplier.available_today
            */
            return default;
        }

        public async Task<LunchSupplier> ConfirmOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def action_confirm_orders(self):
            // orders = self._get_current_orders(state='sent')
            // orders.action_confirm()
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('The orders have been confirmed!'),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LunchSupplier> GetCurrentOrdersInternalAsync(object state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _get_current_orders(self, state='ordered'):
            // """ Returns today's orders """
            // available_today = self.filtered('available_today')
            // if not available_today:
            //     return self.env['lunch.order']
            // 
            // orders = self.env['lunch.order'].search([
            //     ('supplier_id', 'in', available_today.ids),
            //     ('state', '=', state),
            //     ('date', '=', fields.Date.context_today(self.with_context(tz=self.tz))),
            // ], order="user_id, product_id")
            // return orders
            */
            return default;
        }

        protected async Task<LunchSupplier> SearchAvailableTodayInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _search_available_today(self, operator, value):
            // if (not operator in ['=', '!=']) or (not value in [True, False]):
            //     return []
            // 
            // searching_for_true = (operator == '=' and value) or (operator == '!=' and not value)
            // 
            // now = fields.Datetime.now().replace(tzinfo=pytz.UTC).astimezone(pytz.timezone(self.env.user.tz or 'UTC'))
            // fieldname = WEEKDAY_TO_NAME[now.weekday()]
            // 
            // recurrency_domain = expression.OR([
            //     [('recurrency_end_date', '=', False)],
            //     [('recurrency_end_date', '>' if searching_for_true else '<', now)]
            // ])
            // 
            // return expression.AND([
            //     recurrency_domain,
            //     [(fieldname, operator, value)]
            // ])
            */
            return default;
        }

        protected async Task<LunchSupplier> SendAutoEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _send_auto_email(self):
            // """ Send an email to the supplier with the order of the day """
            // # Called daily by cron
            // self.ensure_one()
            // 
            // if not self.available_today:
            //     return
            // 
            // if self.send_by != 'mail':
            //     raise UserError(_("Cannot send an email to this supplier!"))
            // 
            // orders = self._get_current_orders()
            // if not orders:
            //     return
            // 
            // order = {
            //     'company_name': orders[0].company_id.name,
            //     'currency_id': orders[0].currency_id.id,
            //     'supplier_id': self.partner_id.id,
            //     'supplier_name': self.name,
            //     'email_from': self.responsible_id.email_formatted,
            //     'amount_total': sum(order.price for order in orders),
            // }
            // 
            // sites = orders.mapped('user_id.last_lunch_location_id').sorted(lambda x: x.name)
            // orders_per_site = orders.sorted(lambda x: x.user_id.last_lunch_location_id.id)
            // 
            // email_orders = [{
            //     'product': order.product_id.name,
            //     'note': order.note,
            //     'quantity': order.quantity,
            //     'price': order.price,
            //     'toppings': order.display_toppings,
            //     'username': order.user_id.name,
            //     'site': order.user_id.last_lunch_location_id.name,
            // } for order in orders_per_site]
            // 
            // email_sites = [{
            //     'name': site.name,
            //     'address': site.address,
            // } for site in sites]
            // 
            // self.env.ref('lunch.lunch_order_mail_supplier').with_context(
            //     order=order, lines=email_orders, sites=email_sites
            // ).send_mail(self.id)
            // 
            // orders.action_send()
            */
            return default;
        }

        public async Task<LunchSupplier> SendOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def action_send_orders(self):
            // no_auto_mail = self.filtered(lambda s: s.send_by != 'mail')
            // 
            // for supplier in self - no_auto_mail:
            //     supplier._send_auto_email()
            // orders = no_auto_mail._get_current_orders()
            // orders.action_send()
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('The orders have been sent!'),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LunchSupplier> SyncCronInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def _sync_cron(self):
            // for supplier in self:
            //     supplier = supplier.with_context(tz=supplier.tz)
            // 
            //     sendat_tz = pytz.timezone(supplier.tz).localize(datetime.combine(
            //         fields.Date.context_today(supplier),
            //         float_to_time(supplier.automatic_email_time, supplier.moment)))
            //     cron = supplier.cron_id.sudo()
            //     lc = cron.lastcall
            //     if ((
            //         lc and sendat_tz.date() <= fields.Datetime.context_timestamp(supplier, lc).date()
            //     ) or (
            //         not lc and sendat_tz <= fields.Datetime.context_timestamp(supplier, fields.Datetime.now())
            //     )):
            //         sendat_tz += timedelta(days=1)
            //     sendat_utc = sendat_tz.astimezone(pytz.UTC).replace(tzinfo=None)
            // 
            //     cron.active = supplier.active and supplier.send_by == 'mail'
            //     cron.name = f"Lunch: send automatic email to {supplier.name}"
            //     cron.nextcall = sendat_utc
            //     cron.code = dedent(f"""\
            //         # This cron is dynamically controlled by {self._description}.
            //         # Do NOT modify this cron, modify the related record instead.
            //         env['{self._name}'].browse([{supplier.id}])._send_auto_email()""")
            */
            return default;
        }

        public async Task<LunchSupplier> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py) ---
            // def toggle_active(self):
            // """ Archiving related lunch product """
            // res = super().toggle_active()
            // active_suppliers = self.filtered(lambda s: s.active)
            // inactive_suppliers = self - active_suppliers
            // Product = self.env['lunch.product'].with_context(active_test=False)
            // Product.search([('supplier_id', 'in', active_suppliers.ids)]).write({'active': True})
            // Product.search([('supplier_id', 'in', inactive_suppliers.ids)]).write({'active': False})
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}