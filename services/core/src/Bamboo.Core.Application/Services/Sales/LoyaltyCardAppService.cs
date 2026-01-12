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
    [Module("Loyalty", Category = "Sales", Depends = new[] { "product", "portal", "account" })]
    public class LoyaltyCardAppService : GenericApplicationService<LoyaltyCard>, ILoyaltyCardAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public LoyaltyCardAppService(IRepository<LoyaltyCard, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<LoyaltyCard> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _compute_display_name(self):
            // for card in self:
            //     card.display_name = f'{card.program_id.name}: {card.code}'
            */
            return default;
        }

        protected async Task<LoyaltyCard> ComputePointsDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _compute_points_display(self):
            // for card in self:
            //     card.points_display = card._format_points(card.points)
            */
            return default;
        }

        protected async Task<LoyaltyCard> ComputeUseCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _compute_use_count(self):
            // self.use_count = 0
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _compute_use_count(self):
            // super()._compute_use_count()
            // read_group_res = self.env['pos.order.line']._read_group(
            //     [('coupon_id', 'in', self.ids)], ['coupon_id'], ['__count'])
            // count_per_coupon = {coupon.id: count for coupon, count in read_group_res}
            // for card in self:
            //     card.use_count += count_per_coupon.get(card.id, 0)
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _compute_use_count(self):
            // super()._compute_use_count()
            // read_group_res = self.env['sale.order.line']._read_group(
            //     [('coupon_id', 'in', self.ids)], ['coupon_id'], ['__count'])
            // count_per_coupon = {coupon.id: count for coupon, count in read_group_res}
            // for card in self:
            //     card.use_count += count_per_coupon.get(card.id, 0)
            */
            return default;
        }

        protected async Task<LoyaltyCard> ContrainsCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _contrains_code(self):
            // # Prevent a coupon from having the same code a program
            // if self.env['loyalty.rule'].search_count([('mode', '=', 'with_code'), ('code', 'in', self.mapped('code'))]):
            //     raise ValidationError(_('A trigger with the same code as one of your coupon already exists.'))
            */
            return default;
        }

        public async Task<LoyaltyCard> CouponSendAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def action_coupon_send(self):
            // """ Open a window to compose an email, with the default template returned by `_get_default_template`
            //     message loaded by default
            // """
            // self.ensure_one()
            // default_template = self._get_default_template()
            // compose_form = self.env.ref('mail.email_compose_message_wizard_form', False)
            // ctx = dict(
            //     default_model='loyalty.card',
            //     default_res_ids=self.ids,
            //     default_template_id=default_template and default_template.id,
            //     default_composition_mode='comment',
            //     default_email_layout_xmlid='mail.mail_notification_light',
            //     force_email=True,
            // )
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form.id, 'form')],
            //     'view_id': compose_form.id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LoyaltyCard> CouponShareAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_card.py) ---
            // def action_coupon_share(self):
            // self.ensure_one()
            // return self.env['coupon.share'].create_share_action(coupon=self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LoyaltyCard> FormatPointsInternalAsync(object points)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _format_points(self, points):
            // self.ensure_one()
            // if self.point_name == self.program_id.currency_id.symbol:
            //     return format_amount(self.env, points, self.program_id.currency_id)
            // if points == int(points):
            //     return f"{int(points)} {self.point_name or ''}"
            // return f"{points:.2f} {self.point_name or ''}"
            */
            return default;
        }

        protected async Task<LoyaltyCard> GenerateCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _generate_code(self):
            // """
            // Barcode identifiable codes.
            // """
            // return '044' + str(uuid4())[7:-18]
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetDefaultTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _get_default_template(self):
            // self.ensure_one()
            // return self.program_id.communication_plan_ids.filtered(lambda m: m.trigger == 'create').mail_template_id[:1]
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _get_default_template(self):
            // self.ensure_one()
            // if self.source_pos_order_id:
            //     return self.env.ref('pos_loyalty.mail_coupon_template', False)
            // return super()._get_default_template()
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _get_default_template(self):
            // default_template = super()._get_default_template()
            // if not default_template:
            //     default_template = self.env.ref('loyalty.mail_template_loyalty_card', raise_if_not_found=False)
            // return default_template
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetMailAuthorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _get_mail_author(self):
            // self.ensure_one()
            // return (
            //     self.env.user._is_internal() and self.env.user or self.company_id or self.env.company
            // ).partner_id
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _get_mail_author(self):
            // # Default author is the order's salesperson if available, else the order's company.
            // if not self.order_id or self.order_id.sudo().company_id not in self.env.companies:
            //     return super()._get_mail_author()
            // self.ensure_one()
            // return (self.order_id.user_id or self.order_id.company_id).partner_id
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetMailPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _get_mail_partner(self):
            // self.ensure_one()
            // return self.partner_id
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _get_mail_partner(self):
            // return super()._get_mail_partner() or self.sudo().source_pos_order_id.partner_id
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _get_mail_partner(self):
            // return super()._get_mail_partner() or self.order_id.partner_id
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetSignatureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _get_signature(self):
            // """To be overriden"""
            // self.ensure_one()
            // return None
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _get_signature(self):
            // return self.source_pos_order_id.user_id.signature or super()._get_signature()
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _get_signature(self):
            // return self.order_id.user_id.signature or super()._get_signature()
            */
            return default;
        }

        protected async Task<LoyaltyCard> HasSourceOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _has_source_order(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _has_source_order(self):
            // return super()._has_source_order() or bool(self.source_pos_order_id)
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py) ---
            // def _has_source_order(self):
            // return super()._has_source_order() or bool(self.order_id)
            */
            return default;
        }

        protected async Task<LoyaltyCard> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('program_id', 'in', [program["id"] for program in data["loyalty.program"]['data']])]
            */
            return default;
        }

        protected async Task<LoyaltyCard> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['partner_id', 'code', 'points', 'program_id', 'expiration_date', 'write_date']
            */
            return default;
        }

        public async Task<LoyaltyCard> LoyaltyUpdateBalanceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def action_loyalty_update_balance(self):
            // return {
            //     'name': _("Update Balance"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'loyalty.card.update.balance',
            //     'target': 'new',
            //     'context': {
            //         'default_card_id': self.id,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LoyaltyCard> RestrictExpirationOnLoyaltyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _restrict_expiration_on_loyalty(self):
            // for card in self:
            //     if card.program_type == 'loyalty' and card.expiration_date:
            //         raise ValidationError(_("Expiration date cannot be set on a loyalty card."))
            */
            return default;
        }

        protected async Task<LoyaltyCard> SendCreationCommunicationInternalAsync(object force_send)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _send_creation_communication(self, force_send=False):
            // """
            // Sends the 'At Creation' communication plan if it exist for the given coupons.
            // """
            // if self.env.context.get('loyalty_no_mail', False) or self.env.context.get('action_no_send_mail', False):
            //     return
            // # Ideally one per program, but multiple is supported
            // create_comm_per_program = dict()
            // for program in self.program_id:
            //     create_comm_per_program[program] = program.communication_plan_ids.filtered(lambda c: c.trigger == 'create')
            // for coupon in self:
            //     if not create_comm_per_program[coupon.program_id] or not coupon._get_mail_partner():
            //         continue
            //     for comm in create_comm_per_program[coupon.program_id]:
            //         mail_template = comm.mail_template_id
            //         email_values = {}
            //         if not mail_template.email_from:
            //             # provide author_id & email_from values to ensure the email gets sent
            //             author = coupon._get_mail_author()
            //             email_values.update(author_id=author.id, email_from=author.email_formatted)
            //         mail_template.send_mail(
            //             res_id=coupon.id,
            //             force_send=force_send,
            //             email_layout_xmlid='mail.mail_notification_light',
            //             email_values=email_values,
            //         )
            */
            return default;
        }

        protected async Task<LoyaltyCard> SendPointsReachCommunicationInternalAsync(object points_changes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py) ---
            // def _send_points_reach_communication(self, points_changes):
            // """
            // Send the 'When Reaching' communicaton plans for the given coupons.
            // 
            // If a coupons passes multiple milestones we will only send the one with the highest target.
            // """
            // if self.env.context.get('loyalty_no_mail', False):
            //     return
            // milestones_per_program = dict()
            // for program in self.program_id:
            //     milestones_per_program[program] = program.communication_plan_ids\
            //         .filtered(lambda c: c.trigger == 'points_reach')\
            //         .sorted('points', reverse=True)
            // for coupon in self:
            //     if not coupon._get_mail_partner():
            //         continue
            //     coupon_change = points_changes[coupon]
            //     # Do nothing if coupon lost points or did not change
            //     if not milestones_per_program[coupon.program_id] or\
            //         not coupon.partner_id or\
            //         coupon_change['old'] >= coupon_change['new']:
            //         continue
            //     this_milestone = False
            //     for milestone in milestones_per_program[coupon.program_id]:
            //         if coupon_change['old'] < milestone.points and milestone.points <= coupon_change['new']:
            //             this_milestone = milestone
            //             break
            //     if not this_milestone:
            //         continue
            //     this_milestone.mail_template_id.send_mail(res_id=coupon.id, email_layout_xmlid='mail.mail_notification_light')
            */
            return default;
        }
    }
}