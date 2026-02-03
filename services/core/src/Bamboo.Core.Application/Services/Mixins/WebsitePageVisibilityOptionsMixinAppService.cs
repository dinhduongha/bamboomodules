using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsitePageVisibilityOptionsMixinAppService : ApplicationService, IWebsitePageVisibilityOptionsMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public WebsitePageVisibilityOptionsMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def action_generate_leads(self, event_lead_rules=False):
            // """ Re-generate leads based on event.lead.rules.
            // The method is ran synchronously if there is a low amount of registrations, otherwise it
            // goes through a CRON job that runs in batches. """
            // 
            // if not self.env.user.has_group('event.group_event_manager'):
            //     raise UserError(_("Only Event Managers are allowed to re-generate all leads."))
            // 
            // registrations_count = self.env['event.registration'].search_count([
            //     ('event_id', 'in', self.ids),
            //     ('state', 'not in', ['draft', 'cancel']),
            // ])
            // 
            // if registrations_count <= self.env['event.lead.request']._REGISTRATIONS_BATCH_SIZE:
            //     leads = self.env['event.registration'].search([
            //         ('event_id', 'in', self.ids),
            //         ('state', 'not in', ['draft', 'cancel']),
            //     ])._apply_lead_generation_rules(event_lead_rules)
            //     if leads:
            //         notification = _("Yee-ha, %(leads_count)s Leads have been created!", leads_count=len(leads))
            //     else:
            //         notification = _("Aww! No Leads created, check your Lead Generation Rules and try again.")
            // else:
            //     self.env['event.lead.request'].sudo().create([{
            //         'event_id': event.id,
            //         'event_lead_rule_ids': event_lead_rules,
            //     } for event in self])
            //     self.env.ref('event_crm.ir_cron_generate_leads')._trigger()
            //     notification = _("Got it! We've noted your request. Your leads will be created soon!")
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'info',
            //         'sticky': False,
            //         'message': notification,
            //         'next': {'type': 'ir.actions.act_window_close'},  # force a form reload
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_invite_contacts(self):
            // return {
            //     'name': 'Mass Mail Invitation',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('base.model_res_partner').id,
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_invite_contacts(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super().action_invite_contacts()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_mass_mailing_attendees(self):
            // return {
            //     'name': 'Mass Mail Attendees',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('event.model_event_registration').id,
            //         'default_mailing_domain': repr([('event_id', 'in', self.ids), ('state', 'not in', ['cancel', 'draft'])]),
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_mass_mailing_attendees(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super().action_mass_mailing_attendees()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // mass_mailing_action = dict(
            //     name='Mass Mail Attendees',
            //     type='ir.actions.act_window',
            //     res_model='mailing.mailing',
            //     view_mode='form',
            //     target='current',
            //     context=dict(
            //         default_mailing_model_id=self.env.ref('website_event_track.model_event_track').id,
            //         default_mailing_domain=repr([('event_id', 'in', self.ids), ('stage_id.is_cancel', '!=', True)]),
            //         default_subject=_("Event: %s", self.name),
            //     ),
            // )
            // return mass_mailing_action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super().action_mass_mailing_track_speakers()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def action_open_slot_calendar(self):
            // self.ensure_one()
            // now = datetime.now().astimezone(pytz.timezone(self.env.user.tz or 'UTC'))
            // next_hour = now + timedelta(hours=1)
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Slots'),
            //     'view_mode': 'calendar,list,form',
            //     'mobile_view_mode': 'list',
            //     'res_model': 'event.slot',
            //     'target': 'current',
            //     'domain': [('event_id', '=', self.id)],
            //     'context': {
            //         'default_event_id': self.id,
            //         # Default hours for the list view and mobile quick create.
            //         # Desktop calendar multi create using defaults in local storage
            //         # (= the last selected time range or fallback on 12PM-1PM).
            //         'default_start_hour': next_hour.hour,
            //         'default_end_hour': (next_hour + timedelta(hours=1)).hour,
            //         # To disable calendar days outside of event date range.
            //         'event_calendar_range_start_date': self.date_begin.astimezone(pytz.timezone(self.date_tz)).date(),
            //         'event_calendar_range_end_date': self.date_end.astimezone(pytz.timezone(self.date_tz)).date(),
            //         # Calendar view initial date.
            //         'initial_date': min(max(datetime.now(), self.date_begin), self.date_end),
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def action_set_done(self):
            // """
            // Action which will move the events
            // into the first next (by sequence) stage defined as "Ended"
            // (if they are not already in an ended stage)
            // """
            // first_ended_stage = self.env['event.stage'].search([('pipe_end', '=', True)], limit=1, order='sequence')
            // if first_ended_stage:
            //     self.write({'stage_id': first_ended_stage.id})
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def action_view_linked_orders(self):
            // """ Redirects to only the confirmed orders linked to the current events """
            // sale_order_action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // sale_order_action.update({
            //     'domain': [('state', '=', 'sale'), ('order_line.event_id', 'in', self.ids)],
            //     'context': {'create': 0},
            // })
            // return sale_order_action
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_closing_date(self):
            // for event in self:
            //     if event.date_end < event.date_begin:
            //         raise ValidationError(_('The closing date cannot be earlier than the beginning date.'))
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_event_url(self):
            // for event in self.filtered('event_url'):
            //     url = urlparse(event.event_url)
            //     if not (url.scheme and url.netloc):
            //         raise ValidationError(_('Please enter a valid event URL.'))
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _check_for_publication(self, vals):
            // if vals.get('is_published'):
            //     for post in self.filtered(lambda p: p.active):
            //         post.blog_id.message_post_with_source(
            //             'website_blog.blog_post_template_new_post',
            //             subject=post.name,
            //             render_values={'post': post},
            //             subtype_xmlid='website_blog.mt_blog_blog_published',
            //         )
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_slots_dates(self):
            // multi_slots_event_ids = self.filtered(lambda event: event.is_multi_slots).ids
            // if not multi_slots_event_ids:
            //     return
            // min_max_slot_dates_per_event = {
            //     event: (min_start, max_end)
            //     for event, min_start, max_end in self.env['event.slot']._read_group(
            //         domain=[('event_id', 'in', multi_slots_event_ids)],
            //         groupby=['event_id'],
            //         aggregates=['start_datetime:min', 'end_datetime:max']
            //     )
            // }
            // events_w_slots_outside_bounds = []
            // for event, (min_start, max_end) in min_max_slot_dates_per_event.items():
            //     if (not (event.date_begin <= min_start <= event.date_end) or
            //         not (event.date_begin <= max_end <= event.date_end)):
            //         events_w_slots_outside_bounds.append(event)
            // if events_w_slots_outside_bounds:
            //     raise ValidationError(_(
            //         "These events cannot have slots scheduled outside of their time range:\n%(event_names)s",
            //         event_names="\n".join(f"- {event.name}" for event in events_w_slots_outside_bounds)
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _check_website_id(self):
            // for event in self:
            //     if event.website_id and event.website_id.company_id != event.company_id:
            //         raise ValidationError(_("The website must be from the same company as the event."))
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_inline(self):
            // """Use venue address if available, otherwise its name, finally ''. """
            // for event in self:
            //     if (event.address_id.contact_address or '').strip():
            //         event.address_inline = ', '.join(
            //             frag.strip()
            //             for frag in event.address_id.contact_address.split('\n') if frag.strip()
            //         )
            //     else:
            //         event.address_inline = event.address_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_search(self):
            // for event in self:
            //     event.address_search = event.address_id
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _compute_booth_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.booth_menu = event.event_type_id.booth_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.booth_menu):
            //         event.booth_menu = True
            //     elif not event.website_menu:
            //         event.booth_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ Set False in base module. Sub modules will add their own logic
            // (meet or track_quiz). """
            // for event in self:
            //     event.community_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_tz(self):
            // for event in self:
            //     if event.event_type_id.default_timezone:
            //         event.date_tz = event.event_type_id.default_timezone
            //     if not event.date_tz:
            //         event.date_tz = self.env.user.tz or 'UTC'
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_display_name(self):
            // """Adds ticket seats availability if requested by context."""
            // if not self.env.context.get('name_with_seats_availability'):
            //     return super()._compute_display_name()
            // for event in self:
            //     # event or its tickets are sold out
            //     if event.event_registrations_sold_out:
            //         name = _('%(event_name)s (Sold out)', event_name=event.name)
            //     elif event.seats_limited and event.seats_max:
            //         name = _(
            //             '%(event_name)s (%(count)s seats remaining)',
            //             event_name=event.name,
            //             count=formatLang(self.env, event.seats_available, digits=0),
            //         )
            //     else:
            //         name = event.name
            //     event.display_name = name
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_available_ids(self):
            // for event in self:
            //     event.event_booth_category_available_ids = event.event_booth_ids.filtered(lambda booth: booth.is_available).mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_ids(self):
            // for event in self:
            //     event.event_booth_category_ids = event.event_booth_ids.mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_count(self):
            // if self.ids and all(bool(event.id) for event in self):  # no new/onchange mode -> optimized
            //     booths_available_count, booths_total_count = self._get_booth_stat_count()
            //     for event in self:
            //         event.event_booth_count_available = booths_available_count.get(event.id, 0)
            //         event.event_booth_count = booths_total_count.get(event.id, 0)
            // else:
            //     for event in self:
            //         event.event_booth_count = len(event.event_booth_ids)
            //         event.event_booth_count_available = len(event.event_booth_ids.filtered(lambda booth: booth.is_available))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing booths:
            // 
            //   * lines that are available are removed;
            //   * template lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_booth_ids:
            //         event.event_booth_ids = False
            //         continue
            // 
            //     # booths to keep: those that are not available
            //     booths_to_remove = event.event_booth_ids.filtered(lambda booth: booth.is_available)
            //     command = [Command.unlink(booth.id) for booth in booths_to_remove]
            //     if event.event_type_id.event_type_booth_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.booth']._get_event_booth_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_booth_ids
            //         ]
            //     event.event_booth_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_mail_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing mails:
            // 
            //   * lines that are not sent and have no registrations linked are remove;
            //   * type lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_mail_ids:
            //         event.event_mail_ids = self._default_event_mail_ids()
            //         continue
            // 
            //     # lines to keep: those with already sent emails or registrations
            //     mails_to_remove = event.event_mail_ids.filtered(
            //         lambda mail: not(mail._origin.mail_done) and not(mail._origin.mail_registration_ids)
            //     )
            //     command = [Command.unlink(mail.id) for mail in mails_to_remove]
            // 
            //     # lines to add: those which do not have the exact copy available in lines to keep
            //     if event.event_type_id.event_type_mail_ids:
            //         mails_to_keep_vals = {frozendict(mail._prepare_event_mail_values()) for mail in event.event_mail_ids - mails_to_remove}
            //         for mail in event.event_type_id.event_type_mail_ids:
            //             mail_values = frozendict(mail._prepare_event_mail_values())
            //             if mail_values not in mails_to_keep_vals:
            //                 command.append(Command.create(mail_values))
            //     if command:
            //         event.event_mail_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_register_url(self):
            // for event in self:
            //     event.event_register_url = tools.urls.urljoin(event.get_base_url(), f"{event.website_url}/register")
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_open(self):
            // """ Compute whether people may take registrations for this event
            // 
            //   * for cancelled events, registrations are not open;
            //   * event.date_end -> if event is done, registrations are not open anymore;
            //   * event.start_sale_datetime -> lowest start date of tickets (if any; start_sale_datetime
            //     is False if no ticket are defined, see _compute_start_sale_date);
            //   * any ticket is available for sale (seats available) if any;
            //   * seats are unlimited or seats are available;
            // """
            // for event in self:
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     date_end_tz = event.date_end.astimezone(pytz.timezone(event.date_tz or 'UTC')) if event.date_end else False
            //     event.event_registrations_open = event.kanban_state != 'cancel' and \
            //         event.event_registrations_started and \
            //         (date_end_tz >= current_datetime if date_end_tz else True) and \
            //         (not event.seats_limited or not event.seats_max or event.seats_available) and \
            //         (
            //             # Not multi slots: open if no tickets or at least a sale available ticket
            //             (not event.is_multi_slots and
            //                 (not event.event_ticket_ids or any(ticket.sale_available for ticket in event.event_ticket_ids)))
            //             or
            //             # Multi slots: open if at least a slot and no tickets or at least an ongoing ticket with availability
            //             (event.is_multi_slots and event.event_slot_count and (
            //                 not event.event_ticket_ids or any(
            //                     ticket.is_launched and not ticket.is_expired and (
            //                         any(availability is None or availability > 0
            //                             for availability in event._get_seats_availability([
            //                                 (slot, ticket)
            //                                 for slot in event.event_slot_ids
            //                             ])
            //                         )
            //                     ) for ticket in event.event_ticket_ids
            //                 )
            //             ))
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_sold_out(self):
            // """Note that max seats limits for events and sum of limits for all its tickets may not be
            // equal to enable flexibility.
            // E.g. max 20 seats for ticket A, 20 seats for ticket B
            //     * With max 20 seats for the event
            //     * Without limit set on the event (=40, but the customer didn't explicitly write 40)
            // When the event is multi slots, instead of checking if every tickets is sold out,
            // checking if every slot-ticket combination is sold out.
            // """
            // for event in self:
            //     event.event_registrations_sold_out = (
            //         (event.seats_limited and event.seats_max and not event.seats_available > 0)
            //         or (event.event_ticket_ids and (
            //             not any(availability is None or availability > 0
            //                 for availability in event._get_seats_availability([
            //                     (slot, ticket)
            //                     for slot in event.event_slot_ids
            //                     for ticket in event.event_ticket_ids
            //                 ])
            //             )
            //             if event.is_multi_slots else
            //             all(ticket.is_sold_out for ticket in event.event_ticket_ids)
            //         ))
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_started(self):
            // for event in self:
            //     event = event._set_tz_context()
            //     if event.start_sale_datetime:
            //         current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //         start_sale_datetime = fields.Datetime.context_timestamp(event, event.start_sale_datetime)
            //         event.event_registrations_started = (current_datetime >= start_sale_datetime)
            //     else:
            //         event.event_registrations_started = True
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_share_url(self):
            // """Fall back on the website_url to share the event."""
            // for event in self:
            //     event.event_share_url = event.event_url or tools.urls.urljoin(event.get_base_url(), event.website_url)
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_slot_count(self):
            // slot_count_per_event = dict(self.env['event.slot']._read_group(
            //     domain=[('event_id', 'in', self.ids)],
            //     groupby=['event_id'],
            //     aggregates=['__count']
            // ))
            // for event in self:
            //     event.event_slot_count = slot_count_per_event.get(event, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_ticket_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing tickets:
            // 
            //   * lines that have no registrations linked are remove;
            //   * type lines are added;
            // 
            // Note that updating event_ticket_ids triggers _compute_start_sale_date
            // (start_sale_datetime computation) so ensure result to avoid cache miss.
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_ticket_ids:
            //         event.event_ticket_ids = False
            //         continue
            // 
            //     # lines to keep: those with existing registrations
            //     tickets_to_remove = event.event_ticket_ids.filtered(lambda ticket: not ticket._origin.registration_ids)
            //     command = [Command.unlink(ticket.id) for ticket in tickets_to_remove]
            //     if event.event_type_id.event_type_ticket_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.ticket']._get_event_ticket_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_ticket_ids
            //         ]
            //     event.event_ticket_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_url(self):
            // """Reset url field as it should only be used for events with no physical location."""
            // self.filtered('address_id').event_url = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_exhibitor_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.exhibitor_menu = event.event_type_id.exhibitor_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.exhibitor_menu):
            //         event.exhibitor_menu = True
            //     elif not event.website_menu:
            //         event.exhibitor_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_field_is_one_day(self):
            // for event in self:
            //     # Need to localize because it could begin late and finish early in
            //     # another timezone
            //     event = event._set_tz_context()
            //     begin_tz = fields.Datetime.context_timestamp(event, event.date_begin)
            //     end_tz = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_one_day = (begin_tz.date() == end_tz.date())
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_finished(self):
            // for event in self:
            //     if not event.date_end:
            //         event.is_finished = False
            //         continue
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     datetime_end = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_finished = datetime_end <= current_datetime
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_ongoing(self):
            // now = fields.Datetime.now()
            // for event in self:
            //     event.is_ongoing = event.date_begin <= now < event.date_end
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_participating(self):
            // participating_events = self._fetch_is_participating_events()
            // participating_events.is_participating = True
            // (self - participating_events).is_participating = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_visible_on_website(self):
            // if all(event.website_visibility == 'public' for event in self):
            //     self.is_visible_on_website = True
            //     return
            // for event in self:
            //     if event.website_visibility == 'public' or event.is_participating:
            //         event.is_visible_on_website = True
            //     elif not self.env.user._is_public() and event.website_visibility == 'logged_users':
            //         event.is_visible_on_website = True
            //     else:
            //         event.is_visible_on_website = False
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_kanban_state(self):
            // for task in self:
            //     if task.kanban_state != 'cancel':
            //         task.kanban_state = 'normal'
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_lead_count(self):
            // lead_data = self.env['crm.lead']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_data}
            // for event in self:
            //     event.lead_count = mapped_data.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_note(self):
            // for event in self:
            //     if event.event_type_id and not is_html_empty(event.event_type_id.note):
            //         event.note = event.event_type_id.note
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_post_date(self):
            // for blog_post in self:
            //     if blog_post.published_date:
            //         blog_post.post_date = blog_post.published_date
            //     else:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_question_ids(self):
            // """ Update event questions from its event type. Depends are set only on
            // event_type_id itself to emulate an onchange. Changing event type content
            // itself should not trigger this method.
            // 
            // When synchronizing questions:
            // 
            //   * lines with no registered answers for the event are removed;
            //   * type lines are added;
            // """
            // for event in self:
            //     questions_tokeep_ids = []
            //     if self._origin.question_ids:
            //         # Keep questions with attendee answers for the event.
            //         questions_tokeep_ids.extend(
            //             (event.registration_ids.registration_answer_ids.question_id & self._origin.question_ids).ids
            //         )
            // 
            //     if not event.event_type_id and not questions_tokeep_ids:
            //         event.question_ids = self._default_question_ids()
            //         continue
            // 
            //     if questions_tokeep_ids:
            //         questions_toremove = event._origin.question_ids.filtered(
            //             lambda question: question.id not in questions_tokeep_ids)
            //         command = [(3, question.id) for question in questions_toremove]
            //     else:
            //         command = [(5, 0)]
            //     event.question_ids = command
            //     event.question_ids = [Command.link(question_id.id) for question_id in event.event_type_id.question_ids]
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def _compute_sale_price_total(self):
            // """ Takes only confirmed the sale.order.lines related to this event and converts amounts
            // from the currency of the sale order to the currency of the event company.
            // 
            // To avoid extra overhead, we use conversion rates as of 'today'.
            // Meaning we have a number that can change over time, but using the conversion rates
            // at the time of the related sale.order would mean thousands of extra requests as we would
            // have to do one conversion per sale.order (and a sale.order is created every time
            // we sell a single event ticket). """
            // date_now = fields.Datetime.now()
            // event_subtotals = self.env['sale.order.line']._read_group(
            //     [('event_id', 'in', self.ids), ('price_total', '!=', 0), ('state', '=', 'sale')],
            //     ['event_id', 'currency_id'],
            //     ['price_total:sum'],
            // )
            // event_subtotals_mapping = dict.fromkeys(self._origin, 0)
            // for event, currency, sum_price_total in event_subtotals:
            //     event_subtotals_mapping[event] += event.currency_id._convert(
            //         sum_price_total,
            //         currency,
            //         event.company_id or self.env.company,
            //         date_now,
            //     )
            // 
            // for event in self:
            //     event.sale_price_total = event_subtotals_mapping.get(event._origin, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats(self):
            // """ Determine available, reserved, used and taken seats. """
            // # initialize fields to 0
            // for event in self:
            //     event.seats_reserved = event.seats_used = event.seats_available = 0
            // # aggregate registrations by event and by state
            // state_field = {
            //     'open': 'seats_reserved',
            //     'done': 'seats_used',
            // }
            // base_vals = dict((fname, 0) for fname in state_field.values())
            // results = dict((event_id, dict(base_vals)) for event_id in self.ids)
            // if self.ids:
            //     query = """ SELECT event_id, state, count(event_id)
            //                 FROM event_registration
            //                 WHERE event_id IN %s AND state IN ('open', 'done') AND active = true
            //                 GROUP BY event_id, state
            //             """
            //     self.env['event.registration'].flush_model(['event_id', 'state', 'active'])
            //     self.env.cr.execute(query, (tuple(self.ids),))
            //     res = self.env.cr.fetchall()
            //     for event_id, state, num in res:
            //         results[event_id][state_field[state]] = num
            // 
            // # compute seats_available and expected
            // for event in self:
            //     event.update(results.get(event._origin.id or event.id, base_vals))
            //     seats_max = event.seats_max * event.event_slot_count if event.is_multi_slots else event.seats_max
            //     if seats_max > 0:
            //         event.seats_available = seats_max - (event.seats_reserved + event.seats_used)
            // 
            //     event.seats_taken = event.seats_reserved + event.seats_used
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_limited(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if event.event_type_id.has_seats_limitation != event.seats_limited:
            //         event.seats_limited = event.event_type_id.has_seats_limitation
            //     if not event.seats_limited:
            //         event.seats_limited = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_max(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.event_type_id:
            //         event.seats_max = event.seats_max or 0
            //     else:
            //         event.seats_max = event.event_type_id.seats_max or 0
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_sponsor_count(self):
            // data = self.env['event.sponsor']._read_group([('event_id', 'in', self.ids)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.sponsor_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_start_sale_date(self):
            // """ Compute the start sale date of an event. Currently lowest starting sale
            // date of tickets if they are used, of False. """
            // for event in self:
            //     start_dates = [ticket.start_sale_datetime for ticket in event.event_ticket_ids if not ticket.is_expired]
            //     event.start_sale_datetime = min(start_dates) if start_dates and all(start_dates) else False
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_tag_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.tag_ids and event.event_type_id.tag_ids:
            //         event.tag_ids = event.event_type_id.tag_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_teaser(self):
            // for blog_post in self:
            //     if blog_post.teaser_manual:
            //         blog_post.teaser = blog_post.teaser_manual
            //     else:
            //         content = text_from_html(blog_post.content, True)
            //         blog_post.teaser = content[:200] + '...'
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_ticket_instructions(self):
            // for event in self:
            //     if is_html_empty(event.ticket_instructions) and not \
            //        is_html_empty(event.event_type_id.ticket_instructions):
            //         event.ticket_instructions = event.event_type_id.ticket_instructions
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_time_data(self):
            // """ Compute start and remaining time. Do everything in UTC as we compute only
            // time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for event in self:
            //     date_begin_utc = utc.localize(event.date_begin, is_dst=False)
            //     date_end_utc = utc.localize(event.date_end, is_dst=False)
            //     event.is_ongoing = date_begin_utc <= now_utc <= date_end_utc
            //     event.is_done = now_utc > date_end_utc
            //     event.start_today = date_begin_utc.date() == now_utc.date()
            //     if date_begin_utc >= now_utc:
            //         td = date_begin_utc - now_utc
            //         event.start_remaining = int(td.total_seconds() / 60)
            //     else:
            //         event.start_remaining = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_track_count(self):
            // data = self.env['event.track']._read_group([('stage_id.is_cancel', '!=', True)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.track_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_tracks_tag_ids(self):
            // for event in self:
            //     event.tracks_tag_ids = event.track_ids.mapped('tag_ids').filtered(lambda tag: tag.color != 0).ids
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_use_barcode(self):
            // use_barcode = self.env['ir.config_parameter'].sudo().get_param('event.use_event_barcode') == 'True'
            // for record in self:
            //     record.use_barcode = use_barcode
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu_data(self):
            // """ Synchronize with website_menu at change and let people update them
            // at will afterwards. """
            // for event in self:
            //     event.introduction_menu = event.website_menu
            //     event.register_menu = event.website_menu
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu(self):
            // """ Also ensure a value for website_menu as it is a trigger notably for
            // track related menus. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_menu = event.event_type_id.website_menu
            //     elif not event.website_menu:
            //         event.website_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_menu updated value. Also force True is track_proposal changes. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track = event.event_type_id.website_track
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.website_track):
            //         event.website_track = True
            //     elif not event.website_menu:
            //         event.website_track = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track_proposal(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_track updated value (both together True or False at update). """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track_proposal = event.event_type_id.website_track_proposal
            //     elif event.website_track != event._origin.website_track or not event.website_track or not event.website_track_proposal:
            //         event.website_track_proposal = event.website_track
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_website_url(self):
            // super(BlogPost, self)._compute_website_url()
            // for blog_post in self:
            //     if blog_post.id:
            //         blog_post.website_url = "/blog/%s/%s" % (self.env['ir.http']._slug(blog_post.blog_id), self.env['ir.http']._slug(blog_post))
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for event in self:
            //     if event.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         event.website_url = '/event/%s' % self.env['ir.http']._slug(event)
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def copy(self, default=None):
            // res = super().copy(default=default)
            // res.copy_event_menus(self)
            // return res
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", blog.name)) for blog, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def copy_event_menus(self, old_events):
            // for new_event, old_event in zip(self, old_events):
            //     default_menu_values = {'event_id': new_event.id}
            //     new_event.menu_id = old_event.menu_id.copy({'name': new_event.name, 'website_id': new_event.website_id.id})
            //     new_event.introduction_menu_ids = old_event.introduction_menu_ids.copy(default_menu_values)
            //     new_event.other_menu_ids = old_event.other_menu_ids.copy(default_menu_values)
            //     (new_event.introduction_menu_ids + new_event.other_menu_ids + new_event.community_menu_ids + new_event.register_menu_ids).menu_id.parent_id = new_event.menu_id
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def create(self, vals_list):
            // posts = super(BlogPost, self.with_context(mail_create_nolog=True)).create(vals_list)
            // for post, vals in zip(posts, vals_list):
            //     post._check_for_publication(vals)
            // return posts
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def create(self, vals_list):
            // events = super().create(vals_list)
            // events._update_website_menus()
            // return events
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _create_menu(self, sequence, name, url, xml_id, menu_type, parent_menu_type=False):
            // """ Create a new menu for the current event.
            // 
            // If url: create a website menu. Menu leads directly to the URL that
            // should be a valid route.
            // 
            // If xml_id: create a new page using the qweb template given by its
            // xml_id. Take its url back thanks to new_page of website, then link
            // it to a menu. Template is duplicated and linked to a new url, meaning
            // each menu will have its own copy of the template. This is currently
            // limited to one menu: introduction(Home).
            // 
            // :param menu_type: type of menu. Mainly used for inheritance purpose
            //   allowing more fine-grain tuning of menus.
            // :param parent_menu_type: The type of the parent menu. If specified, the
            //   menu will be created as a child of the parent menu with the given type.
            // """
            // self.browse().check_access('write')
            // view_id = False
            // if not url:
            //     # add_menu=False, ispage=False -> simply create a new ir.ui.view with name
            //     # and template
            //     page_result = self.env['website'].sudo().new_page(
            //         name=f'{name} {self.name}', template=xml_id,
            //         add_menu=False, ispage=False)
            //     view_id = page_result['view_id']
            //     view = self.env["ir.ui.view"].browse(view_id)
            //     url = f"/event/{self.env['ir.http']._slug(self)}/page/{view.key.split('.')[-1]}"  # url contains starting "/"
            // 
            // parent_id = self.menu_id.id
            // if parent_menu_type:
            //     parent_menu = self.env['website.event.menu'].search([
            //         ('event_id', '=', self.id),
            //         ('menu_type', '=', parent_menu_type)
            //     ], limit=1)
            //     if parent_menu:
            //         parent_id = parent_menu.menu_id.id
            // website_menu = self.env['website.menu'].sudo().create({
            //     'name': name,
            //     'url': url,
            //     'parent_id': parent_id,
            //     'sequence': sequence,
            //     'website_id': self.website_id.id,
            // })
            // self.env['website.event.menu'].create({
            //     'menu_id': website_menu.id,
            //     'event_id': self.id,
            //     'menu_type': menu_type,
            //     'view_id': view_id,
            // })
            // return website_menu
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_content(self):
            // text = html_escape(_("Start writing here..."))
            // return """
            //     <p>%(text)s</p>
            // """ % {"text": text}
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_cover_properties(self):
            // res = super()._default_cover_properties()
            // res.update({
            //     'background-image': "url('/website_event/static/src/img/event_cover_4.jpg')",
            //     'opacity': '0.4',
            //     'resize_class': 'cover_auto'
            // })
            // return res
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_description(self):
            // # avoid template branding with rendering_bundle=True
            // return self.env['ir.ui.view'].with_context(rendering_bundle=True) \
            //     ._render_template('event.event_default_descripton')
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_event_mail_ids(self):
            // return self.env['event.type']._default_event_mail_type_ids()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def default_get(self, fields):
            // result = super().default_get(fields)
            // if 'date_begin' in fields and 'date_begin' not in result:
            //     now = Datetime.now()
            //     # Round the datetime to the nearest half hour (e.g. 08:17 => 08:30 and 08:37 => 09:00)
            //     result['date_begin'] = now.replace(second=0, microsecond=0) + timedelta(minutes=-now.minute % 30)
            // if 'date_end' in fields and 'date_end' not in result and result.get('date_begin'):
            //     result['date_end'] = result['date_begin'] + timedelta(days=1)
            // return result
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_question_ids(self):
            // return self.env['event.type']._default_question_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_website_meta(self):
            // res = super(BlogPost, self)._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_opengraph']['og:type'] = 'article'
            // res['default_opengraph']['article:published_time'] = self.post_date
            // res['default_opengraph']['article:modified_time'] = self.write_date
            // res['default_opengraph']['article:tag'] = self.tag_ids.mapped('name')
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = json_scriptsafe.loads(self.cover_properties).get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_meta_description'] = self.subtitle
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_website_meta(self):
            // res = super()._default_website_meta()
            // event_cover_properties = json.loads(self.cover_properties)
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = event_cover_properties.get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_twitter']['twitter:card'] = 'summary'
            // res['default_meta_description'] = self.subtitle
            // return res
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _fetch_is_participating_events(self):
            // """Heuristic
            // 
            //   * public, no visitor: not participating as we have no information;
            //   * check only confirmed and attended registrations, a draft registration
            //     does not make the attendee participating;
            //   * public and visitor: check visitor is linked to a registration. As
            //     visitors are merged on the top parent, current visitor check is
            //     sufficient even for successive visits;
            //   * logged, no visitor: check partner is linked to a registration. Do
            //     not check the email as it is not really secure;
            //   * logged as visitor: check partner or visitor are linked to a
            //     registration;
            // """
            // current_visitor = self.env['website.visitor']._get_visitor_from_request()
            // if self.env.user._is_public() and not current_visitor:
            //     return self.env['event.event']
            // 
            // base_domain = Domain('state', 'in', ['open', 'done'])
            // if self:
            //     base_domain = Domain('event_id', 'in', self.ids) & base_domain
            // 
            // visitor_domain = Domain.TRUE
            // partner_id = self.env.user.partner_id
            // if current_visitor:
            //     visitor_domain = Domain('visitor_id', '=', current_visitor.id)
            //     partner_id = current_visitor.partner_id
            // if partner_id:
            //     visitor_domain |= Domain('partner_id', '=', partner_id.id)
            // 
            // registrations_events = self.env['event.registration'].sudo()._read_group(
            //     visitor_domain & base_domain,
            //     ['event_id'], ['__count'])
            // return self.env['event.event'].browse([event.id for event, _reg_count in registrations_events])
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _gc_mark_events_done(self):
            // """ move every ended events in the next 'ended stage' """
            // ended_events = self.env['event.event'].search([
            //     ('date_end', '<', fields.Datetime.now()),
            //     ('stage_id.pipe_end', '=', False),
            // ])
            // if ended_events:
            //     ended_events.action_set_done()
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the post on website
            // directly if user is an employee or if the post is published. """
            // self.ensure_one()
            // user = self.env['res.users'].sudo().browse(access_uid) if access_uid else self.env.user
            // if not force_website and user.share and not self.sudo().website_published:
            //     return super(BlogPost, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.website_url,
            //     'target': 'self',
            //     'target_type': 'public',
            //     'res_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _get_booth_stat_count(self):
            // elements = self.env['event.booth'].sudo()._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id', 'state'], ['__count']
            // )
            // elements_total_count = defaultdict(int)
            // elements_available_count = dict()
            // for event, state, count in elements:
            //     if state == 'available':
            //         elements_available_count[event.id] = count
            //     elements_total_count[event.id] += count
            // return elements_available_count, elements_total_count
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_date_range_str(self, start_datetime=False, lang_code=False):
            // self.ensure_one()
            // datetime = start_datetime or self.date_begin
            // today_tz = pytz.utc.localize(fields.Datetime.now()).astimezone(pytz.timezone(self.date_tz))
            // event_date_tz = pytz.utc.localize(datetime).astimezone(pytz.timezone(self.date_tz))
            // diff = (event_date_tz.date() - today_tz.date())
            // if diff.days <= 0:
            //     return _('today')
            // if diff.days == 1:
            //     return _('tomorrow')
            // if (diff.days < 7):
            //     return _('in %d days', diff.days)
            // if (diff.days < 14):
            //     return _('next week')
            // if event_date_tz.month == (today_tz + relativedelta(months=+1)).month:
            //     return _('next month')
            // return _('on %(date)s', date=format_date(self.env, datetime, lang_code=lang_code, date_format='medium'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_event_resource_urls(self, slot=False):
            // """ Prepare the Google and iCal urls for the event.
            // :param slot: If a slot is given, prepare the urls for the given slot.
            // Returns:
            //     The google and iCal url in a dictionnary
            // """
            // start = slot.start_datetime if slot else self.date_begin
            // end = slot.end_datetime if slot else self.date_end
            // url_date_start = start.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // url_date_stop = end.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // params = {
            //     'action': 'TEMPLATE',
            //     'text': self.name,
            //     'dates': f'{url_date_start}/{url_date_stop}',
            //     'ctz': self.date_tz,
            //     'details': self._get_external_description(),
            // }
            // if self.address_id:
            //     params.update(location=self.address_inline)
            // encoded_params = werkzeug.urls.url_encode(params)
            // google_url = GOOGLE_CALENDAR_URL + encoded_params
            // iCal_url = f'/event/{self.id:d}/ics'
            // if slot:
            //     iCal_url += '?' + werkzeug.urls.url_encode({'slot_id': slot.id})
            // return {'google_url': google_url, 'iCal_url': iCal_url}
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_external_description(self):
            // """
            // Description of the event shortened to maximum 1900 characters to
            // leave some space for addition by sub-modules.
            // Meant to be used for external content (ics/icalc/Gcal).
            // 
            // Reference Docs for URL limit -: https://stackoverflow.com/questions/417142/what-is-the-maximum-length-of-a-url-in-different-browsers
            // """
            // self.ensure_one()
            // description = ''
            // if self.event_share_url:
            //     description = f'<a href="{escape(self.event_share_url)}">{escape(self.name)}</a>\n'
            // description += textwrap.shorten(html_to_inner_content(self.description), 1900)
            // return description
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_external_description_url_encoded(self):
            // """Get a url-encoded version of the description for mail templates."""
            // return urllib.parse.quote_plus(self._get_external_description())
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_ics_file(self, slot=False):
            // """ Returns iCalendar file for the event invitation.
            //     :param slot: If a slot is given, schedule with the given slot datetimes
            //     :returns a dict of .ics file content for each event
            // """
            // result = {}
            // if not vobject:
            //     return result
            // 
            // for event in self:
            //     cal = vobject.iCalendar()
            //     cal_event = cal.add('vevent')
            //     start = slot.start_datetime or event.date_begin
            //     end = slot.end_datetime or event.date_end
            // 
            //     cal_event.add('created').value = fields.Datetime.now().replace(tzinfo=pytz.timezone('UTC'))
            //     cal_event.add('dtstart').value = start.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('dtend').value = end.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('summary').value = event.name
            //     cal_event.add('description').value = event._get_external_description()
            //     if event.address_id:
            //         cal_event.add('location').value = event.address_inline
            // 
            //     result[event.id] = cal.serialize().encode('utf-8')
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/odoo/registration-desk"
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // return {
            //     'community': 'community_menu',
            //     'introduction': 'introduction_menu',
            //     'register': 'register_menu',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // """" Return a list of fields triggering a split of menu to activate /
            // menu to de-activate. Due to saas-13.3 improvement of menu management
            // this is done using side-methods to ease inheritance.
            // 
            // :returns: list of fields, each of which triggering a menu update
            //   like website_menu, website_track, ...
            // :rtype: list"""
            // return ['community_menu', 'introduction_menu', 'register_menu']
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menus_update_by_field(self, menus_state_by_field, force_update=None):
            // """ For each field linked to a menu, get the set of events requiring
            // this menu to be activated or de-activated based on previous recorded
            // value.
            // 
            // :param menus_state_by_field: see ``_split_menus_state_by_field``;
            // :param force_update: list of field to which we force update of menus. This
            //   is used notably when a direct write to a stored editable field messes with
            //   its pre-computed value, notably in a transient mode (aka demo for example);
            // 
            // :returns: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu toggled to True
            //   'deactivated': subset of self having its menu toggled to False
            // } """
            // menus_update_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     if fname in force_update:
            //         menus_update_by_field[fname] = self
            //     else:
            //         menus_update_by_field[fname] = self.env['event.event']
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['activated'].filtered(lambda event: not event[fname])
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['deactivated'].filtered(lambda event: event[fname])
            // return menus_update_by_field
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_seats_availability(self, slot_tickets):
            // """ Get availabilities for given combinations of slot / ticket. Returns
            // a list following input order. None denotes no limit. """
            // self.ensure_one()
            // if not (all(len(item) == 2 for item in slot_tickets)):
            //     raise ValueError('Input should be a list of tuples containing slot, ticket')
            // 
            // if any(slot for (slot, _ticket) in slot_tickets):
            //     slot_tickets_nb_registrations = {
            //         (slot.id, ticket.id): count
            //         for (slot, ticket, count) in self.env['event.registration'].sudo()._read_group(
            //             domain=[('event_slot_id', '!=', False), ('event_id', 'in', self.ids),
            //                     ('state', 'in', ['open', 'done']), ('active', '=', True)],
            //             groupby=['event_slot_id', 'event_ticket_id'],
            //             aggregates=['__count']
            //         )
            //     }
            // 
            // availabilities = []
            // for slot, ticket in slot_tickets:
            //     available = None
            //     # event is constrained: max stands for either each slot, either global (no slots)
            //     if self.seats_limited and self.seats_max:
            //         if slot:
            //             available = slot.seats_available
            //         else:
            //             available = self.seats_available
            //     # ticket is constrained: max standard for either each slot / ticket, either global (no slots)
            //     if available != 0 and ticket and ticket.seats_max:
            //         if slot:
            //             ticket_available = ticket.seats_max - slot_tickets_nb_registrations.get((slot.id, ticket.id), 0)
            //         else:
            //             ticket_available = ticket.seats_available
            //         available = ticket_available if available is None else min(available, ticket_available)
            //     availabilities.append(available)
            // return availabilities
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def get_slot_tickets_availability_pos(self, slot_ticket_ids):
            // self.ensure_one()
            // slot_tickets = [
            //     (
            //         self.event_slot_ids.filtered(lambda slot: slot.id == slot_id) if slot_id else self.env['event.slot'],
            //         self.event_ticket_ids.filtered(lambda ticket: ticket.id == ticket_id) if ticket_id else self.env['event.event.ticket']
            //     )
            //     for slot_id, ticket_id in slot_ticket_ids
            // ]
            // return self._get_seats_availability(slot_tickets)
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_tickets_access_hash(self, registration_ids):
            // """ Returns the ground truth hash for accessing the tickets in route /event/<int:event_id>/my_tickets.
            // The dl links are always made event-dependant, hence the method linked to the record in self.
            // """
            // self.ensure_one()
            // return tools.hmac(self.env(su=True), 'event-registration-ticket-report-access', (self.id, sorted(registration_ids)))
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // """ Method returning menu entries to display on the website view of the
            // event, possibly depending on some options in inheriting modules.
            // 
            // Each menu entry is a tuple containing :
            //   * name: menu item name
            //   * url: if set, url to a route (do not use xml_id in that case);
            //   * xml_id: template linked to the page (do not use url in that case);
            //   * sequence: specific sequence of menu entry to be set on the menu;
            //   * menu_type: type of menu entry (used in inheriting modules to ease
            //     menu management; not used in this module in 13.3 due to technical
            //     limitations);
            //   * parent_menu_type: menu_type of already created menu entry (used for
            //     making submenu of existing menu entry)
            // """
            // self.ensure_one()
            // return [
            //     (_('Home'), False, 'website_event.template_intro', 1, 'introduction', False),
            //     (_('Practical'), '/event/%s/register' % self.env['ir.http']._slug(self), False, 100, 'register', False),
            //     (_('Rooms'), '/event/%s/community' % self.env['ir.http']._slug(self), False, 80, 'community', False),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def google_map_link(self, zoom=8):
            // """ Temporary method for stable """
            // return self._google_map_link(zoom=zoom)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _google_map_link(self, zoom=8):
            // self.ensure_one()
            // if self.address_id:
            //     return self.sudo().address_id.google_map_link(zoom=zoom)
            // return None
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _has_published_track(self):
            // self.ensure_one()
            // return bool(self.track_ids.filtered('is_published'))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('event_ticket_ids', 'in', [ticket['id'] for ticket in data['event.event.ticket']])]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'seats_available', 'event_ticket_ids', 'registration_ids', 'seats_limited', 'write_date',
            //         'question_ids', 'general_question_ids', 'specific_question_ids', 'seats_max',
            //         'is_multi_slots', 'event_slot_ids']
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _mail_get_operation_for_mail_message_operation(self, message_operation):
            // if (message_operation == 'create' and self.env.user.has_group('event.group_event_registration_desk')):
            //     # allow the registration desk users to post messages on Event
            //     # can not be done with "_mail_post_access" otherwise public user will be
            //     # able to post on published Event (see website_event)
            //     return dict.fromkeys(self, 'read')
            // return super()._mail_get_operation_for_mail_message_operation(message_operation)
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.website_published:
            //     for _group_name, _group_method, group_data in groups:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_thread_by_inbox(self, message, recipients_data, msg_vals=False, **kwargs):
            // # Override to avoid keeping all notified recipients of a comment.
            // # We avoid tracking needaction on post comments. Only emails should be
            // # sufficient.
            // msg_vals = msg_vals or {}
            // if msg_vals.get('message_type', message.message_type) == 'comment':
            //     return
            // return super(BlogPost, self)._notify_thread_by_inbox(message, recipients_data, msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _onchange_event_url(self):
            // """Correct the url by adding scheme if it is missing."""
            // for event in self.filtered('event_url'):
            //     parsed_url = urlparse(event.event_url)
            //     if parsed_url.scheme not in ('http', 'https'):
            //         event.event_url = 'https://' + event.event_url
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _onchange_seats_max(self):
            // for event in self:
            //     if event.seats_limited and event.seats_max and event.seats_available <= 0 and \
            //         (event.event_slot_ids if event.is_multi_slots else True):
            //         return {
            //             'warning': {
            //                 'title': _("Update the limit of registrations?"),
            //                 'message': _("There are more registrations than this limit, "
            //                             "the event will be sold out and the extra registrations will remain."),
            //             }
            //         }
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_address_search(self, operator, value):
            // def make_codomain(value):
            //     return Domain.OR(
            //         Domain(field, 'ilike', value)
            //         for field in ('name', 'street', 'street2', 'city', 'zip', 'state_id', 'country_id')
            //     )
            // if isinstance(value, Domain):
            //     domain = value.map_conditions(lambda cond: cond if cond.field_expr != 'display_name' else make_codomain(cond.value))
            //     return Domain('address_id', operator, domain)
            // if operator == 'ilike' and isinstance(value, str):
            //     return Domain('address_id', 'any', make_codomain(value))
            // # for the trivial "empty" case, there is no empty address
            // if operator == 'in' and (not value or not any(value)):
            //     return Domain(False)
            // return NotImplemented
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_build_dates(self):
            // now = fields.Datetime.now()
            // # To fetch the remaining events of the user's current day, the end of the user's day must
            // # be localized and then converted in UTC, as it is the timezone used to record dates and
            // # times in db.
            // tz = timezone(self.env.user.tz or self.env.context.get('tz') or 'UTC')
            // localized_today_begin = tz.localize(fields.Datetime.today())
            // utc_today_end = localized_today_begin.replace(hour=23, minute=59, second=59).astimezone(utc)
            // 
            // def sd(date):
            //     return fields.Datetime.to_string(date)
            // 
            // def get_month_filter_domain(filter_name, months_delta):
            //     localized_month_begin = localized_today_begin.replace(day=1)
            //     utc_months_delta_end = (localized_month_begin + relativedelta(months=months_delta + 1)).astimezone(utc)
            //     filter_string = _('This month') if months_delta == 0 \
            //         else format_date(self.env, value=localized_today_begin + relativedelta(months=months_delta),
            //             date_format='LLLL', lang_code=get_lang(self.env).code).capitalize()
            //     return [filter_name, filter_string, [
            //         ("date_end", ">=", sd(now)),
            //         ("date_begin", "<", sd(utc_months_delta_end))],
            //         0]
            // 
            // return [
            //     ['scheduled', _('Scheduled Events'), [("date_end", ">=", sd(now))], 0],
            //     ['today', _('Today'), [
            //         ("date_end", ">", sd(now)),
            //         ("date_begin", "<", sd(utc_today_end))],
            //         0],
            //     get_month_filter_domain('month', 0),
            //     ['old', _('Past Events'), [
            //         ("date_end", "<", sd(now))],
            //         0],
            //     ['all', _('All Events'), [], 0]
            // ]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // blog = options.get('blog')
            // tags = options.get('tag')
            // date_begin = options.get('date_begin')
            // date_end = options.get('date_end')
            // state = options.get('state')
            // domain = [website.website_domain()]
            // if blog:
            //     domain.append([('blog_id', '=', self.env['ir.http']._unslug(blog)[1])])
            // if tags:
            //     active_tag_ids = [self.env['ir.http']._unslug(tag)[1] for tag in tags.split(',')] or []
            //     if active_tag_ids:
            //         domain.append([('tag_ids', 'in', active_tag_ids)])
            // if date_begin and date_end:
            //     domain.append([("post_date", ">=", date_begin), ("post_date", "<=", date_end)])
            // if self.env.user.has_group('website.group_website_designer'):
            //     if state == "published":
            //         domain.append([("website_published", "=", True), ("post_date", "<=", fields.Datetime.now())])
            //     elif state == "unpublished":
            //         domain.append(['|', ("website_published", "=", False), ("post_date", ">", fields.Datetime.now())])
            // else:
            //     domain.append([("post_date", "<=", fields.Datetime.now())])
            // search_fields = ['name', 'author_name']
            // def search_in_tags(env, search_term):
            //     tags_like_search = env['blog.tag'].search([('name', 'ilike', search_term)])
            //     return [('tag_ids', 'in', tags_like_search.ids)]
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('content')
            //     fetch_fields.append('content')
            //     mapping['description'] = {'name': 'content', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('published_date')
            //     mapping['detail'] = {'name': 'published_date', 'type': 'date'}
            // return {
            //     'model': 'blog.post',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_tags,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-rss',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // date = options.get('date', 'all')
            // country = options.get('country')
            // tags = options.get('tags')
            // event_type = options.get('type', 'all')
            // 
            // domain = [website.website_domain()]
            // domain.append([('is_visible_on_website', '=', True)])
            // 
            // if event_type != 'all':
            //     domain.append([("event_type_id", "=", int(event_type))])
            // search_tags = self.env['event.tag']
            // if tags:
            //     try:
            //         tag_ids = list(filter(None, [self.env['ir.http']._unslug(tag)[1] for tag in tags.split(',')])) or literal_eval(tags)
            //     except SyntaxError:
            //         pass
            //     else:
            //         # perform a search to filter on existing / valid tags implicitely + apply rules on color
            //         search_tags = self.env['event.tag'].search([('id', 'in', tag_ids)])
            // 
            //     # Example: You filter on age: 10-12 and activity: football.
            //     # Doing it this way allows to only get events who are tagged "age: 10-12" AND "activity: football".
            //     # Add another tag "age: 12-15" to the search and it would fetch the ones who are tagged:
            //     # ("age: 10-12" OR "age: 12-15") AND "activity: football
            //     for tags in search_tags.grouped('category_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
            // 
            // no_country_domain = domain.copy()
            // if country:
            //     if country == 'online':
            //         domain.append([("country_id", "=", False)])
            //     elif country != 'all':
            //         domain.append([("country_id", "=", int(country))])
            // 
            // no_date_domain = domain.copy()
            // dates = self._search_build_dates()
            // current_date = None
            // for date_details in dates:
            //     if date == date_details[0]:
            //         domain.append(date_details[2])
            //         no_country_domain.append(date_details[2])
            //         if date_details[0] != 'scheduled':
            //             current_date = date_details[1]
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url', 'address_name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            //     'address_name': {'name': 'address_name', 'type': 'text', 'match': True},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // if with_date:
            //     mapping['detail'] = {'name': 'range', 'type': 'html'}
            // 
            // # Bypassing the access rigths of partner to search the address.
            // def search_in_address(env, search_term):
            //     ret = env['event.event'].sudo()._search([
            //        ('address_search', 'ilike', search_term),
            //     ])
            //     return [('id', 'in', ret)]
            // 
            // return {
            //     'model': 'event.event',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_address,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-ticket',
            //     # for website_event main controller:
            //     'dates': dates,
            //     'current_date': current_date,
            //     'search_tags': search_tags,
            //     'no_date_domain': no_date_domain,
            //     'no_country_domain': no_country_domain,
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_finished(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('date_end', '<=', fields.Datetime.now())]
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_ongoing(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // now = fields.Datetime.now()
            // return [('date_begin', '<=', now), ('date_end', '>', now)]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_participating(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('id', 'in', self._fetch_is_participating_events().ids)]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_visible_on_website(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // user = self.env.user
            // visibility = ['public']
            // if not user._is_public():
            //     visibility.append('logged_users')
            // return ['|', ('is_participating', '=', True), ('website_visibility', 'in', visibility)]
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_date = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // if with_date:
            //     for event, data in zip(self, results_data):
            //         begin = self.env['ir.qweb.field.date'].record_to_html(event, 'date_begin', {})
            //         end = self.env['ir.qweb.field.date'].record_to_html(event, 'date_end', {})
            //         data['range'] = (
            //             Markup('{} <i class="fa fa-long-arrow-right"></i> {}').format(begin, end)
            //             if begin != end else begin
            //         )
            // return results_data
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_post_date(self):
            // for blog_post in self:
            //     blog_post.published_date = blog_post.post_date
            //     if not blog_post.published_date:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_teaser(self):
            // for blog_post in self:
            //     if not blog_post.with_context(lang='en_US').teaser_manual:
            //         # By default, if no teaser is set in english, it will use the
            //         # first 200 characters of the content. We don't want to break
            //         # that when adding a manual teaser in a translation.
            //         # That's how the ORM work: when setting a translation value, if
            //         # there is no source value, the source will also receive the
            //         # translation value
            //         blog_post.update_field_translations('teaser_manual', {'en_US': ''})
            //     blog_post.teaser_manual = blog_post.teaser
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _set_tz_context(self):
            // self.ensure_one()
            // return self.with_context(tz=self.date_tz or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _split_menus_state_by_field(self):
            // """ For each field linked to a menu, get the set of events having this
            // menu activated and de-activated. Purpose is to find those whose value
            // changed and update the underlying menus.
            // 
            // :returns: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu currently set to True
            //   'deactivated': subset of self having its menu currently set to False
            // } """
            // menus_state_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     activated = self.filtered(lambda event: event[fname])
            //     menus_state_by_field[fname] = {
            //         'activated': activated,
            //         'deactivated': self - activated,
            //     }
            // return menus_state_by_field
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def toggle_booth_menu(self, val):
            // self.booth_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def toggle_exhibitor_menu(self, val):
            // self.exhibitor_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def toggle_website_menu(self, val):
            // self.website_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track(self, val):
            // self.website_track = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track_proposal(self, val):
            // self.website_track_proposal = val
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if init_values.keys() & {'is_published', 'website_published'}:
            //     if self.is_published:
            //         return self.env.ref('website_event.mt_event_published', raise_if_not_found=False)
            //     return self.env.ref('website_event.mt_event_unpublished', raise_if_not_found=False)
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menu_entry(self, fname_bool, fname_o2m, fmenu_type):
            // """ Generic method to create menu entries based on a flag on event. This
            // method is a bit obscure, but is due to preparation of adding new menus
            // entries and pages for event in a stable version, leading to some constraints
            // while developing.
            // 
            // :param fname_bool: field name (e.g. website_track)
            // :param fname_o2m: o2m linking towards website.event.menu matching the
            //   boolean fields (normally an entry of website.event.menu with type matching
            //   the boolean field name)
            // :param fmenu_type:
            // """
            // self.ensure_one()
            // new_menu = None
            // 
            // menu_data = [menu_info for menu_info in self._get_website_menu_entries()
            //              if menu_info[4] == fmenu_type]
            // if self[fname_bool] and not self[fname_o2m]:
            //     # menus not found but boolean True: get menus to create
            //     for name, url, xml_id, menu_sequence, menu_type, parent_menu_type in menu_data:
            //         new_menu = self._create_menu(menu_sequence, name, url, xml_id, menu_type, parent_menu_type)
            // elif not self[fname_bool]:
            //     # will cascade delete to the website.event.menu
            //     self[fname_o2m].mapped('menu_id').sudo().unlink()
            // 
            // return new_menu
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // """ Synchronize event configuration and its menu entries for frontend.
            // 
            // :param menus_update_by_field: see ``_get_menus_update_by_field``"""
            // for event in self:
            //     if event.menu_id and not event.website_menu:
            //         # do not rely on cascade, as it is done in SQL -> not calling override and
            //         # letting some ir.ui.views in DB
            //         (event.menu_id + event.menu_id.child_id).sudo().unlink()
            //     elif event.website_menu and not event.menu_id:
            //         root_menu = self.env['website.menu'].sudo().create({'name': event.name, 'website_id': event.website_id.id})
            //         event.menu_id = root_menu
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('community_menu')):
            //         event._update_website_menu_entry('community_menu', 'community_menu_ids', 'community')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('introduction_menu')):
            //         event._update_website_menu_entry('introduction_menu', 'introduction_menu_ids', 'introduction')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('register_menu')):
            //         event._update_website_menu_entry('register_menu', 'register_menu_ids', 'register')
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _verify_seats_availability(self, slot_tickets):
            // """ Check event seats availability, for combinations of slot / ticket.
            // 
            // :param slot_tickets: a list of tuples(slot, ticket, count). Slot and
            //   ticket are optional, depending on event configuration. If count is 0
            //   it is a simple check current values do not overflow limit. If count
            //   is given, it serves as a check there are enough remaining seats.
            // :raises ValidationError: if the event / slot / ticket do not have
            //   enough available seats
            // """
            // self.ensure_one()
            // if not (all(len(item) == 3 for item in slot_tickets)):
            //     raise ValueError('Input should be a list of tuples containing slot, ticket, count')
            // 
            // sold_out = []
            // availabilities = self._get_seats_availability([(item[0], item[1]) for item in slot_tickets])
            // for (slot, ticket, count), available in zip(slot_tickets, availabilities, strict=True):
            //     if available is None:  # unconstrained
            //         continue
            //     if available < count:
            //         if slot and ticket:
            //             name = f'{ticket.name} - {slot.display_name}'
            //         elif slot:
            //             name = slot.display_name
            //         elif ticket:
            //             name = ticket.name
            //         else:
            //             name = self.name
            //         sold_out.append((name, count - available))
            // 
            // if sold_out:
            //     info = []  # note: somehow using list comprehension make translate.py crash in default lang
            //     for item in sold_out:
            //         info.append(_('%(slot_name)s: missing %(count)s seat(s)', slot_name=item[0], count=item[1]))
            //     raise ValidationError(
            //         _('There are not enough seats available for %(event_name)s:\n%(sold_out_info)s',
            //           event_name=self.name,
            //           sold_out_info='\n'.join(info),
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def write(self, vals):
            // result = True
            // # archiving a blog post, unpublished the blog post
            // if 'active' in vals and not vals['active']:
            //     vals['is_published'] = False
            // for post in self:
            //     copy_vals = dict(vals)
            //     published_in_vals = set(vals.keys()) & {'is_published', 'website_published'}
            //     if (published_in_vals and 'published_date' not in vals and
            //             (not post.published_date or post.published_date <= fields.Datetime.now())):
            //         copy_vals['published_date'] = vals[list(published_in_vals)[0]] and fields.Datetime.now() or False
            //     result &= super(BlogPost, post).write(copy_vals)
            // self._check_for_publication(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def write(self, vals):
            // menus_state_by_field = self._split_menus_state_by_field()
            // res = super().write(vals)
            // menus_update_by_field = self._get_menus_update_by_field(menus_state_by_field, force_update=vals.keys())
            // self._update_website_menus(menus_update_by_field=menus_update_by_field)
            // return res
            */
            return default;
        }
    }
}