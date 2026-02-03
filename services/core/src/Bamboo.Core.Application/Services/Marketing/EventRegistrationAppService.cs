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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Event", Category = "Marketing", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public partial class EventRegistrationAppService : GenericAppService<EventRegistration>, IEventRegistrationAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public EventRegistrationAppService(IRepository<EventRegistration, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<EventRegistration> ApplyLeadGenerationRulesInternalAsync(object event_lead_rules)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _apply_lead_generation_rules(self, event_lead_rules=False):
            // leads = self.env['crm.lead']
            // open_registrations = self.filtered(lambda reg: reg.state == 'open')
            // done_registrations = self.filtered(lambda reg: reg.state == 'done')
            // 
            // if not event_lead_rules:
            //     search_triggers = ['create']
            //     if open_registrations:
            //         search_triggers.append('confirm')
            //     if done_registrations:
            //         search_triggers.append('done')
            //     event_lead_rules = self.env['event.lead.rule'].search([('lead_creation_trigger', 'in', search_triggers)])
            // 
            // create_lead_rules = event_lead_rules.filtered(lambda rule: rule.lead_creation_trigger == 'create')
            // leads += create_lead_rules.sudo()._run_on_registrations(self)
            // if open_registrations:
            //     confirm_lead_rules = event_lead_rules.filtered(lambda rule: rule.lead_creation_trigger == 'confirm')
            //     leads += confirm_lead_rules.sudo()._run_on_registrations(open_registrations)
            // if done_registrations:
            //     done_lead_rules = event_lead_rules.filtered(lambda rule: rule.lead_creation_trigger == 'done')
            //     leads += done_lead_rules.sudo()._run_on_registrations(done_registrations)
            // return leads
            */
            return default;
        }

        public async Task<EventRegistration> CancelAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def action_cancel(self):
            // self.write({'state': 'cancel'})
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<EventRegistration> CheckEventSlotInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _check_event_slot(self):
            // if any(registration.event_id != registration.event_slot_id.event_id for registration in self if registration.event_slot_id):
            //     raise ValidationError(_('Invalid event / slot choice'))
            // if any(not registration.event_slot_id for registration in self if registration.is_multi_slots):
            //     raise ValidationError(_('Slot choice is mandatory on multi-slots events.'))
            */
            return default;
        }

        protected async Task<EventRegistration> CheckEventTicketInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _check_event_ticket(self):
            // if any(registration.event_id != registration.event_ticket_id.event_id for registration in self if registration.event_ticket_id):
            //     raise ValidationError(_('Invalid event / ticket choice'))
            */
            return default;
        }

        protected async Task<EventRegistration> CheckSeatsAvailabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _check_seats_availability(self):
            // tocheck = self.filtered(lambda registration: registration.state in ('open', 'done') and registration.active)
            // for event, registrations in tocheck.grouped('event_id').items():
            //     event._verify_seats_availability([
            //         (slot, ticket, 0)
            //         for slot, ticket in self.env['event.registration']._read_group(
            //             [('id', 'in', registrations.ids)],
            //             ['event_slot_id', 'event_ticket_id']
            //         )
            //     ])
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeCompanyNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_company_name(self):
            // for registration in self:
            //     if not registration.company_name and registration.partner_id:
            //         registration.company_name = registration._synchronize_partner_values(
            //             registration.partner_id,
            //             fnames={'company_name'},
            //         ).get('company_name') or False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDateClosedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_date_closed(self):
            // for registration in self:
            //     if not registration.date_closed:
            //         if registration.state == 'done':
            //             registration.date_closed = self.env.cr.now()
            //         else:
            //             registration.date_closed = False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDateRangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_date_range(self):
            // for registration in self:
            //     registration.event_date_range = registration.event_id._get_date_range_str(
            //         start_datetime=registration.event_slot_id.start_datetime,
            //         lang_code=registration.partner_id.lang,
            //     )
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_display_name(self):
            // """ Custom display_name in case a registration is nott linked to an attendee
            // """
            // for registration in self:
            //     registration.display_name = registration.name or f"#{registration.id}"
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_email(self):
            // for registration in self:
            //     if not registration.email and registration.partner_id:
            //         registration.email = registration._synchronize_partner_values(
            //             registration.partner_id,
            //             fnames={'email'},
            //         ).get('email') or False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEventBeginDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_event_begin_date(self):
            // for registration in self:
            //     registration.event_begin_date = registration.event_slot_id.start_datetime or registration.event_id.date_begin
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEventEndDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_event_end_date(self):
            // for registration in self:
            //     registration.event_end_date = registration.event_slot_id.end_datetime or registration.event_id.date_end
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _compute_field_value(self, field):
            // if field.name != 'state':
            //     return super()._compute_field_value(field)
            // 
            // unconfirmed = self.filtered(lambda reg: reg.ids and reg.state in {'draft', 'cancel'})
            // res = super()._compute_field_value(field)
            // confirmed = unconfirmed.filtered(lambda reg: reg.state == 'open')
            // if confirmed:
            //     confirmed._update_mail_schedulers()
            // return res
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _compute_lead_count(self):
            // for record in self:
            //     record.lead_count = len(record.lead_ids)
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_name(self):
            // for registration in self:
            //     if not registration.name and registration.partner_id:
            //         registration.name = registration._synchronize_partner_values(
            //             registration.partner_id,
            //             fnames={'name'},
            //         ).get('name') or False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputePhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _compute_phone(self):
            // for registration in self:
            //     if not registration.phone and registration.partner_id:
            //         partner_values = registration._synchronize_partner_values(
            //             registration.partner_id,
            //             fnames={'phone'},
            //         )
            //         registration.phone = partner_values.get('phone') or False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeRegistrationStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: event_registration.py) ---
            // def _compute_registration_status(self):
            // if not self._has_order():
            //     for reg in self:
            //         if not reg.sale_status:
            //             reg.sale_status = 'free'
            //         if not reg.state:
            //             reg.state = 'open'
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _compute_registration_status(self):
            // for sale_order, registrations in self.filtered('sale_order_id').grouped('sale_order_id').items():
            //     cancelled_so_registrations = registrations.filtered(lambda reg: reg.sale_order_id.state == 'cancel')
            //     cancelled_so_registrations.state = 'cancel'
            //     cancelled_registrations = cancelled_so_registrations | registrations.filtered(lambda reg: reg.state == 'cancel')
            //     if float_is_zero(sale_order.amount_total, precision_rounding=sale_order.currency_id.rounding):
            //         registrations.sale_status = 'free'
            //         registrations.filtered(lambda reg: not reg.state or reg.state == 'draft').state = "open"
            //     else:
            //         sold_registrations = registrations.filtered(lambda reg: reg.sale_order_id.state == 'sale') - cancelled_registrations
            //         sold_registrations.sale_status = 'sold'
            //         (registrations - sold_registrations).sale_status = 'to_pay'
            //         sold_registrations.filtered(lambda reg: not reg.state or reg.state in {'draft', 'cancel'}).state = "open"
            //         (registrations - sold_registrations - cancelled_registrations).state = 'draft'
            // super()._compute_registration_status()
            // 
            // # set default value to free and open if none was set yet
            // for registration in self:
            //     if not registration.sale_status:
            //         registration.sale_status = 'free'
            //     if not registration.state:
            //         registration.state = 'open'
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def _compute_registration_status(self):
            // if self.pos_order_id:
            //     for registration in self:
            //         if registration.pos_order_id.state == 'cancel':
            //             registration.state = 'cancel'
            //         elif float_is_zero(registration.pos_order_id.amount_total, precision_rounding=registration.pos_order_id.currency_id.rounding):
            //             registration.sale_status = 'free'
            //             registration.state = 'open'
            //         else:
            //             registration.sale_status = 'sold'
            //             registration.state = 'open'
            // 
            // super()._compute_registration_status()
            --- ODOO METHOD SOURCE (MODULE: pos_event_sale, FILE: event_registration.py) ---
            // def _compute_registration_status(self):
            // super()._compute_registration_status()
            // for record in self.filtered("pos_order_id.id"):
            //     if record.pos_order_id.state in ['paid', 'done', 'invoiced']:
            //         record.sale_status = 'sold'
            //         record.state = 'open'
            //     else:
            //         record.sale_status = 'to_pay'
            //         record.state = 'draft'
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmCampaignIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _compute_utm_campaign_id(self):
            // for registration in self:
            //     if registration.sale_order_id.campaign_id:
            //         registration.utm_campaign_id = registration.sale_order_id.campaign_id
            //     elif not registration.utm_campaign_id:
            //         registration.utm_campaign_id = False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmMediumIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _compute_utm_medium_id(self):
            // for registration in self:
            //     if registration.sale_order_id.medium_id:
            //         registration.utm_medium_id = registration.sale_order_id.medium_id
            //     elif not registration.utm_medium_id:
            //         registration.utm_medium_id = False
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmSourceIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _compute_utm_source_id(self):
            // for registration in self:
            //     if registration.sale_order_id.source_id:
            //         registration.utm_source_id = registration.sale_order_id.source_id
            //     elif not registration.utm_source_id:
            //         registration.utm_source_id = False
            */
            return default;
        }

        public async Task<EventRegistration> ConfirmAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def action_confirm(self):
            // self.write({'state': 'open'})
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<EventRegistration> ConvertValueInternalAsync(object @value, object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _convert_value(self, value, field_name):
            // """ Small tool because convert_to_write is touchy """
            // if isinstance(value, models.BaseModel) and self._fields[field_name].type in ['many2many', 'one2many']:
            //     return value.ids
            // if isinstance(value, models.BaseModel) and self._fields[field_name].type == 'many2one':
            //     return value.id
            // return value
            */
            return default;
        }

        public override async Task<EventRegistration> CreateAsync(CreateRequestDto<EventRegistration> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def create(self, vals_list):
            // # format numbers: prefetch side records, then try to format according to country
            // all_partner_ids = set(values['partner_id'] for values in vals_list if values.get('partner_id'))
            // all_event_ids = set(values['event_id'] for values in vals_list if values.get('event_id'))
            // for values in vals_list:
            //     if not values.get('phone'):
            //         continue
            // 
            //     related_country = self.env['res.country']
            //     if values.get('partner_id'):
            //         related_country = self.env['res.partner'].with_prefetch(all_partner_ids).browse(values['partner_id']).country_id
            //     if not related_country and values.get('event_id'):
            //         related_country = self.env['event.event'].with_prefetch(all_event_ids).browse(values['event_id']).country_id
            //     if not related_country:
            //         related_country = self.env.company.country_id
            //     values['phone'] = self._phone_format(number=values['phone'], country=related_country) or values['phone']
            // 
            // registrations = super().create(vals_list)
            // registrations._update_mail_schedulers()
            // return registrations
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def create(self, vals_list):
            // """ Trigger rules based on registration creation, and check state for
            // rules based on confirmed / done attendees. """
            // registrations = super(EventRegistration, self).create(vals_list)
            // 
            // # handle triggers based on creation, then those based on confirm and done
            // # as registrations can be automatically confirmed, or even created directly
            // # with a state given in values
            // if not self.env.context.get('event_lead_rule_skip'):
            //     registrations._apply_lead_generation_rules()
            // return registrations
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('sale_order_line_id'):
            //         so_line_vals = self._synchronize_so_line_values(
            //             self.env['sale.order.line'].browse(vals['sale_order_line_id'])
            //         )
            //         vals.update(so_line_vals)
            // registrations = super(EventRegistration, self).create(vals_list)
            // for registration in registrations:
            //     if registration.sale_order_id:
            //         registration.message_post_with_source(
            //             'mail.message_origin_link',
            //             render_values={'self': registration, 'origin': registration.sale_order_id},
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return registrations
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def create(self, vals_list):
            // result = super().create(vals_list)
            // result._update_available_seat()
            // return result
            */
            return await base.CreateAsync(input);
        }

        protected async Task<EventRegistration> FindFirstNotnullInternalAsync(object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _find_first_notnull(self, field_name):
            // """ Small tool to extract the first not nullvalue of a field: its value
            // or the ids if this is a relational field. """
            // value = next((reg[field_name] for reg in self if reg[field_name]), False)
            // return self._convert_value(value, field_name)
            */
            return default;
        }

        protected async Task<EventRegistration> GetEventRegistrationIdsFromOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _get_event_registration_ids_from_order(self):
            // self.ensure_one()
            // return self.sale_order_id.order_line.filtered(
            //     lambda line: line.event_id == self.event_id
            // ).registration_ids.ids
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> GetLeadContactFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_contact_fields(self):
            // """ Get registration fields linked to lead contact. Those are used notably
            // to see if an update of lead is necessary or to fill contact values
            // in ``_get_lead_contact_values())`` """
            // return ['name', 'email', 'phone', 'partner_id']
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadContactValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_contact_values(self):
            // """ Specific management of contact values. Rule creation basis has some
            // effect on contact management
            // 
            //   * in attendee mode: keep registration partner only if partner phone and
            //     email match. Indeed lead are synchronized with their contact and it
            //     would imply rewriting on partner, and therefore on other documents;
            //   * in batch mode: if a customer is found use it as main contact. Registrations
            //     details are included in lead description;
            // 
            // :returns: values used for create / write on a lead
            // :rtype: dict
            // """
            // sorted_self = self.sorted("id")
            // valid_partner = next(
            //     (reg.partner_id for reg in sorted_self if reg.partner_id != self.env.ref('base.public_partner')),
            //     self.env['res.partner']
            // )  # CHECKME: broader than just public partner
            // 
            // # mono registration mode: keep partner only if email and phone matches;
            // # otherwise registration > partner. Note that email format and phone
            // # formatting have to taken into account in comparison
            // if len(self) == 1 and valid_partner:
            //     # compare emails: email_normalized or raw
            //     if self.email and valid_partner.email:
            //         if valid_partner.email_normalized and tools.email_normalize(self.email) != valid_partner.email_normalized:
            //             valid_partner = self.env['res.partner']
            //         elif not valid_partner.email_normalized and valid_partner.email != self.email:
            //             valid_partner = self.env['res.partner']
            // 
            //     # compare phone, taking into account formatting
            //     if valid_partner and self.phone and valid_partner.phone:
            //         phone_formatted = self._phone_format(fname='phone', country=valid_partner.country_id)
            //         partner_phone_formatted = valid_partner._phone_format(fname='phone')
            //         if phone_formatted and partner_phone_formatted and phone_formatted != partner_phone_formatted:
            //             valid_partner = self.env['res.partner']
            //         if (not phone_formatted or not partner_phone_formatted) and self.phone != valid_partner.phone:
            //             valid_partner = self.env['res.partner']
            // 
            // registration_phone = sorted_self._find_first_notnull('phone')
            // if valid_partner:
            //     contact_vals = self.env['crm.lead']._prepare_values_from_partner(valid_partner)
            //     # force email_from / phone only if not set on partner because those fields are now synchronized automatically
            //     if not valid_partner.email:
            //         contact_vals['email_from'] = sorted_self._find_first_notnull('email')
            //     if not valid_partner.phone:
            //         contact_vals['phone'] = registration_phone
            // else:
            //     # don't force email_from + partner_id because those fields are now synchronized automatically
            //     contact_vals = {
            //         'contact_name': sorted_self._find_first_notnull('name'),
            //         'email_from': sorted_self._find_first_notnull('email'),
            //         'phone': registration_phone,
            //         'lang_id': False,
            //     }
            // contact_name = valid_partner.name or sorted_self._find_first_notnull('name') or sorted_self._find_first_notnull('email')
            // contact_vals.update({
            //     'name': f'{self.event_id[:1].name} - {contact_name}',
            //     'partner_id': valid_partner.id,
            // })
            // 
            // return contact_vals
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_description_fields(self):
            // """ Get registration fields linked to lead description. Those are used
            // notably to see if an update of lead is necessary or to fill description
            // in ``_get_lead_description())`` """
            // return ['name', 'email', 'phone']
            --- ODOO METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py) ---
            // def _get_lead_description_fields(self):
            // res = super(EventRegistration, self)._get_lead_description_fields()
            // res.append('registration_answer_ids')
            // return res
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionInternalAsync(object prefix, object line_counter, object line_suffix)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_description(self, prefix='', line_counter=True, line_suffix=''):
            // """ Build the description for the lead using a prefix for all generated
            // lines. For example to enumerate participants or inform of an update in
            // the information of a participant.
            // 
            // :returns: complete description for a lead taking into
            //   account all registrations contained in self
            // :rtype: str
            // """
            // reg_lines = [
            //     registration._get_lead_description_registration(
            //         line_suffix=line_suffix
            //     ) for registration in self
            // ]
            // description = (prefix if prefix else '') + Markup("<br/>")
            // if line_counter:
            //     description += Markup("<ol>") + Markup('').join(reg_lines) + Markup("</ol>")
            // else:
            //     description += Markup("<ul>") + Markup('').join(reg_lines) + Markup("</ul>")
            // return description
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionRegistrationInternalAsync(object line_suffix)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_description_registration(self, line_suffix=''):
            // """ Build the description line specific to a given registration. """
            // self.ensure_one()
            // return Markup("<li>") + "%s (%s)%s" % (
            //     self.name or self.partner_id.name or self.email,
            //     " - ".join(self[field] for field in ('email', 'phone') if self[field]),
            //     f" {line_suffix}" if line_suffix else "",
            // ) + Markup("</li>")
            --- ODOO METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py) ---
            // def _get_lead_description_registration(self, line_suffix=''):
            // """Add the questions and answers linked to the registrations into the description of the lead."""
            // reg_description = super(EventRegistration, self)._get_lead_description_registration(line_suffix=line_suffix)
            // if not self.registration_answer_ids:
            //     return reg_description
            // 
            // answer_descriptions = []
            // for answer in self.registration_answer_ids:
            //     answer_value = answer.value_answer_id.name if answer.question_type == "simple_choice" else answer.value_text_box
            //     answer_value = Markup("<br/>").join(["    %s" % line for line in answer_value.split('\n')])
            //     answer_descriptions.append(Markup("  - %s<br/>%s") % (answer.question_id.title, answer_value))
            // return Markup("%s%s<br/>%s") % (reg_description, _("Questions"), Markup('<br/>').join(answer_descriptions))
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadGroupingInternalAsync(object rules, object rule_to_new_regs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_grouping(self, rules, rule_to_new_regs):
            // """ Perform grouping of registrations in order to enable order-based
            // lead creation and update existing groups with new registrations.
            // 
            // Heuristic in event is the following. Registrations created in multi-mode
            // are grouped by event and creation_date. Customer use case: website_event
            // flow creates several registrations in a create-multi. Cron use case:
            // when running a rule on existing registrations, grouping on event only
            // is not sufficient, create_date is a safe bet for registration groups.
            // 
            // Update is not supported as there is no way to determine if a registration
            // is part of an existing batch.
            // 
            // :param rules: lead creation rules to run on registrations given by self;
            // :param rule_to_new_regs: dict: for each rule, subset of self matching
            //   rule conditions. Used to speedup batch computation;
            // 
            // :returns: for each rule, rule (key of dict) gives a list of groups.
            //   Each group is a tuple (
            //     existing_lead: existing lead to update;
            //     group_record: record used to group;
            //     registrations: sub record set of self, containing registrations
            //                    belonging to the same group;
            //   )
            // :rtype: dict
            // """
            // grouped_registrations = {
            //     (create_date, event): sub_registrations
            //     for event, registrations in self.grouped('event_id').items()
            //     for create_date, sub_registrations in registrations.grouped('create_date').items()
            // }
            // 
            // return dict(
            //     (rule, [(False, key, (registrations & rule_to_new_regs[rule]).sorted('id'))
            //             for key, registrations in grouped_registrations.items()])
            //     for rule in rules
            // )
            --- ODOO METHOD SOURCE (MODULE: event_crm_sale, FILE: event_registration.py) ---
            // def _get_lead_grouping(self, rules, rule_to_new_regs):
            // """ Override to support sale-order based grouping and update.
            // 
            // When checking for groups for rules, we search for existing leads linked
            // to same group (based on sale_order_id) and rule. Each rule can therefore
            // update an existing lead or create a new one, for each sale order that
            // makes the group. """
            // so_registrations = self.filtered(lambda reg: reg.sale_order_id)
            // grouping_res = super(EventRegistration, self - so_registrations)._get_lead_grouping(rules, rule_to_new_regs)
            // 
            // if so_registrations:
            //     # find existing leads in batch to put them in cache and avoid multiple search / queries
            //     related_registrations = self.env['event.registration'].search([
            //         ('sale_order_id', 'in', so_registrations.sale_order_id.ids)
            //     ])
            //     related_leads = self.env['crm.lead'].search([
            //         ('event_lead_rule_id', 'in', rules.ids),
            //         ('registration_ids', 'in', related_registrations.ids)
            //     ])
            // 
            //     for rule in rules:
            //         rule_new_regs = rule_to_new_regs[rule]
            // 
            //         # for each group (sale_order), find its linked registrations
            //         so_to_regs = defaultdict(lambda: self.env['event.registration'])
            //         for registration in rule_new_regs & so_registrations:
            //             so_to_regs[registration.sale_order_id] |= registration
            // 
            //         # for each grouped registrations, prepare result with group and existing lead
            //         so_res = []
            //         for sale_order, registrations in so_to_regs.items():
            //             registrations = registrations.sorted('id')  # as an OR was used, re-ensure order
            //             leads = related_leads.filtered(lambda lead: lead.event_lead_rule_id == rule and lead.registration_ids.sale_order_id == sale_order)
            //             so_res.append((leads, sale_order, registrations))
            //         if so_res:
            //             grouping_res[rule] = grouping_res.get(rule, list()) + so_res
            // 
            // return grouping_res
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadTrackedValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_tracked_values(self):
            // """ Tracked values are based on two subset of fields to track in order
            // to fill or update leads. Two main use cases are
            // 
            //   * description fields: registration contact fields: email, phone, ...
            //     on registration. Other fields are added by inheritance like
            //     question answers;
            //   * contact fields: registration contact fields + partner_id field as
            //     contact of a lead is managed specifically. Indeed email and phone
            //     synchronization of lead / partner_id implies paying attention to
            //     not rewrite partner values from registration values.
            // 
            // Tracked values are therefore the union of those two field sets. """
            // tracked_fields = list(set(self._get_lead_contact_fields()) | set(self._get_lead_description_fields()))
            // return dict(
            //     (registration.id,
            //      dict((field, self._convert_value(registration[field], field)) for field in tracked_fields)
            //     ) for registration in self
            // )
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadValuesInternalAsync(object rule)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _get_lead_values(self, rule):
            // """ Get lead values from registrations. Self can contain multiple records
            // in which case first found non void value is taken. Note that all
            // registrations should belong to the same event.
            // 
            // :returns: values used for create / write on a lead
            // :rtype: dict
            // """
            // sorted_self = self.sorted("id")
            // lead_values = {
            //     # from rule
            //     'type': rule.lead_type,
            //     'user_id': rule.lead_user_id.id,
            //     'team_id': rule.lead_sales_team_id.id,
            //     'tag_ids': rule.lead_tag_ids.ids,
            //     'event_lead_rule_id': rule.id,
            //     # event and registration
            //     'event_id': self.event_id.id,
            //     'referred': self.event_id.name,
            //     'registration_ids': self.ids,
            //     'campaign_id': sorted_self._find_first_notnull('utm_campaign_id'),
            //     'source_id': sorted_self._find_first_notnull('utm_source_id'),
            //     'medium_id': sorted_self._find_first_notnull('utm_medium_id'),
            // }
            // lead_values.update(sorted_self._get_lead_contact_values())
            // lead_values['description'] = sorted_self._get_lead_description(_("Participants"), line_counter=True)
            // return lead_values
            --- ODOO METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py) ---
            // def _get_lead_values(self, rule):
            // """Update lead values from Lead Generation rules to include the visitor and their language"""
            // lead_values = super()._get_lead_values(rule)
            // if self.visitor_id:
            //     lead_values['visitor_ids'] = self.visitor_id
            // if self.visitor_id.lang_id:
            //     lead_values['lang_id'] = self.visitor_id.lang_id[0].id
            // return lead_values
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> GetRandomBarcodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _get_random_barcode(self):
            // """Generate a string representation of a pseudo-random 8-byte number for barcode
            // generation.
            // 
            // A decimal serialisation is longer than a hexadecimal one *but* it
            // generates a more compact barcode (Code128C rather than Code128A).
            // 
            // Generate 8 bytes (64 bits) barcodes as 16 bytes barcodes are not
            // compatible with all scanners.
            //  """
            // return str(int.from_bytes(os.urandom(8), 'little'))
            */
            return default;
        }

        protected async Task<EventRegistration> GetRegistrationSummaryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _get_registration_summary(self):
            // self.ensure_one()
            // 
            // is_date_closed_today = False
            // if self.date_closed:
            //     event_tz = pytz.timezone(self.event_id.date_tz)
            //     now = fields.Datetime.now(pytz.UTC).astimezone(event_tz)
            //     closed_date = self.date_closed.astimezone(event_tz)
            //     is_date_closed_today = now.date() == closed_date.date()
            // 
            // return {
            //     'id': self.id,
            //     'name': self.name,
            //     'partner_id': self.partner_id.id,
            //     'slot_name': self.event_slot_id.display_name,
            //     'ticket_name': self.event_ticket_id.name,
            //     'event_id': self.event_id.id,
            //     'event_display_name': self.event_id.display_name,
            //     'registration_answers': self.registration_answer_ids.filtered('value_answer_id').mapped('display_name'),
            //     'company_name': self.company_name,
            //     'badge_format': self.event_id.badge_format,
            //     'date_closed_formatted': format_date(env=self.env, value=self.date_closed, date_format='short') if self.date_closed else False,
            //     'is_date_closed_today': is_date_closed_today,
            // }
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _get_registration_summary(self):
            // res = super(EventRegistration, self)._get_registration_summary()
            // res.update({
            //     'sale_status': self.sale_status,
            //     'sale_status_value': self.sale_status and dict(self._fields['sale_status']._description_selection(self.env))[self.sale_status],
            //     'has_to_pay': self.sale_status == 'to_pay',
            // })
            // return res
            */
            return default;
        }

        protected async Task<EventRegistration> GetWebsiteRegistrationAllowedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_registration.py) ---
            // def _get_website_registration_allowed_fields(self):
            // return {'name', 'phone', 'email', 'company_name', 'event_id', 'partner_id', 'event_slot_id', 'event_ticket_id'}
            */
            return default;
        }

        protected async Task<EventRegistration> HasOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: event_registration.py) ---
            // def _has_order(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _has_order(self):
            // return super()._has_order() or self.sale_order_id
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def _has_order(self):
            // return super()._has_order() or self.pos_order_id
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return False
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'event_id', 'event_ticket_id', 'event_slot_id', 'pos_order_line_id', 'pos_order_id', 'phone',
            //         'company_name', 'email', 'name', 'registration_answer_ids', 'registration_answer_choice_ids', 'write_date']
            */
            return default;
        }

        protected async Task<EventRegistration> LoadRecordsCreateInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _load_records_create(self, values):
            // """ In import mode: do not run rules those are intended to run when customers
            // buy tickets, not when bootstrapping a database. """
            // return super(EventRegistration, self.with_context(event_lead_rule_skip=True))._load_records_create(values)
            */
            return default;
        }

        protected async Task<EventRegistration> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _load_records_write(self, values):
            // """ In import mode: do not run rules those are intended to run when customers
            // buy tickets, not when bootstrapping a database. """
            // return super(EventRegistration, self.with_context(event_lead_rule_skip=True))._load_records_write(values)
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> MailTemplateDefaultValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _mail_template_default_values(self):
            // return {
            //     "email_from": "{{ (object.event_id.organizer_id.email_formatted or object.event_id.company_id.email_formatted or user.email_formatted or '') }}",
            //     "lang": "{{ object.event_id.lang or object.partner_id.lang }}",
            //     "use_default_to": True,
            // }
            */
            return default;
        }

        protected async Task<EventRegistration> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_registration.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // default_mailing_model_id = self.env.context.get('default_mailing_model_id')
            // default_mailing_domain = self.env.context.get('default_mailing_domain')
            // if default_mailing_model_id and mailing.mailing_model_id.id == default_mailing_model_id and default_mailing_domain:
            //     return ast.literal_eval(default_mailing_domain)
            // return [('state', 'not in', ['cancel', 'draft'])]
            */
            return default;
        }

        protected async Task<EventRegistration> MessageAddDefaultRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _message_add_default_recipients(self):
            // # Prioritize registration email over partner_id, which may be shared when a single
            // # partner booked multiple seats
            // results = super()._message_add_default_recipients()
            // for record in self:
            //     email_to_lst = results[record.id]['email_to_lst']
            //     if len(email_to_lst) == 1:
            //         email_normalized = email_normalize(email_to_lst[0])
            //         if email_normalized and email_normalized == email_normalize(record.email):
            //             results[record.id]['email_to_lst'] = [formataddr((record.name or "", email_normalized))]
            // return results
            */
            return default;
        }

        protected async Task<EventRegistration> MessageComputeSubjectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _message_compute_subject(self):
            // if self.name:
            //     return _(
            //         "%(event_name)s - Registration for %(attendee_name)s",
            //         event_name=self.event_id.name,
            //         attendee_name=self.name,
            //     )
            // return _(
            //     "%(event_name)s - Registration #%(registration_id)s",
            //     event_name=self.event_id.name,
            //     registration_id=self.id,
            // )
            */
            return default;
        }

        protected async Task<EventRegistration> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     email_normalized = email_normalize(self.email)
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email or (email_normalized and partner.email_normalized == email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email', 'in', [new_partner[0].email, new_partner[0].email_normalized])
            //         else:
            //             email_domain = ('email', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('state', 'not in', ['cancel']),
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(EventRegistration, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        protected async Task<EventRegistration> OnchangeEventInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _onchange_event(self):
            // if self.event_slot_id and self.event_id != self.event_slot_id.event_id:
            //     self.event_slot_id = False
            // if self.event_ticket_id and self.event_id != self.event_ticket_id.event_id:
            //     self.event_ticket_id = False
            */
            return default;
        }

        protected async Task<EventRegistration> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     country = self.partner_id.country_id or self.event_id.country_id or self.env.company.country_id
            //     self.phone = self._phone_format(fname='phone', country=country) or self.phone
            */
            return default;
        }

        [ApiModel]
        public async Task<EventRegistration> RegisterAttendeeAsync(EventRegistrationRegisterAttendeeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def register_attendee(self, barcode, event_id):
            // attendee = self.search([('barcode', '=', barcode)], limit=1)
            // if not attendee:
            //     return {'error': 'invalid_ticket'}
            // res = attendee._get_registration_summary()
            // if attendee.state == 'cancel':
            //     status = 'canceled_registration'
            // elif attendee.state == 'draft':
            //     status = 'unconfirmed_registration'
            // elif attendee.event_id.is_finished:
            //     status = 'not_ongoing_event'
            // elif attendee.state != 'done':
            //     if event_id and attendee.event_id.id != event_id:
            //         status = 'need_manual_confirmation'
            //     else:
            //         attendee.action_set_done()
            //         status = 'confirmed_registration'
            // else:
            //     status = 'already_registered'
            // res.update({'status': status})
            // return res
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<EventRegistration> SaleOrderRegistrationDataChangeNotifyInternalAsync(object new_record_field, object new_record)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _sale_order_registration_data_change_notify(self, new_record_field, new_record):
            // fallback_user_id = self.env.user.id if not self.env.user._is_public() else self.env.ref("base.user_admin").id
            // for registration in self:
            //     render_context = {
            //         'registration': registration,
            //         'record_type': _('Ticket') if new_record_field == 'event_ticket_id' else _('Slot'),
            //         'old_name': registration[new_record_field].display_name,
            //         'new_name': new_record.display_name,
            //     }
            //     user_id = registration.event_id.user_id.id or registration.sale_order_id.user_id.id or fallback_user_id
            //     registration.sale_order_id._activity_schedule_with_view(
            //         'mail.mail_activity_data_warning',
            //         user_id=user_id,
            //         views_or_xmlid='event_sale.event_registration_change_exception',
            //         render_context=render_context)
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> SearchEventBeginDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _search_event_begin_date(self, operator, value):
            // return Domain.OR([
            //     ["&", ("event_slot_id", "!=", False), ("event_slot_id.start_datetime", operator, value)],
            //     ["&", ("event_slot_id", "=", False), ("event_id.date_begin", operator, value)],
            // ])
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> SearchEventEndDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _search_event_end_date(self, operator, value):
            // return Domain.OR([
            //     ["&", ("event_slot_id", "!=", False), ("event_slot_id.end_datetime", operator, value)],
            //     ["&", ("event_slot_id", "=", False), ("event_id.date_end", operator, value)],
            // ])
            */
            return default;
        }

        public async Task<EventRegistration> SendBadgeEmailAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def action_send_badge_email(self):
            // """ Open a window to compose an email, with the template - 'event_badge'
            //     message loaded by default
            // """
            // self.ensure_one()
            // template = self.env.ref('event.event_registration_mail_template_badge', raise_if_not_found=False)
            // compose_form = self.env.ref('mail.email_compose_message_wizard_form')
            // ctx = dict(
            //     default_model='event.registration',
            //     default_res_ids=self.ids,
            //     default_template_id=template.id if template else False,
            //     default_composition_mode='comment',
            //     default_email_layout_xmlid="mail.mail_notification_light",
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
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> SetDoneAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def action_set_done(self):
            // """ Close Registration """
            // self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> SetDraftAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def action_set_draft(self):
            // self.write({'state': 'draft'})
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<EventRegistration> SynchronizePartnerValuesInternalAsync(object partner, object fnames)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _synchronize_partner_values(self, partner, fnames=None):
            // if fnames is None:
            //     fnames = {'name', 'email', 'phone'}
            // if partner:
            //     contact_id = partner.address_get().get('contact', False)
            //     if contact_id:
            //         contact = self.env['res.partner'].browse(contact_id)
            //         return dict((fname, contact[fname]) for fname in fnames if contact[fname])
            // return {}
            */
            return default;
        }

        protected async Task<EventRegistration> SynchronizeSoLineValuesInternalAsync(object so_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def _synchronize_so_line_values(self, so_line):
            // if so_line:
            //     return {
            //         # Avoid registering public users but respect the portal workflows
            //         'partner_id': False if self.env.user._is_public() and self.env.user.partner_id == so_line.order_id.partner_id else so_line.order_id.partner_id.id,
            //         'event_id': so_line.event_id.id,
            //         'event_slot_id': so_line.event_slot_id.id,
            //         'event_ticket_id': so_line.event_ticket_id.id,
            //         'sale_order_id': so_line.order_id.id,
            //         'sale_order_line_id': so_line.id,
            //     }
            // return {}
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateAvailableSeatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def _update_available_seat(self):
            // # Here sudo is used in order for pos_event to update the available seats to all open pos session when a ticket is sold in website for example
            // session_ids = self.env['pos.session'].sudo().search([("state", "!=", "closed")])
            // if len(session_ids) > 0:
            //     session_ids.config_id._update_events_seats(self.event_id)
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateLeadsInternalAsync(object new_vals, object lead_tracked_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def _update_leads(self, new_vals, lead_tracked_vals):
            // """ Update leads linked to some registrations. Update is based depending
            // on updated fields, see ``_get_lead_contact_fields()`` and ``_get_lead_
            // description_fields()``. Main heuristic is
            // 
            //   * check attendee-based leads, for each registration recompute contact
            //     information if necessary (changing partner triggers the whole contact
            //     computation); update description if necessary;
            //   * check order-based leads, for each existing group-based lead, only
            //     partner change triggers a contact and description update. We consider
            //     that group-based rule works mainly with the main contact and less
            //     with further details of registrations. Those can be found in stat
            //     button if necessary.
            // 
            // :param new_vals: values given to write. Used to determine updated fields;
            // :param lead_tracked_vals: dict(registration_id, registration previous values)
            //   based on new_vals;
            // """
            // for registration in self:
            //     leads_attendee = registration.lead_ids.filtered(
            //         lambda lead: lead.event_lead_rule_id.lead_creation_basis == 'attendee'
            //     )
            //     if not leads_attendee:
            //         continue
            // 
            //     old_vals = lead_tracked_vals[registration.id]
            //     # if partner has been updated -> update registration contact information
            //     # as they are computed (and therefore not given to write values)
            //     if 'partner_id' in new_vals:
            //         new_vals.update(**dict(
            //             (field, registration[field])
            //             for field in self._get_lead_contact_fields()
            //             if field != 'partner_id')
            //         )
            // 
            //     lead_values = {}
            //     # update contact fields: valid for all leads of registration
            //     upd_contact_fields = [field for field in self._get_lead_contact_fields() if field in new_vals.keys()]
            //     if any(new_vals[field] != old_vals[field] for field in upd_contact_fields):
            //         lead_values = registration._get_lead_contact_values()
            // 
            //     # update description fields: each lead has to be updated, otherwise
            //     # update in batch
            //     upd_description_fields = [field for field in self._get_lead_description_fields() if field in new_vals.keys()]
            //     if any(new_vals[field] != old_vals[field] for field in upd_description_fields):
            //         for lead in leads_attendee:
            //             lead_values['description'] = "%s<br/>%s" % (
            //                 lead.description,
            //                 registration._get_lead_description(_("Updated registrations"), line_counter=True)
            //             )
            //             lead.write(lead_values)
            //     elif lead_values:
            //         leads_attendee.write(lead_values)
            // 
            // leads_order = self.lead_ids.filtered(lambda lead: lead.event_lead_rule_id.lead_creation_basis == 'order')
            // for lead in leads_order:
            //     lead_values = {}
            //     if new_vals.get('partner_id'):
            //         lead_values.update(lead.registration_ids._get_lead_contact_values())
            //         if not lead.partner_id:
            //             lead_values['description'] = lead.registration_ids._get_lead_description(_("Participants"), line_counter=True)
            //         elif new_vals['partner_id'] != lead.partner_id.id:
            //             lead_values['description'] = (lead.description or '') + "<br/>" + lead.registration_ids._get_lead_description(_("Updated registrations"), line_counter=True, line_suffix=_("(updated)"))
            //     if lead_values:
            //         lead.write(lead_values)
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateMailSchedulersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def _update_mail_schedulers(self):
            // """ Update schedulers to set them as running again, and cron to be called
            // as soon as possible. """
            // if self.env.context.get("install_mode", False):
            //     # running the scheduler for demo data can cause an issue where wkhtmltopdf runs during
            //     # server start and hangs indefinitely, leading to serious crashes
            //     # we currently avoid this by not running the scheduler, would be best to find the actual
            //     # reason for this issue and fix it so we can remove this check
            //     return
            // 
            // open_registrations = self.filtered(lambda registration: registration.state == 'open')
            // if not open_registrations:
            //     return
            // 
            // onsubscribe_schedulers = self.env['event.mail'].sudo().search([
            //     ('event_id', 'in', open_registrations.event_id.ids),
            //     ('interval_type', '=', 'after_sub'),
            // ])
            // if not onsubscribe_schedulers:
            //     return
            // 
            // # either trigger the cron, either run schedulers immediately (scaling choice)
            // async_scheduler = self.env['ir.config_parameter'].sudo().get_param('event.event_mail_async')
            // if async_scheduler:
            //     self.env.ref('event.event_mail_scheduler')._trigger()
            //     self.env.ref('mail.ir_cron_mail_scheduler_action')._trigger()
            // else:
            //     # we could simply call _create_missing_mail_registrations and let cron do their job
            //     # but it currently leads to several delays. We therefore call execute until
            //     # cron triggers are correctly used
            //     for scheduler in onsubscribe_schedulers:
            //         try:
            //             scheduler.with_context(
            //                 event_mail_registration_ids=open_registrations.ids
            //             ).with_user(SUPERUSER_ID).execute()
            //         except Exception as e:
            //             _logger.exception("Failed to run scheduler %s", scheduler.id)
            //             scheduler._warn_error(e)
            */
            return default;
        }

        public async Task<EventRegistration> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def action_view_pos_order(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("point_of_sale.action_pos_pos_form")
            // action['views'] = [(False, 'form')]
            // action['res_id'] = self.pos_order_id.id
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def action_view_sale_order(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // action['views'] = [(False, 'form')]
            // action['res_id'] = self.sale_order_id.id
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<EventRegistration> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_registration.py) ---
            // def write(self, vals):
            // confirming = vals.get('state') in {'open', 'done'}
            // to_confirm = (self.filtered(lambda registration: registration.state in {'draft', 'cancel'})
            //               if confirming else None)
            // ret = super().write(vals)
            // if confirming:
            //     to_confirm._update_mail_schedulers()
            // 
            // if vals.get('state') == 'done':
            //     message = _("Attended on %(attended_date)s", attended_date=format_date(env=self.env, value=fields.Datetime.now(), date_format='short'))
            //     self._message_log_batch(bodies={registration.id: message for registration in self})
            // 
            // return ret
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py) ---
            // def write(self, vals):
            // """ Update the lead values depending on fields updated in registrations.
            // There are 2 main use cases
            // 
            //   * first is when we update the partner_id of multiple registrations. It
            //     happens when a public user fill its information when they register to
            //     an event;
            //   * second is when we update specific values of one registration like
            //     updating question answers or a contact information (email, phone);
            // 
            // Also trigger rules based on confirmed and done attendees (state written
            // to open and done).
            // """
            // to_update, event_lead_rule_skip = False, self.env.context.get('event_lead_rule_skip')
            // if not event_lead_rule_skip:
            //     to_update = self.filtered(lambda reg: reg.lead_count)
            // if to_update:
            //     lead_tracked_vals = to_update._get_lead_tracked_values()
            // 
            // res = super(EventRegistration, self).write(vals)
            // 
            // if not event_lead_rule_skip and to_update:
            //     self.env.flush_all()  # compute notably partner-based fields if necessary
            //     to_update.sudo()._update_leads(vals, lead_tracked_vals)
            // 
            // # handle triggers based on state
            // if not event_lead_rule_skip:
            //     if vals.get('state') == 'open':
            //         self.env['event.lead.rule'].search([('lead_creation_trigger', '=', 'confirm')]).sudo()._run_on_registrations(self)
            //     elif vals.get('state') == 'done':
            //         self.env['event.lead.rule'].search([('lead_creation_trigger', '=', 'done')]).sudo()._run_on_registrations(self)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py) ---
            // def write(self, vals):
            // if vals.get('sale_order_line_id'):
            //     so_line_vals = self._synchronize_so_line_values(
            //         self.env['sale.order.line'].browse(vals['sale_order_line_id'])
            //     )
            //     vals.update(so_line_vals)
            // 
            // updated_fields_to_notify = []
            // if vals.get('event_slot_id'):
            //     updated_fields_to_notify.append(('event.slot', 'event_slot_id'))
            // if vals.get('event_ticket_id'):
            //     updated_fields_to_notify.append(('event.event.ticket', 'event_ticket_id'))
            // for model, field in updated_fields_to_notify:
            //     self.filtered(
            //         lambda registration: registration[field] and registration[field].id != vals[field]
            //     )._sale_order_registration_data_change_notify(field, self.env[model].browse(vals[field]))
            // 
            // return super(EventRegistration, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py) ---
            // def write(self, vals):
            // result = super().write(vals)
            // self._update_available_seat()
            // return result
            */
            return await base.WriteAsync(input);
        }
    }
}